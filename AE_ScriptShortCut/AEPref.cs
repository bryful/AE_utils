using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_ScriptShortCut
{
	public class AEPrefItem
	{
		public string Caption = "";
		public string FilePath = "";
		public AEPrefItem()
		{
			Caption = "";
			FilePath = "";
		}
		public AEPrefItem(string cap,string p)
		{
			Caption = cap;
			FilePath = p;
		}
	}

	public class AEPref
	{
		// ******************************************************
		static public readonly string[] keyPat = new string[]
{
			" Enter",
			" Delete",
			" Backspace",
			" Tab",
			" Return",
			" Esc",
			" LeftArrow",
			" RightArrow",
			" UpArrow",
			" DownArrow",
			" Space",
			" !",
			" DoubleQuote",
			" #",
			" $",
			" %",
			" &",
			" SingleQuote",
			" LParen",
			" RParen",
			" *",
			" Plus",
			" Comma",
			" -",
			" .",
			" /",
			" 0",
			" 1",
			" 2",
			" 3",
			" 4",
			" 5",
			" 6",
			" 7",
			" 8",
			" 9",
			" :",
			" ;",
			" <",
			" =",
			" >",
			" ?",
			" @",
			" A",
			" B",
			" C",
			" D",
			" E",
			" F",
			" G",
			" H",
			" I",
			" J",
			" K",
			" L",
			" M",
			" N",
			" O",
			" P",
			" Q",
			" R",
			" S",
			" T",
			" U",
			" V",
			" W",
			" X",
			" Y",
			" Z",
			" [",
			" Backslash",
			" ]",
			" ^",
			" _",
			" `",
			" {",
			" |",
			" }",
			" ~",
			" Umlaut_A",
			" Ring_A",
			" Cedilla_C",
			" Acute_E",
			" Tilde_N",
			" Umlaut_O",
			" Umlaut_U",
			" Acute_a",
			" Grave_a",
			" Circumflex_a",
			" Umlaut_a",
			" Tilde_a",
			" Ring_a",
			" Cedilla_c",
			" Acute_e",
			" Grave_e",
			" Circumflex_e",
			" Umlaut_e",
			" Acute_i",
			" Grave_i",
			" Circumflex_i",
			" Umlaut_i",
			" Tilde_n",
			" Acute_o",
			" Grave_o",
			" Circumflex_o",
			" Umlaut_o",
			" Tilde_o",
			" Acute_u",
			" Grave_u",
			" Circumflex_u",
			" Umlaut_u",
			" Section",
			" German_dbl_s",
			" Acute",
			" Yen",
			" Grave_A",
			" Tilde_A",
			" Tilde_O",
			" Umlaut_y",
			" Umlaut_Y",
			" Circumflex_A",
			" Circumflex_E",
			" Acute_A",
			" Umlaut_E",
			" Grave_E",
			" Acute_I",
			" Circumflex_I",
			" Umlaut_I",
			" Grave_I",
			" Acute_O",
			" Circumflex_O",
			" Grave_O",
			" Acute_U",
			" Circumflex_U",
			" Grave_U",
			" PadDecimal",
			" PadComma",
			" PadMultiply",
			" PadPlus",
			" PadClear",
			" PadSlash",
			" PadMinus",
			" PadEqual",
			" PadInsert",
			" PadDelete",
			" PadHome",
			" PadEnd",
			" PadPageUp",
			" PadPageDown",
			" Pad0",
			" Pad1",
			" Pad2",
			" Pad3",
			" Pad4",
			" Pad5",
			" Pad6",
			" Pad7",
			" Pad8",
			" Pad9",
			" F1",
			" F2",
			" F3",
			" F4",
			" F5",
			" F6",
			" F7",
			" F8",
			" F9",
			" F10",
			" F11",
			" F12",
			" F13",
			" F14",
			" F15",
			" F16",
			" F17",
			" F18",
			" F19",
			" F20",
			" F21",
			" F22",
			" F23",
			" F24",
			" HELP",
			" HOME",
			" PageUP",
			" FwdDel",
			" END",
			" PageDOWN",
			" NumLock",
			" Insert",
			" Pause",
			" CapsLock"

};
		// ******************************************************
		static public readonly string[] VersionName = new string[]
		{
			"CS6",     // (11.0)
			"CC",      // (12.0)
			"CC 2015", // (13.0)
			"CC 2017", // (14.0)
			"CC 2018", // (15.0)
			"CC 2019", // (16.0)
			"CC 2020", // (17.0)
			"CC 2021", // (18.0)
			"CC 2022", // (19.0)
			"CC 2023", // (20.0)
		};
		// ******************************************************
		static public string VersionNumToName(string s)
		{
			string ret = "";
			string ss = s.Replace("(", "").Replace(")", "");
			if (ss == String.Empty) return ret;
			string[] ssa = ss.Split('.');
			string ssa0 = ssa[0];
			if (ssa0 == "11") { ret = "CS6"; }
			else if (ssa0 == "12") { ret = "CC"; }
			else if (ssa0 == "13") { ret = "CC 2015"; }
			else if (ssa0 == "14") { ret = "CC 2017"; }
			else if (ssa0 == "15") { ret = "CC 2018"; }
			else if (ssa0 == "16") { ret = "CC 2019"; }
			else if (ssa0 == "17") { ret = "CC 2020"; }
			else if (ssa0 == "18") { ret = "CC 2021"; }
			else if (ssa0 == "19") { ret = "CC 2022"; }
			else if (ssa0 == "20") { ret = "CC 2023"; }
			else { ret = ss; }

			return ret;
		}
		// ******************************************************
		static public string KeyString(int idx)
		{
			string ret = "";
			if ((idx >= 0) && (idx < keyPat.Length))
			{
				ret = keyPat[idx];
			}
			return ret;
		}
		// ******************************************************
		static public int IndexOfKeyString(string s)
		{
			int ret = -1;
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
		// ******************************************************
		static public AEPrefItem[] GetVersions()
		{
			AEPrefItem [] ret = new AEPrefItem [0];

			string p = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			p = Path.Combine(p, "Adobe");
			p = Path.Combine(p, "After Effects");
			if (Directory.Exists(p) == false) return ret;

			string[] subFolders = Directory.GetDirectories(p, "*", System.IO.SearchOption.TopDirectoryOnly);
			if (subFolders.Length <= 0) return ret;

			List<AEPrefItem> rr = new List<AEPrefItem>();

			for ( int i=0; i< subFolders.Length; i++)
			{
				AEPrefItem[] ai = GetPrefFile(subFolders[i]);
				if(ai.Length>0)
				{
					for(int j=0; j< ai.Length;j++)
					{
						rr.Add(ai[j]);
					}
				}
			}
			ret = rr.ToArray();


			return ret;

		}
		static private AEPrefItem [] GetPrefFile(string dir)
		{
			AEPrefItem [] ret = new AEPrefItem[0];
			if (Directory.Exists(dir) == false) return ret;

			string dirName = Path.GetFileName(dir);
			string capName = dirName + "(" + VersionNumToName(dirName) + ")";

			string[] lst = new string[0];
			string aeks = Path.Combine(dir, "aeks");

			if (Directory.Exists(aeks) == true)
			{
				lst = Directory.GetFiles(aeks, "*.txt");
			}
			else
			{
				lst = Directory.GetFiles(dir, "*.txt");

			}
			if (lst.Length > 0)
			{
				List<AEPrefItem> rr = new List<AEPrefItem>();
				for (int i = 0; i < lst.Length; i++)
				{
					if (IsShortCutFile(lst[i]) == true)
					{
						string cap = capName + " : " + Path.GetFileName(lst[i]);
						rr.Add(new AEPrefItem(cap, lst[i]));
					}
				}
				ret = rr.ToArray();
			}
			return ret;
		}
		/// <summary>
		/// ショートカット設定ファイルか
		/// </summary>
		/// <param name="p">ファイルパス</param>
		/// <returns>bool</returns>
		static bool IsShortCutFile(string p)
		{
			bool ret = false;

			if (File.Exists(p) == false) return ret;

			try
			{
				//テキストファイルの中身をすべて読み込む
				string str = File.ReadAllText(p, Encoding.GetEncoding("shift_jis"));

				int pos = str.IndexOf("# Text File Version");
				if ( pos>= 0)
				{
					pos = str.IndexOf("** header **", pos);
					if ( pos>= 0)
					{
						pos = str.IndexOf("AE_TopLevelWindow", pos);
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
	}
}
