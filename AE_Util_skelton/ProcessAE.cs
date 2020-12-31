using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace BRY
{
	public class ProcessAE
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


		/// <summary>
		/// バージョンを表す文字列
		/// インストールされたフォルダ名から獲得
		/// </summary>
		public string VersionStr = "";
		/// <summary>
		/// 実行ファイルのファイル名
		/// </summary>
		public string FileName = "";
		/// <summary>
		/// 現在のaeのプロジェクトファイル名 aep
		/// </summary>
		public string ProjectName
		{
			get
			{
				string ret = "";

				if(Proc!=null)
				{
					PNFT d = ProjectNameFromTitle(Proc.MainWindowTitle);
					ret = d.ProjectName;
				}

				return ret;
			}
		}

		private Process m_Proc = null;
		/// <summary>
		/// After EffectsのProcess
		/// </summary>
		public Process Proc
		{
			get { return m_Proc; }
			set
			{
				VersionStr = "";
				FileName = "";
				m_Proc = value;
				if(m_Proc!=null)
				{
					try
					{
						FileName = m_Proc.MainModule.FileName;
						VersionStr = VersionFromFileName(FileName);
					}
					catch
					{
						VersionStr = "";
						FileName = "";
					}
				}
			}
		}
		/// <summary>
		/// プロセスID
		/// </summary>
		public int ProcessID
		{
			get
			{
				if (m_Proc != null)
				{
					return m_Proc.Id;
				}
				else
				{
					return 0;
				}
			}
		}
		/// <summary>
		/// AEのメインウィンドウが最大化されているかどうか
		/// </summary>
		public bool IsWS_MAXIMIZE
		{
			get
			{
				bool ret = false;
				if (Proc != null)
				{
					int style = GetWindowLong(Proc.MainWindowHandle, -16);
					ret = ((style & 0x01000000) == 0x01000000);
				}
				return ret;
			}
		}
		// *********************************************************************************
		/// <summary>
		/// プロジェクトが保存されていなかったらtrue
		/// </summary>
		public bool IsNoSaved
		{
			get
			{
				bool ret = false;

				if (Proc != null)
				{
					PNFT d = ProjectNameFromTitle(Proc.MainWindowTitle);
					ret = d.IsNoSaved;
				}

				return ret;
			}
		}
		// *********************************************************************************
		/// <summary>
		/// After Effectsのタイトルバー
		/// </summary>
		public string WindowTitle
		{
			get
			{
				string ret = "";
				if (Proc != null)
				{
					ret = Proc.MainWindowTitle;
				}
				return ret;
			}
		}
		// *********************************************************************************
		public ProcessAE()
		{
			Proc = null;
			VersionStr = "";
			FileName = "";

		}
		// *********************************************************************************
		public ProcessAE(Process ps)
		{
			Proc = ps;
		}

		// *********************************************************************************
		public override string ToString()
		{
			string id = "";
			if (Proc != null)
			{
				id = String.Format("ProcessID:{0}", Proc.Id);

			}
			return String.Format("VersionStr:\"{0}\", Project:\"{1}\", FileName:\"{2}\", IsMAX:{3}, IsNoSaved:{4}, {5}",
				VersionStr,
				ProjectName,
				FileName,
				IsWS_MAXIMIZE,
				IsNoSaved,
				id
				);
		}
		// *********************************************************************************
		public string ToAEJson
		{
			get
			{
				string ret = "";
				ret += String.Format("ProcessID:{0},", ProcessID);
				ret += String.Format("WindowTitle:{0},", "\"" + WindowTitle + "\"");
				ret += String.Format("FileName:{0},", "\"" + FileName + "\"");
				ret += String.Format("VersionStr:{0},", "\"" + VersionStr + "\"");
				ret += String.Format("IsWS_MAXIMIZE:{0},", IsWS_MAXIMIZE);
				ret += String.Format("ProjectName:{0},", "\"" + ProjectName + "\"");
				ret += String.Format("IsNoSaved:{0}", IsNoSaved);

				return "{" + ret + "}";
			}
		}
		// *********************************************************************************
		/// <summary>
		/// aerenderのフルパス
		/// </summary>
		public string aerender
		{
			get
			{
				if (FileName != "")
				{
					string n = Path.GetDirectoryName(FileName);
					return Path.Combine(n, "aerender.exe");
				}
				else
				{
					return "";
				}
			}
		}
		// *********************************************************************************
		/// <summary>
		/// 実行ファイルのフルパスから、バージョンを調べる
		/// </summary>
		/// <param name="p"></param>
		/// <returns>"CS6" or "CC" or "CC 2019" or "2020"</returns>
		static public string VersionFromFileName(string p)
		{
			string ret = "";
			try
			{
				string n = Path.GetFileName(p).ToLower();
				if ((n == "afterfx.exe") || (n == "aerender.exe"))
				{
					ret = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(p)));
					ret = ret.Substring(NFsAE.TARGET_HEAD.Length).Trim();
				}
			}
			catch
			{
				ret = "";
			}

			return ret;
		}
		// *********************************************************************************
		private class PNFT
		{
			public string VersionStr = "";
			public string ProjectName = "";
			public bool IsNoSaved = false;
		}

		static public dynamic ProjectNameFromTitle(string p)
		{
			PNFT ret = new PNFT();

			ret.VersionStr = "";
			ret.ProjectName = "";
			ret.IsNoSaved = false;


			string header = "Adobe After Effects";

			if (p.IndexOf(header) != 0) return ret;
			if (p.ToLower().IndexOf(".aep") < 0) return ret;
			p = p.Substring(header.Length);

			int idx = p.IndexOf("-");
			if (idx >= 0)
			{
				string vs = p.Substring(0, idx - 1).Trim();
				ret.VersionStr = vs;
				string pn = p.Substring(idx + 1).Trim();
				ret.ProjectName = pn;

				if (pn.Length > 2)
				{

					if (pn[pn.Length - 1] == '*')
					{
						ret.IsNoSaved = true;
						ret.ProjectName = pn.Substring(0,pn.Length - 1).Trim();
					}
				}
			}

			return ret;
		}
	}
}
