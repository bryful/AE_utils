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
			mes += "            /fore   ウィンドウを最前面に\r\n";
			mes += "            /i[xxxx] 指定したプロセスIDのみに実行\r\n";
			mes += "            /help   この表示\r\n";

			Console.WriteLine(mes);
		}

		static void AnalysisCmd(string[] args, out EXEC_MODE md, out int pid ,out bool IsFore)
		{
			md = EXEC_MODE.MAX;
			pid = 0;
			IsFore = false;

			CmdArgs ca = new CmdArgs(args);
			if (ca.OptionsCount <= 0) return;

			CmdOptions[] opts = ca.FindOptions("he",true);
			if(opts.Length>0)
			{
				md = EXEC_MODE.HELP;
				return;
			}
			opts = ca.FindOptions("?");
			if (opts.Length > 0)
			{
				md = EXEC_MODE.HELP;
				return;
			}
			opts = ca.FindOptions("mi", true);
			if (opts.Length > 0)
			{
				md = EXEC_MODE.MIN;
			}
			opts = ca.FindOptions("f", true);
			if (opts.Length > 0)
			{
				IsFore = true;
			}
			opts = ca.FindOptions("i", true);
			if (opts.Length > 0)
			{
				foreach(CmdOptions co in opts)
				{
					string s = co.Option.Substring(1);
					int v = 0;
					if (int.TryParse(s, out v) == false) continue;
					if (v > 0)
					{
						pid = v;
						break;
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
			bool isFore = false;
			AnalysisCmd(args, out md, out pid, out isFore);
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
					ProcessAE pp = null;
					foreach (ProcessAE p in lst)
					{
						if(p.ProcessID == pid)
						{
							pp = p;
							break;
						}
					}
					if(pp!=null)
					{
						pp.SetWindow((int)md);
						if (isFore) pp.SetForegroundWindow();
						return;
					}
				}
				foreach (ProcessAE p in lst)
				{
					p.SetWindow((int)md);
					if (isFore) p.SetForegroundWindow();
				}
			}
			else
			{
				Usage();
			}
		}
	}
}
