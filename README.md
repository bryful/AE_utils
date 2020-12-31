# AE_utils
Adobe After Effectsで作業を少し楽にするための小物ツール類です。
基本的に単独アプリですが、同時作業で楽になるようにフローティングバーが付いています。

ソース見ればわかるように少しづつ増やしていきます。


## 共通の使い方
普通のアプリですので、適当なところにインストールして実行してください。

## 個別の解説
<hr>

### <b>AE_Util_skelton</b>
これらのアプリのテンプレートとして作ったものです。

<b>NFsAEクラス</b>
同じコードをなるべく使いまわすために作ったクラスです。<br>
インストールされているAEをリストアップしたり、実行中のAEの状態を確認できます。<br>
スクリプト実行の機能もあります。
<br>
AfterFX.exe -r でスクリプトを呼び出すとウィンドウの最大化が解除されてしまうので、無理やり最大化状態に復帰させるように呼び出します。内部で<b>aeWin.exe</b>を呼び出して実装しています。

ビルドする際は、プラットフォームをx64にするか、anycpuで「32ビットを選ぶ」をOFFにしてください。エラーが出ます。


<b>ProcessAEクラス</b>
Processクラスから、いろいろな情報を引き出すクラス。<br>
win32apiを使いまくっているので、Macへの移植はかなり難しくなりました。

* ProcessID プロセスID
* WindowTitle タイトルバー文字列
* FileName 実行ファイルAfterFX.exeのフルパス
* VersionStr バージョン識別の文字列
* IsWS_MAXIMIZE ウィンドウが最大化ならtrue
* ProjectName aepファイルのフルパス
* IsNoSaved aepが保存されていない場合true

<hr>

### <b>aeStatus</b>
After Effectsの状態を調べるコンソールアプリです。
実行すると

```
([
	{ProcessID:16320,
	WindowTitle:"Adobe After Effects 2020 - 名称未設定プロジェクト.aep *",
	FileName:"C:\Program Files\Adobe\Adobe After Effects 2020\Support Files\AfterFX.exe",
	VersionStr:"2020",
	IsWS_MAXIMIZE:True,
	ProjectName:"名称未設定プロジェクト.aep",
	IsNoSaved:True
	},
	{ProcessID:23172,
	WindowTitle:"Adobe After Effects - 名称未設定プロジェクト.aep *",
	FileName:"C:\Program Files\Adobe\Adobe After Effects CC 2019\Support Files\AfterFX.exe",
	VersionStr:"CC 2019",
	IsWS_MAXIMIZE:False,
	ProjectName:"名称未設定プロジェクト.aep",
	IsNoSaved:True}
])

```
* ProcessID プロセスID
* WindowTitle タイトルバー文字列
* FileName 実行ファイルAfterFX.exeのフルパス
* VersionStr バージョン識別の文字列
* IsWS_MAXIMIZE ウィンドウが最大化ならtrue
* ProjectName aepファイルのフルパス
* IsNoSaved aepが保存されていない場合true

以上の情報が配列として標準出力に出力されます。
callSystemの返り値をevalで処理できます。

<hr>

### <b>aeWin</b>
After Efefctsのウィンドウの最大化・最小化を制御するコンソールアプリです。

```
[aeWin.exe] After Effectsのウィンドウの状態を設定する
   aeWin <option>
   option : /max    ウィンドウを最大化(デフォルト)
            /min    ウィンドウを最小化
            /normal ウィンドウを通常化
            /i[xxxx] 指定したプロセスIDのみに実行
            /help   この表示
```

NFsAEクラスでウィンドウの最大化を実装するために作ったものですが、単独でも使えます。
前に作った奴はAEを複数起動させているとどれか１個だけしか処理していなかったので、複数起動させていても使えるようにしてあります。

何もオプションを付けていない場合は、すべてのAfterFXを最大化させます。


<hr>

### <b>MousePos</b>

実行した時点でのマウスカーソルの位置を返すコンソールアプリです。

>({x:692, y:265})

これもcallSystemの返り値をevalで処理できます。


<hr>

### AE_Menu
スクリプトメニューを簡単に作るアプリ。
スクリプトを複数入れたフォルダをD&Dするとメニューを作ります。右クリックでいろいろ編集します。
ExportScriptでメニュースクリプトを書き出します。

<hr>

### AE_ColorPalette.exe
俗にいうカラーパレットです。

![AE_ColorPalette](https://user-images.githubusercontent.com/50650451/77540762-047ca600-6ee7-11ea-8511-bfb290b8dcec.png)
カラープロパティを選択して、コピー＆ペーストできます。
ありそうでなかったので作りました。通常のコンポジット時ではあまり使わないと思いますが、シェイプでデザインしてる時に重宝します。

今まで新規ビューで画像を開いてやってましたが、これでただでさえ狭い画面を少しは有効に使えるようになります。

<hr>

### AE_Expression_CopyPaste
単純にコピーしたテキストを貯めることができるアプリです。
AE上でコピーしたものはほぼ全てテキストデータになっているので、AEのパラメータを貯めておくことができます。

![AE_Expression_CopyPaste](https://user-images.githubusercontent.com/50650451/77541340-e499b200-6ee7-11ea-8b97-3b56ab59546f.png)

僕ばエクスプレッションでよく使うコード等を貯めています。

<hr>

### aeclip.exe
![aeclip exe](https://user-images.githubusercontent.com/50650451/77542192-25de9180-6ee9-11ea-97a0-ccb8ef3a6fee.png)
これはコンソールアプリです。
aeclip.exe
         aeclip [/c] filename (copy to clipboard.)
         aeclip [/p] (from clipboard to STD default)
         aeclip [/o] filename (from clipboard to file)
         aeclip  /h or /? (help)

指定したテキストファイルをクリップボードに送ったり、クリップボードの中身を出力できます。
AEスクリプト中でクリップボードを使いたいときに使います。
適当なテキストファイルを書き出して

 system.callSystem("aeclip foo.txt");

とかして使います。実際のサンプルコードは以下のようになります。
```
	var aeclipPath = File.decode($.fileName.getParent()+"/aeclip.exe");//getParent()は自作プロトタイプ
	//実行スクリプトファイルと同じ場所にaeclipを置いたとして
	var toClipbord = function(str)
	{
		var ob = Folder.temp.fullName;
		var pa =  ob + "/tmp.txt";
		var ff = new File(pa);
		ff.encoding = "utf-8";
		if (ff.open("w")){
			try{
				ff.write(str);
			}finally{
				ff.close();
			}
		}
		var fclip = new File(aeclipPath);
		var cmd =  "\"" + fclip.fsName +"\"" + " /c \"" + ff.fsName + "\"";
		if (ff.exists==true){
			try{
				var er = system.callSystem(cmd);
			}catch(e){
				alert("ca" + e.toString());
			}
		}

	}
```

<hr>

## Dependency
Visual studio 2017 C#


## Setup

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi)
twitter:[bryful](https://twitter.com/bryful)
bryful@gmail.com

## References
