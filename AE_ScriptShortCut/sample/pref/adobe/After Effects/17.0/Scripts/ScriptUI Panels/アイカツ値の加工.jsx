﻿(function (me){	if ( app.preferences.getPrefAsLong("Main Pref Section", "Pref_SCRIPTING_FILE_NETWORK_SECURITY") != 1){		var s = "すみません。以下の設定がオフになっています。\r\n\r\n";		s +=  "「環境設定：一般設定：スクリプトによるファイルへの書き込みとネットワークへのアクセスを許可」\r\n";		s += "\r\n";		s += "このスクリプトを使う為にはオンにする必要が有ります。\r\n";		alert(s);		return;	}	function getFileNameWithoutExt(s)	{		var ret = s;		var idx = ret.lastIndexOf(".");		if ( idx>=0){			ret = ret.substring(0,idx);		}		return ret;	}	function getScriptName()	{		var ary = $.fileName.split("/");		return File.decode( getFileNameWithoutExt(ary[ary.length-1]));	}	function getScriptPath()	{		var s = $.fileName;		return s.substring(0,s.lastIndexOf("/"));	}	var scriptName = getScriptName();//*************************//MainWindowvar winObj = ( me instanceof Panel) ? me : new Window("palette", scriptName, [0,0,0+220,0+500]  ,{resizeable:true, maximizeButton:true, minimizeButton:true});
//*************************//controlsvar yp = 10;var lbCaption = winObj.add("statictext",[10, yp, 10+420, yp+20],scriptName);yp+=30;var edInfo = winObj.add("edittext",[10, yp, 10+200, yp+160],"");yp+=170;var btnGet = winObj.add("button",[10, yp, 10+200, yp+25],"最大値・平均値を求める");yp+=35;var btnFlatting = winObj.add("button",[10, yp, 10+200, yp+25],"平坦化");yp+=35;var lbCaption2 = winObj.add("statictext",[10, yp, 10+400, yp+20],"最大値");yp+=20;var edMaxValueOne = winObj.add("edittext",[10, yp, 10+200, yp+25],"50");yp+=25;var btnRemapOne = winObj.add("button",[10, yp, 10+200, yp+25],"最大値を1に変換");yp+=40;var lbCaption2 = winObj.add("statictext",[10, yp, 10+400, yp+20],"マッピングの最大値");yp+=20;var edMaxValue = winObj.add("edittext",[10, yp, 10+200, yp+25],"1");yp+=25;var lbCaption2 = winObj.add("statictext",[10, yp, 10+400, yp+20],"マッピングの最小値");yp+=20;var edMinValue = winObj.add("edittext",[10, yp, 10+200, yp+25],"0");yp+=25;var btnMap = winObj.add("button",[10, yp, 10+200, yp+25],"数値をマッピング");//*************************var dispMes = function(str){	edInfo.text += str;}//*************************var clearMes = function(){	edInfo.text = "";}//*************************var selectProp = function(){	var ret = [];		var ac = app.project.activeItem;	if ( (ac instanceof CompItem)==false) {		clearMes();		dispMes("コンポがアクティブになっていません");		return ret;	}	var props = ac.selectedProperties;	if ( (props==null)|| (props.length<=0) ) {		clearMes();		dispMes("プロパティが選択されていません");		return ret;	}else{		ret = props;	}			return ret;}//*************************var getPropAverage = function(prop){	if ( (prop instanceof PropertyGroup)||(prop instanceof PropertyBase)||(prop instanceof MaskPropertyGroup)){		return "";	}	var ret = "// *******************\r\n";	ret += prop.parentProperty.name+"/";	ret += prop.name +"\r\n";	if(prop.propertyValueType != PropertyValueType.OneD)	{		ret += "no PropertyValueType.OneD"		return ret;	}	var nums = prop.numKeys;	if(nums<=0) {		ret += "no keys"		return ;	}		var maxV = 0;	var avrV = 0;	var avrD = 1 / nums;		var values = [];		for (var i=1; i<=nums; i++)	{		var v = prop.keyValue(i);		values.push(v);		if (  maxV < v ) maxV = v;		avrV += v * avrD;	} 	var borderLo = maxV/3; 	var borderMid = maxV*2/3; 	var countLo = 0; 	var countMid = 0; 	var countHi = 0; 	var n = values.length; 	for ( var i=0; i<n; i++) 	{ 		if ( values[i] < borderLo){ 			countLo++; 		} 		else if ( values[i] < borderMid){ 			countMid++; 		} 		else{ 			countHi++; 		} 	}	ret += "MaxValue : " + maxV + "\r\n";	ret += "Average  :  " + avrV + "\r\n";	ret += "Level Lo : " + Math.floor(countLo*100/n) + "%\r\n";	ret += "Level Mid: " + Math.floor(countMid*100/n) + "%\r\n";	ret += "Level Hi : " + Math.floor(countHi*100/n) + "%\r\n"; 	 		return ret;}//*************************var execGet = function(){	clearMes();	var props = selectProp();	if (props.length<=0) return;		for ( var i=0; i<props.length; i++)	{		dispMes(getPropAverage(props[i]));	}}//*************************btnGet.onClick = execGet;// ****************************************var setPropFlatting = function(prop){	if ( (prop instanceof PropertyGroup)||(prop instanceof PropertyBase)||(prop instanceof MaskPropertyGroup)){		return "";	}	var ret = "// *******************\r\n";	ret += prop.parentProperty.name+"/";	ret += prop.name +"\r\n";	if(prop.propertyValueType != PropertyValueType.OneD)	{		ret += "no PropertyValueType.OneD"		return ret;	}	var nums = prop.numKeys;	if(nums<=0) {		ret += "no keys"		return ;	}	var times = [];	var values = [];	var values2 = [];		if (nums<3) {		ret += "keys is none"		return ;	}	for (var i=1; i<=nums; i++)	{		times.push(prop.keyTime(i));		values.push(prop.keyValue(i));	}	values2.push( (values[0] + values[0] + values[1])/3);	var n = times.length;	for ( var i= 1; i<n-1; i++)	{		var vv = ( values[i-1] + values[i] + values[i+1]) /3;		values2.push(vv);	}	values2.push( (values[n-2] + values[n-1] + values[n-1])/3);	prop.setValuesAtTimes(times,values2);		ret = getPropAverage(prop);  	ret += "Flatting Done!\r\n"; 		return ret;}var execFlatting = function(){	clearMes();	var props = selectProp();	if (props.length<=0) return;	app.beginUndoGroup("Flatting");	for ( var i=0; i<props.length; i++)	{		dispMes(setPropFlatting(props[i]));	}	app.endUndoGroup();}btnFlatting.onClick = execFlatting;//*************************var setPropRemapOne = function(prop,maxV){	if ( (prop instanceof PropertyGroup)||(prop instanceof PropertyBase)||(prop instanceof MaskPropertyGroup)){		return "";	}	var ret = "// *******************\r\n";	ret += prop.parentProperty.name+"/";	ret += prop.name +"\r\n";	if(prop.propertyValueType != PropertyValueType.OneD)	{		ret += "no PropertyValueType.OneD"		return ret;	}	var nums = prop.numKeys;	if(nums<=0) {		ret += "no keys";		return ;	}	var times = [];	var values = [];	var values2 = [];		for (var i=1; i<=nums; i++)	{		times.push(prop.keyTime(i));		values.push(prop.keyValue(i));	} 	 	var n = values.length;	for (var i=0; i<n; i++)	{		values2.push(values[i] / maxV );	}	prop.setValuesAtTimes(times,values2); 	 	ret = getPropAverage(prop); 	 	ret += "Remap One Done!\r\n"; 		return ret;}//*************************var execRemapOne = function(){		clearMes();	var props = selectProp();	if (props.length<=0) return;	var s = edMaxValueOne.text;	if ((s =="")||(s == " ")||(s == "  ")||(s == "　"))	{		alert("最大値が入力されていません");		return;	}	var maxV = Number(s);	if (isNaN(maxV)==true)	{		alert("最大値が不正です");		return;	}else{		if (maxV<=0) {			alert("最大値が0以下です");			return;		}	}		app.beginUndoGroup("Remap One");	for ( var i=0; i<props.length; i++)	{		dispMes(setPropRemapOne(props[i],maxV));	}	app.endUndoGroup();}btnRemapOne.onClick = execRemapOne;//*************************var setPropMap = function(prop,maxV,minV){	if ( (prop instanceof PropertyGroup)||(prop instanceof PropertyBase)||(prop instanceof MaskPropertyGroup)){		return "";	}	var ret = "// *******************\r\n";	ret += prop.parentProperty.name+"/";	ret += prop.name +"\r\n";	if(prop.propertyValueType != PropertyValueType.OneD)	{		ret += "no PropertyValueType.OneD"		return ret;	}	var nums = prop.numKeys;	if(nums<=0) {		ret += "no keys"		return ;	}	var times = [];	var values = [];	var values2 = [];		var vb = maxV-minV;		for (var i=1; i<=nums; i++)	{		times.push(prop.keyTime(i));		var v = prop.keyValue(i);		if (v<=minV){			v = 0;		}else{			v = (v - minV)/vb;		}		values.push(v);	}	prop.setValuesAtTimes(times,values);	 	ret = getPropAverage(prop); 	ret += "Remap Value Done!\r\n"; 		return ret;}//*************************var execMap = function(){	clearMes();	var props = selectProp();	if (props.length<=0) return;	var s = edMaxValue.text;	if ((s =="")||(s == " ")||(s == "  ")||(s == "　"))	{		alert("最大値が入力されていません");		return;	}	var maxV = Number(s);	if (isNaN(maxV)==true)	{		alert("最大値が不正です");		return;	}else{		if (maxV<=0) {			alert("最大値が0以下です");			return;		}	}	var s2 = edMinValue.text;	if ((s2 =="")||(s2 == " ")||(s2 == "  ")||(s2 == "　"))	{		alert("最小値が入力されていません");		return;	}	var minV = Number(s2);	if (isNaN(minV)==true)	{		alert("最小値が不正です");		return;	}else{		if (minV<0) {			alert("最小値が0以下です");			return;		}		if ( maxV<=minV) {			alert("最小値の方が大きいです");			return;		}	}	app.beginUndoGroup("値をマッピング");	for ( var i=0; i<props.length; i++)	{		dispMes(setPropMap(props[i],maxV,minV));	}	app.endUndoGroup();}btnMap.onClick = execMap;//*************************//*************************//window show	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}})(this);