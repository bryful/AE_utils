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
	public class CombKeys : ComboBox
	{
		public CombKeys()
		{
			this.Items.Clear();
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MinimumSize = new Size(100, 0);
		}
		protected override void InitLayout()
		{
			//base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(AEPref.keyPat);
			if (this.SelectedIndex < 0) 
			{
				this.SelectedIndex = 0;
			}
			
		}
	}

}
