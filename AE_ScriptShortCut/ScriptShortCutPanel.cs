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

namespace AE_ScriptShortCut
{
	public class ScriptShortCutPanel : Panel
	{
		private readonly int m_RowCount = 20;
		private int m_RowHeigth = 26;
		private int RowMax;
		private ScriptShortCut[] m_lst = new ScriptShortCut[0];
		
		public ScriptShortCutPanel()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);

			this.Size = new Size(600, m_RowHeigth * 10);
			RowMax = m_RowCount * m_RowHeigth;
			m_lst = new ScriptShortCut[m_RowCount];
			for (int i=0; i< m_RowCount; i++)
			{
				m_lst[i] = new ScriptShortCut();
				m_lst[i].Size = new Size(600, 24);
				m_lst[i].Location = new Point(0, i * m_RowHeigth);
				m_lst[i].Index = i + 1;
				this.Controls.Add(m_lst[i]);
			}

		}
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			for (int i = 0; i < m_RowCount; i++)
			{
				m_lst[i].Font = this.Font;
			}
		}
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			if (m_lst.Length >= m_RowCount)
			{
				for (int i = 0; i < m_RowCount; i++)
				{
					m_lst[i].Width = this.ClientSize.Width-10;
				}
			}
		}
	}
}
