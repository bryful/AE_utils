﻿(function (me){
	var resizeValue = 2;
	//選択されたプロパティグループを獲得
	var vectorKind = function(p) 
	var execResizeRect = function(p,dir,inout)
	var execResizeEllipse = function(p,dir,inout)
	var execResize = function(dir,inout)
	var execMoveSub = function(p, dir)
	var execMove = function(dir)
	
	//*************************
	//MainWindow
	var winObj = ( me instanceof Panel) ? me : new Window("palette", "vectorResize", [0,0,0+290,0+490],{resizeable:true});

	
	var btnM = [];
	//*************************
	//controls
	var gbResize = winObj.add("panel",[10, 30, 10+270, 30+190],"Resize");
	btnR[1] = gbResize.add("button",[157, 44, 157+32, 44+32],"上");
	btnR[2] = gbResize.add("button",[221, 75, 221+32, 75+32],"右");
	btnR[3] = gbResize.add("button",[189, 75, 189+32, 75+32],"右");
	btnR[4] = gbResize.add("button",[157, 140, 157+32, 140+32],"下");
	btnR[5] = gbResize.add("button",[157, 106, 157+32, 106+32],"下");
	btnR[6] = gbResize.add("button",[93, 75, 93+32, 75+32],"左");
	btnR[7] = gbResize.add("button",[125, 75, 125+32, 75+32],"左");

	btnR[1].onClick = function() {execResize(0,-1);}
	btnR[2].onClick = function() {execResize(1,1);}
	btnR[3].onClick = function() {execResize(1,-1);}
	btnR[4].onClick = function() {execResize(2,1);}
	btnR[5].onClick = function() {execResize(2,-1);}
	btnR[6].onClick = function() {execResize(3,1);}
	btnR[7].onClick = function() {execResize(3,-1);}

	
	btnM[1] = gbMove.add("button",[189, 73, 189+48, 73+32],"右");
	btnM[2] = gbMove.add("button",[141, 119, 141+48, 119+32],"下");
	btnM[3] = gbMove.add("button",[93, 73, 93+48, 73+32],"左");
	
	var btnSwapSize = gbUtils.add("button",[10, 10, 10+250, 10+24],"横縦サイズ入れ替え");
	
	//*************************
	btnSwapSize.onClick = function(){
		alert("横縦サイズ入れ替え");
	}
	//*************************
	//window show
	if ( ( me instanceof Panel) == false){
		winObj.center();
		winObj.show();
	}
})(this);