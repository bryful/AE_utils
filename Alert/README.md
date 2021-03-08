# Alert.exe

After Effects 2020のスクリプトで表示されるアラートダイアログがあまりにも見づらいので作ったものです。

* htmlタグを認識します。cssも大丈夫と思います。
* 読み込み時に上書き・追加が選べます。


# 使い方

scriptCode/AlertSample.jsxを参照してください。<br>

基本的には

```
var mes = {};
	mes.headcss = "p{color:blue; font-size:large;}h1{color:red; line-height:1.5; font-size:xx-large;}body{font-family:'メイリオ')}";
	mes.title = title;
	mes.body = "<h1>Alert Sample</h1>";
	mes.body += "<p>アラートダイアログのサンプルです。<br>";
	mes.body += "こんなことができます";
	mes.body += "<lu><li><b>html</b>のタグが使えます。<li>というかhtmlしか使えない<li>cssも使えるはず</lu>";
	mes.body += "</lu></p>";
	//mes.left = 50; // isCenterがtrueだと無視される
	//mes.top = 50; // isCenterがtrueだと無視される
	//mes.width = 450;
	//mes.height = 400;
	mes.isCenter = false;
	var objStr = mes.toSource();
```
上記のオブジェクトを作成しtoSourceでテキスト化してファイルに保存。それをalert.exeに読み込ませば表示されます。<br>
<br>
**system.callSystem**を使ってAlert.exe呼び出すと通常のダイアログっぽい動作になります。**AlertCall.exe**を使って呼び出すとフローティングパレットのような挙動になります。


# Dependency
Visual studio 2019 C#


## Setup

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi)
twitter:[bryful](https://twitter.com/bryful)
bryful@gmail.com

## References
