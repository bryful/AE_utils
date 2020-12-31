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
	public enum AEStutas
	{
		/// <summary>
		/// AEの状態 不明
		/// </summary>
		None,
		/// <summary>
		/// すでに起動中
		/// </summary>
		IsRunning,
		/// <summary>
		/// 起動スタート
		/// </summary>
		IsRunStart
	}
	public class NFsAE
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

		#region Const
		static public readonly string TARGET_DIR = @"C:\Program Files\Adobe";
		static public readonly string TARGET_HEAD = @"Adobe After Effects";
		static public readonly string TARGET_EXE = @"\Support Files\AfterFX.exe";
		static public readonly string TARGET_RENDER = @"\Support Files\aerender.exe";
		#endregion

		#region Event
		public event EventHandler TargetAEIndexChanged;

		protected virtual void OnTargetAEIndexChanged(EventArgs e)
		{
			if (TargetAEIndexChanged != null)
			{
				TargetAEIndexChanged(this, e);
			}
		}
		#endregion
		#region installed
		private string[] m_InstalledAFX = new string[0];
		public int InstallCount
		{
			get { return m_InstalledAFX.Length; }
		}
		public string[] InstalledAFX
		{
			get
			{
				return m_InstalledAFX;
			}
		}
		#endregion

		public string TargetVersionStr
		{
			get
			{
				string ret = "";
				if (m_TargetVersionIndex >= 0)
				{
					ret = m_InstalledAFX[m_TargetVersionIndex].ToUpper();
				}
				return ret;
			}
			set
			{

				string tag = value.ToUpper().Trim();
				if (m_InstalledAFX.Length > 0)
				{
					for (int i = 0; i < m_InstalledAFX.Length; i++)
					{
						if (tag == m_InstalledAFX[i])
						{
							TargetVersionIndex = i;
							break;
						}
					}
				}
			}
		}

		private int m_TargetVersionIndex = -1;
		public int TargetVersionIndex
		{
			get { return m_TargetVersionIndex; }
			set
			{
				if (m_TargetVersionIndex != value)
				{
					m_TargetVersionIndex = value;
					OnTargetAEIndexChanged(new EventArgs());
				}
			}
		}
		public string AfterFXPath
		{
			get
			{
				string ret = "";
				if (m_TargetVersionIndex >= 0)
				{
					ret = CombineAE(m_InstalledAFX[m_TargetVersionIndex]);
				}
				return ret;
			}
		}
		public string AerenderPath
		{
			get
			{
				string ret = "";
				if (m_TargetVersionIndex >= 0)
				{
					ret = CombineAERENDER(m_InstalledAFX[m_TargetVersionIndex]);
				}
				return ret;
			}
		}
		private string m_AeWin = "aeWin.exe";
		public string AeWin
		{
			get { return m_AeWin; }
			set
			{
				m_AeWin = value;

				if(m_AeWin=="")
				{
					m_AeWin = "aeWin.exe";
				}
			}
		}
		// *****************************************************************
		public NFsAE ()
		{
		}
		// *****************************************************************
		/// <summary>
		/// インストールされているAfter Effects
		/// </summary>
		/// <returns>インストールされているフォルダの文字列配列</returns>
		static public string[] FindInstalledAfterFX()
		{
			List<string> ret = new List<string>();

			string[] dl = Directory.GetDirectories(TARGET_DIR, TARGET_HEAD + "*", SearchOption.TopDirectoryOnly);

			if (dl.Length > 0)
			{
				string pn = TARGET_DIR + "\\" + TARGET_HEAD + " ";
				foreach (string p in dl)
				{
					string pp = p + TARGET_EXE;
					if (File.Exists(pp) == true)
					{
						string p2 = p.Substring(pn.Length);
						ret.Add(p2);
					}
				}
			}
			return ret.ToArray();
		}
		// *****************************************************************
		
		public void FindInstalledAE()
		{
			string verStr = "";
			if ((m_TargetVersionIndex>=0)&&(m_TargetVersionIndex < m_InstalledAFX.Length))
			{
				verStr = m_InstalledAFX[m_TargetVersionIndex];
			}


			m_InstalledAFX = FindInstalledAfterFX();
			if (m_InstalledAFX.Length > 0)
			{
				TargetVersionStr = verStr;

			}

		}
		// *****************************************************************
		#region Combine
		static public string CombineAE(string p)
		{
			return TARGET_DIR + "\\" + TARGET_HEAD + " " + p + TARGET_EXE;

		}
		static public string CombineAERENDER(string p)
		{
			return TARGET_DIR + "\\" + TARGET_HEAD + " " + p + TARGET_RENDER;

		}
		static public string[] CombineAE(string[] p)
		{
			string[] ret = new string[p.Length];
			if (p.Length > 0)
			{
				for (int i = 0; i < p.Length; i++)
				{
					ret[i] = CombineAE(p[i]);

				}
			}
			return ret;
		}
		// *****************************************************************
		static public string[] CombineAERENDER(string[] p)
		{
			string[] ret = new string[p.Length];
			if (p.Length > 0)
			{
				for (int i = 0; i < p.Length; i++)
				{
					ret[i] = CombineAERENDER(p[i]);

				}
			}
			return ret;
		}
		#endregion
		// ******************************************************************************
		public AEStutas Run()
		{
			AEStutas ret = AEStutas.None;
			if (m_TargetVersionIndex < 0) return ret;

			try
			{
				string ss = m_InstalledAFX[m_TargetVersionIndex];

				ProcessAE pae;
				AEStutas aes = CheckRun(ss, out pae);

				if (aes == AEStutas.IsRunning)
				{
					ret = AEStutas.IsRunning;
					return ret;
				}
				string exePath = CombineAE(ss);
				if (File.Exists(exePath) == true)
				{
					var app = new ProcessStartInfo();
					app.FileName = exePath;
					app.UseShellExecute = true;
					Process ps = Process.Start(app);
					if (ps != null) ret = AEStutas.IsRunStart;
				}
			}
			catch
			{
				ret = AEStutas.None;
			}
			return ret;
		}
		// ******************************************************************************
		public bool ExecScriptFile(string p)
		{
			bool ret = false;
			if (m_TargetVersionIndex < 0) return ret;

			string tag = m_InstalledAFX[m_TargetVersionIndex];

			ProcessAE pae = new ProcessAE();
			if (CheckRun(tag, out pae) != AEStutas.IsRunning) return ret;

			if (File.Exists(p) == false) return ret;

			string exePath = CombineAE(tag);
			if (File.Exists(exePath) == true)
			{
				var app = new ProcessStartInfo();
				app.FileName = exePath;
				app.Arguments = "-r " + p;
				app.UseShellExecute = true;
				if (pae.IsWS_MAXIMIZE)
				{
					app.WindowStyle = ProcessWindowStyle.Maximized;
				}
				Process ps = Process.Start(app);
				if (pae.Proc != null)
				{
					if (pae.IsWS_MAXIMIZE == true)
					{
						FileInfo fi = new FileInfo(m_AeWin);

						if (fi.Exists == true)
						{
							ProcessStartInfo aeWin = new ProcessStartInfo();
							aeWin.FileName = fi.FullName;
							aeWin.Arguments = String.Format("/max /i{0}", pae.ProcessID);
							aeWin.UseShellExecute = true;
							aeWin.WindowStyle = ProcessWindowStyle.Hidden;
							Process ps2 = Process.Start(aeWin);
						}
					}

				}
				ret = true;

			}
			return ret;

		}
		// ******************************************************************************
		public bool ExecScriptCode(string p)
		{
			bool ret = false;
			if (m_TargetVersionIndex < 0) return ret;

			string tag = m_InstalledAFX[m_TargetVersionIndex];
			ProcessAE pae = new ProcessAE();
			if (CheckRun(tag, out pae) != AEStutas.IsRunning) return ret;

			p = p.Replace("\r", "");
			p = p.Replace("\n", "");
			p = p.Replace("\t", "");

			string exePath = CombineAE(tag);
			if (File.Exists(exePath) == true)
			{
				ProcessStartInfo app = new ProcessStartInfo();
				app.FileName = exePath;
				app.Arguments = "-s \"" + p + "\"";
				app.UseShellExecute = true;
				if (pae.IsWS_MAXIMIZE)
				{
					app.WindowStyle = ProcessWindowStyle.Maximized;
				}
				Process ps = Process.Start(app);


				if (pae.Proc != null)
				{
					if (pae.IsWS_MAXIMIZE == true)
					{

						FileInfo fi = new FileInfo(m_AeWin);
						if (fi.Exists==true)
						{
							ProcessStartInfo aeWin = new ProcessStartInfo();
							aeWin.FileName = fi.FullName;
							aeWin.Arguments = String.Format("/max /i{0}", pae.ProcessID);
							aeWin.UseShellExecute = true;
							aeWin.WindowStyle = ProcessWindowStyle.Hidden;
							Process ps2 = Process.Start(aeWin);
						}
					}

				}
				ret = true;
			}
			return ret;

		}
		// ******************************************************************************
		static public AEStutas CheckRun(string s, out ProcessAE pae)
		{
			AEStutas ret = AEStutas.None;
			ProcessAE[] lst = ProcessAEList();
			pae = new ProcessAE();
			if (lst.Length > 0)
			{
				foreach (ProcessAE p in lst)
				{
					if (p.VersionStr == s)
					{
						ret = AEStutas.IsRunning;
						pae = p;
						break;
					}
				}
			}
			return ret;
		}
		
		// *********************************************************************************
		static public ProcessAE[] ProcessAEList()
		{
			List<ProcessAE> ret = new List<ProcessAE>();
			foreach (Process p in Process.GetProcesses())
			{
				if (p.ProcessName == "AfterFX")
				{
					ProcessAE pae = new ProcessAE(p);
					ret.Add(pae);

				}
			}
			return ret.ToArray();
		}
		// *********************************************************************************
		static public string[] ProcessList()
		{
			ProcessAE[] a = ProcessAEList();
			string[] ret = new string[a.Length];
			if (a.Length > 0)
			{
				for (int i = 0; i < a.Length; i++)
				{
					ret[i] = a[i].ToString();
				}
			}
			return ret;
		}
		// *********************************************************************************
	}
}
