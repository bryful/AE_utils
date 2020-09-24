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

using Codeplex.Data;

namespace AE_Menu
{
	public class SelectedIndexChangedArgs : EventArgs
	{
		public int SelectedIndex = -1;
		public int Count = 0;

	}
	public class IconButtonList : Control
	{
		public delegate void SelectedIndexHangedHandler(object sender, SelectedIndexChangedArgs e);
		public event SelectedIndexHangedHandler SelectedIndexChanged;
		protected virtual void OnSelectedIndex(SelectedIndexChangedArgs e)
		{
			SelectedIndexChanged?.Invoke(this, e);
		}

		private string m_TargetDir = "";
		public string TargetDir
		{
			get { return m_TargetDir; }
			set
			{
				Listup(value);
			}
		}
		private string m_MenuName="";
		public string MenuName
		{
			get { return m_MenuName; }
			set
			{
				m_MenuName = value;
				if(m_Form!=null)
				{
					m_Form.Text = m_MenuName;
				}
			}
		}
		private Size m_ButtonSize = new Size(240, 20);
		public Size ButtonSize
		{
			get { return m_ButtonSize; }
			set
			{
				SetButtonSize(value);
			}
		}
		public int Count { get { return m_List.Count; } }
		private List<IconButton> m_List = new List<IconButton>();
		private int m_SelectedIndex = -1;
		public int SelectedIndex
		{
			get { return m_SelectedIndex; }
			set
			{
				if(m_SelectedIndex!=value)
				{
					if (m_SelectedIndex >= 0)
					{
						m_List[m_SelectedIndex].Active = false;
						m_List[m_SelectedIndex].Invalidate();

					}
					m_SelectedIndex = value;
					m_List[m_SelectedIndex].Active = true;
					m_List[m_SelectedIndex].Invalidate();
					this.Invalidate();
				}
			}
		}
		private Color m_BackJSX = Color.FromArgb(64, 64, 64);
		private Color m_BackJSXBIN = Color.FromArgb(32, 32, 32);
		private Color m_BackFFX = Color.FromArgb(90, 90, 90);
		private Color m_TextColor = Color.FromArgb(255, 255, 255);


		private bool IsCopy = false; 
		private Color CJSX  = Color.FromArgb(64, 64, 64);
		private Color CJSXBIN = Color.FromArgb(32, 32, 32);
		private Color CFFX = Color.FromArgb(32, 32, 32);

		public Color BackJSX
		{
			get { return m_BackJSX; }
			set { m_BackJSX = value;  this.Invalidate(); }
		}
		public Color BackJSXBIN
		{
			get { return m_BackJSXBIN; }
			set { m_BackJSXBIN = value;  this.Invalidate(); }
		}
		public Color BackFFX
		{
			get { return m_BackFFX; }
			set { m_BackFFX = value;  this.Invalidate(); }
		}
		public Color TextColor
		{
			get { return m_TextColor; }
			set { m_TextColor = value; this.Invalidate(); }
		}
		private bool m_RelativePath = false;
		public bool RelativePath
		{
			get { return m_RelativePath; }
			set { m_RelativePath = value; }
		}
		// ************************************************************
		public IconButtonList()
		{
			this.BackColor = Color.DarkKhaki;
			m_List.Clear();
			SizeChk();
		}
		// ************************************************************
		public void SetButtonSize(Size sz)
		{
			if (m_ButtonSize != sz)
			{
				m_ButtonSize = sz;
				if(m_List.Count>0)
				{
					for (int i = 0; i < m_List.Count; i++)
					{
						m_List[i].SetSize(m_ButtonSize);
					}
				}
				SizeChk();
			}
		}
		// ************************************************************
		public void SizeChk()
		{
			int cnt = m_List.Count;
			if (cnt <= 0) cnt = 1;
			Size nSz = new Size(m_ButtonSize.Width, m_ButtonSize.Height* cnt);
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = nSz;
			this.MinimumSize = nSz;
			this.MaximumSize = nSz;
			if (m_List.Count > 0)
			{
				for (int i = 0; i < m_List.Count; i++)
				{
					m_List[i].Location = new Point(0, i * m_ButtonSize.Height);
				}
			}
			if (m_Form != null)
			{
				m_Form.ClientSize = new Size(this.Width+ 5,this.Height);

			}
		}
		// ************************************************************
		public int FindScript(string filename)
		{
			int ret = -1;
			if (m_List.Count>0)
			{
				for (int i = 0; i < m_List.Count; i++)
				{
					if (m_List[i].FileName == filename)
					{
						ret = i;
						break;
					} 
				}
			}
			return ret;
		}
		// ************************************************************
		public bool AddFile(string filename)
		{
			bool ret = false;
			int idx = FindScript(filename);
			if (idx >= 0) return ret;
			IconButton ib = new IconButton();
			ib.FileName = filename;
			if(ib.Jsxtype!=JSXTYPE.NONE)
			{
				int cnt = m_List.Count;
				ib.SetSize(m_ButtonSize);
				ib.Location = new Point(0, cnt * m_ButtonSize.Height);
				ib.Index = cnt;
				ib.ForeColor = this.ForeColor;
				ib.BackColor = this.BackColor;
				ib.BackJSX = m_BackJSX;
				ib.BackJSXBIN = m_BackJSXBIN;
				ib.BackFFX = m_BackFFX;
				ib.TextColor = m_TextColor;

				ib.MouseClick += Ib_MouseClick;
				m_List.Add(ib);
				this.Controls.Add(ib);
				SizeChk();
				ret = true;
			}
			return ret;
		}

