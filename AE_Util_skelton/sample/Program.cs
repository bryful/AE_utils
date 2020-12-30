using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices; //WindowsAPIを使うために追加

namespace WindosStatusAfterFX
{

	/*
	 * このプログラムの作成するに当たって以下のHPを参考にしました。
	 * 
	 * 宇宙仮面の C# プログラミング
	 * ウィンドウを整列させる
	 * http://uchukamen.com/Programming1/WindowFunctions/index.htm
	 * 
	 * 
	 * muumoo.jp
	 * C#(っていうか.NET)でウィンドウを列挙
	 * http://muumoo.jp/news/2008/03/26/0enumwindows.html
	 * 
	 */

	class Program
	{
		private delegate int EnumWindowsDelegate(IntPtr hWnd, int lParam);

		[DllImport("user32.dll")]
		private static extern int EnumWindows(EnumWindowsDelegate lpEnumFunc, int lParam);
		[DllImport("user32.dll")]
		private static extern int IsWindowVisible(IntPtr hWnd);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
		[DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("User32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);
		[STAThread]
		static void Main()
		{
			//既に起動していたら終了
			if (System.Diagnostics.Process.GetProcessesByName(
					System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
			{
				return;
			}

			string[] cmds;
			cmds = System.Environment.GetCommandLineArgs();

			if (cmds.Length < 2)
			{
				return;
			}
			string cmd = cmds[1].ToLower();
			int ws = 0;

			switch (cmd)
			{
				case "normal": ws = 1; break;
				case "min": ws = 2; break;
				case "max":
				default:
					ws = 3; break;
			}


			System.Diagnostics.Process fxP = null;
			IntPtr fxWnd = (IntPtr)0;
			string fxTitle = "";

			EnumWindows(new EnumWindowsDelegate(delegate(IntPtr hWnd, int lParam)
			{
				StringBuilder sb = new StringBuilder(0x1024);
				if (IsWindowVisible(hWnd) != 0 && GetWindowText(hWnd, sb, sb.Capacity) != 0)
				{
					string title = sb.ToString();
					int pid;
					GetWindowThreadProcessId(hWnd, out pid);
					System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);

					if (p.ProcessName == "AfterFX")
					{
						fxP = p;
						fxWnd = hWnd;
						fxTitle = title;
						return 0;
					}
				}
				return 1;
			}), 0);

			if ((int)fxWnd != 0)
			{
				fxP.WaitForInputIdle();
				ShowWindow(fxWnd, ws);
				SetForegroundWindow(fxWnd);
			}
		}
	}
}
