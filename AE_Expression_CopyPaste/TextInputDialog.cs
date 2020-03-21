using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_Util_skelton
{

    public partial class TextInputDialog : Form
    {
        private string cap = "";
        private string exp = "";

        public string ExpStr
        {
            get { return tbExpStr.Text; }
            set
            {
                tbExpStr.Text = value;
                exp = value;
            }
        }
        public string ExpCap
        {
            get
            {
                string s = tbExpStr.Text;
                //s = s.Replace("\r", "\\r");
                //s = s.Replace("\n", "\\n");
                return tbExpCap.Text;
            }
            set
            {
                string s = value;
                //s = s.Replace("\\r", "\r");
                //s = s.Replace("\\n", "\n");
                tbExpCap.Text = s;
                cap = s;
            }
        }


        public TextInputDialog()
        {
            InitializeComponent();
        }

        private void tbExpCap_TextChanged(object sender, EventArgs e)
        {
            BtnOK.Enabled = ((tbExpCap.Text != cap) || (tbExpStr.Text != exp));
        }

        private void btnREDO_Click(object sender, EventArgs e)
        {
            tbExpCap.Text = cap;
            tbExpStr.Text = exp;
        }
    }
}
