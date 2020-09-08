(function(me){
#includepath  "./(アイカツ作業)"
#include "アイカツ作業.jsxinc"
#include "cameraScale.jsxinc"
#include "faceMask.jsxinc"
#include "floor.jsxinc"
#include "parMask.jsxinc"
#include "addMovedValue.jsxinc"
#include "floorInsert.jsxinc"
#include "addFootPar.jsxinc"
#include "layoutRing.jsxinc"

    //グローバルな変数
	var scriptName = File.decode($.fileName.getName().changeExt(""));
    // ********************************************************************************
	var winObj = ( me instanceof Panel) ? me : new Window("palette", 
        scriptName, 
        [ 0,  0,  600,  600]  ,
        {resizeable:true, maximizeButton:true, minimizeButton:true});
        winObj.orientaion ="row";
    // ********************************************************************************
    //コントロール配列用
    var cntrols = [];
    // ********************************************************************************
    var tabPanel = winObj.add("tabbedpanel",[5,5,590,590]);
    
    tabPanel.orientaion ="row";
    tabPanel.onChange = function()
    {
        //writeLn(tabPanel.selection.index);
    }
    var tabIdx = 0;
    var tabs = [];
    var addTab = function(str)
    {
        var ret = tabPanel.add("tab");
        ret.text = str;
        ret.index = tabIdx;
        tabs.push(ret);
        tabIdx++;
        return ret;
    }

    // ********************************************************************************
    //カメラスケール調整
    // ********************************************************************************
 //#region CameraScale
    var tabScale = addTab("スケール調整");
    var xx = 5;
    var yy = 5;
    var stInfo = tabScale.add("staticText",[xx,yy,xx + 180,yy+25],"選択したコンポを複製してカメラスケールを変更します");
    cntrols.push(stInfo);
    yy += 30;
    var btnScaleTargetComp = tabScale.add("button",[xx,yy,xx+180,yy+25],"選択");
    cntrols.push(btnScaleTargetComp);
    yy += 25;
    var edScaleTargetComp = tabScale.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edScaleTargetComp.targetComp = null;
    cntrols.push(edScaleTargetComp);
    yy += 35;
    var stInfo = tabScale.add("staticText",[xx,yy,xx + 180,yy+25],"スケール。1で100%");
    cntrols.push(stInfo);
    yy += 25;
    var edScaleSale = tabScale.add("edittext",[xx,yy,xx+180,yy+25],"0.1");
    cntrols.push(edScaleSale);
    yy += 35;
    var stInfo = tabScale.add("staticText",[xx,yy,xx + 180,yy+25],"実行後レイヤコンポにつける文字");
    cntrols.push(stInfo);
    yy += 25;
    var edScaleAfter = tabScale.add("edittext",[xx,yy,xx+180,yy+25],"_x0.1_");
    cntrols.push(edScaleAfter);
    yy += 35;
    var btnScaleExec = tabScale.add("button",[xx,yy,xx+180,yy+35],"実行");
    cntrols.push(btnScaleExec);

    btnScaleTargetComp.onClick = function()
    {
        edScaleTargetComp.text = "";
        edScaleTargetComp.targetComp = null;
        var cmp = getComp();
        if (cmp==null) return;
        edScaleTargetComp.text = cmp.name;
        edScaleTargetComp.targetComp = cmp;
    }
 
    btnScaleExec.onClick =scaleExec;

// #endregion
    // ********************************************************************************
    // 顔マスク作成
    // ********************************************************************************
// #region FaceMask
    var tabFaceMask = addTab("顔マスク");
    xx = 5;
    yy = 5;
    var stInfo = tabFaceMask.add("staticText",[xx,yy,xx + 180,yy+25],"選択したマーカーを元に顔マスク作成");
    cntrols.push(stInfo);
    yy += 30;
    var btnFaceMaskExec = tabFaceMask.add("button",[xx,yy,xx+180,yy+25],"レイヤーを選択して実行");
    cntrols.push(btnFaceMaskExec);
    yy += 25;
   btnFaceMaskExec.onClick = function()
    {
        var lyr = get3DLayer();
        if (lyr == null) return;
     	app.beginUndoGroup("顔マスク");
        faceMaskExec(lyr);
	    app.endUndoGroup();
    }
// #endregion
    // ********************************************************************************
    // 床マーカー
    // ********************************************************************************
 //#region Floor
     
    
    var tabFloor = addTab("床の高さへ");
    xx = 5;
    yy = 5;
    var stInfo = tabFloor.add("staticText",[xx,yy,xx + 180,yy+25],"選択したレイヤを複製して床の高さ(y=0)に固定します");
    cntrols.push(stInfo);
    yy += 30;
    var btnFloorExec = tabFloor.add("button",[xx,yy,xx+180,yy+25],"レイヤ選択して実行");
    cntrols.push(btnFloorExec);
    yy += 25;
    btnFloorExec.onClick = function()
    {
        var lyr = get3DLayer();
        if (lyr == null) return;
     	app.beginUndoGroup("床へ");
        floorExec(lyr);
	    app.endUndoGroup();
    }
// #endregion
    // ********************************************************************************
    // パーティキュラー用マスク
    // ********************************************************************************
 //#region ParMask
    var tabParticularMask = addTab("Particularマスク");
    xx = 5;
    yy = 5;
    var stInfo = tabParticularMask.add("staticText",[xx,yy,xx + 180,yy+25],"パーティキュラー用のマスク作成");
    cntrols.push(stInfo);
    yy += 30;
    var btnPCamera = tabParticularMask.add("button",[xx,yy,xx+180,yy+25],"カメラレイヤ選択");
    cntrols.push(btnPCamera);
    yy += 25;
    var edPCamera = tabParticularMask.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edPCamera.camera = null;
    cntrols.push(edPCamera);
    yy += 35;
    var btnPPos = tabParticularMask.add("button",[xx,yy,xx+180,yy+25],"位置マーカー選択");
    cntrols.push(btnPPos);
    yy += 25;
    var edPPos = tabParticularMask.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edPPos.posLayer = null;
    cntrols.push(edPPos);
    yy += 35;
    var btnPTarget = tabParticularMask.add("button",[xx,yy,xx+180,yy+25],"マスク化するレイヤ");
    cntrols.push(btnPTarget);
    yy += 25;
    var edPTarget = tabParticularMask.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edPTarget.maskLayer = null;
    cntrols.push(edPTarget);
    yy += 35;
    var btnPExec = tabParticularMask.add("button",[xx,yy,xx+180,yy+35],"実行");
    cntrols.push(btnPExec);

    btnPCamera.onClick = function()
    {
        edPCamera.camera = null;
        edPCamera.text = "";
        var cam = getCameraLayer();
        if (cam== null) {
            alert("カメラレイヤを選んでください");
            return;
        }
        edPCamera.camera = cam;
        edPCamera.text = cam.name;
    }
    btnPPos.onClick = function()
    {
        edPPos.posLayer = null;
        edPPos.text = "";
        var lyr = get3DLayer();
        if (lyr== null) {
            alert("位置レイヤを選んでください");
            return;
        }
        if (lyr instanceof CameraLayer) {
            return;
        }
        edPPos.posLayer = lyr;
        edPPos.text = lyr.name;
    }
    btnPTarget.onClick = function()
    {
        edPTarget.maskLayer = null;
        edPTarget.text = "";
        var lyr = getLayer();
        if (lyr== null) {
            alert("位置レイヤを選んでください");
            return;
        }
        if (lyr instanceof CameraLayer) {
            return;
        }
        edPTarget.maskLayer = lyr;
        edPTarget.text = lyr.name;
    }
    btnPExec.onClick = function()
    {
        try{
            var cm = edPCamera.camera;
            var ppos = edPPos.posLayer;
            var mask = edPTarget.maskLayer;
            if ( (cm==undefined)||(ppos==undefined)||(mask==undefined)
            ||(cm==null)||(ppos==null)||(mask==null))
            {
                alert("パラメータを設定してください");
                return ret;
            }
            parMaskExec(cm,ppos,mask);
        }catch(e){
            alert(e.toString());
        }
    }
 // #endregion
    // ********************************************************************************
    // ポジション関係
    // ********************************************************************************
 //#region Position
    var tabPosition = addTab("ポジション");

    xx = 5;
    yy = 5;
    var stInfo = tabPosition.add("staticText",[xx,yy,xx + 180,yy+25],"ポジション関係");
    cntrols.push(stInfo);
   yy += 30;
    var stInfo = tabPosition.add("staticText",[xx,yy,xx + 180,yy+25],"ポイント制御にtoComp()を入れて追加");
    cntrols.push(stInfo);
   yy += 25;
     var btnPos2D = tabPosition.add("button",[xx,yy,xx+180,yy+25],"2Dポイント制御追加");
    cntrols.push(btnPos2D);
    yy += 40;
    var stInfo = tabPosition.add("staticText",[xx,yy,xx + 180,yy+25],"3Dポイント制御にtoWorld()を入れて追加");
    cntrols.push(stInfo);
   yy += 25;
    var btnPos3D = tabPosition.add("button",[xx,yy,xx+180,yy+25],"3Dポイント制御追加");
    cntrols.push(btnPos3D);
    yy += 40;
    var stInfo = tabPosition.add("staticText",[xx,yy,xx + 180,yy+25],"選択レイヤの中心位置マーカーを作成");
    cntrols.push(stInfo);
   yy += 25;
    var btnPosMix = tabPosition.add("button",[xx,yy,xx+180,yy+25],"選択したレイヤの中心位置を作る");
    cntrols.push(btnPosMix);
    yy += 40;
    var stInfo = tabPosition.add("staticText",[xx,yy,xx + 180,yy+25],"移動距離をスライダー制御に入れて追加");
    cntrols.push(stInfo);
   yy += 25;
    var btnMoveLength = tabPosition.add("button",[xx,yy,xx+180,yy+35],"移動距離を求める");
    cntrols.push(btnMoveLength);
   yy += 40;

    btnPos2D.onClick = addPoint2D;
    btnPos3D.onClick = addPoint3D;
    btnPosMix.onClick = addCenterLayer;
    btnMoveLength.onClick = addMovedValue;
 // #endregion
    // ********************************************************************************
    // 接地タイミング
    // ********************************************************************************
//#region Touch    
    var tabFoot = addTab("接地タイミング");
    xx = 5;
    yy = 5;
    var stInfo = tabFoot.add("staticText",[xx,yy,xx + 180,25],"接地タイミングで指定したフッテージを挿入します。");
    cntrols.push(stInfo);
    yy += 25;
    var btnFootTarget = tabFoot.add("button",[xx,yy,xx+180,yy+25],"対象のマーカー");
    cntrols.push(btnFootTarget);
    yy += 25;
    var edFootTarget = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edFootTarget);
    edFootTarget.lyr = null;
    yy += 35;
    var stInfo = tabFoot.add("staticText",[xx,yy,xx + 180,yy+25],"床の高さ。余裕を持たす事");
    cntrols.push(stInfo);
    yy += 25;
    var edFootFloor = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"-35");
    cntrols.push(edFootFloor);
    yy += 35;
    var cbFootTouch = tabFoot.add("checkbox",[xx,yy,xx+180,yy+25],"着地で挿入");
    cntrols.push(cbFootTouch);
    yy += 25;
    var btnFootInsertTouch = tabFoot.add("button",[xx,yy,xx+180,yy+25],"挿入するコンポ");
    cntrols.push(btnFootInsertTouch);
    yy += 25;
    var edFootInsertTouch = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edFootInsertTouch);
    edFootInsertTouch.ftg = null;
    yy += 35;
    var cbFootLeave = tabFoot.add("checkbox",[xx,yy,xx+180,yy+25],"離れたところで挿入");
    cntrols.push(cbFootLeave);
    yy += 25;
    var btnFootInsertLeave = tabFoot.add("button",[xx,yy,xx+180,yy+25],"挿入するコンポ");
    cntrols.push(btnFootInsertLeave);
    yy += 25;
    var edFootInsertLeave = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edFootInsertLeave);
    edFootInsertLeave.ftg = null;

    yy += 35;
    var cbFootMoved = tabFoot.add("checkbox",[xx,yy,xx+180,yy+25],"地面近くで動いたとき発生");
    cntrols.push(cbFootMoved);
    yy += 25;
     var stInfo = tabFoot.add("staticText",[xx,yy,xx + 180,yy+25],"高さがこれ以下の場合に発生");
    cntrols.push(stInfo);
    yy += 25;
    var edFootY = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"-50");
    cntrols.push(edFootY);
    yy += 25;
     var stInfo = tabFoot.add("staticText",[xx,yy,xx + 180,yy+25],"これ以上動いたら");
    cntrols.push(stInfo);
    yy += 25;
    var edFootMoved = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"50");
    cntrols.push(edFootMoved);
    yy += 25;

   var btnFootInsertMoved = tabFoot.add("button",[xx,yy,xx+180,yy+25],"挿入するコンポ");
    cntrols.push(btnFootInsertMoved);
    yy += 25;
    var edFootInsertMoved = tabFoot.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edFootInsertMoved);
    edFootInsertMoved.ftg = null;
    yy += 35;
    var btnFootExec = tabFoot.add("button",[xx,yy,xx+180,yy+35],"挿入実行");
    cntrols.push(btnFootExec);

    
    // *****

    btnFootTarget.onClick = function()
    {
        edFootTarget.lyr = null;
        edFootTarget.text = "";
        var cmp = get3DLayer();
        if (cmp==null) return;
        edFootTarget.lyr = cmp;
        edFootTarget.text = cmp.name;
    }
    btnFootInsertTouch.onClick = function()
    {
        edFootInsertTouch.ftg = null;
        edFootInsertTouch.text = "";
        var cmp = getFootageComp();
        if (cmp==null) return;
        edFootInsertTouch.ftg = cmp;
        edFootInsertTouch.text = cmp.name;

    }
    btnFootInsertLeave.onClick = function()
    {
        edFootInsertLeave.ftg = null;
        edFootInsertLeave.text = "";
        var cmp = getFootageComp();
        if (cmp==null) return;
        edFootInsertLeave.ftg = cmp;
        edFootInsertLeave.text = cmp.name;

    }
     btnFootInsertMoved.onClick = function()
    {
        edFootInsertMoved.ftg = null;
        edFootInsertMoved.text = "";
        var cmp = getFootageComp();
        if (cmp==null) return;
        edFootInsertMoved.ftg = cmp;
        edFootInsertMoved.text = cmp.name;

    }
    

    btnFootExec.onClick = function()
    {
        var lyr = edFootTarget.lyr;
        if ((lyr==undefined)||(lyr==null)) return;

        if (cbFootTouch.value == true)
        {
            var icmp =  edFootInsertTouch.ftg;
            if ((icmp==undefined)||(icmp==null)) return;
            var border = edFootFloor.text * 1;
            touchInsert(lyr,icmp,border);
        }
        if (cbFootLeave.value == true)
        {
            var icmp =  edFootInsertLeave.ftg;
            if ((icmp==undefined)||(icmp==null)) return;
            var border = edFootFloor.text * 1;
            leaveInsert(lyr,icmp,border);
        }
        if (cbFootMoved.value == true)
        {
            var icmp =  edFootInsertMoved.ftg;
            if ((icmp==undefined)||(icmp==null)) return;
            var yPos = edFootY.text * 1;
            var mValue = edFootMoved.text * 1;

            movedInsert(lyr,icmp,yPos,mValue);
        }
    }
