(function(me){
	FsJSON = {};
	function toJSON(obj)
	{
		var ret = "";
		if (typeof(obj) === "boolean"){
			ret = obj.toString();
		}else if (typeof(obj)=== "number"){
			ret = obj.toString();
		}else if (typeof(obj)=== "string"){
			ret = "\""+ obj +"\"";
		}else if ( obj instanceof Array){
			var r = "";
			for ( var i=0; i<obj.length;i++){
				if ( r !== "") r +=",";
				r += toJSON(obj[i]);
			}
			ret = "[" + r + "]";
		}else{
			for ( var a in obj)
			{
				if ( ret !=="") ret +=",";
				ret += "\""+a + "\":" + toJSON(obj[a]);
			}
			ret = "{" + ret + "}";
			
		}
		if ( (ret[0] === "(")&&(ret[ret.length-1]===")"))
		{
			ret = ret.substring(1,ret.length-1);
		}
		return ret;
	}
	FsJSON.toJSON = toJSON;
	//------------------------
	function parse(s)
	{
		var ret = null;
		if ( typeof(s) !== "string") return ret;
		//前後の空白を削除
		s = s.replace(/[\r\n]+$|^\s+|\s+$/g, "");
		s = s.split("\r").join("").split("\n").join("");
		if ( s.length<=0) return ret;
		
		var ss = "";
		var idx1 =0;
		var len = s.length;
		while(idx1<len)
		{
			var idx2 = -1;
			if ( s[idx1]==="\""){
				var idx2 = s.indexOf("\"",idx1+1);
				if ((idx2>idx1)&&(idx2<s.length)){
					if ( s[idx2+1] !== ":") idx2 = -1;
				}
			}
			if ( idx2 ==-1) {
				ss += s[idx1];
				idx1++;
			}else{
				ss += s.substring(idx1+1,idx2)+":";
				idx1 = idx2+2;
			}
		}
		if ( ss[0]=="{"){
			ss ="("+ss+")";
		}
		try{
			ret = eval(ss);
		}catch(e){
			ret = null;
		}
		return ret;
	}
	FsJSON.parse = parse;


	
	//----------------------------------
	//prototype登録
	String.prototype.trim = function(){
		if (this=="" ) return ""
		else return this.replace(/[\r\n]+$|^\s+|\s+$/g, "");
	}
	String.prototype.getParent = function(){
		var r=this;var i=this.lastIndexOf("/");if(i>=0) r=this.substring(0,i);
		return r;
	}
	//ファイル名のみ取り出す（拡張子付き）
	String.prototype.getName = function(){
		var r=this;var i=this.lastIndexOf("/");if(i>=0) r=this.substring(i+1);
		return r;
	}
	//拡張子のみを取り出す。
	String.prototype.getExt = function(){
		var r="";var i=this.lastIndexOf(".");if (i>=0) r=this.substring(i);
		return r;
	}
	//指定した書拡張子に変更（dotを必ず入れること）空文字を入れれば拡張子の消去。
	String.prototype.changeExt=function(s){
		var i=this.lastIndexOf(".");
		if(i>=0){return this.substring(0,i)+s;}else{return this; }
	}
	//文字の置換。（全ての一致した部分を置換）
	String.prototype.replaceAll=function(s,d){ return this.split(s).join(d);}

	//----------------------------------
	var scriptName = File.decode($.fileName.getName().changeExt(""));
	//var saveName = File.decode($.fileName.getName().changeExt(".json"));
	

	var saveName =  Folder.myDocuments.fullName +  "/AE_ColorPalette_color.json";
	// ********************************************************************************
	/*
		アクティブなコンポジションを獲得
	*/
	// ********************************************************************************
	var getActiveComp = function()
	{
		var ret = null;
		ret = app.project.activeItem;
		
		if ( (ret instanceof CompItem)===false)
		{
			ret = null;
			alert("コンポをアクティブにしてください！");
		}
		return ret;
	}
	// ********************************************************************************
	/*
		ウィンドウの作成
	*/
	// ********************************************************************************
	var winObj = ( me instanceof Panel) ? me : new Window("palette", "ShapeAssist", [ 0,  0, 345,  100]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});

	var btn_xx = 15;
	var btn_yy = 15;
	
	var btnToJson = winObj.add("button", [ btn_xx, btn_yy, btn_xx + 320, btn_yy + 25], "toJson" );
	btn_yy += 30;

	var YOKO = 6;
	var TATE = 13;
	var MAX_COUNT = YOKO*TATE;;
	// ********************************************************************************
	var layerFromColor = function(lyr,ary)
	{
		var sa = lyr.name.split("_");
		if (sa.length<3) return;
		var idx = -1;
		try{
			idx = sa[1]*1 + sa[2]*YOKO;
		}catch(e){
			alert(lyr.name +"\r\n"+ e.toSource());
			return;
		}

		


		var eg = lyr.property("ADBE Effect Parade");
		var col = null;
		if (eg.numProperties >0)
		{
			for (var i=1; i<=eg.numProperties;i++)
			{
				if (eg.property(i).matchName=="ADBE Color Control")
				{
					col = eg.property(i);
					break;
				}
			}
		}
		if (col==null) return;
		var p = col.property(1).value;
		if (p instanceof Array){
			if (p.length>=4){
				var p2 = [];
				p2.push(p[3]*255);
				p2.push(p[0]*255);
				p2.push(p[1]*255);
				p2.push(p[2]*255);
				ary[idx] = p2;
			}
		}
	}
	// ********************************************************************************
	var exec = function()
	{
		var ac = getActiveComp();
		if (ac==null) return;
		if (ac.numLayers<=0) {
			return;
		}
		var obj = {};
		obj.Rows = TATE;
		obj.Cols = YOKO;
		obj.Colors = [];
		for (var i=1; i<=MAX_COUNT;i++) {
			var a =[255,10,10,10];
			obj.Colors.push(a);
		}
		
		for (var i=1; i<=ac.numLayers;i++)
		{
			layerFromColor(ac.layer(i),obj.Colors);
		}
		var js = toJSON(obj);
		
		var f = new File(saveName);
		if (f.open("w")){
			try{
				f.write(js);
			}catch(e){
			}finally{
				f.close();
			}
		}
		alert(f.fsName);
	}
	btnToJson.onClick = exec;
	// ********************************************************************************
	var resizeWin = function()
	{
		var b = winObj.bounds;
		var w = b[2] - b[0];
		var h = b[3] - b[1];
		
		var bb = btnToJson.bounds;
		bb[2] = bb[0]  + w - 30;
	}
	resizeWin();
	winObj.onResize = resizeWin;
	// ********************************************************************************
	/*
		実行
	*/
	// ********************************************************************************
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}
	//-------------------------------------------------------------------------
})(this);