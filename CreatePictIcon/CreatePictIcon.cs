using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using Codeplex.Data;

namespace CreatePictIcon
{
	public class JsxData
	{
		public string Name = "";
		public string Caption = "";
		public int Height = 50;

		public Color ForeColor = Color.White;
		public Color BackColor = Color.DarkGray;

		public dynamic ToJson()
		{
			dynamic ret = new DynamicJson();
			ret["Name"] = Name;
			ret["Caption"] = Caption;
			ret["Height"] = Height;
			ret["ForeColor"] = ForeColor.ToArgb();
			ret["BackColor"] = BackColor.ToArgb();

			return ret;

		}
		public void FromObj(dynamic d)
		{

			DynamicJson d2 = (DynamicJson)d;
			if(d2.IsDefined("Name")==true) Name = d["Name"];
			if (d2.IsDefined("Caption") == true) Caption = d["Caption"];
			if (d2.IsDefined("Height") == true) Height = (int)d["Height"];
			if (d2.IsDefined("ForeColor") == true) ForeColor = Color.FromArgb( (int)d["ForeColor"]);
			if (d2.IsDefined("BackColor") == true) BackColor = Color.FromArgb((int)d["BackColor"]);
		}

	}

	public class CreatePictIcon
	{
		private string m_targetFolder = "";
		private int m_IconWidth = 180;
		private int m_IconHeight = 30;

		public string FontName = "System";
		public int FontSizeNormal = 12;
		public int FontSizeSmall = 9;
		public Color ForeColor = Color.White;
		public Color BackColor_JSX = Color.FromArgb(78,78,78);
		public Color BackColor_FFX = Color.FromArgb(90,90,0);
		public Color BackColor_JSXBIN = Color.FromArgb(90, 25, 25);


