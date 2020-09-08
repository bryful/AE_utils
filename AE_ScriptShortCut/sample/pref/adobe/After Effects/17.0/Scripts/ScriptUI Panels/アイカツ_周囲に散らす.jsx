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
var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [0,0,0+220,0+400]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});

//*************************
//controls
var yp = 10;
var lbCaption = winObj.add("statictext",[10, yp, 10+420, yp+20],"散らします");
yp+=25;
var lbCaption2 = winObj.add("statictext",[10, yp, 10+420, yp+20],"位置マーカーとカレントを選択してください。");
yp+=30;
var btnGetLayer = winObj.add("button",[10, yp, 10+200, yp+25],"位置マーカーを指定");
yp+=30;
var edLayer = winObj.add("edittext",[10, yp, 10+200, yp+20],"未指定",{readonly:true});
yp+=30;
var lbCaption3 = winObj.add("statictext",[10, yp, 10+420, yp+20],"散らす個数を指定してください");
yp+=30;
var edCount = winObj.add("edittext",[10, yp, 10+200, yp+20],"10");
yp+=30;
var lbCaption4 = winObj.add("statictext",[10, yp, 10+420, yp+20],"散らす距離の最小値");
yp+=30;
var edMinLen = winObj.add("edittext",[10, yp, 10+200, yp+20],"290");
yp+=30;
var lbCaption5 = winObj.add("statictext",[10, yp, 10+420, yp+20],"散らす距離の最大値");
yp+=30;
var edMaxLen = winObj.add("edittext",[10, yp, 10+200, yp+20],"300");
yp+=30;
var lbCaption5 = winObj.add("statictext",[10, yp, 10+420, yp+20],"散らばり具合");
yp+=30;
var edRand = winObj.add("edittext",[10, yp, 10+200, yp+20],"20");
yp+=30;
var btnExec = winObj.add("button",[10, yp, 10+200, yp+25],"実行");
yp+=30;
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

    var minLen = 0;
    var maxLen = 0;
    var cnt = 0;
    var rnd = 0;
    try
    {
        minLen = edMinLen.text *1;
        maxLen = edMaxLen.text *1;
        cnt = edCount.text *1;
        rnd = edRand.text *1;
    }catch(e)
    {
		alert("数値がおかしい");
        return;
    }

	app.beginUndoGroup(scriptName);

    //センター位置用のnullを作成
    var newLayer = targetLayer.containingComp.layers.addNull();
	newLayer.name = "roundCenter";
    newLayer.threeDLayer = true;
    newLayer.moveBefore(targetLayer);
    
    //角度を初期化
    newLayer.autoOrient = AutoOrientType.CAMERA_OR_POINT_OF_INTEREST;
    newLayer.transform.orientation.setValue([0,0,0]);
    newLayer.transform.xRotation.setValue(0);
    newLayer.transform.yRotation.setValue(0);
    newLayer.transform.zRotation.setValue(0);
    
    //位置を設定
    var centerPos = targetLayer.transform.position.valueAtTime(targetLayer.time,false);
    newLayer.transform.position.setValue(centerPos);
    newLayer.startTime = newLayer.time;
    newLayer.inPoint = newLayer.time;

    //子レイヤを作成
    var childlayers = [];
    for (var i=0; i<cnt;i++) {
        childlayers.push( newLayer.duplicate() );
        childlayers[i].name = "round_" + i;
    }

    //エクスプレッション用のスライダ作成
    var eg = newLayer.property("ADBE Effect Parade");
	var fx1 = eg.addProperty("ADBE Slider Control");
	fx1.name = "lengthPar";
    fx1.enabled = false;
    fx1(1).setValue(100);
	var fx2 = eg.addProperty("ADBE Slider Control");
	fx2.name = "scale";
    fx2.enabled = false;
    fx2(1).setValue(100);
	var fx3 = eg.addProperty("ADBE Slider Control");
	fx3.name = "opacity";
    fx3.enabled = false;
    fx3(1).setValue(100);

    //子レイヤの処理
    for ( var i=0; i<cnt; i++)
    {
        //初期化
        newLayer.transform.orientation.setValue([0,0,0]);
        newLayer.transform.xRotation.setValue(0);
        newLayer.transform.yRotation.setValue(0);
        newLayer.transform.zRotation.setValue(0);
        var xLen = 0;
        var yLen = -1 * (minLen + (maxLen-minLen) * Math.random());
        var zLen = 0;
        xLen += rnd - 2 * rnd * Math.random(); 
        yLen += rnd - 2 * rnd * Math.random(); 
        zLen += rnd - 2 * rnd * Math.random();

        childlayers[i].parent = newLayer;
        childlayers[i].transform.position.setValue([xLen,yLen,zLen]);
        var r = i*360/cnt;
        newLayer.transform.zRotation.setValue(r);
        childlayers[i].parent = null;
        childlayers[i].transform.orientation.setValue([0,0,0]);
        childlayers[i].transform.xRotation.setValue(0);
        childlayers[i].transform.yRotation.setValue(0);
        childlayers[i].transform.zRotation.setValue(0);
    }
    newLayer.transform.orientation.setValue([0,0,0]);
    newLayer.transform.xRotation.setValue(0);
    newLayer.transform.yRotation.setValue(0);
    newLayer.transform.zRotation.setValue(0);
    var posExp = "try{\r\n"+
    "	parent = thisLayer.parent;\r\n"+
    "	lengthPar = parent.effect(\"lengthPar\")(1)/100;\r\n"+
    "	if(lengthPar<0) lengthPar = 0;\r\n"+
    "	value * lengthPar;\r\n"+
    "}catch(e){\r\n"+
    "	value;\r\n"+
    "}\r\n";
    var opaExp =
    "try{\r\n"+
    "	parent = thisLayer.parent;\r\n"+
    "	parent.effect(\"opacity\")(1);\r\n"+
    "}catch(e){\r\n"+
    "	value;\r\n"+
    "}\r\n";
    var scaleExp = 
    "try{\r\n"+
    "	parent = thisLayer.parent;\r\n"+
    "	s = parent.effect(\"scale\")(1)/100;\r\n"+
    "	if(s<0) s = 0;\r\n"+
    "	value * s;\r\n"+
    "}catch(e){\r\n"+
    "	value;\r\n"+
    "}\r\n";
    for ( var i=0; i<cnt; i++)
    {
        childlayers[i].transform.orientation.setValue([0,0,0]);
        childlayers[i].transform.xRotation.setValue(0);
        childlayers[i].transform.yRotation.setValue(0);
        childlayers[i].transform.zRotation.setValue(0);
        childlayers[i].parent = newLayer;
        childlayers[i].transform.position.expression = posExp;
        childlayers[i].transform.opacity.expression = opaExp;
        childlayers[i].transform.scale.expression = scaleExp;

    }
    app.endUndoGroup();expression
	
}
btnExec.onClick = exec;

//*************************
//window show
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}


})(this);
