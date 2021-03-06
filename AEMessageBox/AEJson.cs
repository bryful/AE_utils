using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Codeplex.Data;

namespace BRY
{
	public class AEJson
	{
		private dynamic m_jsonObj = new DynamicJson();
		// **********************************************************************************
		static private string ParenK(string src)
		{
			string ret = src;
			ret = ret.Trim();
			if (ret.Length >= 2)
			{
				if ((ret[0] == '(') && (ret[ret.Length-1] == ')'))
				{
					ret = ret.Substring(1, ret.Length - 2).Trim();
					if (ret.Length >= 2)
					{
						if ((ret[0] == '{') && (ret[ret.Length - 1] == '}'))
						{
							ret = ret.Substring(1, ret.Length - 2).Trim();
						}
					}
				}
			}
			return ret;
		}
		// **********************************************************************************
		static private int FindColon(string src, int start = 0)
		{
			int ret = -1;
			int len = src.Length;
			if (start >= len) return ret;

			int idx = start;
			while (idx<len)
			{
				char c = src[idx];
				if (c == ':')
				{
					ret = idx;
					break;
				}
				if (c == '\"')
				{
					if (idx < len)
					{
						for (int j = idx + 1; j < len; j++)
						{
							char c2 = src[j];
							if (c2 == '\"')
							{
								if ((j > 0)&& (src[j - 1]=='\\'))
								{
								}
								else
								{
									idx = j;
									break;
								}
							}
						}
					}
				}
				idx++;
			}
			return ret;
		}
		// **********************************************************************************
		static private int FindComma(string src, int start)
		{
			int ret = 0;
			int len = src.Length;
			if  ( (start<=0)||(start>=len) ) return -1;
			for ( int i= start;i>=0;i--)
			{
				if (src[i]==',')
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		// **********************************************************************************
		static public string FromAEJson(string src)
		{
			string ret = "";
			//前後の空白を削除
			src = ParenK(src);
			src = src.Trim();
			src = src.Replace("\r\n","");
			if (src.Length <= 0) return ret;

			int idx = 0;
			int len = src.Length;
			while (idx < len)
			{
				// : を探す
				int idxColon = FindColon(src, idx);
				// :
				if (idxColon>=0)
				{
					// ,を探す
					int idxComma = FindComma(src, idxColon);
					if (idxComma>=0)
					{
						if (idxComma>idx)
						{
							ret += src.Substring(idx, idxComma - idx) + ",";
						}
						int s0 = idxComma + 1;
						if (idxComma == 0) s0 = 0;
						ret += "\"" + src.Substring(s0, idxColon - s0).Trim() + "\":";
						idx = idxColon + 1;
					}
					else
					{

						ret += src.Substring(idx);
						break;
					}

				}
				else
				{
					// :が見つからなかった
					ret += src.Substring(idx);
					break;
				}
			}
			ret = "{" + ret + "}";
			return ret;
		}
		// **********************************************************************************
		static public dynamic LoadAEJson(string p,out bool ok)
		{
			ok = false;
			dynamic ret = new DynamicJson();
			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					if (str != "")
					{
						str = FromAEJson(str);
						ret = DynamicJson.Parse(str);
						ok = true;
					}
				}
			}
			catch
			{
				ret = new DynamicJson();
				ok = false;
			}
			return ret;
		}
		// **********************************************************************************
	}
}
