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
	public class FolderList : ListBox
	{
		private string m_CurrentPath = "";
		public string CurrentPath
		{
			get { return m_CurrentPath; }
			set { Listup(value); }
		}
		// *************************************************************
		public FolderList()
		{
			Listup();
			this.MouseDoubleClick += FolderList_MouseDoubleClick;
		}

		private void FolderList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = this.SelectedIndex;
			if (index < 0) return;
			Listup(Path.Combine(m_CurrentPath, (string)this.Items[index]));
		}


		// *************************************************************
		private void Listup(string p = "")
		{
			if ((p=="")||(Directory.Exists(p)==false))
			{
				p = Directory.GetCurrentDirectory();
			}
			string[] sa = Directory.GetDirectories(p);
			m_CurrentPath = p;
			this.Items.Clear();
			this.Items.Add("..");
			foreach (string s in sa)
			{
				string ss = Path.GetFileName(s);
				if ((ss == ".") || (ss == "..")) continue;
				if (ss.IndexOf(".") == 0) continue;

				this.Items.Add(ss);
			}
		}

	}
}
