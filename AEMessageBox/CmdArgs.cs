using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRY
{
	public class CmdOptions
	{
		/// <summary>
		/// オプション文字列
		/// </summary>
		public string Option = "";
		/// <summary>
		/// 配列のインデックス
		/// </summary>
		public int Index = -1;
	}

	public class CmdArgs
	{
		#region Property
		private string[] m_args = new string[0];
		public string[] Args
		{
			get { return m_args; }
			set
			{
				m_args = value;
				m_options = listupOptions(value);
			}
		}
		private CmdOptions[] m_options = new CmdOptions[0];
		public CmdOptions[] Options
		{
			get { return m_options; }
		}
		public int OptionsCount
		{
			get { return m_options.Length; }
		}

		#endregion
		public CmdArgs(string[] sa)
		{
			Args = sa;
		}
		/// <summary>
		/// optionの検索。
		/// tagで始まるoptionを１個のみ検索
		/// </summary>
		/// <param name="tag">検索する文字列</param>
		/// <param name="IgnoreCase">truなら、大文字小文字を区別しない</param>
		/// <returns>CmdOptions</returns>
		public CmdOptions FindOption(string tag, bool IgnoreCase = false)
		{
			StringComparison sc = StringComparison.CurrentCulture;
			if (IgnoreCase == true)
			{
				sc = StringComparison.CurrentCultureIgnoreCase;
			}
			CmdOptions ret = new CmdOptions();
			foreach (CmdOptions opt in m_options)
			{
				if (opt.Option.IndexOf(tag, sc) == 0)
				{
					ret = opt;
					break;
				}
			}
			return ret;
		}
		public CmdOptions[] FindOptions(string tag, bool IgnoreCase = false)
		{
			StringComparison sc = StringComparison.CurrentCulture;
			if (IgnoreCase == true)
			{
				sc = StringComparison.CurrentCultureIgnoreCase;
			}
			List<CmdOptions> ret = new List<CmdOptions>();
			foreach (CmdOptions opt in m_options)
			{
				if (opt.Option.IndexOf(tag, sc) == 0)
				{
					ret.Add(opt);
				}
			}
			return ret.ToArray();
		}
		/// <summary>
		///  / or - で始まるオプションを切り出す。
		/// </summary>
		/// <param name="sa"></param>
		/// <returns></returns>
		static public CmdOptions[] listupOptions(string[] sa)
		{
			List<CmdOptions> ret = new List<CmdOptions>();
			if (sa.Length > 0)
			{
				for (int i = 0; i < sa.Length; i++)
				{
					string s = sa[i];
					if ((s[0] == '-') || (s[0] == '/'))
					{
						string ss = s.Substring(1).Trim();
						if (ss != String.Empty)
						{
							CmdOptions opt = new CmdOptions();
							opt.Option = ss;
							opt.Index = i;
							ret.Add(opt);
						}
					}
				}
			}
			return ret.ToArray();
		}
	}
}
