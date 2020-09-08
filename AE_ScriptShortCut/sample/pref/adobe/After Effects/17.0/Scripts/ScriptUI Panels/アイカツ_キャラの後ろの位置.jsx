(function (me){
	if ( app.preferences.getPrefAsLong("Main Pref Section", "Pref_SCRIPTING_FILE_NETWORK_SECURITY") != 1){
		var s = "すみません。以下の設定がオフになっています。\r\n\r\n";
		s +=  "「環境設定：一般設定：スクリプトによるファイルへの書き込みとネットワークへのアクセスを許可」\r\n";
		s += "\r\n";
		s += "このスクリプトを使う為にはオンにする必要が有ります。\r\n";
		alert(s);
		return;
	}
	function getFileNameWithoutExt(s)
	{
		var ret = s;
		var idx = ret.lastIndexOf(".");
		if ( idx>=0){
			ret = ret.substring(0,idx);
		}
		return ret;
	}
	function getScriptName()
	{
		var ary = $.fileName.split("/");
		return File.decode( getFileNameWithoutExt(ary[ary.length-1]));
	}
	function getScriptPath()
	{
		var s = $.fileName;
		return s.substring(0,s.lastIndexOf("/"));
	}


	var scriptName = getScriptName();

	var targetComp = null;
	var targetLayer = null;
//*************************
//MainWindow
var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [0,0,0+220,0+260]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});

//*************************
//controls
var yp = 10;
var lbCaption = winObj.add("statictext",[10, yp, 10+420, yp+20],"キャラクタの後ろの位置を求めます");
yp+=25;
var lbCaption2 = winObj.add("statictext",[10, yp, 10+420, yp+20],"位置マーカーを選択してください。");
yp+=30;
var btnGetLayer = winObj.add("button",[10, yp, 10+200, yp+25],"位置マーカーを指定");
yp+=30;
var edLayer = winObj.add("edittext",[10, yp, 10+200, yp+20],"未指定",{readonly:true});
yp+=30;
var btnExec = winObj.add("button",[10, yp, 10+200, yp+25],"実行");
//*************************
var getLayer = function()
{
	targetLayer = null;
	edLayer.text = "未指定";
	var ac = app.project.activeItem;
	if ( (ac instanceof CompItem)===false) 
	{
		alert("コンポがアクティブになっていません");
		return;
	}
	var sel = ac.selectedLayers;
	if (sel.length !=1)
	{
		alert("レイヤは１個だけ選んでください");
		return;
	}
	if ( sel[0].threeDLayer === false)
	{
		alert("3Dレイヤじゃない");
		return;
	}
	targetLayer = sel[0];
	edLayer.text = targetLayer.name;
}
btnGetLayer.onClick = getLayer;

//*************************
var exec = function()
{
	if (targetLayer === null) 
	{
		alert("レイヤを選んでください");
		return;
	}
	if (targetLayer.threeDLayer == false){
		alert("3Dレイヤを選んでください");
		return;
		
	}

	app.beginUndoGroup(scriptName);


    var newLayer = targetLayer.containingComp.layers.addNull();
	newLayer.name = targetLayer.name +"_back";
    newLayer.threeDLayer = true;
	newLayer.moveBefore(targetLayer);
    newLayer.autoOrient = AutoOrientType.CAMERA_OR_POINT_OF_INTEREST;
    var times = [];
    var values = [];
    var pos = targetLayer.transform.position;
    if(pos.numKeys>0)
    {
        for(var i=1; i<=pos.numKeys;i++){
            times.push(pos.keyTime(i));
            values.push(pos.keyValue(i));
        }
        newLayer.transform.position.setValuesAtTimes(times,values);
    }else{
        newLayer.transform.position.setValue(pos.value);
    }

	var eg = newLayer.property("ADBE Effect Parade");
	var fx1 = eg.addProperty("ADBE Slider Control");
	fx1.name = "yPos";
    fx1.enabled = false;
    fx1(1).setValue(-90);
	var fx2 = eg.addProperty("ADBE Slider Control");
	fx2.name = "zOffset";
    fx2.enabled = false;
    fx2(1).setValue(100);

    var expStr = "try{\r\n"
    +"cameraPos = thisComp.activeCamera.transform.position.value;\r\n"
    +"rootPos = transform.position.value;\r\n"
    +"rootPos[1] = effect(\"yPos\")(1);\r\n"
    +"len = effect(\"zOffset\")(1);\r\n"
    +"ePos = cameraPos - rootPos;\r\n"
    +"ePos[0] = len*ePos[0]/ePos[2];\r\n"
    +"ePos[1] = len*ePos[1]/ePos[2];\r\n"
    +"ePos[2] = len;\r\n"
    +"rootPos + ePos;\r\n"
    +"}catch(e){\r\n"
    +"value;\r\n"
    +"}\r\n"

    newLayer.transform.position.expression = expStr;
	npos.expressionEnabled = true;
	app.endUndoGroup();
	
}
btnExec.onClick = exec;

//*************************
//window show
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}


})(this);
