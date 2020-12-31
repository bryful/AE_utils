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

namespace aeStatus
{
	public class AE_Status
	{
		public int ProcessID = 0;
		public string WindowTitle = "";
		public bool IsWindowMax = false;
		public string FileName = "";
		public string ProjectName = "";
		public string VersionStr = "";
		public bool IsNoSaved = false;

		public string ToAEJson
		{
			get
			{
				string ret = "";
				ret += String.Format("ProcessID:{0},", ProcessID);
				ret += String.Format("WindowTitle:{0},", "\"" + WindowTitle +"\"");
				ret += String.Format("FileName:{0},", "\"" + FileName + "\"");
				ret += String.Format("VersionStr:{0},", "\"" + VersionStr + "\"");
				ret += String.Format("IsWindowMax:{0},", IsWindowMax);
				ret += String.Format("ProjectName:{0},", "\"" + ProjectName + "\"");
				ret += String.Format("IsNoSaved:{0}", IsNoSaved);

				return "{" + ret + "}";
			}
		}


	}
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
		
		
		// ***************************************************************
		private static List<AE_Status> StatusList = new List<AE_Status>();

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
				AE_Status aes = new AE_Status();
				AE_Status nm = ProjectNameFromTitle(p.MainWindowTitle);

				aes.ProcessID = p.Id;
				aes.WindowTitle = p.MainWindowTitle;
				int style = GetWindowLong(p.MainWindowHandle, -16);
				aes.IsWindowMax = ((style & 0x01000000) == 0x01000000);
				aes.FileName = p.MainModule.FileName;
				aes.ProjectName = nm.ProjectName;
				aes.VersionStr = VersionFromFileName(aes.FileName);
				aes.IsNoSaved = nm.IsNoSaved;

				StatusList.Add(aes);
			}
			return true;
		}
		// ***************************************************************
		static private string VersionFromFileName(string p)
		{
			string TARGET_HEAD = @"Adobe After Effects";
			string ret = "";
			try
			{
				string n = Path.GetFileName(p).ToLower();
				if ((n == "afterfx.exe") || (n == "aerender.exe"))
				{
					ret = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(p)));
					ret = ret.Substring(TARGET_HEAD.Length).Trim();
				}
			}
			catch
			{
				ret = "";
			}

			return ret;
		}
		// ***************************************************************
		static private AE_Status ProjectNameFromTitle(string p)
		{
			AE_Status ret = new AE_Status();

			string header = "Adobe After Effects";

			if (p.IndexOf(header) != 0) return ret;
			if (p.ToLower().IndexOf(".aep") < 0) return ret;
			p = p.Substring(header.Length);

			int idx = p.IndexOf("-");
			if (idx >= 0)
			{
				ret.VersionStr = p.Substring(0, idx - 1).Trim();
				ret.ProjectName = p.Substring(idx + 1).Trim();
				ret.IsNoSaved = false;
				if (ret.ProjectName.Length>2)
				{
					if(ret.ProjectName.Substring(ret.ProjectName.Length-1)=="*")
					{
						ret.ProjectName = ret.ProjectName.Substring(0, ret.ProjectName.Length - 1).Trim();
						ret.IsNoSaved = true;
					}
				}
			}

			return ret;
		}
		static void Main(string[] args)
		{
			string ret = "";
			StatusList.Clear();
			EnumWindows(EnumerateWindows, IntPtr.Zero);
			foreach(AE_Status aes in StatusList)
			{
				if (ret != "") ret += ",";
				ret += aes.ToAEJson;
			}

			Console.WriteLine("([" + ret + "])");

		}
	}
}
