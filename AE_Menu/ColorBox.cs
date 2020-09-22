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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
namespace AE_Menu
{
	public class ColorBox :Control
	{

		private string m_DispText = "AAAAA";
		public string DispText
		{
			get { return m_DispText; }
			set
			{
				m_DispText = value;
				this.Invalidate();
			}
		}
		// ***************************************************************
		public ColorBox()
		{
			this.ForeColor = Color.White;
			this.BackColor = Color.DarkGray;
			this.Size = new Size(120, 120);

			this.Click += ColorBox_Click;

		}
		public Color TargetColor
		{
			get { return this.BackColor; }
			set
			{
				this.BackColor = value;
				this.Invalidate();
			}
		}
		// ***************************************************************
		private void ColorBox_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = this.BackColor;
			dlg.FullOpen = true;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				this.BackColor = dlg.Color;
				this.Invalidate();
			}
		}

		// ***************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(Color.Black);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			p.Width = 2;
			try
			{
				Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
				sb.Color = this.BackColor;
				g.FillRectangle(sb, r);

				sb.Color = this.ForeColor;
				g.DrawString(m_DispText, this.Font, sb, r, sf);

				r = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
				g.DrawRectangle(p, r);

			}
			finally
			{
				sb.Dispose();
				p.Dispose();
				sf.Dispose();
			}
		}
	}
}
