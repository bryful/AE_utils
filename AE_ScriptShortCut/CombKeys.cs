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
		private readonly string[] keyPat = new string[]
{
			"None",
			"Enter",
			"Delete",
			"Backspace",
			"Tab",
			"Return",
			"Esc",
			"LeftArrow",
			"RightArrow",
			"UpArrow",
			"DownArrow",
			"Space",
			"!",
			"DoubleQuote",
			"#",
			"$",
			"%",
			"&",
			"SingleQuote",
			"LParen",
			"RParen",
			"*",
			"Plus",
			"Comma",
			"-",
			".",
			"/",
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			":",
			";",
			"<",
			"=",
			">",
			"?",
			"@",
			"A",
			"B",
			"C",
			"D",
			"E",
			"F",
			"G",
			"H",
			"I",
			"J",
			"K",
			"L",
			"M",
			"N",
			"O",
			"P",
			"Q",
			"R",
			"S",
			"T",
			"U",
			"V",
			"W",
			"X",
			"Y",
			"Z",
			"[",
			"Backslash",
			"]",
			"^",
			"_",
			"`",
			"{",
			"|",
			"}",
			"~",
			"Umlaut_A",
			"Ring_A",
			"Cedilla_C",
			"Acute_E",
			"Tilde_N",
			"Umlaut_O",
			"Umlaut_U",
			"Acute_a",
			"Grave_a",
			"Circumflex_a",
			"Umlaut_a",
			"Tilde_a",
			"Ring_a",
			"Cedilla_c",
			"Acute_e",
			"Grave_e",
			"Circumflex_e",
			"Umlaut_e",
			"Acute_i",
			"Grave_i",
			"Circumflex_i",
			"Umlaut_i",
			"Tilde_n",
			"Acute_o",
			"Grave_o",
			"Circumflex_o",
			"Umlaut_o",
			"Tilde_o",
			"Acute_u",
			"Grave_u",
			"Circumflex_u",
			"Umlaut_u",
			"Section",
			"German_dbl_s",
			"Acute",
			"Yen",
			"Grave_A",
			"Tilde_A",
			"Tilde_O",
			"Umlaut_y",
			"Umlaut_Y",
			"Circumflex_A",
			"Circumflex_E",
			"Acute_A",
			"Umlaut_E",
			"Grave_E",
			"Acute_I",
			"Circumflex_I",
			"Umlaut_I",
			"Grave_I",
			"Acute_O",
			"Circumflex_O",
			"Grave_O",
			"Acute_U",
			"Circumflex_U",
			"Grave_U",
			"PadDecimal",
			"PadComma",
			"PadMultiply",
			"PadPlus",
			"PadClear",
			"PadSlash",
			"PadMinus",
			"PadEqual",
			"PadInsert",
			"PadDelete",
			"PadHome",
			"PadEnd",
			"PadPageUp",
			"PadPageDown",
			"Pad0",
			"Pad1",
			"Pad2",
			"Pad3",
			"Pad4",
			"Pad5",
			"Pad6",
			"Pad7",
			"Pad8",
			"Pad9",
			"F1",
			"F2",
			"F3",
			"F4",
			"F5",
			"F6",
			"F7",
			"F8",
			"F9",
			"F10",
			"F11",
			"F12",
			"F13",
			"F14",
			"F15",
			"F16",
			"F17",
			"F18",
			"F19",
			"F20",
			"F21",
			"F22",
			"F23",
			"F24",
			"HELP",
			"HOME",
			"PageUP",
			"FwdDel",
			"END",
			"PageDOWN",
			"NumLock",
			"Insert",
			"Pause",
			"CapsLock"

};
		public CombKeys()
		{
			this.Items.Clear();
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MinimumSize = new Size(100, 0);
			this.AutoSize = false;
			this.SetStyle(ControlStyles.DoubleBuffer,true);
		}
		protected override void InitLayout()
		{
			//base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(keyPat);
			if (this.SelectedIndex < 0) 
			{
				this.SelectedIndex = 0;
			}
			
		}
		// ******************************************************
		public void SetKey(string s)
		{
			int idx = IndexOfKeyString(s);
			if(this.SelectedIndex != idx)
			{
				this.SelectedIndex = idx;
			}
		}
		// ******************************************************
		private int IndexOfKeyString(string s)
		{
			int ret = 0;
			string ss = s.ToLower().Trim();
			if (ss == String.Empty) return ret;
			for (int i = 0; i < keyPat.Length; i++)
			{
				if (ss == keyPat[i].ToLower())
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
	}

}
