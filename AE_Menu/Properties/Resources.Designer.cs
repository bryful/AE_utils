﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AE_Menu.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AE_Menu.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   /*
        ///	AE_Menuで書き出されるスクリプトメニューのひな型。
        ///
        ///	以下の$で始まるタグが置換される。(下の例は全角二していますが実際は半角です)
        ///
        ///	＄Title		メニューのタイトル名に置換される。
        ///
        ///	＄BaseFolder	jsx/ffxが収納されているフォルダのパスに置換される。
        ///				絶対パスの場合 &quot;/c/Bin/Scripts&quot;
        ///				相対パスの場合 &quot;./(foo)&quot;
        ///				になる
        ///
        ///	＄Items		呼び出すjsx/ffxのファイル名を配列として置換
        ///		&quot;aaa.jsx&quot;,
        ///		&quot;bbb.jsz&quot;
        ///		&quot;ccc.ffx&quot;
        ///		こんな感じな形式に置換
        ///
        ///	＄IconWidth	ボタンの横幅ピクセル
        ///	＄IconHeight	ボタンの縦幅ピクセル
        ///
        ///*/
        ///(function(me){
        /////----------------------------------
        ////*
        /////ライブラリの読み込み　必要に応じて
        ///#includepath &quot;./;./(lib)&quot;
        ///#include &quot;prototypeArray.jsx&quot;
        ///#include [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string JSX {
            get {
                return ResourceManager.GetString("JSX", resourceCulture);
            }
        }
    }
}
