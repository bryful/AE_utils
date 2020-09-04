using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_ScriptShortCut
{
	public class AEShortcutFile
	{
		private string[] keyPat = new string[]
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

		private string m_FilePath = "";
		private string[] m_FileData = new string[0];
		private int[] m_IndexList = new int[20];
		// *********************************************************
		public AEShortcutFile()
		{

		}
		// *********************************************************
		/// <summary>
		/// ショートカット設定ファイルを読み込む
		/// </summary>
		/// <param name="p">ファイルのパス</param>
		/// <returns>正常に読み込めたらtrue</returns>
		public bool LoadFile(string p)
		{
			bool ret = false;
			m_FileData = new string[0];

			if (File.Exists(p) == true)
			{
				try
				{
					string[] lines = File.ReadAllLines(p, Encoding.GetEncoding("shift_jis"));
					if (lines.Length > 900)
					{
						if (lines[0].IndexOf("# Text File Version 1.1") >= 0)
						{
							m_FileData = lines;
							GetIndexList();
							ret = true;
						}
					}
				}
				catch
				{
					ret = false;
				}
			}
			return ret;
		}
		// *********************************************************
		/// <summary>
		/// ショートカット設定ファイルを保存
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool SaveFile(string p)
		{
			bool ret = false;
			if (m_FileData.Length <= 800) return ret;

			try
			{
				File.WriteAllLines(p, m_FileData, Encoding.GetEncoding("shift_jis"));
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;

		}
		// *********************************************************
		private int IndexOfScriptShortCut(int idx,int startIdx=200)
		{
			int ret = -1;
			int len = m_FileData.Length;
			if ( len < 200) return ret;
			if ((idx < 1) || (idx > 20)) return ret;
			if (startIdx < 200) startIdx = 200;
			if (startIdx >= len) return ret;

			string tag = String.Format("\t\"ExecuteScriptMenuItem{0:00}\"", idx); 

			for ( int i= startIdx; i < len; i++) 
			{
				if (m_FileData[i].IndexOf(tag) >= 0)
				{
					ret = i;
					break;
				}
			}

			return ret;
		}
		// *********************************************************
		private bool GetIndexList()
		{
			bool ret = false;

			int cnt = 0;
			for ( int i = 1; i <= 20; i++) 
			{
				int r = IndexOfScriptShortCut(i, 200);
				m_IndexList[i] = r;
				if (r >= 0) { cnt++; }
			}
			ret = (cnt == 20);
			return ret;

		}
	}
}
