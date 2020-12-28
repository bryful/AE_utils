using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Codeplex.Data;

namespace AE_Menu
{
	public enum JSXTYPE
	{
		NONE = 0,
		JSX,
		JSXBIN,
		FFX
	};

	public class IconButton : Control
	{
		private int m_SideWidth = 5;
		public int SideWidth
		{
			get { return m_SideWidth; }
			set
			{
				if(m_SideWidth != value)
				{
					m_SideWidth = value;
					CreatePict();
					this.Invalidate();
				}
			}
		}

		public int Index = -1;
		private string m_FileName = "";
		public string FileName 
		{
			get { return m_FileName; }
			set
			{
				if(m_FileName!=value)
				{
					SetFileName(value);
				}
			}
		}
		private JSXTYPE m_Jsxtype = JSXTYPE.NONE;
		public JSXTYPE Jsxtype
		{
			get { return m_Jsxtype; }
		}

		private string m_Caption = "";
		public string Caption
		{
			get { return m_Caption; }
			set 
			{
				if(m_Caption != value)
				{
					m_Caption = value;
					CreatePict();
					this.Invalidate();
				}
			}
		}
		private StringFormat m_sf = new StringFormat();
		private Bitmap m_bitmap = new Bitmap(240,24);

		public bool Active = false;

		public void SetColor(Color b,Color c)
		{
			this.ForeColor = c;
			this.BackColor = b;
			CreatePict();
			this.Invalidate();
		}

