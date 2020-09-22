using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_Menu
{
	public partial class SizeDialog : Form
	{
		
		private IconButtonList m_IconButtonList = null;
		public SizeDialog()
		{
			InitializeComponent();

			sizeBox1.ValueChanged += SizeBox1_ValueChanged;
		}

		private void SizeBox1_ValueChanged(object sender, EventArgs e)
		{
			if(m_IconButtonList!=null)
			{
				m_IconButtonList.ButtonSize = sizeBox1.Value;
				m_IconButtonList.Refresh();
			}
		}

		public IconButtonList IconButtonList
		{
			get { return m_IconButtonList; }
			set
			{
				m_IconButtonList = value;
				if(m_IconButtonList!=null)
				{
					sizeBox1.Value = m_IconButtonList.ButtonSize;
				}
			}
		}
		public bool Exec(IconButtonList ibl)
		{
			bool ret = false;
			if (ibl == null) return ret;
			Size bs = ibl.ButtonSize;
			this.IconButtonList = ibl;

			if (this.ShowDialog()==DialogResult.OK)
			{
				ibl.ButtonSize = sizeBox1.Value;
				ret = true;
			}
			else
			{
				ibl.ButtonSize = bs;
			}
			return ret;
		}
	}
}
