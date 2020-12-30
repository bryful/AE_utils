using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace BRY
{
    public class ProcessAE
	{
        public string VersionID;
        public string ProjectName;
        public string FileName;
        public bool IsWS_MAXIMIZE;
        public IntPtr WindowHandle;
        public Process proc = null;
        public ProcessAE()
		{
            VersionID = "";
            ProjectName = "";
            FileName = "";
            IsWS_MAXIMIZE = false;
            WindowHandle = (IntPtr)0;


        }
        public ProcessAE(string vid, string pn,string fn)
		{
            VersionID = vid;
            ProjectName = pn;
            FileName = "";
            WindowHandle = (IntPtr)0;
        }
        public override string ToString()
		{
            return String.Format("Version:\"{0}\" Priject:\"{1}\" FileName:\"{2}\" MAX:{3}", 
                VersionID, 
                ProjectName, 
                FileName,
                IsWS_MAXIMIZE);
        }
        public string aerender
		{
			get
			{
                string n = Path.GetDirectoryName(FileName);
                return Path.Combine(n, "aerender.exe");
			}
		}

    }
    public enum AEStutas
	{
        None,
        IsRunning,
        IsRunStart
	}

    public class NFsAE :Component
    {

        public event EventHandler TargetAEIndexChanged;

        protected virtual void OnTargetAEIndexChanged(EventArgs e)
        {
            if (TargetAEIndexChanged != null)
            {
                TargetAEIndexChanged(this, e);
            }
        }

        static private readonly string TARGET_DIR = @"C:\Program Files\Adobe";
        static private readonly string TARGET_HEAD = @"Adobe After Effects";
        static private readonly string TARGET_EXE = @"\Support Files\AfterFX.exe";
        static private readonly string TARGET_RENDER = @"\Support Files\aerender.exe";

		#region installed
		private string[] m_InstalledAFX = new string[0];
        public int InstallCount
		{
			get { return m_InstalledAFX.Length; }
		}
        public string[] InstalledAFX()
        {
            return m_InstalledAFX;
        }
        #endregion


        public string TargetAE
		{
			get
			{
                string ret = "";
                if (m_TargetAEIndex>=0)
				{
                    ret = m_InstalledAFX[m_TargetAEIndex];
				}
                return ret;
			}
            set
			{

                string tag = value.ToUpper().Trim();
                if(m_InstalledAFX.Length>0)
				{
                    for (int i=0; i< m_InstalledAFX.Length; i++)
					{
                        if (tag == m_InstalledAFX[i])
						{
                            TargetAEIndex = i;
                            break;
						}
					}
				}
			}
		}

        private int m_TargetAEIndex = -1;
        public int TargetAEIndex
		{
            get { return m_TargetAEIndex; }
			set
			{
                if(m_TargetAEIndex != value)
				{
                    m_TargetAEIndex = value;
                    if(m_CombTargetAE!=null)
					{
                       if( m_CombTargetAE.SelectedIndex != m_TargetAEIndex)
						{
                            m_CombTargetAE.SelectedIndex = m_TargetAEIndex;
                        }

                    }
                    OnTargetAEIndexChanged(new EventArgs());
                }
            }
        }

        public string AEPath
		{
			get
			{
                string ret = "";
                if(m_TargetAEIndex>=0)
				{
                    ret = CombineAE(m_InstalledAFX[m_TargetAEIndex]);
                }
                return ret;
			}
		}
        public string AerenderPath
        {
            get
            {
                string ret = "";
                if (m_TargetAEIndex >= 0)
                {
                    ret = CombineAERENDER( m_InstalledAFX[m_TargetAEIndex]);
                }
                return ret;
            }
        }
       


        #region CombTargeAE
        private ComboBox m_CombTargetAE = null;
        public ComboBox CombTargetAE
		{
            get { return m_CombTargetAE; }
            set
			{
                m_CombTargetAE = value;
                if(m_CombTargetAE!=null)
				{
                    m_CombTargetAE.DropDownStyle = ComboBoxStyle.DropDownList;
                    m_CombTargetAE.Items.Clear();
                    if(m_InstalledAFX.Length>0)
					{
                        m_CombTargetAE.Items.Clear();
                        m_CombTargetAE.Items.AddRange(m_InstalledAFX);
                        if ((m_TargetAEIndex >= 0) && (m_TargetAEIndex < m_CombTargetAE.Items.Count))
                        {
                            m_CombTargetAE.SelectedIndex = m_TargetAEIndex;
                        }
						m_CombTargetAE.SelectedIndexChanged += M_CombTargetAE_SelectedIndexChanged;
                    }
                }
			}
		}

		private void M_CombTargetAE_SelectedIndexChanged(object sender, EventArgs e)
		{
            ComboBox cmb = (ComboBox)sender;
            int idx = cmb.SelectedIndex;
            if ((idx >= 0) && (idx < m_InstalledAFX.Length))
            {
                if (TargetAEIndex != idx)
                {
                    TargetAEIndex = idx;
                }
            }
		}
		#endregion

		public NFsAE()
        {
            FindAE();
        }
        /// <summary>
        /// インストールされているAfter Effects
        /// </summary>
        /// <returns>インストールされているフォルダの文字列配列</returns>
        static public string[] FindAfterFX()
        {
            List<string> ret = new List<string>();

            string [] dl = Directory.GetDirectories(TARGET_DIR, TARGET_HEAD+ "*", SearchOption.TopDirectoryOnly);

            if (dl.Length > 0)
            {
                string pn = TARGET_DIR + "\\" + TARGET_HEAD + " ";
                foreach (string p in dl)
                {
                    string pp = p + TARGET_EXE; 
                    if (File.Exists(pp)==true)
                    {
                        string p2 = p.Substring(pn.Length);
                        ret.Add(p2);
                    }
                }
            }
             return ret.ToArray();
        }
        public void FindAE()
		{
            m_InstalledAFX = FindAfterFX();
            if(m_InstalledAFX.Length>0)
			{
                if((m_TargetAEIndex>=0)&&(m_TargetAEIndex>= m_InstalledAFX.Length))
				{
                    m_TargetAEIndex = -1;
                }

            }

            if (m_CombTargetAE!=null)
			{
                m_CombTargetAE.Items.Clear();
                m_CombTargetAE.Items.AddRange(m_InstalledAFX);
                m_CombTargetAE.SelectedIndex = m_TargetAEIndex;
            }

        }
 
		#region Combine
		static public string CombineAE(string p)
		{
            return TARGET_DIR +"\\"+ TARGET_HEAD + " "  + p + TARGET_EXE;

        }
        static public string CombineAERENDER(string p)
        {
            return TARGET_DIR + "\\" + TARGET_HEAD + " " + p + TARGET_RENDER;

        }
        static public string [] CombineAE(string [] p)
        {
            string[] ret = new string[p.Length];
            if(p.Length>0)
			{
                for(int i=0; i<p.Length;i++ )
				{
                    ret[i] = CombineAE(p[i]);

                }
			}
            return ret;
        }
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
            if (m_TargetAEIndex < 0) return ret;

            try
            {
                string ss = m_InstalledAFX[m_TargetAEIndex];

                ProcessAE pae;
                AEStutas aes = CheckRun(ss,out pae);

                if(aes == AEStutas.IsRunning)
				{
                    ret = AEStutas.IsRunning;
                    return ret;
				}
                string exePath = CombineAE(ss);
                if (File.Exists(exePath) == true)
                {
                    var app = new ProcessStartInfo();
                    app.FileName = exePath;
                    //app.Arguments = "memo.txt";
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
            if (m_TargetAEIndex < 0) return ret;

            string tag = m_InstalledAFX[m_TargetAEIndex];

            ProcessAE pae = new ProcessAE();
            if (CheckRun(tag, out pae) !=AEStutas.IsRunning) return ret;

            if (File.Exists(p) == false) return ret;

            string exePath = CombineAE(tag);
            if (File.Exists(exePath) == true)
            {
                var app = new ProcessStartInfo();
                app.FileName = exePath;
                app.Arguments = "-r " + p;
                app.UseShellExecute = true;
                Process ps = Process.Start(app);
                ret = true;

            }
            return ret;

		}
        // ******************************************************************************
        public bool ExecScriptCode(string p)
        {
            bool ret = false;
            if (m_TargetAEIndex < 0) return ret;

            string tag = m_InstalledAFX[m_TargetAEIndex];
            ProcessAE pae = new ProcessAE();
            if (CheckRun(tag,out pae) != AEStutas.IsRunning) return ret;

            p = p.Replace("\r", "");
            p = p.Replace("\n", "");
            p = p.Replace("\t", "");

            string exePath = CombineAE(tag);
            if (File.Exists(exePath) == true)
            {
                var app = new ProcessStartInfo();
                app.FileName = exePath;
                app.Arguments = "-s \"" + p +"\"";
                app.UseShellExecute = true;
                Process ps = Process.Start(app);

                if(pae.proc != null)
				{
                    if (pae.IsWS_MAXIMIZE == true)
                    {
                        pae.proc.WaitForInputIdle();
                        ShowWindow(pae.proc.MainWindowHandle, 3);
                        SetForegroundWindow(pae.proc.MainWindowHandle);
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
                    if ( p.VersionID == s)
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
        /// <summary>
        /// 実行ファイルのフルパスから、バージョンを調べる
        /// </summary>
        /// <param name="p"></param>
        /// <returns>"CS6" or "CC" or "CC 2019" or "2020"</returns>
        static private string VersionFromFileName(string p)
		{
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
        // *********************************************************************************
        static private ProcessAE ProjectNameFromTitle(string p)
		{
            ProcessAE ret =new ProcessAE();

            string header = "Adobe After Effects";

            if (p.IndexOf(header) != 0) return ret;
            if (p.ToLower().IndexOf(".aep") < 0) return ret;
            p = p.Substring(header.Length);

            int idx = p.IndexOf("-");
			if (idx >= 0)
			{
                ret.VersionID = p.Substring(0, idx - 1).Trim();
                ret.ProjectName = p.Substring(idx + 1).Trim();
            }

            return ret;
		}
        // *********************************************************************************
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        /*
        [DllImport("user32.dll", SetLastError = true)]
        static extern long SetWindowLongA(IntPtr hWnd, int nIndex, long dwNewLong);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint flags);



		[StructLayout(LayoutKind.Sequential)]
		private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
        */

        static public ProcessAE [] ProcessAEList()
		{
            List<ProcessAE> ret = new List<ProcessAE>();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName=="AfterFX")
				{
                    ProcessAE pae = new ProcessAE();
                    try
                    {
                        ProcessAE nm = ProjectNameFromTitle(p.MainWindowTitle);
                        pae.ProjectName = nm.ProjectName;
                        pae.FileName = p.MainModule.FileName;
                        pae.VersionID = VersionFromFileName(pae.FileName);
                        pae.WindowHandle = p.MainWindowHandle;
                        pae.proc = p;

                        int style = GetWindowLong(p.MainWindowHandle, -16);
                        pae.IsWS_MAXIMIZE = ((style & 0x01000000) == 0x01000000);
                    }
                    catch
					{
					}
                   

                    ret.Add(pae);

                }
            }
            return ret.ToArray();
        }
        static public string [] ProcessList()
        {
            ProcessAE[] a = ProcessAEList();
            string[] ret = new string[a.Length];
            if(a.Length>0)
			{
                for(int i = 0; i< a.Length; i++)
				{
                    ret[i] = a[i].ToString();
				}
			}
            foreach (ProcessAE p in a)
            {
            }
            return ret;
        }
        // *************************************************************************************

        
    }
}