		public IconButton()
		{
			Init("", new Size(240, 20));
			this.ForeColor = Color.White;
			this.BackColor = Color.DarkGray;

		}
		public void CopyFrom(IconButton b)
		{
			Index = b.Index;
			Active = b.Active;

			m_FileName = b.m_FileName;
			m_Caption = b.m_Caption;
			m_Jsxtype = b.m_Jsxtype;
			this.ForeColor = b.ForeColor;
			this.BackColor = b.BackColor;

			this.Font = b.Font;
			this.CreatePict();

		}
		// ******************************************************
		public object ToJson()
		{
			dynamic obj = new DynamicJson();
			//obj["Index"] = Index;
			obj["FileName"] = m_FileName;
			obj["Caption"] = m_Caption;
			obj["ForeColor"] = this.ForeColor.ToArgb();
			obj["BackColor"] = this.BackColor.ToArgb();
			return (object)obj;

		}
		// ******************************************************
		public void FromJson(dynamic obj)
		{
			DynamicJson obj2 = (DynamicJson)obj;
			
			if (obj2.IsDefined("FileName") == true)
			{
				m_FileName = obj.FileName;
			}
			if (obj2.IsDefined("Caption") == true)
			{
				m_Caption = obj.Caption;
			}
			CreatePict();
			this.Invalidate();
		}
		// ******************************************************
		public void Init(string filename,Size sz)
		{
			this.BackColor = Color.White;
			this.ForeColor = Color.Black;
			if (File.Exists(filename))
			{
				m_FileName = filename;
				m_Caption = CaptionStr(Path.GetFileName(filename));
			}
			else
			{
				m_FileName = "";
				m_Caption = "";

			}
			m_sf.Alignment = StringAlignment.Near;
			m_sf.LineAlignment = StringAlignment.Center;

			SetSize(sz,true);
		}
		// ******************************************************
		public void SetSize(Size sz,bool IsRef = false)
		{
			if (this.Size != sz)
			{
				this.MinimumSize = new Size(0, 0);
				this.MaximumSize = new Size(0, 0);
				this.Size = sz;
				this.MaximumSize = sz;
				this.MinimumSize = sz;
			}
			if((IsRef == true)|| (this.Size != sz))
			{
				CreatePict();
				this.Invalidate();
			}
		}
		// ******************************************************
		public void CreatePict()
		{
			if ((this.Width <= m_SideWidth * 2) || (this.Height <= 0)) return;
			int w = this.Width - m_SideWidth * 2;
			int h = this.Height;
			if ( (w!=m_bitmap.Width)|| (w != m_bitmap.Height)) 
			{
				m_bitmap = new Bitmap(w, h);
			}
			Graphics g = Graphics.FromImage(m_bitmap);
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				sb.Color = this.BackColor;
				g.FillRectangle(sb, new Rectangle(-1, -1, w + 2, h + 2));

				if (m_Caption != "")
				{
					SizeF stringSize = g.MeasureString(m_Caption, this.Font, 2000, m_sf);

					float sz = this.Font.Size;
					do
					{
						if (stringSize.Width < m_bitmap.Width) break;
						sz -= 1;
						this.Font = new Font(this.Font.Name, sz);
						stringSize = g.MeasureString(m_Caption, this.Font, 2000, m_sf);
					} while (stringSize.Width > m_bitmap.Width);
					sb.Color = this.ForeColor;
					Rectangle rct = new Rectangle(0, 0, w, h);
					g.DrawString(m_Caption, this.Font, sb, rct, m_sf);
				}

			}
			finally
			{
				sb.Dispose();
			}
		}
		// ******************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);
				g.DrawImage(m_bitmap, m_SideWidth, 0);
				if (Active == true)
				{
					Pen p = new Pen(this.ForeColor);
					try
					{
						Rectangle rct = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
						p.Width = 1;
						g.DrawRectangle(p, rct);

					}
					finally
					{
						p.Dispose();
					}
				}
			}
			finally
			{
				sb.Dispose();
			}




		}
		// ******************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			CreatePict();
			this.Invalidate();
		}
		// ******************************************************
		// ******************************************************
		public string CaptionStr(string s)
		{
			string[] tag = new string[] { "CS6", "CC2020", "CC2021", "CC2022", "CC2023", "CC", "CC2015", "CC2016", "CC2017", "CC2018", "CC2019" };
			s = s.Trim();
			if (s == "") return s;

			int idx = -1;
			int tagIdx = -1;
			string s0 = s.ToUpper();
			for (int i=0; i<tag.Length;i++)
			{
				int idx2 = s0.LastIndexOf(tag[i]);
				if(idx2>=0)
				{
					idx = idx2;
					tagIdx = i;
					break;
				}
			}
			if (idx < 0)
			{
				return s;
			}
			s = s.Replace(tag[tagIdx], "");
			s = s.Replace("__", "_");
			s = s.Replace("--", "-");
			s = s.Replace("  ", " ");
			char c = s[s.Length - 1];
			if ( (c== '_')||(c=='-')|| (c == '.'))
			{
				s = s.Substring(0, s.Length - 1);
			}

			return s;


		}

		// ******************************************************
		public bool ReplaceFilename(string fn)
		{
			bool ret = false;
			if (File.Exists(fn) == true)
			{
				if(m_FileName != fn)
				{
					m_FileName = fn;
					m_Caption = CaptionStr(Path.GetFileName(fn));
					CreatePict();
					this.Invalidate();
				}
			}
			return ret;
		}
		// ******************************************************
		protected override void OnFontChanged(EventArgs e)
		{
			CreatePict();
			this.Invalidate();
		}
		protected override void OnForeColorChanged(EventArgs e)
		{
			CreatePict();
			this.Invalidate();

		}
		protected override void OnBackColorChanged(EventArgs e)
		{
			CreatePict();
			this.Invalidate();
		}
		// ******************************************************
		public bool SetFileName(string s)
		{
			bool ret = false;
			m_FileName = "";
			m_Caption = "";
			m_Jsxtype = JSXTYPE.NONE;
			if (File.Exists(s) == false) return ret;
			string e = Path.GetExtension(s).ToLower();
			if(e==".jsx")
			{
				m_Jsxtype = JSXTYPE.JSX;
			}else if (e== ".jsxbin")
			{
				m_Jsxtype = JSXTYPE.JSXBIN;

			}
			else if (e == ".ffx")
			{
				m_Jsxtype = JSXTYPE.FFX;
			}
			if (m_Jsxtype != JSXTYPE.NONE)
			{
				m_FileName = s;
				m_Caption = CaptionStr(Path.GetFileNameWithoutExtension(s));
				ret = true;
			}
			CreatePict();
			this.Invalidate();
			return ret;
		}
		// ******************************************************
		public void SavePict()
		{
			if (m_FileName=="") return;
			string p = Path.ChangeExtension(m_FileName, ".png");
			m_bitmap.Save(p);
		}
	}

}
