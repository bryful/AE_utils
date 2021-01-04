# C#用 After Effects制御ライブラリ NFsAEのサンプル

NFsAEクラスは、C#からAfter Effectsを制御するC#のライブラリです。

まだ未完成ですが一応実用レベルまでできたのでgithubにアップしました。

[https://github.com/bryful/AE_utils](https://github.com/bryful/AE_utils)

とりあえずサンプルとして試しに作った作ったものをアップします。 　　
基本的にサンプルですが、何かに使えそうなのでアップします。


# aeStatus.exe

起動しているAfterFXの情報を標準出力に出すコンソールアプリです。

```
(
[
	{
	ProcessID:16876,
	WindowTitle:"Adobe After Effects 2020 - 名称未設定プロジェクト.aep",
	FileName:"C:\Program Files\Adobe\Adobe After Effects 2020\Support Files\AfterFX.exe",
	VersionStr:"2020",
	IsWS_MAXIMIZE:True,
	ProjectName:"名称未設定プロジェクト.aep",
	IsNoSaved:False
	}
]
)
```
こんな感じに出力します。
callSystemで使う事を想定しています。

# aeWin.exe
AfterFXのウィンドウの最大化・最小化を制御するコンソールアプリです。

```
[aeWin.exe] After Effectsのウィンドウの状態を設定する
   aeWin <option>
   option : /max    ウィンドウを最大化(デフォルト)
            /min    ウィンドウを最小化
            /normal ウィンドウを通常化
            /fore   ウィンドウを最前面に
            /i[xxxx] 指定したプロセスIDのみに実行
            /help   この表示

```
引数無しで実行すると開いているすべてのAfterFXを最大化します。

AfterFX -r でスクリプトを実行させると最大化が解除されてしまうので、それを無理やり修正するのに使います。　　

# AE_Util_skelton.exe

NFsAEの動作確認用のアプリです。
インストールされているAfter Effectsをリストアップしたり、起動させたりスクリプトを実行させたりできます。
基本的に動作確認用なので実用性はありません。

# AfterFXControl.exe
複数のバージョンのAfter Effectsを管理するアプリ。
バージョンを選んで実行させたり、起動しているAEの切り替え・最大化最小化ができます。
本当はウィンドウ整列までしたかったのですが、あまり使わなさそうなのでこれだけにしてます。

bry-ful
Hiroshi Furuhashi



