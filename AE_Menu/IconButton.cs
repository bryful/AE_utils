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

namespace AE_Menu
{
	public class IconButton : Control
	{
		public int Index = -1;
		private string m_FileName = "<none>";
		private string m_Caption = "<none>";

		private StringFormat m_sf = new StringFormat();
		private Bitmap m_bitmap = new Bitmap(200,25);

		public bool Active = false;

		public IconButton(string filename, Size sz)
		{
			Init(filename, sz);
		}
		public IconButton()
		{
			Init("",new Size(200, 25));
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
			if ((this.Size != sz)||(IsRef==true))
			{
				this.MinimumSize = new Size(0, 0);
				this.MaximumSize = new Size(0, 0);
				this.Size = sz;
				this.MaximumSize = sz;
				this.MinimumSize = sz;
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
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);
				if (m_Caption != "")
				{
					sb.Color = this.ForeColor;
					Rectangle rct = new Rectangle(5, 0, m_bitmap.Width - 10, m_bitmap.Height);
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

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			CreatePict();
			this.Invalidate();
		}
	}

}