// #endregion
    // ********************************************************************************
    // 接地パーティクル
    // ********************************************************************************
 //#region TouchPar
    var tabFootP = addTab("接地パーティクル");
    xx = 5;
    yy = 5;
    var stInfo = tabFootP.add("staticText",[xx,yy,xx + 180,25],"接地タイミングをスライダー制御に設定します");
    cntrols.push(stInfo);
    yy += 35;
   var btnFootPTarget = tabFootP.add("button",[xx,yy,xx+180,yy+25],"対象のマーカー");
    cntrols.push(btnFootPTarget);
    yy += 25;
    var edFootPTarget = tabFootP.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edFootPTarget);
    edFootPTarget.lyr = null;
    yy += 35;
    var stInfo = tabFootP.add("staticText",[xx,yy,xx + 180,yy+25],"床の高さ。ゆとりを考慮してください");
    cntrols.push(stInfo);
    yy += 25;
    var edFootPFloor = tabFootP.add("edittext",[xx,yy,xx+180,yy+25],"-35");
    cntrols.push(edFootPFloor);
    yy += 35;
    var stInfo = tabFootP.add("staticText",[xx,yy,xx + 180,yy+25],"着地からのオフセットコマ数");
    cntrols.push(stInfo);
    yy += 25;
    var edFootPOffset = tabFootP.add("edittext",[xx,yy,xx+180,yy+25],"-1");
    cntrols.push(edFootPOffset);
    yy += 35;
    var stInfo = tabFootP.add("staticText",[xx,yy,xx + 180,yy+25],"発生のコマ数");
    cntrols.push(stInfo);
    yy += 25;
    var edFootPT = tabFootP.add("edittext",[xx,yy,xx+180,yy+25],"3");
    cntrols.push(edFootPT);
    yy += 35;
    var stInfo = tabFootP.add("staticText",[xx,yy,xx + 180,yy+25],"発生後のFOのコマ数");
    cntrols.push(stInfo);
    yy += 25;
    var edFootPFO = tabFootP.add("edittext",[xx,yy,xx+180,yy+25],"6");
    cntrols.push(edFootPFO);
    yy += 35;
    var btnFootPExec = tabFootP.add("button",[xx,yy,xx+180,yy+35],"実行");
    cntrols.push(btnFootPExec);

 

    btnFootPTarget.onClick = function()
    {
        edFootPTarget.lyr = null;
        edFootPTarget.text = "";
        var lyr = get3DLayer();
        if (lyr!=null){
            edFootPTarget.lyr = lyr;
            edFootPTarget.text = lyr.name;
        }
    }

    btnFootPExec.onClick = function()
    {
        try{
            var lyr = edFootPTarget.lyr;
            if (lyr==null){
                alert("エラー");
                return;
            }
            var floor = edFootPFloor.text * 1;
            var offset = edFootPOffset.text *1;
            var t = edFootPT.text * 1;
            var fo = edFootPFO.text *1;
            app.beginUndoGroup("西貝")
            addFootPar(lyr,floor,offset,t,fo);
            app.endUndoGroup();

        }catch(e){
            alert(e.toString());
        }
    }

