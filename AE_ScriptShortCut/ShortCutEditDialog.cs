using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_ScriptShortCut
{
	public partial class ShortCutEditDialog : Form
	{
		public string ScriptName
		{
			get { return tbScriptName.Text; }
			set { tbScriptName.Text = value; }
		}
		public ShortCutEditDialog()
		{
			InitializeComponent();
			Init();
		}
		public void Init()
		{
			cbCtrl.Checked = false;
			cbAlt.Checked = false;
			cbShift.Checked = false;
			combKeys1.SelectedIndex = 0;
		}
		public void SetTag(string s)
		{
			Init();
			s = s.Trim().ToLower();
			if (s == "") return;
			string[] sa = s.Split('+');
			
			for ( int i=0; i<sa.Length;i++)
			{
				string ss = sa[i];
				if( ss == "ctrl")
				{
					cbCtrl.Checked = true;
				}
				else if (ss == "alt")
				{
					cbAlt.Checked = true;
				}
				else if (ss == "shift")
				{
					cbShift.Checked = true;
				}
				else
				{
					combKeys1.SetKey(ss);
					if (combKeys1.SelectedIndex < 0) combKeys1.SelectedIndex = 0;
				}

			}

		}
		public string GetTag()
		{
			string ret = "";

			if (combKeys1.SelectedIndex <= 0) return ret;

			if (cbCtrl.Checked == true) ret += "Ctrl";
			if (cbAlt.Checked == true)
			{
				if (ret != "") ret += "+";
				ret += "Alt";
			}
			if (cbShift.Checked == true)
			{
				if (ret != "") ret += "+";
				ret += "Shift";
			}
			if (ret != "") ret += "+";
			ret += combKeys1.SelectedText;

			return ret;

		}

		public string keyString
		{
			get { return GetTag(); }
			set { SetTag(value); }
		}
	}
}
