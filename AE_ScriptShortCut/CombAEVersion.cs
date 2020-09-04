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
	public class CombAEVersion : ComboBox
	{
		private string[] m_PathList = new string[0];
		public CombAEVersion()
		{
			this.Items.Clear();
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MinimumSize = new Size(100, 0);
		}
		protected override void InitLayout()
		{
			//base.InitLayout();
			GetVersions();

		}
		public void GetVersions()
		{
			this.Items.Clear();
			AEPrefItem[] ret = AEPref.GetVersions();
			if(ret.Length>0)
			{
				string[] caps = new string[ret.Length];
				for ( int i=0; i< ret.Length;i++)
				{
					caps[i] = ret[i].Caption;
				}
				this.Items.AddRange(caps);
			}
		}

	}
}