// #endregion
    // ********************************************************************************
    // リング状に配置
    // ********************************************************************************
 //#region Ring
    var tabRing = addTab("リング状に配置");
   xx = 5;
    yy = 5;
    var stInfo = tabRing.add("staticText",[xx,yy,xx + 180,25],"指定したレイヤをリング状に配置する");
    cntrols.push(stInfo);
    yy += 35;
   var btnRingTarget = tabRing.add("button",[xx,yy,xx+180,yy+25],"対象のコンポ");
    cntrols.push(btnRingTarget);
    yy += 25;
    var edRingTarget = tabRing.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edRingTarget.cmp = null;
    cntrols.push(edRingTarget);
    yy += 35;
   var btnRingInsert = tabRing.add("button",[xx,yy,xx+180,yy+25],"追加するフッテージ");
    cntrols.push(btnRingInsert);
    yy += 25;
    var edRingInsert = tabRing.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    edRingInsert.ftg = null;
    cntrols.push(edRingInsert);
    yy += 35;
    var stInfo = tabRing.add("staticText",[xx,yy,xx + 180,yy+25],"リングの直径(px)");
    cntrols.push(stInfo);
    yy += 25;
    var edRingRadius = tabRing.add("edittext",[xx,yy,xx+180,yy+25],"1200");
    cntrols.push(edRingRadius);
    yy += 35;
    var stInfo = tabRing.add("staticText",[xx,yy,xx + 180,yy+25],"複製する数");
    cntrols.push(stInfo);
    yy += 25;
    var edRingCount = tabRing.add("edittext",[xx,yy,xx+180,yy+25],"12");
    cntrols.push(edRingCount);
    yy += 35;
    var cbCameraFront = tabRing.add("checkbox",[xx,yy,xx+180,yy+25],"カメラの方向に向くようにする");
    cntrols.push(cbCameraFront);
    yy += 35;
    var cbCollapse = tabRing.add("checkbox",[xx,yy,xx+180,yy+25],"コラップスをONにする");
    cntrols.push(cbCollapse);
    yy += 35;
    var btnRingExec = tabRing.add("button",[xx,yy,xx+180,yy+35],"実行");
    cntrols.push(btnRingExec);

 


    btnRingTarget.onClick = function()
    {
        edRingTarget.cmp = null;
        edRingTarget.text = "";
        var cmp = getComp();
        if (cmp!=null){
            edRingTarget.cmp = cmp;
            edRingTarget.text = cmp.name;
        }
    }
    btnRingInsert.onClick = function()
    {
        edRingInsert.ftg = null;
        edRingInsert.text = "";
        var ftg = getFootageComp();
        if (ftg!=null){
            edRingInsert.ftg = ftg;
            edRingInsert.text = ftg.name;
        }
    }

    btnRingExec.onClick = function()
    {
        try{
            var cmp =  edRingTarget.cmp;
            if (cmp==null) return;
            var insert = edRingInsert.ftg;
            if (insert==null) return;
            var radius = edRingRadius.text * 1;
            var rcount = edRingCount.text *1;
            var isFront = cbCameraFront.value;
            var isCollapse = cbCollapse.value;
            app.beginUndoGroup("じょ");
            layoutRing(cmp,insert,radius,rcount,isFront,isCollapse);
            app.endUndoGroup();

        }catch(e){
            alert(e.toString());
        }
    }

