(function (){

    /*
        alert.exeを呼び出すサンプル
    */
    var alertFunc = function(body,title,css)
    {
        //オブジェクトに以下のパラメータを設定
        var mes = {};
        if ( (css!=undefined)&&(css!=null)&&(css!=""))
        {
            mes.headcss = css;
        }
        else
        {
            mes.headcss = "p{color:blue; font-size:large;}h1{color:red; line-height:1.5; font-size:xx-large;}body{font-family:'メイリオ')}";
        }
        if ( (title!=undefined)&&(title!=null)&&(title!=""))
        {
            mes.title = title;
        }else{
            mes.title = "alert サンプル";
        }
        if ( (body!=undefined)&&(body!=null)&&(body!=""))
        {
            mes.body = body;
        }else{
            mes.body = "<h1>Alert Sample</h1>";
            mes.body += "<p>アラートダイアログのサンプルです。<br>";
            mes.body += "こんなことができます";
            mes.body += "<lu><li><b>html</b>のタグが使えます。<li>というかhtmlしか使えない<li>cssも使えるはず</lu>";
            mes.body += "</lu></p>";

        }

        //mes.left = 50; // isCenterがtrueだと無視される
        //mes.top = 50; // isCenterがtrueだと無視される
        //mes.width = 450;
        //mes.height = 400;
        mes.isCenter = false;
        var objStr = mes.toSource();

        //tempフォルダにファイルを保存 拡張子は.json
        var f = new File(Folder.temp.fullName +"/alert.json");

        //一応実行前に同盟ファイルは消しておく
        if (f.exists){
            f.remove();
        }
        if (f.open("w"))
        {
            try{
                //エンコードをutf-8にしておく
                f.encoding = "utf-8";
                f.write(objStr);
            }catch(e){

            }finally{
                f.close();

            }
        }
        if (f.exists)
        {
            try{
                //alert.exeの場所は任意に。
                //ここではスクリプトと同じ場所として記述
                //渡すパスはfsNameで作成
                var call = "alertcall.exe"; // フローティングダイアログ
                //var call = "alert.exe"; // 普通のダイアログ
                call +=" \"" +f.fsName +"\""
                system.callSystem(call);
            }catch(e){
                alert(e.toString());
            }
        }

    }

    alertFunc("アラート表示のサンプルA<br>","サンプル");

})();