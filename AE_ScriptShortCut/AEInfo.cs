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

namespace BRY
{
	
	/// <summary>
	/// インストールされたAEの情報
	/// </summary>
	public class AEInfoItem 
	{
		private string m_Caption = "";
		public string Caption { get { return m_Caption; } }
		private string m_InstailFolder = "";
		/// <summary>
		/// インストールフォルダパス
		/// </summary>
		public string InstailFolder { get { return m_InstailFolder; } }
		public void SetInstailFolder(string p)
		{
			if( Directory.Exists(p))
			{
				m_InstailFolder = p;
				m_Caption = p.Replace(@"C:\Program Files\Adobe\Adobe After Effects ", "");
			}
			else
			{
				m_InstailFolder = "";
				m_Caption = "";
			}
		}
		private bool m_IsCS6 = false;
		/// <summary>
		/// CS6かどうか
		/// </summary>
		public bool IsCS6 { get { return m_IsCS6; } }
		public void SetIsCS6(bool p)
		{
			m_IsCS6 = p;
		}
		private string m_PrefFolder = "";
		public string PrefFolder { get { return m_PrefFolder; } }
		public void SetPrefFolder(string p)
		{
			if (Directory.Exists(p))
			{
				m_PrefFolder = p;
			}
			else
			{
				m_PrefFolder = "";
			}
		}

		/// <summary>
		/// aerenderのパス
		/// </summary>
		public string AerenderPath
		{
			get
			{
				string ret = "";
				if (InstailFolder!="")
				{
					ret = m_InstailFolder + @"\Support Files\aerender.exe"; 
				}
				return ret;
			}
		}
		/// <summary>
		/// Scriptsフォルダ
		/// </summary>
		public string ScriptsFolder
		{
			get
			{
				string ret = "";
				if (InstailFolder != "")
				{
					ret = m_InstailFolder + @"\Support Files\Scripts";
				}
				return ret;
			}
		}
		public string PrefScriptsFolder 
		{
			get 
			{
				if(m_IsCS6==true)
				{
					return "";
				}
				else
				{
					return m_PrefFolder + @"\Scripts";
				}
			} 
		}
		
		public string Info
		{
			get
			{
				string ret = "";
				ret = "***\r\n";
				if (m_Caption != "")
				{
					ret += m_Caption + "\r\n";
					ret += m_InstailFolder + "\r\n";
					ret += String.Format("IsCS6:{0}\r\n", m_IsCS6);
					ret += m_PrefFolder + "\r\n";

					if(m_SctriptsFiles.Length>0)
					{
						for(int i=0; i< m_SctriptsFiles.Length; i++)
						{
							ret += m_SctriptsFiles[i] + "\r\n";
						}
					}

					ret += "---\r\n";
				}
				return ret;
			}
		}

		private string [] m_SctriptsFiles = new string[0];

		public void GetScripts()
		{
			m_SctriptsFiles = new string[0];
			if (m_InstailFolder == "") return;

			string[] lst1 = new string[0];
			string[] lst2 = new string[0];
			lst1 = Directory.GetFiles(m_InstailFolder+ @"\Support Files\Scripts","*.jsx*");
			if (m_IsCS6 == false)
			{
				lst2 = Directory.GetFiles(m_PrefFolder + @"\Scripts", "*.jsx*");
			}

			int cnt = lst1.Length + lst2.Length;
			if (cnt <= 0) return;

			m_SctriptsFiles = new string[cnt];

			for (int i=0; i < lst1.Length; i++) 
			{
				m_SctriptsFiles[i] = Path.GetFileName(lst1[i]); 
			}
			if(lst2.Length>0)
			{
				for (int i = 0; i < lst2.Length; i++)
				{
					m_SctriptsFiles[lst1.Length + i] = Path.GetFileName(lst2[i]);
				}

			}

		}
	}