// #endregion
    // ********************************************************************************
    // ぐるぐるパーティクル
    // ********************************************************************************
// region Guru
  var tabGuru = addTab("ぐるぐるパーティクル");
    xx = 5;
    yy = 5;
    var stInfo = tabGuru.add("staticText",[xx,yy,xx + 180,25],"ぐるぐるパーティクルの元を作成");
    cntrols.push(stInfo);
    yy += 35;
   var btnGetComp = tabGuru.add("button",[xx,yy,xx+180,yy+25],"選択コンポジション");
    cntrols.push(btnGetComp);
    yy += 25;
    var edGetComp = tabGuru.add("edittext",[xx,yy,xx+180,yy+25],"",{readonly:true});
    cntrols.push(edGetComp);
    edGetComp.cmp = null;
    yy += 35;
    var stInfo = tabGuru.add("staticText",[xx,yy,xx + 180,yy+25],"数");
    cntrols.push(stInfo);
    yy += 25;
    var edCount = tabGuru.add("edittext",[xx,yy,xx+180,yy+25],"2");
    cntrols.push(edCount);
    yy += 35;
    var btnGuruExec = tabGuru.add("button",[xx,yy,xx+180,yy+35],"実行");
    cntrols.push(btnGuruExec);


  
        function newName(s)
        {
              function findName(nm)
            {
                var ret = false;
                if (app.project.numItems>0)
                {
                    var cnt = app.project.numItems;
                    if (cnt>500) cnt = 500;
                    for (var i=1; i<=cnt; i++)
                    {
                        if (app.project.items[i].name == nm)
                        {
                            ret = true;
                            break;
                        }
                    }
                }
                return ret;
            }
            var nm = s;
            var idx=0;
            do
            {
                nm = s + idx + "";
                idx++;
            }while(findName(nm)==true);
            return nm;
        }

    var mkGuruGuru = function(cmp,count)
    {
        var nm = newName("center");
        var centerL = addNull(cmp,nm,null);
        centerL.threeDLayer = true;
        var rot = 360 / count;

        var fx = addFx(centerL,"ADBE Slider Control","radius");
        fx(1).setValue(200);

        for ( var i=0; i<count; i++)
        {
            var nm2 = "side" + i;
            var c = addNull(cmp,nm2,centerL);
            c.threeDLayer = true;
            c.parent = centerL;
            c.transform.position.setValue([0,0,0]);
            c.transform.anchorPoint.expression = "p = thisComp.layer(\"" + nm + "\").effect(\"radius\")(1);[p,0,0];"
            c.transform.yRotation.setValue(i*rot);
            var lt = cmp.layers.addLight(nm2+"_light",[100,50]);
            lt.name = nm2+"_light";
            lt.lightType = LightType.POINT;
            lt.parent = c;
            lt.transform.position.setValue([0,0,0]);
        }
    }

    btnGetComp.onClick = function()
    {
        edGetComp.cmp = null;
        edGetComp.text = "";
        var cmp = getComp();
        if(cmp==null){
            return;
        }
        edGetComp.cmp = cmp;
        edGetComp.text = cmp.name;
    }
    btnGuruExec.onClick = function()
    {
        var cmp = edGetComp.cmp;
        if(cmp==null) return;
        var count = edCount.text * 1;
        if (count<1) count = 1;
        app.beginUndoGroup("かすみ");
        mkGuruGuru(cmp,count);
        app.endUndoGroup();
    }
