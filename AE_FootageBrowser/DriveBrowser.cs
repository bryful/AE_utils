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

namespace AE_Util_skelton
{
	public class DriveBrowser : ComboBox
	{
		private string[] m_DriveList = new string[27];
		private string[] m_DriveListSub = new string[27];
		public DriveBrowser()
		{
			Listup();
		}
		public void Listup()
		{
			 string[] sa = Directory.GetLogicalDrives();
			this.Items.Clear();
			if (sa.Length > 0)
			{
				int cnt = sa.Length;
				Array.Resize(ref m_DriveList, cnt);
				Array.Resize(ref m_DriveListSub, cnt);
				for(int i=0; i<cnt; i++)
				{
				}

				this.Items.AddRange(m_DriveList);
			}
		}

	}
}
