using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfterFXControl
{
	public partial class NavBar : Form
	{
		public enum ModePos
		{
			LEFT,
			TOPLEFT,
			TOPRIGHT,
			RIGHT,
			BOTTOMRIGHT,
			BOTTOMLEFT
		};
		private ModePos m_PosMode = ModePos.LEFT;
		public ModePos PosMode
		{
			get { return m_PosMode; }

			set
			{
				if (m_PosMode != value)
				{
					m_PosMode = value;
					LocSet();
				}
			}
		}
		private Form m_form = null;
		public Form Form
		{
			get { return m_form; }
			set
			{
				m_form = value;
				if (m_form != null)
				{
					this.Text = m_form.Text;
					SizeSet();
					LocSet();
					SetIsFront(m_IsFront);
					m_form.SizeChanged += M_form_SizeChanged;
					m_form.Move += M_form_Move;

				}
			}
		}
		private bool m_IsFront = false;
		public bool IsFront
		{
			get { return m_IsFront; }
			set { SetIsFront(value); }
		}

		public string Caption
		{
			get { return label1.Text; }
			//set { label1.Text = value; }
		}
		private void M_form_Move(object sender, EventArgs e)
		{
			LocSet();
		}

		private void M_form_SizeChanged(object sender, EventArgs e)
		{
			SizeSet();
			LocSet();
		}

		private Point mousePoint;
		
		public NavBar()
		{
			this.Size = new Size(160, 20);
			InitializeComponent();
			SizeSet();
			IsFront = true;
		}
		// *****************************************************************
		public void LocSet()
		{
			if (m_form == null) return;

			switch (m_PosMode)
			{
				case ModePos.LEFT:
					this.Location = new Point(m_form.Left - this.Width, m_form.Top);
					break;
				case ModePos.TOPLEFT:
					this.Location = new Point(m_form.Left, m_form.Top-this.Height);
					break;
				case ModePos.TOPRIGHT:
					this.Location = new Point(m_form.Left+m_form.Width- this.Width, m_form.Top - this.Height);
					break;
				case ModePos.RIGHT:
					this.Location = new Point(m_form.Left + m_form.Width, m_form.Top);
					break;
				case ModePos.BOTTOMRIGHT:
					this.Location = new Point(m_form.Left + m_form.Width - this.Width, m_form.Top + m_form.Height);
					break;
				case ModePos.BOTTOMLEFT:
					this.Location = new Point(m_form.Left, m_form.Top + m_form.Height);
					break;
			}


		}
		// *****************************************************************
		public void SizeSet()
		{
			//if (m_form == null) return;

			this.Size = new Size(160, 20);

		}
		// *****************************************************************
		private void NavBar_MouseDown(object sender, MouseEventArgs e)
		{
			formActive();
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				mousePoint = new Point(e.X, e.Y);
			}
		}

		private void NavBar_MouseMove(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				int xx = e.X - mousePoint.X;
				int yy = e.Y - mousePoint.Y;
				this.Location = new Point(this.Location.X + xx, this.Location.Y + yy);
				if (m_form != null)
				{
					switch (m_PosMode)
					{
						case ModePos.LEFT:
							m_form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
							break;
						case ModePos.TOPLEFT:
							m_form.Location = new Point(this.Location.X, this.Location.Y + this.Height);
							break;
						case ModePos.TOPRIGHT:
							m_form.Location = new Point(this.Location.X - m_form.Width + this.Width, this.Location.Y + this.Height);
							break;
						case ModePos.RIGHT:
							m_form.Location = new Point(this.Location.X - m_form.Width, this.Location.Y);
							break;
						case ModePos.BOTTOMRIGHT:
							m_form.Location = new Point(this.Location.X - m_form.Width + this.Width, this.Location.Y-m_form.Height);
							break;
						case ModePos.BOTTOMLEFT:
							m_form.Location = new Point(this.Location.X , this.Location.Y - m_form.Height);
							break;
					}

				}
			}
		}
		// *****************************************************************
		public void SetIsFront(bool b)
		{
			//if (m_IsFront == b) return;
			m_IsFront = b;
			if (m_IsFront == true)
			{
				formActive();
			}
			else
			{
				if (m_form == null) return;
				m_form.TopMost = false;
			}

		}
		// *****************************************************************
		private void formActive()
		{
			if (m_form == null) return;
			m_form.BringToFront();
			m_form.TopMost = true;
			if (m_IsFront == false)
			{
				m_form.TopMost = false;
			}
		}
		// *****************************************************************
		private void checkBox1_Click(object sender, EventArgs e)
		{
			SetIsFront(checkBox1.Checked);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MenuPosLeft_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.LEFT;
		}

		private void MenuPostRight_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.RIGHT;
		}

		private void MenuPosTopLeft_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.TOPLEFT;

		}

		private void MenuPosTopRight_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.TOPRIGHT;
		}

		private void MenuPostBottomRight_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.BOTTOMRIGHT;
		}

		private void MenuPostBottomLeft_Click(object sender, EventArgs e)
		{
			PosMode = ModePos.BOTTOMLEFT;
		}

		// *****************************************************************
	}
}
