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
	public class SizeBox :Control
	{
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}

		public Size Value
		{
			get { return ValueCalc(); }
			set { SetValue(value); }
		}
		private Label m_WLb = new Label();
		private NumericUpDown m_WNum = new NumericUpDown();
		private Label m_HLb = new Label();
		private NumericUpDown m_HNum = new NumericUpDown();
		public SizeBox()
		{
			this.Size = new Size(150, 50);
			this.MaximumSize = new Size(1000, 50);
			this.MinimumSize = new Size(70, 50);

			m_WLb.Text = "Width:";
			m_WLb.AutoSize = false;
			m_WLb.TextAlign = ContentAlignment.MiddleRight;
			m_WLb.Size = new Size(50, 25);
			m_WLb.Location = new Point(0, 0);

			m_WNum.Maximum = 1000;
			m_WNum.Minimum = 10;
			m_WNum.Value = 200;
			m_WNum.AutoSize = false;
			m_WNum.Size = new Size(100, 25);
			m_WNum.Location = new Point(50, 0);

			m_HLb.Text = "Height:";
			m_HLb.AutoSize = false;
			m_HLb.TextAlign = ContentAlignment.MiddleRight;
			m_HLb.Size = new Size(50, 25);
			m_HLb.Location = new Point(0, 25);

			m_HNum.Maximum = 1000;
			m_HNum.Minimum = 10;
			m_HNum.Value = 25;
			m_HNum.AutoSize = false;
			m_HNum.Size = new Size(100, 25);
			m_HNum.Location = new Point(50, 25);



			this.Controls.Add(m_WLb);
			this.Controls.Add(m_WNum);
			this.Controls.Add(m_HLb);
			this.Controls.Add(m_HNum);

			m_WNum.ValueChanged += M_WNum_ValueChanged;
			m_HNum.ValueChanged += M_WNum_ValueChanged;

		}

		// *******************************************************
		private void M_WNum_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}

		// *******************************************************
		private Size ValueCalc()
		{
			return new Size((int)m_WNum.Value, (int)m_HNum.Value);
		}
		// *******************************************************
		public void SetValue(Size sz)
		{
			if ((int)m_WNum.Value != sz.Width)
			{
				m_WNum.Value = (decimal)sz.Width;
			}
			if ((int)m_HNum.Value != sz.Height)
			{
				m_HNum.Value = (decimal)sz.Height;
			}

		}
		// *******************************************************
		public int CaptionWidth
		{
			get { return m_WLb.Width; }
			set
			{
				int w1 = value;
				if (m_WLb.Width!=w1)
				{
					m_WLb.Width = w1;
					m_HLb.Width = w1;
					int w = this.Size.Width - w1;
					m_WNum.Width = w;
					m_HNum.Width = w;
					m_WNum.Left = w1;
					m_HNum.Left = w1;
				}
			}
		}
		// *******************************************************
		protected override void OnResize(EventArgs e)
		{
			//base.OnResize(e);

			int w = this.Size.Width - m_WLb.Width;
			m_WNum.Width = w;
			m_HNum.Width = w;
		}
		// *******************************************************
	}
}
