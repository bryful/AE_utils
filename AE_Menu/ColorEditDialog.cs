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
	public partial class ColorEditDialog : Form
	{
		public ColorEditDialog()
		{
			InitializeComponent();
		}
		public Color Back
		{
			get { return colorBox1.TargetColor; }
			set { colorBox1.TargetColor = value; }
		}
		public Color Fore
		{
			get { return colorBox1.TextColor; }
			set { colorBox1.TextColor = value; }
		}

		private void btnFore_Click(object sender, EventArgs e)
		{
			colorBox1.ShowDialogFore();
		}
	}
}
