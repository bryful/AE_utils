//アイカツ編集ムービー書き出しコンポの作成CC2020
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
var winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [0,0,0+200,0+200]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});

//*************************
//controls
var yp = 10;
var lbCaption = winObj.add("statictext",[20, yp, 10+160, yp+20],"選択したフッテージをIKP編集用へ");
yp+=25;
var btnExecHi = winObj.add("button",[20, yp, 10+160, yp+25],"本番高画質-実行");
yp+=40;
var btnExecLo = winObj.add("button",[20, yp, 10+160, yp+25],"ダミー素材-実行");
yp+=40;
var cbToRQ = winObj.add("checkbox",[20, yp, 10+160, yp+25],"同時にレンダーキューへ登録");
cbToRQ.value = true;

var ctrlTbl = [];
ctrlTbl.push(lbCaption);
ctrlTbl.push(btnExecHi);
ctrlTbl.push(btnExecLo);
ctrlTbl.push(cbToRQ);

//*************************
var getFootage = function()
{
    var ret = [];

    var sel = app.project.selection;
    if(sel.length<=0) return ret;

    for (var i=0; i<sel.length;i++)
    {
        if (sel[i] instanceof FootageItem)
        {
            ret.push(sel[i]);
        }
    }
    return ret;

}
var createComp = function(ftg,mode,isRQ)
{
    var ret = false;
    if ((ftg instanceof FootageItem)==false) return ret;

    var nm = getFileNameWithoutExt(ftg.name);
    var cmp = ftg.parentFolder.items.addComp(nm, 1920, 1080, ftg.pixelAspect, ftg.duration, ftg.frameRate);
    cmp.duration = ftg.duration;

    var lyr = cmp.layers.add(ftg);
	var scaleV = 1920*100/ftg.width;

	if(mode == 0){
		//upscale
		var eg = lyr.property("ADBE Effect Parade");
		var ups = null; 
		var upsName = "ADBE Upscale";
		if (eg.canAddProperty(upsName))
		{
			ups = eg.addProperty(upsName);
			if (ups!=null)
			{
				ups.property(3).setValue(scaleV);
				if(isRQ) {
					var rq = app.project.renderQueue.items.add(cmp);
					rq.outputModules[1].applyTemplate("prores 444");
				}
				ret = true;
			}
		}
	}else{
		var sp = lyr.transform.scale;
		sp.setValue([scaleV,scaleV]);
		if(isRQ) {
			var rq = app.project.renderQueue.items.add(cmp);
			rq.outputModules[1].applyTemplate("prores 422");
		}
	}
    return ret; 
}


//*************************
var execHi = function()
{
    var sel = getFootage();
    if(sel.length<=0){
        alert("なんか選んで");
        return;
    }
	app.beginUndoGroup(scriptName+"_Hi");
	var isRQ = cbToRQ.value;
	for ( var i=0; i<sel.length;i++)
	{
		createComp(sel[i],0,isRQ);
	}
	app.endUndoGroup();
}
btnExecHi.onClick = execHi;
//*************************
var execLo = function()
{
    var sel = getFootage();
    if(sel.length<=0){
        alert("なんか選んで");
        return;
    }
	var isRQ = cbToRQ.value;
	app.beginUndoGroup(scriptName+"_Lo");
	for ( var i=0; i<sel.length;i++)
	{
		createComp(sel[i],1,isRQ);
	}
	app.endUndoGroup();
}
btnExecLo.onClick = execLo;

//*************************
//*************************
var resize = function()
{
	var b = winObj.bounds;
	var w = b[2] - b[0] - 40; 

	for ( var i=0; ctrlTbl.length;i++)
	{
		var bb = ctrlTbl[i].bounds;
		bb[2] = bb[0] + w;
		ctrlTbl[i].bounds = bb;
	}
}
winObj.onResize = resize;
//window show
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}


})(this);
