using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic.ApplicationServices;

namespace AE_Util_skelton
{
	public class MyApp : WindowsFormsApplicationBase
	{
		public MyApp()
		: base()
		{
			this.EnableVisualStyles = true;
			this.IsSingleInstance = true;
			this.MainForm = new Form1();//スタートアップフォームを設定
			this.StartupNextInstance += new StartupNextInstanceEventHandler(MyApplication_StartupNextInstance);
		}
		public void MyApplication_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
		{
			//ここに二重起動されたときの処理を書く
			//e.CommandLineでコマンドライン引数を取得出来る
			Form1 f = (Form1)this.MainForm;
			f.GetCommand(e.CommandLine.ToArray<string>());
		}
	}
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//下の3行を復活させれば多重起動ができる
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

			MyApp winAppBase = new MyApp();
			winAppBase.Run(args);
		}
	}

}
