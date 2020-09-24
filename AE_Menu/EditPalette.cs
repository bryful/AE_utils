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
	public partial class EditPalette : Form
	{
		//private int m_SelectedIndex = -1;
		//private int m_Count = 0;

		private IconButtonList m_IconButonList = null;
		public IconButtonList IconButonList
		{
			get { return m_IconButonList; }
			set
			{
				m_IconButonList = value;
				if(m_IconButonList!=null)
				{
					m_IconButonList.SelectedIndexChanged += M_IconButonList_SelectedIndexChanged;
					EnabledChk();

				}
			}
		}

		private void M_IconButonList_SelectedIndexChanged(object sender, SelectedIndexChangedArgs e)
		{

			EnabledChk();
		}
		public void EnabledChk()
		{
			if (m_IconButonList == null) return;
			if(m_IconButonList .Count<= 0)
			{
				btnUp.Enabled = false;
				btnDown.Enabled = false;
				btnEditCaption.Enabled = false;
				btnFont.Enabled = false;
				btnCellColor.Enabled = false;
			}
			else
			{
				btnUp.Enabled = (m_IconButonList.SelectedIndex > 0);
				btnDown.Enabled = ((m_IconButonList.SelectedIndex >= 0)&&(m_IconButonList.SelectedIndex < m_IconButonList.Count - 1));
				btnEditCaption.Enabled = (m_IconButonList.SelectedIndex >= 0);
				btnFont.Enabled = (m_IconButonList.SelectedIndex >= 0);
				btnCellColor.Enabled = (m_IconButonList.SelectedIndex >= 0);

			}
		}

		public EditPalette()
		{
			InitializeComponent();
			EnabledChk();
			btnDown.Click += BtnDown_Click;
			btnUp.Click += BtnUp_Click;
			btnEditCaption.Click += BtnEditCaption_Click;
			btnFont.Click += BtnFont_Click;
			btnCellColor.Click += BtnCellColor_Click;
			this.Shown += EditPalette_Shown;
		}

		private void EditPalette_Shown(object sender, EventArgs e)
		{
			EnabledChk();
		}

		private void BtnCellColor_Click(object sender, EventArgs e)
		{
			if (m_IconButonList != null)
			{
				m_IconButonList.CellColorDialog();
				EnabledChk();
			}
		}

		private void BtnFont_Click(object sender, EventArgs e)
		{
			if (m_IconButonList != null)
			{
				m_IconButonList.ShowFontDialog();
				EnabledChk();
			}
		}


		private void BtnEditCaption_Click(object sender, EventArgs e)
		{
			if (m_IconButonList != null)
			{
				m_IconButonList.ShowCaptionDialog();
				EnabledChk();
			}
		}

		private void BtnUp_Click(object sender, EventArgs e)
		{
			if (m_IconButonList != null)
			{
				m_IconButonList.ItemUp();
				m_IconButonList.Refresh();
				EnabledChk();
			}
		}

		private void BtnDown_Click(object sender, EventArgs e)
		{
			if(m_IconButonList!=null)
			{
				m_IconButonList.ItemDown();
				m_IconButonList.Refresh();
				EnabledChk();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
