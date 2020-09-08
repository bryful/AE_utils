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
var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [0,0,0+220,0+360]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});

//*************************
//controls
var yp = 10;
var lbCaption = winObj.add("statictext",[10, yp, 10+420, yp+20],"選択したレイヤをランダムに配置します");
yp+=25;
var lb1 = winObj.add("statictext",[10, yp, 10+420, yp+20],"X最小値/最大値");
yp+=25;
var edMinX = winObj.add("edittext",[10, yp, 10+200, yp+20],"-50");
yp+=30;
var edMaxX = winObj.add("edittext",[10, yp, 10+200, yp+20],"50");
yp+=30;
var lb2 = winObj.add("statictext",[10, yp, 10+420, yp+20],"y最小値/最大値");
yp+=25;
var edMinY = winObj.add("edittext",[10, yp, 10+200, yp+20],"-50");
yp+=30;
var edMaxY = winObj.add("edittext",[10, yp, 10+200, yp+20],"50");
yp+=30;
var lb3 = winObj.add("statictext",[10, yp, 10+420, yp+20],"Z最小値/最大値");
yp+=25;
var edMinZ = winObj.add("edittext",[10, yp, 10+200, yp+20],"-50");
yp+=30;
var edMaxZ = winObj.add("edittext",[10, yp, 10+200, yp+20],"50");
yp+=30;
var btnExec = winObj.add("button",[10, yp, 10+200, yp+25],"実行");
//*************************
var getLayers = function()
{
    var ret = [];
    var ac = app.project.activeItem;
    if((ac instanceof CompItem)==false){
        alert("コンポを選択してください");
        return ret;
    }
    var sel = ac.selectedLayers;
    if (sel.length>0)
    {
        for (var i=0;i<sel.length;i++)
        {
            if (sel[i].threeDLayer==true)
            {
                ret.push(sel[i]);
            }
        }
    }
    if(ret.length<=0)
    {
        alert("レイヤを選択してください");
    }
    return ret;
}
//*************************
var toFloat = function(s)
{
    var ret = 0;
    if (s=="") return ret;
    try{
        ret = parseFloat(s);
    }catch(e){
        ret = 0;
    }
    return ret;

}
//*************************
var exec = function()
{
    var lyrs = getLayers();
    if(lyrs.length>0)
    {
        var xMin = toFloat(edMinX.text);
        var yMin = toFloat(edMinY.text);
        var zMin = toFloat(edMinZ.text);
        var xMax = toFloat(edMaxX.text);
        var yMax = toFloat(edMaxY.text);
        var zMax = toFloat(edMaxZ.text);
        
        app.beginUndoGroup(scriptName);
        for ( var i=0; i<lyrs.length; i++)
        {
            var lyr = lyrs[i];
            try{
                var p = lyr.property("ADBE Transform Group").property("ADBE Position");
                if ( p.numKeys<=0)
                {
                    var x =  xMin  + (xMax - xMin)*Math.random();
                    var y =  yMin  + (yMax - yMin)*Math.random();
                    var z =  zMin  + (zMax - zMin)*Math.random();
                    p.setValue([x,y,x]);
                }
            }catch(e){
                alert(e.toString());
            }
        }
        app.endUndoGroup();

    }

	
}
btnExec.onClick = exec;

//*************************
//window show
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}


})(this);
