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
	public partial class TextDialog : Form
	{
		public TextDialog()
		{
			InitializeComponent();
			InitCaption();
		}
		public string Value
		{
			get { return tbNew.Text; }

			set
			{
				tbNew.Text = tbOrg.Text = value;
			}
		}
		public string LabelText1
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}
		public string LabelText2
		{
			get { return label2.Text; }
			set { label2.Text = value; }
		}
		public void InitCaption()
		{
			label1.Text = "元のキャプション";
			label2.Text = "新しいキャプション";
			this.Text = "キャプションの編集";
		}
		public void InitTitle()
		{
			label1.Text = "元のタイトル";
			label2.Text = "新しいタイトル";
			this.Text = "タイトルの編集";
		}
	}
}
