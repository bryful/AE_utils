using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace aeWin
{
	class Program
	{
		#region DllImport
		// トップレベルウィンドウを列挙する
		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lParam);

		// ウィンドウの表示状態を調べる(WS_VISIBLEスタイルを持つかを調べる)
		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		//ウィンドウのタイトルの長さを取得する
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		// ウィンドウのタイトルバーのテキストを取得
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// ウィンドウを作成したプロセスIDを取得
		//[DllImport("user32")]// 「.dll」なくても動いてた
		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

		// EnumWindowsから呼び出されるコールバック関数のデリゲート
		private delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("User32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);
		#endregion
		private static List<Process> ProcessList = new List<Process>();

		private static bool EnumerateWindows(IntPtr hWnd, IntPtr lParam)
		{
			if (IsWindowVisible(hWnd) == false) return true;

			int textLen = GetWindowTextLength(hWnd);
			if (textLen == 0) return true;

			// ウィンドウハンドルからプロセスIDを取得
			int processId;
			GetWindowThreadProcessId(hWnd, out processId);
			// プロセスIDからProcessクラスのインスタンスを取得
			Process p = Process.GetProcessById(processId);
			if (p.ProcessName == "AfterFX")
			{
				ProcessList.Add(p);
			}
			return true;
		}
		public enum EXEC_MODE{
			NONE = 0,
			NORMAL,
			MIN,
			MAX,
			HELP
		};
	

		static void Usage()
		{
			string mes = "";
			mes += "[aeWin.exe] After Effectsのウィンドウの状態を設定する\r\n";
			mes += "   aeWin <option>\r\n";
			mes += "   option : /max    ウィンドウを最大化(デフォルト)\r\n";
			mes += "            /min    ウィンドウを最小化\r\n";
			mes += "            /normal ウィンドウを通常化\r\n";
			mes += "            /id[xxxx] 指定したプロセスIDのみに実行\r\n";
			mes += "            /help   この表示\r\n";

			Console.WriteLine(mes);
		}

		static void AnalysisCmd(string[] args, out EXEC_MODE md, out int pid)
		{
			md = EXEC_MODE.MAX;
			pid = 0;
			foreach (string s in args)
			{
				if (s.Length < 3) continue;
				if( (s[0]=='/')|| (s[0] == '-'))
				{
					string sa = s.Substring(1).ToLower();
					if (sa.IndexOf("ma") == 0)
					{
						md = EXEC_MODE.MAX;
					}
					else if (sa.IndexOf("mi") == 0)
					{
						md = EXEC_MODE.MIN;
					}
					else if (sa.IndexOf("no") == 0)
					{
						md = EXEC_MODE.NORMAL;

					}
					else if (sa.IndexOf("he") == 0)
					{
						md = EXEC_MODE.HELP;
						return;

					}
					else if (sa[0] == 'i')
					{
						int v = 0;
						if (int.TryParse(sa.Substring(1),out v)==true)
						{
							if(md == EXEC_MODE.NONE) md = EXEC_MODE.MAX;
							pid = v;
						}
						else
						{
							md = EXEC_MODE.HELP;
							pid = 0;
						}
					}
				}
			}
		}
		static void Main(string[] args)
		{
			if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
			{
				return;
			}
			EXEC_MODE md = EXEC_MODE.HELP;
			int pid = 0;
			AnalysisCmd(args, out md, out pid);
			if((md==EXEC_MODE.HELP)|| (md == EXEC_MODE.NONE))
			{
				Usage();
				return;
			}

			ProcessList.Clear();
			EnumWindows(EnumerateWindows, IntPtr.Zero);

			if(ProcessList.Count>0)
			{
				if (pid > 0)
				{
					Process pp = null;
					foreach (Process p in ProcessList)
					{
						if(p.Id == pid)
						{
							pp = p;
							break;
						}
					}
					if(pp!=null)
					{
						pp.WaitForInputIdle();
						ShowWindow(pp.MainWindowHandle, (int)md);
						SetForegroundWindow(pp.MainWindowHandle);
						return;
					}
				}
				foreach (Process p in ProcessList)
				{
					p.WaitForInputIdle();
					ShowWindow(p.MainWindowHandle, (int)md);
					SetForegroundWindow(p.MainWindowHandle);
				}
			}
			else
			{
				Usage();
			}
		}
	}
}
