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
		public event EventHandler InstalledAFXIndexChanged;
		public event EventHandler InstalledAFXChanged;

		public event EventHandler RunningAFXIndexChanged;
		public event EventHandler RunningAFXChanged;


		protected virtual void OnInstalledAFXIndexChanged(EventArgs e)
		{
			if (InstalledAFXIndexChanged != null)
			{
				InstalledAFXIndexChanged(this, e);
			}
		}

		protected virtual void OnInstalledAFXChanged(EventArgs e)
		{
			if (InstalledAFXChanged != null)
			{
				InstalledAFXChanged(this, e);
			}
		}
		protected virtual void OnRunningAFXIndexChanged(EventArgs e)
		{
			if (RunningAFXIndexChanged != null)
			{
				RunningAFXIndexChanged(this, e);
			}
		}
		protected virtual void OnRunningAFXChanged(EventArgs e)
		{
			if (RunningAFXChanged != null)
			{
				RunningAFXChanged(this, e);
			}
		}
		#endregion

		private Timer m_Timer = new Timer();

		#region installed
		private string[] m_InstalledAFX = new string[0];
		public int InstalledCount
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

		private ProcessAE[] m_RunningAFX = new ProcessAE[0];
		public ProcessAE[] RunningAFX
		{
			get { return m_RunningAFX; }
		}
		public string [] RunningAFXStr
		{
			get
			{
				string[] ret = new string[m_RunningAFX.Length];
				if(m_RunningAFX.Length>0)
				{
					for(int i=0; i< m_RunningAFX.Length;i++)
					{
						ret[i] = m_RunningAFX[i].VersionStr;
					}
				}
				return ret;
			}
		}
		public int RunningCount
		{
			get { return m_RunningAFX.Length; }
		}

		public string InstalledAFXStr
		{
			get
			{
				string ret = "";
				if (m_InstalledAFXIndex >= 0)
				{
					ret = m_InstalledAFX[m_InstalledAFXIndex].ToUpper();
				}
				return ret;
			}
			set
			{

				string tag = value.ToUpper().Trim();
				if (m_InstalledAFX.Length > 0)
				{
					int idx = -1;
					for (int i = 0; i < m_InstalledAFX.Length; i++)
					{
						if (tag == m_InstalledAFX[i])
						{
							idx = i;
							break;
						}
					}
					InstalledAFXIndex = idx;
				}
			}
		}

		private int m_InstalledAFXIndex = -1;
		public int InstalledAFXIndex
		{
			get { return m_InstalledAFXIndex; }
			set
			{
				if (value < 0) value = -1;
				if (m_InstalledAFXIndex != value)
				{
					if ((value >= -1) && (value < InstalledCount))
					{
						m_InstalledAFXIndex = value;
						OnInstalledAFXIndexChanged(new EventArgs());
					}
				}
			}
		}
		private int m_RunningAFXIndex = -1;
		public int RunningAFXIndex
		{
			get { return m_RunningAFXIndex; }
			set
			{
				if (value < 0) value = -1;
				if (m_RunningAFXIndex != value)
				{
					if ((value >= -1) && (value < RunningCount))
					{
						m_RunningAFXIndex = value;
						OnRunningAFXIndexChanged(new EventArgs());
					}
				}
			}
		}
		public string AfterFXPath
		{
			get
			{
				string ret = "";
				if (m_InstalledAFXIndex >= 0)
				{
					ret = CombineAE(m_InstalledAFX[m_InstalledAFXIndex]);
				}
				return ret;
			}
		}
		public string AerenderPath
		{
			get
			{
				string ret = "";
				if (m_InstalledAFXIndex >= 0)
				{
					ret = CombineAERENDER(m_InstalledAFX[m_InstalledAFXIndex]);
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
		public NFsAE()
		{
			FindRunningAFX();

			m_Timer.Tick += M_Timer_Tick;
			m_Timer.Interval = 1000 * 15;
			m_Timer.Enabled = true;
		}

		// *****************************************************************
		private void M_Timer_Tick(object sender, EventArgs e)
		{
			FindRunningAFX();
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
				List<string> al = new List<string>();
				string pn = TARGET_DIR + "\\" + TARGET_HEAD + " ";
				foreach (string p in dl)
				{
					string pp = p + TARGET_EXE;
					if (File.Exists(pp) == true)
					{
						string p2 = p.Substring(pn.Length);
						al.Add(p2);
					}
				}
				// 表示のソートを行う
				if(al.Count>0)
				{
					// まずCS関係から
					for(int i=0; i<al.Count; i++)
					{
						if (al[i] == String.Empty) continue;
						if(al[i].IndexOf("CS")==0)
						{
							ret.Add(al[i]);
							al[i] = "";
						}
					}
					// CCを
					for (int i = 0; i < al.Count; i++)
					{
						if (al[i] == String.Empty) continue;
						if (al[i].IndexOf("CC") == 0)
						{
							ret.Add(al[i]);
							al[i] = "";
						}
					}
					// 残り 20**
					for (int i = 0; i < al.Count; i++)
					{
						if (al[i] == String.Empty) continue;
						if (al[i].IndexOf("20") == 0)
						{
							ret.Add(al[i]);
							al[i] = "";
						}
					}
					int cnt = al.Count - 1;
					for (int i= cnt; i>=0;i--)
					{
						if (al[i]==String.Empty)
						{
							al.RemoveAt(i);
						}
					}
					if(al.Count>0)
					{
						for(int i=0; i<al.Count;i++)
						{
							ret.Insert(0, al[i]);
						}
					}

				}


			}
			return ret.ToArray();
		}
		// *****************************************************************
		
		public void FindInstalledAFX()
		{
			string verStr = "";
			if ((m_InstalledAFXIndex>=0)&&(m_InstalledAFXIndex < m_InstalledAFX.Length))
			{
				verStr = m_InstalledAFX[m_InstalledAFXIndex];
			}

			string[] sa = FindInstalledAfterFX();

			bool rf = false;
			if( sa.Length==m_InstalledAFX.Length)
			{
				if (sa.Length > 0)
				{
					for (int i = 0; i < sa.Length; i++)
					{
						if (sa[i] != m_InstalledAFX[i])
						{
							rf = true;
							break;
						}
					}
				}
			}
			else
			{
				rf = true;
			}

			if (rf==true) {
				m_InstalledAFX = sa;
				OnInstalledAFXChanged(new EventArgs());
			}

			if ((m_InstalledAFX.Length > 0)&&(verStr!=""))
			{
				InstalledAFXStr = verStr;

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
			if (m_InstalledAFXIndex < 0) return ret;

			try
			{
				string ss = m_InstalledAFX[m_InstalledAFXIndex];

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
					app.WindowStyle = ProcessWindowStyle.Maximized;
					app.UseShellExecute = true;
					Process ps = Process.Start(app);
					if (ps != null)
					{
						ret = AEStutas.IsRunStart;

						FileInfo fi = new FileInfo(m_AeWin);

						if (fi.Exists == true)
						{
							ProcessStartInfo aeWin = new ProcessStartInfo();
							aeWin.FileName = fi.FullName;
							aeWin.Arguments = String.Format("/max /fore /i{0}", ps.Id);
							aeWin.UseShellExecute = true;
							aeWin.WindowStyle = ProcessWindowStyle.Hidden;
							Process ps2 = Process.Start(aeWin);
						}
					}
				}
			}
			catch
			{
				ret = AEStutas.None;
			}
			return ret;
		}
		// ******************************************************************************
		public Process CallAerender(string aep,string op = "")
		{
			Process ret = null;
			if (m_InstalledAFXIndex < 0) return ret;

			if (File.Exists(aep) == false) return ret;

				string ap = AerenderPath;
			if (File.Exists(ap) == true)
			{
				var app = new ProcessStartInfo();
				app.FileName = ap;

				string ss = "-project \"" + aep + "\"";
				if (op != "")
				{
					ss += op + " ";
				}
				app.Arguments = ss;
				app.UseShellExecute = true;
				ret = Process.Start(app);
			}

			return ret;
		}
		// ******************************************************************************
		public bool ExecScriptFile(string p)
		{
			bool ret = false;
			if (m_InstalledAFXIndex < 0) return ret;

			string tag = m_InstalledAFX[m_InstalledAFXIndex];

			ProcessAE pae = new ProcessAE();
			if (CheckRun(tag, out pae) != AEStutas.IsRunning) return ret;

			if (File.Exists(p) == false) return ret;

			string exePath = CombineAE(tag);
			if (File.Exists(exePath) == true)
			{
				bool IsMax = pae.IsWS_MAXIMIZE;
				var app = new ProcessStartInfo();
				app.FileName = exePath;
				app.Arguments = "-r " + p;
				app.UseShellExecute = true;
				if (IsMax)
				{
					app.WindowStyle = ProcessWindowStyle.Maximized;
				}
				Process ps = Process.Start(app);
				if (pae.Proc != null)
				{
					if (IsMax == true)
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
			if (m_InstalledAFXIndex < 0) return ret;

			string tag = m_InstalledAFX[m_InstalledAFXIndex];
			ProcessAE pae = new ProcessAE();
			if (CheckRun(tag, out pae) != AEStutas.IsRunning) return ret;

			p = p.Replace("\r", "");
			p = p.Replace("\n", "");
			p = p.Replace("\t", "");

			string exePath = CombineAE(tag);
			if (File.Exists(exePath) == true)
			{
				bool IsMax = pae.IsWS_MAXIMIZE;
				ProcessStartInfo app = new ProcessStartInfo();
				app.FileName = exePath;
				app.Arguments = "-s \"" + p + "\"";
				app.UseShellExecute = true;
				if (IsMax)
				{
					app.WindowStyle = ProcessWindowStyle.Maximized;
				}
				Process ps = Process.Start(app);


				if (pae.Proc != null)
				{
					if (IsMax)
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
		public void FindRunningAFX()
		{
			int pcid = 0;
			if(m_RunningAFXIndex>=0)
			{
				pcid = m_RunningAFX[m_RunningAFXIndex].ProcessID;
			}

			ProcessAE[] lst = ProcessAEList();

			bool rf = false;
			if ( m_RunningAFX.Length != lst.Length)
			{
				rf = true;
			}
			else
			{
				if (lst.Length > 0)
				{
					for (int i = 0; i < lst.Length; i++)
					{
						if (lst[i].ProcessID != m_RunningAFX[i].ProcessID)
						{
							rf = true;
							break;
						}
					}
				}
			}
			if(rf==true)
			{
				m_RunningAFX = lst;
				OnRunningAFXChanged(new EventArgs());
				int idx = -1;
				if((pcid>0)&&(m_RunningAFX.Length>0))
				{
					for(int i=0; i< m_RunningAFX.Length; i++)
					{
						if (m_RunningAFX[i].ProcessID == pcid)
						{
							idx = i;
							break;
						}
					}

				}
				if ((idx<0)&&(m_RunningAFX.Length>0))
				{
					idx = m_RunningAFX.Length - 1;
				}
				RunningAFXIndex = idx;
			}
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