		private void Ib_MouseClick(object sender, MouseEventArgs e)
		{
			int idx = ((IconButton)sender).Index;
			//MessageBox.Show(string.Format("idx{0}", idx));
			if (m_SelectedIndex >= 0)
			{
				m_List[m_SelectedIndex].Active = false;
				m_List[m_SelectedIndex].Invalidate();

			}
			m_SelectedIndex = idx;
			if (m_SelectedIndex >= 0)
			{
				m_List[m_SelectedIndex].Active = true;
				m_List[m_SelectedIndex].Invalidate();
			}


			SelectedIndexChangedArgs r = new SelectedIndexChangedArgs();
			r.SelectedIndex = m_SelectedIndex;
			r.Count = m_List.Count;
			OnSelectedIndex(r);


			this.Invalidate();
		}

		// ************************************************************
		public void AddFileDialog()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				AddFile(dlg.FileName);

			}
		}



		

		// ************************************************************
		public void ReplaceFile(int idx, string filename)
		{
			if((idx>=0)&&(idx<m_List.Count))
			{
				m_List[idx].ReplaceFilename(filename);
			}
		}
		// ************************************************************
		private Form m_Form = null;
		public Form Form
		{
			get { return m_Form; }
			set
			{
				m_Form = value;
				if (m_Form!=null)
				{
					this.Location = new Point(0, 0);
					m_Form.ClientSize = this.Size;
					m_Form.WindowState = FormWindowState.Normal;
					m_Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
					m_Form.Text = m_MenuName;

				}
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if(m_Form!=null)
			{
				m_Form.ClientSize = this.Size;

			}
		}

		// ************************************************************
		public bool SaveFile(string p)
		{
			bool ret = false;
			dynamic obj = new DynamicJson();
			double[] sz = new double[2];
			sz[0] = (double)m_ButtonSize.Width;
			sz[1] = (double)m_ButtonSize.Height;
			obj["ButtonSize"] = sz;

			var dat = new object[m_List.Count];
			if(m_List.Count>0)
			{
				for (int i = 0; i < m_List.Count; i++) 
				{
					dat[i] = m_List[i].ToJson();
				}
				obj["kk"] = m_List[0].ToJson();
			}
			obj["List"] = dat;

			try
			{
				string js = obj.ToString();
				File.WriteAllText(p, js, Encoding.GetEncoding("utf-8"));
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public void BackupStore()
		{
			string appName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			string p = Path.Combine(Application.UserAppDataPath, appName + "_def.json");
			SaveFile(p);

		}
		// ************************************************************
		public bool Listup(string s)
		{
			bool ret = false;
			m_TargetDir = "";
			m_List.Clear();
			if (Directory.Exists(s) == false) return ret;

			string[] fl = Directory.GetFiles(s, "*.*");
			if(fl.Length>0)
			{
				for(int i=0; i<fl.Length;i++)
				{
					if(AddFile(fl[i])==true)
					{
					}
				}
			}
			ret = (m_List.Count > 0);
			if(ret==true)
			{
				m_TargetDir = s;
				m_MenuName = Path.GetFileNameWithoutExtension(s);
				if(m_MenuName.Length>=2)
				{
					if ((m_MenuName[0]=='(')&& (m_MenuName[m_MenuName.Length-1] == ')'))
					{
						m_MenuName = m_MenuName.Substring(1, m_MenuName.Length - 2);
					}
				}
				if(m_Form!=null)
				{
					m_Form.Text = m_MenuName;
				}
			}
			return ret;
		}
		// ************************************************************
		public void ShowFontDialog()
		{
			if (m_SelectedIndex < 0) return;
			FontDialog dlg = new FontDialog();
			dlg.Font = m_List[m_SelectedIndex].Font;
			if( dlg.ShowDialog() ==DialogResult.OK)
			{
				m_List[m_SelectedIndex].Font = dlg.Font;
			}
		}
		// ************************************************************
		public void ShowCaptionDialog()
		{
			if (m_SelectedIndex < 0) return;
			TextDialog dlg = new TextDialog();
			dlg.InitCaption();
			dlg.Value = m_List[m_SelectedIndex].Caption;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_List[m_SelectedIndex].Caption = dlg.Value;
			}
		}
		// ************************************************************
		public void ShowTitleDialog()
		{
			if (m_List.Count <= 0) return;
			TextDialog dlg = new TextDialog();
			dlg.InitTitle();
			dlg.Value = m_MenuName;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_MenuName = dlg.Value;
				if(m_Form!=null)
				{
					m_Form.Text = m_MenuName;
				}
			}
		}
		// *****************************************************************
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			if(m_List.Count>0)
			{
				for(int i=0;i< m_List.Count;i++)
				{
					m_List[i].ForeColor = this.ForeColor;
				}
			}
		}
		// *****************************************************************
		public void ExportPict()
		{
			if(m_List.Count>0)
			{
				for(int i=0; i<m_List.Count;i++)
				{
					m_List[i].SavePict();
				}
			}
		}
		// *****************************************************************
		public void ItemUp()
		{
			if (m_SelectedIndex < 0) return;
			if (m_SelectedIndex>0)
			{
				IconButton tmp = new IconButton();
				tmp.CopyFrom(m_List[m_SelectedIndex]);
				m_List[m_SelectedIndex].CopyFrom(m_List[m_SelectedIndex-1]);
				m_List[m_SelectedIndex].Index += 1;
				m_List[m_SelectedIndex-1].CopyFrom(tmp);
				m_List[m_SelectedIndex - 1].Index -= 1;
				m_SelectedIndex -= 1;
				this.Invalidate();
			}
		}
		// *****************************************************************
		public void ItemDown()
		{
			if (m_SelectedIndex < 0) return;
			if (m_SelectedIndex < m_List.Count-1)
			{
				IconButton tmp = new IconButton();
				tmp.CopyFrom(m_List[m_SelectedIndex]);
				m_List[m_SelectedIndex].CopyFrom(m_List[m_SelectedIndex + 1]);
				m_List[m_SelectedIndex].Index -= 1;
				m_List[m_SelectedIndex + 1].CopyFrom(tmp);
				m_List[m_SelectedIndex + 1].Index += 1;
				m_SelectedIndex += 1;
				this.Invalidate();
			}
		}
		// *****************************************************************
		private string ToJsPath(string s)
		{
			string ret = "";
			DirectoryInfo di = new DirectoryInfo(s);
			string ss = di.FullName;
			if(ss[1]==':')
			{
				ss = ss.Replace("\\", "/");
				// C:\aaa\bbbb
				ret = "/";
				ret += ss.Substring(0, 1).ToLower();
				ret += ss.Substring(2);

			}
			return ret;
		}
		// *****************************************************************
		public void ChkJsxTemplate()
		{
			string p = Path.ChangeExtension(Application.ExecutablePath, ".jsx");

			if (File.Exists(p) == false)
			{
				string jsx = Properties.Resources.JSX;
				try
				{
					File.WriteAllText(p, jsx, Encoding.GetEncoding("utf-8"));
				}
				catch
				{
				}
			}
		}
		// *****************************************************************
		public string LoadJsxTemplate()
		{
			string ret = "";
			string p = Path.ChangeExtension(Application.ExecutablePath, ".jsx");

			if (File.Exists(p) == true)
			{
				try
				{
					ret = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
				}
				catch
				{
					ret = Properties.Resources.JSX;
				}
			}
			else
			{
				ret = Properties.Resources.JSX;
				ChkJsxTemplate();
			}
			return ret;
		}
		// *****************************************************************
		public void ExportJSX()
		{
			if (m_List.Count <= 0) return;

			string p = Path.Combine(Path.GetDirectoryName(m_TargetDir), m_MenuName + ".jsx");

			ExportDialog dlg = new ExportDialog();
			dlg.ExportPath = p;
			dlg.RelativePath = m_RelativePath;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				p = dlg.ExportPath;
				m_RelativePath = dlg.RelativePath;
			}
			else
			{
				return;
			}

			string jsx = LoadJsxTemplate();

			jsx = jsx.Replace("$Title", m_MenuName);
			if (m_RelativePath == true)
			{
				jsx = jsx.Replace("$BaseFolder", "./" + Path.GetFileName(m_TargetDir));
			}
			else
			{
				jsx = jsx.Replace("$BaseFolder", ToJsPath(m_TargetDir));
			}
			string items = "";
			for(int i=0;i < m_List.Count; i++)
			{
				if (items != "") items += ",\r\n";
				items += "\"" + Path.GetFileName(m_List[i].FileName) +"\"";
			}
			items += "\r\n";
			jsx = jsx.Replace("$Items", items);
			jsx = jsx.Replace("$IconWidth", string.Format("{0}",m_ButtonSize.Width));
			jsx = jsx.Replace("$IconHeight", string.Format("{0}", m_ButtonSize.Height));

			try
			{
				File.WriteAllText(p, jsx, Encoding.GetEncoding("utf-8"));
			}
			catch
			{
			}
			
		}
		// *****************************************************************
		public void AllColorDialog()
		{
			ColorEditDialog dlg = new ColorEditDialog();

			dlg.BackJsx = m_BackJSX;
			dlg.BackJsxbin = m_BackJSXBIN;
			dlg.BackFfx = m_BackFFX;


			if (dlg.ShowDialog()==DialogResult.OK)
			{
				m_BackJSX = dlg.BackJsx;
				m_BackJSXBIN = dlg.BackJsxbin;
				m_BackFFX = dlg.BackFfx;

				if(m_List.Count>0)
				{
					for(int i=0; i<m_List.Count;i++)
					{
						m_List[i].SetColors(m_BackJSX, m_BackJSXBIN, m_BackFFX);
					}
				}

			}
		}
		// *****************************************************************
		public void CellColorDialog()
		{
			if (m_SelectedIndex < 0) return;
			ColorEditDialog dlg = new ColorEditDialog();

			dlg.BackJsx =  m_List[m_SelectedIndex].BackJSX;
			dlg.BackJsxbin = m_List[m_SelectedIndex].BackJSXBIN;
			dlg.BackFfx = m_List[m_SelectedIndex].BackFFX;


			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_List[m_SelectedIndex].SetColors(dlg.BackJsx, dlg.BackJsxbin, dlg.BackFfx);
			}
		}
		// *****************************************************************
		public void CopyColor()
		{
			if (m_SelectedIndex < 0) return;
			CJSX = m_List[m_SelectedIndex].BackJSX;
			CJSXBIN = m_List[m_SelectedIndex].BackJSXBIN;
			CFFX = m_List[m_SelectedIndex].BackFFX;
			IsCopy = true;
		}
		// *****************************************************************
		public void PeasteColor()
		{
			if (m_SelectedIndex < 0) return;
			if (IsCopy == false) return;
			m_List[m_SelectedIndex].BackJSX = CJSX;
			m_List[m_SelectedIndex].BackJSXBIN = CJSXBIN;
			m_List[m_SelectedIndex].BackFFX = CFFX;
		}
	}
}
