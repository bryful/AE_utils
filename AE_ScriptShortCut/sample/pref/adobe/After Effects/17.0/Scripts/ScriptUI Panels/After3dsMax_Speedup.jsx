(function(me){

	//----------------------------------
	String.prototype.trim = function(){
		if (this=="" ) return ""
		else return this.replace(/[\r\n]+$|^\s+|\s+$/g, "");
	}
	Array.prototype.indexIn = function(i){
		return ((typeof(i)=="number")&&(i>=0)&&(i<this.length));
	}
	Array.prototype.removeAt = function(i) {
		if(this.indexIn(i)==true) return this.splice(i,1);else return null;
	}
	//ファイル名のみ取り出す（拡張子付き）
	String.prototype.getName = function(){
		var r=this;var i=this.lastIndexOf("/");if(i>=0) r=this.substring(i+1);
		return r;
	}
	String.prototype.changeExt=function(s){
		var i=this.lastIndexOf(".");
		if(i>=0){return this.substring(0,i)+s;}else{return this + s; }
	}
	Application.prototype.getScriptName = function(){
		return File.decode($.fileName.getName());
	}
	
	//----------------------------------
	var scriptName = File.decode($.fileName.getName().changeExt(""));
	//--------------------------------------------------------------------------------
	var optObj1 = function(ary)
	{
		var ret = [];
		try{
			var last = ary.length -1;
			if (last<2) return ary;
			
			ret.push(ary[0]);
			for ( var i=1; i<last; i++)
			{
				if ( (ary[i-1].v0 != ary[i].v0)||(ary[i+1].v0 != ary[i].v0) ) 
				{
					ret.push(ary[i]);
				}
			}
			if (ret.length==1)
			{
				if (ret[0].v0 != ary[last].v0) 
				{
					ret.push(ary[last]);
				}
			}
		}catch(e){
			alert("optObj1 eror");
			return ret;
		}
		return ret;
	}
	//--------------------------------------------------------------------------------
	var optObj3 = function(ary)
	{
		var ret = [];
		try{
			var last = ary.length -1;
			if (last<2) return ary;
			
			ret.push(ary[0]);
			for ( var i=1; i<last; i++)
			{
				if ( (ary[i-1].v0 != ary[i].v0)||(ary[i+1].v0 != ary[i].v0)||
				     (ary[i-1].v1 != ary[i].v1)||(ary[i+1].v1 != ary[i].v1)||
				     (ary[i-1].v2 != ary[i].v2)||(ary[i+1].v2 != ary[i].v2)
				 ) 
				{
					ret.push(ary[i]);
				}
			}
			if (ret.length==1)
			{
				if ( (ret[0].v0 != ary[last].v0) || (ret[0].v1 != ary[last].v1) || (ret[0].v2 != ary[last].v2) )
				{
					ret.push(ary[last]);
				}
			}
		}catch(e){
			alert("optObj3 eror");
			return ret;
		}
		return ret;
	}
	//--------------------------------------------------------------------------------
	var decode3ds = function(str)
	{
		var ret = {};
		ret.enabled = false;

		if (str=="") {
			alert("Read Error!");
			return ret;
		}
		
		
		ret.comp = {};
		ret.comp.name ="";
		ret.comp.width = 100;
		ret.comp.height = 100;
		ret.comp.aspect = 1;
		ret.comp.duration = 1;
		ret.comp.frameRate = 24;
		ret.comp.frame = 24;
		ret.comp.echelle = 10;
		
		ret.camera = {};
		ret.camera.pos = [];
		ret.camera.posTimes = [];
		ret.camera.anc = [];
		ret.camera.zoomDef = 0;
		ret.camera.zoom = [];
		ret.camera.zoomTimes = [];

		ret.camera.rotTimes = [];
		ret.camera.rot = [];

		ret.plane = [];
		ret.obj = [];
		ret.lumiere = [];
		ret.autotrack = [];


		try{
			//各要素に分ける
			var ensemble = str.split("|");
			
			if (ensemble==""){
				alert("ensemble none eror!");
				return ret;
			}
			if (ensemble.length<4) {
				alert("ensemble format error!");
				return ret;
			}
			try{
				var cmpStr = ensemble[0];
				var camStr = ensemble[1];
				var plnAry = [];
				if ((ensemble[2]!=null)&&(ensemble[2]!="")) plnAry = ensemble[2].split("$");
				
				var objAry = [];
				if ((ensemble[3]!=null)&&(ensemble[3]!="")) objAry = ensemble[3].split("$");
				//var lumiereAry =  ensemble[4].split("$");
				//var autotrackAry = ensemble[5].split("$");

			}catch(e){
				alert("ensemble split error!");
				return ret;
			}

			//コンポの情報
			var scene_base = cmpStr.split(",");
			if ((scene_base=="")||(scene_base.length<8))
			{
				alert("scene_base none!");
				return ret;
			}
			try{
				ret.comp.name = scene_base[0];
				ret.comp.width = parseFloat(scene_base[1]);
				ret.comp.height = parseFloat(scene_base[2]);
				ret.comp.aspect = parseFloat(scene_base[3]);
				ret.comp.duration = parseFloat(scene_base[4]);
				ret.comp.frameRate = parseFloat(scene_base[5]);
				ret.comp.frame = parseFloat(scene_base[6]);
				ret.comp.echelle = parseFloat(scene_base[7]);
				if (ret.comp.frame<=0) {
					return ret;
				}
			}catch(e){
				alert("scene_base error: " + e.toString());
				return ret;
			}

			//cameraの情報			var camera_prop = camStr.split("*");
			if ((camera_prop=="")||(camera_prop.length<2)){
				alert("camera_prop none erorr!");
				return ret;
			}
			try{
			var camInfo = camera_prop[0].split(",");
				ret.camera.name = camInfo[0];
				ret.camera.zoomDef = parseFloat(camInfo[1]);
			}catch(e){
				alert("camInfo error!");
				return ret;
			}
			
			//カメラ情報を読み取り
			var camPos = [];
			var camRot = [];
			var camZoom = [];
			for ( var i=0; i<ret.comp.frame; i++)
			{
				var tm = i / ret.comp.frameRate;
				var v = camera_prop[i+1].split(",");
				var pObj = {};
				pObj.time = tm;
				pObj.v0 =parseFloat(v[0]);
				pObj.v1 =parseFloat(v[1]);
				pObj.v2 =parseFloat(v[2]);
				camPos.push(pObj);
				var rObj = {};
				rObj.time = tm;
				rObj.v0 =parseFloat(v[3]);
				rObj.v1 =parseFloat(v[4]);
				rObj.v2 =parseFloat(v[5]);
				camRot.push(rObj);
				var zObj = {};
				zObj.time = tm;
				zObj.v0 = parseFloat(v[6]);
				camZoom.push(zObj);

			}
			ret.camera.posTimes = [];
			ret.camera.pos = [];
			ret.camera.anc = [];
			camPos = optObj3(camPos);
			if (camPos.length>0){
				for ( var i=0; i<camPos.length;i++)
				{
					ret.camera.posTimes.push(camPos[i].time);
					var p = [];
					var p2 = [];
					p.push(camPos[i].v0);
					p.push(camPos[i].v1);
					p.push(camPos[i].v2);
					ret.camera.pos.push(p);
					p2.push(camPos[i].v0);
					p2.push(camPos[i].v1+1);
					p2.push(camPos[i].v2);
					ret.camera.anc.push(p2);
				}
			}
			ret.camera.rotTimes = [];
			ret.camera.xrot = [];
			ret.camera.yrot = [];
			ret.camera.zrot = [];
			camRot = optObj3(camRot);
			if (camRot.length>0){
				for ( var i=0; i<camRot.length;i++)
				{
					ret.camera.rotTimes.push(camRot[i].time);
					ret.camera.xrot.push(camRot[i].v0);
					ret.camera.yrot.push(camRot[i].v1);
					ret.camera.zrot.push(camRot[i].v2);
				}
			}

			ret.camera.zoomTimes = [];
			ret.camera.zoom = [];
			camZoom = optObj1(camZoom);
			if (camZoom.length>0){
				for ( var i=0; i<camZoom.length;i++)
				{
					ret.camera.zoomTimes.push(camZoom[i].time);
					ret.camera.zoom.push(camZoom[i].v0);
				}
			}


			
			//平面の処理
			if (plnAry.length>0){
				for (var i=0; i<plnAry.length; i++)
				{
					var obj = {};
					obj.posTimes = [];
					obj.pos = [];
					obj.rotTimes = [];
					obj.xrot = [];
					obj.yrot = [];
					obj.zrot = [];
					var plane = plnAry[i].split("*");
					var p = plane[0].split(",");
					obj.name = p[0];
					obj.width = parseFloat(p[1]);
					obj.height = parseFloat(p[2]);
					var plnPos = [];
					var plnRot = [];
					for ( var k=0; k<ret.comp.frame;k++)
					{
						var pp = plane[k+1].split(",");
						var tm = k/ret.comp.frameRate;
						var pObj = {};
						pObj.time = tm;
						pObj.v0 = parseFloat(pp[0]);
						pObj.v1 = parseFloat(pp[1]);
						pObj.v2 = parseFloat(pp[2]);
						plnPos.push(pObj);
						var rObj = {};
						rObj.time = tm;
						rObj.v0 = parseFloat(pp[3]);
						rObj.v1 = parseFloat(pp[4]);
						rObj.v2 = parseFloat(pp[5]);
						plnRot.push(rObj);
						
					}
					obj.posTimes = [];
					obj.pos = [];
					obj.xrot = [];
					obj.yrot = [];
					obj.zrot = [];
					plnPos = optObj3(plnPos);
					if (plnPos.length>0){
					
						for ( var k=0; k<plnPos.length;k++)
						{
							obj.posTimes.push(plnPos[k].time);
							var p = [];
							p.push(plnPos[k].v0);
							p.push(plnPos[k].v1);
							p.push(plnPos[k].v2);
							obj.pos.push(p);
						}
					}
					plnRot = optObj3(plnRot);
					if (plnRot.length>0){
					
						for ( var k=0; k<plnRot.length;k++)
						{
							obj.rotTimes.push(plnRot[k].time);
							var p = [];
							obj.xrot.push(plnRot[k].v0);
							obj.yrot.push(plnRot[k].v1);
							obj.zrot.push(plnRot[k].v2);
						}
					}
					ret.plane.push(obj);
				}
			}
		
			//null			if (objAry.length>0){
				for (var i=0; i<objAry.length; i++)
				{
					var obj = {};
					obj.posTimes = [];
					obj.pos = [];
					obj.rotTimes = [];
					obj.xrot = [];
					obj.yrot = [];
					obj.zrot = [];
					var object = objAry[i].split("*");
					obj.name = object[0];
					
					var objPos = [];
					var objRot = [];
					for ( var k=0; k<ret.comp.frame;k++)
					{
						var pp = object[k+1].split(",");
						var tm = k/ret.comp.frameRate;
						var pObj ={};
						pObj.time = tm;
						pObj.v0 = parseFloat(pp[0]);
						pObj.v1 = parseFloat(pp[1]);
						pObj.v2 = parseFloat(pp[2]);
						objPos.push(pObj);
						var rObj ={};
						rObj.time = tm;
						rObj.v0 = parseFloat(pp[3]);
						rObj.v1 = parseFloat(pp[4]);
						rObj.v2 = parseFloat(pp[5]);
						objRot.push(rObj);
					}
					obj.posTimes = [];
					obj.pos = [];
					obj.xrot = [];
					obj.yrot = [];
					obj.zrot = [];
					objPos = optObj3(objPos);
					if (objPos.length>0){
					
						for ( var k=0; k<objPos.length;k++)
						{
							obj.posTimes.push(objPos[k].time);
							var p = [];
							p.push(objPos[k].v0);
							p.push(objPos[k].v1);
							p.push(objPos[k].v2);
							obj.pos.push(p);
						}
					}
					objRot = optObj3(objRot);
					if (objRot.length>0){
					
						for ( var k=0; k<objRot.length;k++)
						{
							obj.rotTimes.push(objRot[k].time);
							var p = [];
							obj.xrot.push(objRot[k].v0);
							obj.yrot.push(objRot[k].v1);
							obj.zrot.push(objRot[k].v2);
						}
					}
					ret.obj.push(obj);
				}
			}
		}catch(e){
			alert(e.toString());
		}
		ret.enabled=true;
		
		return ret;	
	}
	//--------------------------------------------------------------------------------
	var loadA3ds = function(p)
	{
		var ret = "";
		var fl = new File(p);
		if (fl.exists==false) return ret;
		if (fl.open("r")){
			try{
				ret = fl.read();
			}catch(e){
				alert("load Error :"+e.toString()) ;
				ret = "";
			}finally{
				fl.close();
			}
		}
		
		return ret;
	}

	//-------------------------------------------------------------------------
	var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [ 0,  0,  220,  400]  ,{resizeable:true});
	//-------------------------------------------------------------------------
	var yPos = 10;
	var lbSelect = winObj.add("statictext", [ 10, yPos ,10 +  800, yPos +  23], "select a3ds file" );
	yPos += 28;
	var btnSelect = winObj.add("button", [   10, yPos,    10 +  200, yPos +  23], "Select" );
	yPos += 28;
	var edPath = winObj.add("edittext", [ 10, yPos ,10 +  800, yPos +  23], "" );
	yPos += 28;
	var btnExec = winObj.add("button", [   10, yPos,    10 +  200, yPos+  23], "Exec" );
	yPos += 28;
	var lbInfo = winObj.add("statictext", [ 10, yPos ,10 +  800, yPos +  23], "Light and Autotrack  no supported" );
	
	
	//--------------------------------------------------------------------------------
	var selectFile = function()
	{
		edPath.text = "";
		var ret =  File.openDialog("Select a *a3ds file", "");
		if (ret) {
			edPath.text = ret;
		}
	}
	btnSelect.onClick = selectFile;
	//--------------------------------------------------------------------------------
	var exec = function()
	{
		var st = ( new Date()).getTime();
		var p = edPath.text;		var str = loadA3ds(p);
		if ( str == "" ) return;
		
		var r = decode3ds(str);		
		/*		var js = r.toSource();
		var sv = new File(p+".json");
		try{
			if (sv.open("w")){
				sv.write(js);
				sv.close();
			}
		}catch(e){
			alert(e.toString());
		}
		*/
		
		app.beginUndoGroup("Piyo 100% - After3dsMax")
		//コンポの作成
		try{
		var myComp = app.project.items.addComp(
			r.comp.name,
			r.comp.width,
			r.comp.height,
			r.comp.aspect,
			r.comp.duration,
			r.comp.frameRate);
		}catch(e){
			alert(e.toString());
		}
		myComp.duration = r.comp.duration;
		//カメラの作成
		var myCamera = myComp.layers.addCamera(r.camera.name,[0,0]);
		
		var myAnc = myCamera.property("ADBE Transform Group").property("ADBE Anchor Point");
		var myPos = myCamera.property("ADBE Transform Group").property("ADBE Position");
		var camOrientation = myCamera.property("ADBE Transform Group").property("ADBE Orientation");
		var zoom = myCamera.property("ADBE Camera Options Group").property("ADBE Camera Zoom");

		//zoomの初期値
		zoom.setValue(r.camera.zoomDef);

		//一時名称
		var nom_hasard = Math.ceil(Math.random()*1549753);

		try{
			var plane_ref = myComp.layers.addSolid([0,0,0],nom_hasard,20,20,1,r.comp.duration);
			plane_ref.threeDLayer = true;
			var solid = plane_ref.source;
			var x_rot = myComp.layers.add(solid,r.comp.duration);
			var y_rot = myComp.layers.add(solid,r.comp.duration);
			var z_rot = myComp.layers.add(solid,r.comp.duration);
			x_rot.threeDLayer = true;
			x_rot.name = "X";
			y_rot.threeDLayer = true;
			y_rot.name = "Y";
			z_rot.threeDLayer = true;
			z_rot.name = "Z";
			
		}catch(e){
			alert("plane_ref error: " + e.toString());
		}
		//orientationを求める
		var ancTbl = [];
		try{
			for ( var i=0; i<r.camera.rotTimes.length;i++) {
				plane_ref.orientation.setValue([0,0,0]);
				x_rot.orientation.setValue([270,0,0]);
				y_rot.orientation.setValue([270,0,0]);
				z_rot.orientation.setValue([270,0,0]);
				x_rot.xRotation.setValue(0);
				y_rot.zRotation.setValue(0);
				z_rot.yRotation.setValue(0);
				plane_ref.parent = x_rot;
				x_rot.parent = y_rot;
				y_rot.parent = z_rot;
				x_rot.xRotation.setValue(r.camera.xrot[i]);
				y_rot.zRotation.setValue(r.camera.yrot[i]);
				z_rot.yRotation.setValue(r.camera.zrot[i]);
				plane_ref.parent = null;
				x_rot.parent = null;
				y_rot.parent = null;
				ancTbl.push(plane_ref.orientation.value);
			}
		}catch(e){
			alert("camera rot " + e.toString());
		}
		
		try{
			zoom.setValuesAtTimes( r.camera.zoomTimes,r.camera.zoom);
			myPos.setValuesAtTimes(r.camera.posTimes,r.camera.pos);
			myAnc.setValuesAtTimes(r.camera.posTimes,r.camera.anc);
			camOrientation.setValuesAtTimes(r.camera.rotTimes,ancTbl);		}catch(e){			alert("cam:" + e.toString());		}
		//平面の処理
		if(r.plane.length>0)
		{
			for ( var i=0; i<r.plane.length; i++)
			{
				var w = r.plane[i].width;
				if (w>8000) w = 8000;
				var h = r.plane[i].height;
				if (h>8000) h = 8000;
				
				var plane_solide = myComp.layers.addSolid(
					[(Math.random()*(255))/255,(Math.random()*(255))/255,(Math.random()*(255))/255],
					r.plane[i].name,
					w,
					h,
					1,
					r.comp.duration);
				plane_solide.threeDLayer = true;

				var ancTbl = [];
				for ( var k=0; k<r.plane[i].rotTimes.length;k++) {
					plane_ref.orientation.setValue([270,0,0]);
					x_rot.orientation.setValue([270,0,0]);
					y_rot.orientation.setValue([270,0,0]);
					z_rot.orientation.setValue([270,0,0]);
					x_rot.xRotation.setValue(0);
					y_rot.zRotation.setValue(0);
					z_rot.yRotation.setValue(0);
					plane_ref.parent = x_rot;
					x_rot.parent = y_rot;
					y_rot.parent = z_rot;
					x_rot.xRotation.setValue(r.plane[i].xrot[k]);
					y_rot.zRotation.setValue(r.plane[i].yrot[k]);
					z_rot.yRotation.setValue(r.plane[i].zrot[k]);
					plane_ref.parent = null;
					x_rot.parent = null;
					y_rot.parent = null;
					ancTbl.push(plane_ref.orientation.value);
				}				try{
					plane_solide.position.setValuesAtTimes(r.plane[i].posTimes,r.plane[i].pos);
					plane_solide.orientation.setValuesAtTimes(r.plane[i].rotTimes,ancTbl);
				}catch(e){					alert("plane:"+i+ "/ " +e.toString());								}

			}
		}
		//null		if(r.obj.length>0)
		{
			for ( var i=0; i<r.obj.length; i++)
			{
				plane_solide = myComp.layers.addNull();
				plane_solide.name = r.obj[i].name;
				plane_solide.source.name = r.obj[i].name;
				plane_solide.threeDLayer = true;

				var ancTbl = [];
				for ( var k=0; k<r.obj[i].rotTimes.length;k++) {
					plane_ref.orientation.setValue([270,0,0]);
					x_rot.orientation.setValue([270,0,0]);
					y_rot.orientation.setValue([270,0,0]);
					z_rot.orientation.setValue([270,0,0]);
					x_rot.xRotation.setValue(0);
					y_rot.zRotation.setValue(0);
					z_rot.yRotation.setValue(0);
					plane_ref.parent = x_rot;
					x_rot.parent = y_rot;
					y_rot.parent = z_rot;
					x_rot.xRotation.setValue(r.obj[i].xrot[k]);
					y_rot.zRotation.setValue(r.obj[i].yrot[k]);
					z_rot.yRotation.setValue(r.obj[i].zrot[k]);
					plane_ref.parent = null;
					x_rot.parent = null;
					y_rot.parent = null;
					ancTbl.push(plane_ref.orientation.value);
				}				try{
					plane_solide.position.setValuesAtTimes(r.obj[i].posTimes,r.obj[i].pos);
					plane_solide.orientation.setValuesAtTimes(r.obj[i].rotTimes,ancTbl);
				}catch(e){					alert("obj:"+i+ "/ " +e.toString());				}			}
		}




		plane_ref.remove();
		x_rot.remove();
		y_rot.remove();
		z_rot.remove();
		solid.remove();
				//sv.remove();		
		var lt = ( new Date()).getTime();

		var sec = (lt -st)/1000;

		app.endUndoGroup();
		alert("Finished : "+sec+"seconds");
	}
	btnExec.onClick = exec;
	//-------------------------------------------------------------------------
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}
	//-------------------------------------------------------------------------
})(this);
