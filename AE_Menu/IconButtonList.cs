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
	


		private bool IsCopy = false;

		Color CFore = Color.White;
		Color CBack = Color.DarkGray;
		Font CFont = null;


		private bool m_RelativePath = false;
		public bool RelativePath
		{
			get { return m_RelativePath; }
			set { m_RelativePath = value; }
		}
		// ************************************************************
		public IconButtonList()
		{
			this.BackColor = Color.FromArgb(64, 64, 64);
			this.ForeColor = Color.White;
			CFont = this.Font;
			CFore = this.ForeColor;
			CBack = this.BackColor;

			Clear();
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
						m_List[i].SetSize(m_ButtonSize,true);
					}
				}
				SizeChk();
			}
		}
		// ************************************************************
		public void Clear()
		{
			if(this.Controls.Count>0)
			{
				for (int i = this.Controls.Count - 1; i >= 0; i--)
				{
					this.Controls[i].Dispose();
				}
				this.Controls.Clear();
			}
			if (m_List.Count>0)
			{
				for(int i= m_List.Count-1; i>=0 ;i--)
				{
					m_List[i].Dispose();

				}
				m_List.Clear();
			}
			m_SelectedIndex = -1;
			m_MenuName = "";
			m_TargetDir = "";
			SizeChk();
			if(m_Form!=null)
			{
				this.Text = "AE_Menu";
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
				m_Form.ClientSize = new Size(this.Width,this.Height);

			}
			this.Invalidate();
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
				ib.CreatePict();
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
		public void SelectDirDialog()
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();

			dlg.Description = "フォルダを指定してください。";

			dlg.RootFolder = Environment.SpecialFolder.MyComputer;
			if ( m_TargetDir!="")
			{
				dlg.SelectedPath = m_TargetDir;
			}

			//ダイアログを表示する
			if (m_Form!=null)
			{
				if (dlg.ShowDialog(m_Form) == DialogResult.OK)
				{
					Listup(dlg.SelectedPath);
				}

			}
			else
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					Listup(dlg.SelectedPath);
				}

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
		// ************************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if(m_Form!=null)
			{
				m_Form.ClientSize = this.Size;

			}
			this.Invalidate();
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
			
			Clear();
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
			SizeChk();
			this.Refresh();

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
		public void ShowAllFontDialog()
		{
			FontDialog dlg = new FontDialog();
			dlg.Font = m_List[0].Font;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				this.Font = dlg.Font;
			}
		}
		// ************************************************************
		protected override void OnFontChanged(EventArgs e)
		{
			if (m_List.Count <= 0) return;
			for(int i=0; i<m_List.Count;i++)
			{
				m_List[i].Font = this.Font;
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
				this.Invalidate();
			}
		}
		// *****************************************************************
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			if (m_List.Count > 0)
			{
				for (int i = 0; i < m_List.Count; i++)
				{
					m_List[i].BackColor = this.BackColor;
				}
				this.Invalidate();
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
		public bool ExportJSXDialog()
		{
			if (m_List.Count <= 0) return false;

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
				return false;
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
				return false;
			}
			return true;
			
		}
	
		// *****************************************************************
		public void AllColorDialog()
		{
			ColorEditDialog dlg = new ColorEditDialog();

			dlg.Fore = this.ForeColor;
			dlg.Back = this.BackColor;

			if (dlg.ShowDialog()==DialogResult.OK)
			{
				this.ForeColor = dlg.Fore;
				this.BackColor = dlg.Back;
				if (m_List.Count>0)
				{
					for(int i=0; i<m_List.Count;i++)
					{
						m_List[i].ForeColor = this.ForeColor;
						m_List[i].BackColor = this.BackColor;
					}
				}
				this.Invalidate();


			}
		}
		// *****************************************************************
		public void CellColorDialog()
		{
			if (m_SelectedIndex < 0) return;
			ColorEditDialog dlg = new ColorEditDialog();

			dlg.Back =  m_List[m_SelectedIndex].BackColor;
			dlg.Fore = m_List[m_SelectedIndex].ForeColor;


			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_List[m_SelectedIndex].SetColor(dlg.Back, dlg.Fore);
			}
		}
		// *****************************************************************
		public void CopyColor()
		{
			if (m_SelectedIndex < 0) return;
			CBack = m_List[m_SelectedIndex].BackColor;
			CFore = m_List[m_SelectedIndex].ForeColor;
			CFont = m_List[m_SelectedIndex].Font;
			IsCopy = true;
		}
		// *****************************************************************
		public void PeasteColor()
		{
			if (m_SelectedIndex < 0) return;
			if (IsCopy == false) return;
			m_List[m_SelectedIndex].BackColor = CBack;
			m_List[m_SelectedIndex].ForeColor = CFore;
			m_List[m_SelectedIndex].Font = CFont;
		}
		// *****************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.Controls.Count <= 0)
			{
				Graphics g = e.Graphics;
				SolidBrush sb = new SolidBrush(this.BackColor);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				Rectangle r = this.ClientRectangle;
				try
				{
					g.FillRectangle(sb, r);
					sb.Color = this.ForeColor;
					g.DrawString("ここへフォルダをD&D", this.Font, sb, r, sf);
				}
				finally
				{
					sb.Dispose();
					sf.Dispose();
				}

			}
		}
	}
}
