using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_Menu
{
	public partial class ExportDialog : Form
	{
		public bool RelativePath
		{
			get { return rbRel.Checked; }
			set
			{

				rbAbs.Checked = !value;
				rbRel.Checked = value;

			}
		}
		private string m_ExportPath_org = "";
		public ExportDialog()
		{
			InitializeComponent();
		}
		public string ExportPath
		{
			get { return Path.Combine(tbPath.Text,tbName.Text); }
			set
			{
				m_ExportPath_org = value;
				tbPath.Text = Path.GetDirectoryName(value);
				tbName.Text = Path.GetFileName(value);

			}
		}

		private void rbAbs_Click(object sender, EventArgs e)
		{
			bool b = (rbAbs.Checked == true);
			btnFolder.Enabled =  b;
			tbPath.Enabled =  b;
			if(! b)
			{
				tbPath.Text = Path.GetDirectoryName(m_ExportPath_org);
			}
		}

		private void btnFolder_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = tbPath.Text;
			dlg.FileName = tbName.Text;
			dlg.Filter = "*.jsx|*.jsx";
			dlg.DefaultExt = ".jsx";
			dlg.Title = "Export JsxFile";
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				tbPath.Text = Path.GetDirectoryName( dlg.FileName);
				tbName.Text = Path.GetFileName(dlg.FileName);
			}

		}

		private void ExportDialog_Load(object sender, EventArgs e)
		{

		}
	}
}
