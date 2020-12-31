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


using BRY;
namespace aeWin
{
	class Program
	{
		#region DllImport
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("User32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);
		#endregion
	
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
			mes += "            /i[xxxx] 指定したプロセスIDのみに実行\r\n";
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

			ProcessAE[] lst = NFsAE.ProcessAEList();

			if(lst.Length>0)
			{
				if (pid > 0)
				{
					Process pp = null;
					foreach (ProcessAE p in lst)
					{
						if(p.ProcessID == pid)
						{
							pp = p.Proc;
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
				foreach (ProcessAE p in lst)
				{
					p.Proc.WaitForInputIdle();
					ShowWindow(p.Proc.MainWindowHandle, (int)md);
					SetForegroundWindow(p.Proc.MainWindowHandle);
				}
			}
			else
			{
				Usage();
			}
		}
	}
}
