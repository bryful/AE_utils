(function(me){

    var getMask = function()
    {
        var ret = null;
        var ac = app.project.activeItem;
        if ( (ac instanceof CompItem) == false)return ret;
        var pl = ac.selectedProperties;
        if (pl.length<=0) return ret;
        for (var i=0; i<pl.length; i++)
        {
            //
            if(pl[i].matchName == "ADBE Mask Parade") continue;
            if(pl[i].matchName == "ADBE Mask Atom") continue;
            if (pl[i].matchName == "ADBE Mask Shape");
            {
                ret = pl[i];
                break;
            }
        }
        return ret;
    }
    var exec = function()
    {
        var mask = getMask();
        if(mask!=null) {
            var msk = mask.value;
            var obj = {}; 
            obj.closed = msk.closed;
            obj.vertices = msk.vertices;
            obj.inTangents = msk.inTangents;
            obj.outTangents = msk.outTangents;
            
            var js = obj.toSource();
            DEBUG.clear();
            DEBUG.write(js);
        }
    }
	// ********************************************************************************
	var winObj = ( me instanceof Panel) ? me : new Window("palette", "Test", [ 0,  0, 345,  360]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});
	var btnExec = winObj.add("button", [  5,   5,   5 +  40,   5 + 20 ] , "exec");

	// ********************************************************************************
	btnExec.onClick = exec;
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}
})(this);