	public class AEInfo : Component
	{
		private readonly string m_InstailPathBase = @"C:\Program Files\Adobe\Adobe After Effects ";
		private readonly string[] m_InstailPath =
		{
			@"CS6",
			@"CC",
			@"CC 2015",
			@"CC 2017",
			@"CC 2018",
			@"CC 2019",
			@"2020",
			@"2021"

		};
		private readonly string[] m_VerStr =
		{
			@"11",
			@"12",
			@"13",
			@"14",
			@"15",
			@"16",
			@"17",
			@"18"

		};
		private readonly string AfterFXPath = @"\Support Files\AfterFX.exe";
		private readonly string ScriptPath = @"\Support Files\Scripts";
		private readonly string PrefPath = @"\Adobe\After Effects";

		private List<AEInfoItem> m_AEInfoItems = new List<AEInfoItem>();

		private int m_SelectedIndex = -1;
		public int SelectedIndex
		{
			get { return m_SelectedIndex; }
			set
			{
				if(m_AEInfoItems.Count>=value)
				{
					m_SelectedIndex = -1;
				}
				else
				{
					m_SelectedIndex = value;
				}
			}
		}

		// ********************************************************************
		public AEInfo()
		{
			GetInfo();
		}
		// ********************************************************************
		public string Info
		{
			get
			{
				string ret = "";
				if(m_AEInfoItems.Count>0)
				{
					for(int i=0; i< m_AEInfoItems.Count; i++)
					{
						ret += m_AEInfoItems[i].Info;
					}
				}
				return ret;
			}
		}
		public int Count
		{
			get { return m_AEInfoItems.Count; }
		}
		// ********************************************************************
		public string [] Captions
		{
			get
			{
				string[] ret = new string[m_AEInfoItems.Count];
				if(ret.Length>0)
				{
					for ( int i=0; i< ret.Length; i++)
					{
						ret[i] = m_AEInfoItems[i].Caption;
					}
				}
				return ret;
			}
		}
		// ********************************************************************
		private bool IsPrefDirName(string p)
		{
			bool ret = false;

			string n = Path.GetFileName(p);

			if (n.Length < 4)
			{
				return ret;
			}
			ret = true;
			for ( int i=0; i< n.Length; i++)
			{
				char c = n[i];
				if (((c >= '0') && (c <= '9')) || (c == '.'))
				{
					//
				}
				else
				{
					ret = false;
					break;
				}
			}
			return ret;
		}
		// ********************************************************************
		public void GetInfo()
		{
			m_AEInfoItems.Clear();
			// Pref
			string PrefP = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			PrefP = Path.Combine(PrefP, "Adobe");
			PrefP = Path.Combine(PrefP, "After Effects");
			if(Directory.Exists(PrefP) == false) { PrefP = ""; }

			for ( int i=0; i< m_InstailPath.Length; i++)
			{
				string p = m_InstailPathBase + m_InstailPath[i] + AfterFXPath;
				if(File.Exists(p)==true)
				{
					AEInfoItem ai = new AEInfoItem();
					ai.SetInstailFolder(m_InstailPathBase + m_InstailPath[i]);
					ai.SetIsCS6((i == 0));

					//環境設定の入ってるフォルダを探す
					string[] subdir = Directory.GetDirectories(PrefP, m_VerStr[i]+".*", System.IO.SearchOption.TopDirectoryOnly);
					if (subdir.Length>0)
					{
						for(int j= subdir.Length-1;j>=0;j-- )
						{
							if(IsPrefDirName(subdir[j])==true)
							{
								ai.SetPrefFolder(subdir[j]);
								break;
							}
						}
					}
					ai.GetScripts();
					m_AEInfoItems.Add(ai);
				}
			}
		}
		// ********************************************************************
		private ComboBox m_CombInstailedAE = null;
		public ComboBox CombInstailedAE
		{
			get { return m_CombInstailedAE; }
			set
			{
				m_CombInstailedAE = value;
				if(m_CombInstailedAE!=null)
				{
					m_CombInstailedAE.DropDownStyle = ComboBoxStyle.DropDownList;
					m_CombInstailedAE.Items.Clear();
					m_CombInstailedAE.Items.AddRange(Captions);
					m_CombInstailedAE.SelectedIndexChanged += M_CombInstailedAE_SelectedIndexChanged;
				}
			}
		}
		private void M_CombInstailedAE_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedIndex = m_CombInstailedAE.SelectedIndex;
		}
		// ********************************************************************
	}
}
