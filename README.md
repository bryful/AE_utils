# AE_utils
Adobe After Effectsで作業を少し楽にするための小物ツール類です。  
基本的に単独アプリですが、同時作業で楽になるようにフローティングバーが付いています。
  
ソース見ればわかるように少しづつ増やしていきます。  
  
## 共通の使い方
普通のアプリですので、適当なところにインストールして実行してください。

## 個別の解説

### AE_ColorPalette.exe
俗にいうカラーパレットです。  
  
![AE_ColorPalette](https://user-images.githubusercontent.com/50650451/77540762-047ca600-6ee7-11ea-8511-bfb290b8dcec.png)  
カラープロパティを選択して、コピー＆ペーストできます。  
ありそうでなかったので作りました。通常のコンポジット時ではあまり使わないと思いますが、シェイプでデザインしてる時に重宝します。  
  
今まで新規ビューで画像を開いてやってましたが、これでただでさえ狭い画面を少しは有効に使えるようになります。  
  
### AE_Expression_CopyPaste
単純にコピーしたテキストを貯めることができるアプリです。  
AE上でコピーしたものはほぼ全てテキストデータになっているので、AEのパラメータを貯めておくことができます。  
  
![AE_Expression_CopyPaste](https://user-images.githubusercontent.com/50650451/77541340-e499b200-6ee7-11ea-8b97-3b56ab59546f.png)  
  
僕ばエクスプレッションでよく使うコード等を貯めています。

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
## Dependency
Visual studio 2017 C#


## Setup

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi) http://bryful.yuzu.bz/  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

## References
