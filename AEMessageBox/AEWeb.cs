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

using Codeplex.Data;

using Markdig;

namespace BRY
{
	public class AEWeb : WebBrowser
	{
		private string m_headcss = "";
		public string headcss
		{
			get { return m_headcss; }
			set 
			{ 
				m_headcss = value;
				Disp();
			}
		}
		private string m_body = "";
		public string body
		{
			get { return m_body; }
			set 
			{
				string s = value.Replace("\r\n", "<br>\r\n");
				m_body = s;
				Disp();
			}
		}
		public void Disp()
		{
			if ((this.Document != null) && (this.Document.Body != null))
			{
				this.Document.Body.InnerHtml = m_body;
			}
			else
			{
				this.DocumentText = Html;
			}
		}
		private bool m_isCenter = true;
		public bool isCenter { get { return m_isCenter; } }
		private int m_left = 0;
		public int WinLeft { get { return m_left; } }
		private int m_top = 0;
		public int WinTop { get { return m_top; } }
		private int m_width = 0;
		public int WinWidth { get { return m_width; } }
		private int m_height = 0;
		public int WinHeight { get { return m_height; } }

		public Point WinLocation
		{
			get { return new Point(m_left, m_top); }
		}
		public Size WinSize
		{
			get { return new Size(m_width, m_height); }
		}

		public string Html
		{
			get
			{
				return HTML_BASE.Replace("{$CSS}", m_headcss).Replace("{$BODY}", m_body);
			}
		}

		private readonly string HTML_BASE =
			"<!DOCTYPE html>\r\n" +
			"<html>\r\n" +
			"<head>\r\n" +
			"<style type=\"text/css\">\r\n" +
			"<!--\r\n" +
			"{$CSS}\r\n" +
			"-->\r\n" +
			"</style>\r\n" +
			"</head>\r\n" +
			"<body>\r\n" +
			"{$BODY}" +
			"</body>\r\n" +
			"</html>\r\n";
		private string m_title = "";
		public string title
		{
			get { return m_title; }
		}

		public AEWeb()
		{

		}
		public void Clear()
		{
			m_headcss = "";
			m_body = "";
			m_isCenter = true;
			m_left = 0;
			m_top = 0;
			m_width = 0;
			m_height = 0;
			m_title = "";
		}
		// *****************************************************************************************
		public bool LoadJson(string p)
		{
			bool ret = false;
			Clear();
			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					if (str != "")
					{
						try
						{
							dynamic json = DynamicJson.Parse(str);

							string key = "body";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_body = (string)json[key];
								m_body = m_body.Replace("\r\n", "<br>\r\n").Trim();
							}
							key = "headcss";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_headcss = (string)json[key];
							}
							key = "isCenter";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_isCenter = (bool)json[key];
							}
							key = "left";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_left = (int)json[key];
							}
							key = "top";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_left = (int)json[key];
							}
							key = "width";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_width = (int)json[key];
							}
							key = "height";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_height = (int)json[key];
							}

							key = "title";
							if (((DynamicJson)json).IsDefined(key) == true)
							{
								m_title = (string)json[key];
							}
							ret = true;
						}
						catch
						{
							m_body = str.Replace("\r\n", "<br>\r\n");
						}
						Disp();
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
