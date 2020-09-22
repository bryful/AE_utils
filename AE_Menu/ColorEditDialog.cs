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
		public Color BackJsx
		{
			get { return colorBox1.TargetColor; }
			set { colorBox1.TargetColor = value; }
		}
		public Color BackFfx
		{
			get { return colorBox2.TargetColor; }
			set { colorBox2.TargetColor = value; }
		}
		public Color BackJsxbin
		{
			get { return colorBox3.TargetColor; }
			set { colorBox3.TargetColor = value; }
		}
	}
}