// #endregion
    // ********************************************************************************
    // リサイズレイアウト
    // ********************************************************************************
//#region Resize
    var layoutSet = function()
    {
        var wb = winObj.bounds;
        var w = wb[2] -wb[0];
        var h = wb[3] -wb[1];

        var tpb = tabPanel.bounds;
        tpb[0] = 5;
        tpb[1] = 5;
        tpb[2] = tpb[0] + (w-10);
        tpb[3] = tpb[1] + (h-10);
        tabPanel.bounds = tpb;
        var tw = tpb[2] - tpb[0];
        var th = tpb[3] - tpb[1];

        for ( var i=0; i<cntrols.length;i++)
        {
            var bb = cntrols[i].bounds;
            bb[2] =  tw -10;
            cntrols[i].bounds = bb;
        }
    }
    layoutSet();
    winObj.onResize = layoutSet;
// #endregion 
    // ********************************************************************************
    // 設定ファイル
    // ********************************************************************************
// #region pref
    var prefPath = Folder.userData.fullName + "/IKWork.json";
    var prefSave = function()
    {
        var obj = {};
        obj.tabIndex = tabPanel.selection.index;

        var f = new File(prefPath);
        try{
            if (f.open("w")){
                f.write(obj.toSource());
            }
        }catch(e){
            alert(e.toString());
        }finally{
            f.close();
        }

    }
    var prefLoad = function()
    {
        var f = new File(prefPath);
        try{
            if (f.open("r")){
                var js = f.read();
                if (js!="") {
                    var obj = eval(js);
                    var idx = obj.tabIndex;
                    tabPanel.selection = tabs[idx];
                }
            }
        }catch(e){
            alert(e.toString());
        }finally{
            f.close();
        }

    }
    prefLoad();
    winObj.onClose = function()
    {
        prefSave();
    }
// #endregion
    //-------------------------------------------------------------------------

	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}


})(this);