		private bool m_JsonDispFlag = false;
		public bool JsonDispFlag
		{
			get { return m_JsonDispFlag; }
		}
		public CreatePictIcon()
		{
			Init();
		}
		public void Init()
		{
			m_IconWidth = 180;
			m_IconHeight = 30;

			FontName = "System";
			FontSizeNormal = 12;
			FontSizeSmall = 9;
			ForeColor = Color.White;
			BackColor_JSX = Color.FromArgb(78, 78, 78);
			BackColor_FFX = Color.FromArgb(90, 90, 0);
			BackColor_JSXBIN = Color.FromArgb(90, 25, 25);
		}
		// ************************************************************************
		private string ColorToStr(Color col)
		{
			return string.Format("{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
		}
		// ************************************************************************
		private bool ColorFromStr(string s, ref Color col)
		{
			if (s.Length>=6)
			{
				try
				{
					int r = Convert.ToInt32(s.Substring(0, 2),16);
					int g = Convert.ToInt32(s.Substring(2, 2),16);
					int b = Convert.ToInt32(s.Substring(4, 2),16);

					col = Color.FromArgb(r, g, b);
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				return false;
			}

		}
		// ************************************************************************
		public string ToJson()
		{
			dynamic obj = new DynamicJson();
			obj["IconWidth"] = (double)m_IconWidth;
			obj["IconHeight"] = (double)m_IconHeight;
			obj["FontName"] = FontName;
			obj["FontSizeNormal"] = FontSizeNormal;
			obj["FontSizeSmall"] = FontSizeSmall;
			obj["ForeColor"] = ColorToStr(ForeColor);
			obj["BackColor_JSX"] = ColorToStr(BackColor_JSX);
			obj["BackColor_FFX"] = ColorToStr(BackColor_FFX);
			obj["BackColor_JSXBIN"] = ColorToStr(BackColor_JSXBIN);

			string s = obj.ToString();
			return s;
		}
		public void FromJson(string s)
		{
			Init();
			if (s == "") return;
			var json = DynamicJson.Parse(s);
			DynamicJson jd = (DynamicJson)json;
			if (jd.IsDefined("IconWidth") == true) m_IconWidth = (int)json["IconWidth"];
			if (jd.IsDefined("IconHeight") == true) m_IconWidth = (int)json["IconHeight"];
			if (jd.IsDefined("FontName") == true) FontName = json["FontName"];
			if (jd.IsDefined("FontSizeNormal") == true) FontSizeNormal = (int)json["FontSizeNormal"];
			if (jd.IsDefined("FontSizeSmall") == true) FontSizeSmall = (int)json["FontSizeSmall"];
			
			Color col = Color.Black;
			if (jd.IsDefined("ForeColor") == true)
			{
				if (ColorFromStr(json["ForeColor"],ref col)==true)
				{
					ForeColor = col;
				}
			}
			if (jd.IsDefined("BackColor_JSX") == true)
			{
				if (ColorFromStr(json["BackColor_JSX"], ref col) == true)
				{
					BackColor_JSX = col;
				}
			}
			if (jd.IsDefined("BackColor_FFX") == true)
			{
				if (ColorFromStr(json["BackColor_FFX"], ref col) == true)
				{
					BackColor_FFX = col;
				}
			}
			if (jd.IsDefined("BackColor_JSXBIN") == true)
			{
				if (ColorFromStr(json["BackColor_JSXBIN"], ref col) == true)
				{
					BackColor_FFX = col;
				}
			}

		}
		// ***************************************************************************
		public void SavePref()
		{
			string path = Path.ChangeExtension(Application.ExecutablePath, ".json");
			try
			{
				string js = ToJson();
				File.WriteAllText(path, js, Encoding.GetEncoding("utf-8"));
			}
			catch
			{
			}

		}
		// ***************************************************************************
		public void LoadPref()
		{
			string path = Path.ChangeExtension(Application.ExecutablePath, ".json");

			if (File.Exists(path) == false) return;

			try
			{
				string str = File.ReadAllText(path, Encoding.GetEncoding("utf-8"));
				FromJson(str);
			}
			catch
			{
			}
		}
		// ***************************************************************************
		public bool GetCommand(string[] args)
		{
			bool ret = false;
			Init();
			if (args.Length<=0)
			{
				return ret;
			}
			int idx = 0;
			int v = 0;
			Color col = Color.White;
			bool initFlag = false;
			do
			{
				string s = args[idx];
				if (Directory.Exists(s) == true)
				{
					if (m_targetFolder == "")
					{
						m_targetFolder = s;
					}
				}
				else if (s.Length >= 2)
				{
					if ((s[0] == '-') || (s[0] == '/'))
					{
						string op = s.Substring(1).ToLower();
						idx++;
						if (idx >= args.Length)
						{
							if(op=="init")
							{
								initFlag = true;
							}else if (op == "json")
							{
								m_JsonDispFlag = true;
							}
							break;
						}

						if ((op == "width") || (op == "w"))
						{
							if (int.TryParse(args[idx], out v) == true)
							{
								m_IconWidth = v;
							}

						}
						else if ((op == "height") || (op == "h"))
						{
							if (int.TryParse(args[idx], out v) == true)
							{
								m_IconHeight = v;
							}
						}
						else if ((op == "fontname") || (op == "f"))
						{
							FontName = args[idx];
						}
						else if ((op == "fontsize") || (op == "fsn") || (op == "fontsizenormal"))
						{
							if (int.TryParse(args[idx], out v) == true)
							{
								FontSizeNormal = v;
							}
						}
						else if ((op == "fontsizesmall") || (op == "fss") || (op == "fontsizenormal"))
						{
							if (int.TryParse(args[idx], out v) == true)
							{
								FontSizeSmall = v;
							}

						}
						else if ((op == "forecolor") || (op == "fore") || (op == "forecol"))
						{
							if (ColorFromStr(args[idx], ref col))
							{
								ForeColor = col;
							}
						}
						else if ((op == "bockcolor_jsx") || (op == "jsx") || (op == "jsxcol"))
						{
							if (ColorFromStr(args[idx], ref col))
							{
								BackColor_JSX = col;
							}
						}
						else if ((op == "bockcolor_ffx") || (op == "ffx") || (op == "ffxcol"))
						{
							if (ColorFromStr(args[idx], ref col))
							{
								BackColor_FFX = col;
							}
						}
						else if ((op == "bockcolor_jsxbin") || (op == "jsxbin") || (op == "jsxbincol") || (op == "bincol") || (op == "bin"))
						{
							if (ColorFromStr(args[idx], ref col))
							{
								BackColor_JSXBIN = col;
							}
						}
						else if (op == "init")
						{
							initFlag = true;
						}
						else if (op == "json")
						{
							m_JsonDispFlag = true;
						}

					}
				}
				idx++;
			} while (idx < args.Length);

			ret = (m_targetFolder != "");
			if (initFlag==true)
			{
				Init();
			}
			return ret;

		}
		public string Info
		{
			get
			{
				string ret = "";
				ret = string.Format(
					"input:{0}\r\n",
					m_targetFolder
					);
				return ret;
			}
		}

		private bool ListupJsxFile(string s)
		{
			bool ret = false;

			if (Directory.Exists(s) == false) return ret;

			string [] fl = Directory.GetFiles(s,"*.*");
			if(fl.Length>0)
			{
				for(int i=0; i<fl.Length;i++)
				{
					string e = Path.GetExtension(fl[i]).ToLower();
					if((e==".jsx")|| (e == ".jsxbin")|| (e == ".ffx"))
					{
						CreateIcon(fl[i]);
					}
				}
			}
			return ret;
		}
		public bool ListupJsxFile()
		{
			return ListupJsxFile(m_targetFolder);
		}
		private bool CreateIcon(string s)
		{
			bool ret = false;

			if (File.Exists(s) == false)
			{
				return ret;
			}
			string e = Path.GetExtension(s).ToLower();
			if ((e == ".jsx") || (e == ".ffx") || (e == ".jsxbin"))
			{
				string p = Path.GetFileNameWithoutExtension(s);
				Bitmap bmp = new Bitmap(m_IconWidth, m_IconHeight);
				SolidBrush sb = new SolidBrush(BackColor_JSX);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				Graphics g = Graphics.FromImage(bmp);
				g.TextRenderingHint = TextRenderingHint.AntiAlias;

				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				Font fnt = new Font(FontName, FontSizeNormal);
				try
				{


					if (e == ".jsx") { sb.Color = BackColor_JSX; }
					else if (e == ".ffx") { sb.Color = BackColor_FFX; }
					else if (e == ".jsxbin") { sb.Color = BackColor_JSXBIN; }
					g.FillRectangle(sb, new Rectangle(-1, -1, bmp.Width+2, bmp.Height+2));

					SizeF stringSize = g.MeasureString(p, fnt, 2000, sf);
					if((m_IconWidth-5)<(int)stringSize.Width)
					{
						fnt = new Font(FontName, FontSizeSmall);
					}

					sb.Color = ForeColor;
					Rectangle rct = new Rectangle(5, 0, bmp.Width, bmp.Height);
					g.DrawString(p, fnt, sb, rct, sf);

					bmp.Save(Path.ChangeExtension(s, ".png"));
					ret = true;
				} catch 
				{
					ret = false;
				}
				finally
				{
					g.Dispose();	
					bmp.Dispose();
					sb.Dispose();
					sf.Dispose();
					fnt.Dispose();
				}

			}

			return ret;
		}
	}
}
