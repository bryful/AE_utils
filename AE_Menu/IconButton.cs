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

		private Color m_BackJSX = Color.FromArgb(64, 64, 64);
		private Color m_BackJSXBIN = Color.FromArgb(32,32,32);
		private Color m_BackFFX = Color.FromArgb(90,90,90);
		private Color m_TextColor = Color.FromArgb(255, 255, 255);

		public Color BackJSX
		{
			get { return m_BackJSX; }
			set { m_BackJSX = value; CreatePict();this.Invalidate(); }
		}
		public Color BackJSXBIN
		{
			get { return m_BackJSXBIN; }
			set { m_BackJSXBIN = value; CreatePict(); this.Invalidate(); }
		}
		public Color BackFFX
		{
			get { return m_BackFFX; }
			set { m_BackFFX = value; CreatePict(); this.Invalidate(); }
		}
		public Color TextColor
		{
			get { return m_TextColor; }
			set { m_TextColor = value; CreatePict(); this.Invalidate(); }
		}
		public void SetColors(Color jsx,Color jsxbin, Color ffx)
		{
			m_BackJSX = jsx;
			m_BackJSXBIN = jsxbin;
			m_BackFFX = ffx;
			CreatePict();
			this.Invalidate();
		}

		public IconButton()
		{
			Init("", new Size(240, 20));
			this.ForeColor = Color.White;
			this.Font = new Font(this.Font.Name, 12);

		}
		public void CopyFrom(IconButton b)
		{
			Index = b.Index;
			Active = b.Active;

			m_FileName = b.m_FileName;
			m_Caption = b.m_Caption;
			m_Jsxtype = b.m_Jsxtype;
			m_BackJSX = b.m_BackJSXBIN;
			m_BackJSXBIN = b.m_BackJSXBIN;
			m_BackFFX= b.m_BackFFX;
			m_TextColor = b.m_TextColor;
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
				m_Caption = Path.GetFileName(filename);
			}
			else
			{
				m_FileName = "";
				m_Caption = filename;

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
			if( (this.Width!=m_bitmap.Width)|| (this.Height != m_bitmap.Height)) 
			{
				m_bitmap = new Bitmap(this.Width, this.Height);
			}
			Graphics g = Graphics.FromImage(m_bitmap);
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				switch (m_Jsxtype)
				{
					case JSXTYPE.JSX:
						sb.Color = m_BackJSX;
						break;
					case JSXTYPE.JSXBIN:
						sb.Color = m_BackJSXBIN;
						break;
					case JSXTYPE.FFX:
						sb.Color = m_BackFFX;
						break;

				}
				g.FillRectangle(sb, new Rectangle(-1, -1, this.Width + 2, this.Height + 2));
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
					sb.Color = m_TextColor;
					Rectangle rct = new Rectangle(5, 0, m_bitmap.Width, m_bitmap.Height);
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
			g.DrawImage(m_bitmap, 0, 0);
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
		// ******************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			CreatePict();
			this.Invalidate();
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
					m_Caption = Path.GetFileName(fn);
					CreatePict();
					this.Invalidate();
				}
			}
			return ret;
		}
		// ******************************************************
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
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
				m_Caption = Path.GetFileNameWithoutExtension(s);
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
