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
	public class IconButtonList : Control
	{
		private Size m_ButtonSize = new Size(150, 25);
		public int Count { get { return m_List.Count; } }
		private List<IconButton> m_List = new List<IconButton>();
		private int m_SelectedIndex = -1;
		// ************************************************************
		public IconButtonList()
		{
			AddFile("AA");
			AddFile("BB");
			//SizeChk();
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
				m_Form.ClientSize = this.Size;

			}
		}
		// ************************************************************
		
		// ************************************************************
		public void AddFile(string filename)
		{
			m_List.Add(new IconButton(filename, m_ButtonSize));
			int cnt = m_List.Count;
			m_List[cnt - 1].SetSize(m_ButtonSize);
			m_List[cnt - 1].Location = new Point(0, (cnt-1) * m_ButtonSize.Height);
			m_List[cnt - 1].Index = cnt - 1;
			m_List[cnt - 1].MouseHover += IconButtonList_MouseHover;

			this.Controls.Add(m_List[cnt - 1]);
			SizeChk();
		}


		private void IconButtonList_MouseHover(object sender, EventArgs e)
		{
			int idx = ((IconButton)sender).Index;
			if (m_SelectedIndex >= 0)
			{
				m_List[m_SelectedIndex].Active = false;
				m_List[m_SelectedIndex].Invalidate();

			}
			m_SelectedIndex = idx;
			m_List[m_SelectedIndex].Active = true;
			m_List[m_SelectedIndex].Invalidate();

			this.Invalidate();
		}

		// ************************************************************
		private void IconButtonList_MouseClick(object sender, MouseEventArgs e)
		{
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
					m_Form.ClientSize = this.Size;


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
		
	}
}
