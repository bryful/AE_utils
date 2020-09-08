/*

*/

(function(me){

	#includepath "./;../"
	#include "json2.jsxinc"
	#include "bryScriptLib.jsxinc"

	//----------------------------------
	var scriptName = File.decode($.fileName.getName().changeExt(""));
	var aeclipPath = File.decode($.fileName.getParent()+"/aeclip.exe");

	var cntrlTbl = [];
	// ********************************************************************************
	var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [ 0,  0,  490,  150]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});
	// ********************************************************************************
	var ctrl_xx = 10;
	var ctrl_yy = 10;
	var stCaption = winObj.add("statictext",     [ctrl_xx, ctrl_yy, ctrl_xx + 470,   ctrl_yy +  25], "jsonファイルを読み込んでスライダーキーを設定します。");
	ctrl_yy += 30;
	var stCaption2 = winObj.add("statictext",     [ctrl_xx, ctrl_yy, ctrl_xx + 470,   ctrl_yy +  25], "適応させたいレイヤを選んだあと実行してください。かなり時間かかります。");
	ctrl_yy += 30;
	var btnExec = winObj.add("button", [ctrl_xx,ctrl_yy,ctrl_xx+ 470,ctrl_yy+25], "実行" );
	ctrl_yy += 30;
	var stCaption3 = winObj.add("statictext",     [ctrl_xx, ctrl_yy, ctrl_xx + 470,   ctrl_yy +  25], "終了後ダイアログが開きますので、お待ちください");
	ctrl_yy += 30;

	cntrlTbl.push(stCaption);
	cntrlTbl.push(stCaption2);
	cntrlTbl.push(btnExec);

	// ********************************************************************************
	var resizeWin = function()
	{
		var b = winObj.bounds;
		var w = b[2] - b[0];
		var h = b[3] - b[1];
		var cnt = cntrlTbl.length;
		for ( var i=0; i<cnt; i++)
		{
			var c = cntrlTbl[i];
			var bs = c.bounds;
			bs[0] = ctrl_xx;
			bs[2] = bs[0] + w - ctrl_xx*2;
			c.bounds = bs;
		}
	}
	resizeWin();
	winObj.onResize = resizeWin;
	//-------------------------------------------------------------------------
	function zero2(idx)
	{
		var r = "00";
		if (idx==0){
			r = "00";
		}else if (idx<10){
			r = "0"+idx;
		}else{
			r = idx + "";
		}
		return r;
	}
	//-------------------------------------------------------------------------
	var exexNow = false;
	var execSub = function(obj,lyr)
	{
		var ret =false;
		var data = obj.data;
		if(data == null) return ret;
		var cnt = data.length;
		if(cnt <=0) return ret;
		var frames = data[0].length;
		var eg = lyr.property("ADBE Effect Parade");
		for ( var i=0; i<cnt;i++)
		{
			var nm = "snd" + zero2(i);
			if(eg.property(nm)==null){
				var p = eg.addProperty("ADBE Slider Control");
				p.name = nm;
				p.enabled = false;
				p.property(1).setValue(1);
			}
		}
		var fr = lyr.containingComp.frameRate;
		var times = [];
		for(var i=0; i<frames;i++) times.push(i/fr);
		for ( var i=0; i<cnt;i++)
		{
			var nm = "snd" + zero2(i);
			var fx = eg.property(nm);
			if(fx==null)
			{
				fx = eg.addProperty("ADBE Slider Control");
				fx.name = nm;
				fx.enabled = false;
				fx.property(1).setValue(1);
			}
			fx.property(1).setValuesAtTimes(times,data[i]);
		}


	}
	//-------------------------------------------------------------------------
	var exec = function()
	{
		var ret =false;
		var lyr = BRY.getActiveLayer();
		if(lyr==null){
			return ret;
		}
		var fn = File.openDialog("Select","*.json");
		if (fn) {
			var f = new File(fn);
			f.open("r");
			try{
				execNow = true;
				var js  = f.read();
				var obj = JSON.parse(js);
				app.beginUndoGroup(scriptName);
				ret = execSub(obj,lyr);
				execNow = false;
				app.endUndoGroup();
			}catch(e){
				alert("exec\r\n" + e.toString());
			}finally{
				f.close();
			}
		}
		if(ret==false){
			alert("errer");
		}else{
			alert("実行完了");

		}
		return ret;
	}
	btnExec.onClick = function(){
		if(exexNow==true) return;
		exec();
	};
	
	//-------------------------------------------------------------------------
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}
	//-------------------------------------------------------------------------
})(this);