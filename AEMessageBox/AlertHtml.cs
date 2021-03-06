using BRY;
using Codeplex.Data;
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


namespace BRY
{
	public class AlertHtml:Component
	{

		private string m_headcss = "";
		public string headcss
		{
			get { return m_headcss; }
			set { m_headcss = value; }
		}
		private string m_body = "";
		public string body
		{
			get { return m_body; }
			set { m_body = value.Replace("\r\n","<br>\r\n"); }
		}

		private bool m_isCenter = true;
		public bool isCenter { get { return m_isCenter; } }
		private int m_left = 0;
		public int left { get { return m_left; } }
		private int m_top = 0;
		public int top { get { return m_top; } }
		private int m_width = 0;
		public int width { get { return m_width; } }
		private int m_height = 0;
		public int height { get { return m_height; } }

		public Point Location
		{
			get { return new Point(m_left, m_top); }
		}
		public Size Size
		{
			get { return new Size(m_width, m_height); }
		}


		private string m_title = "";
		public string title
		{
			get { return m_title; }
		}

		public string Html
		{
			get
			{
				return HTML_BASE.Replace("{$CSS}", m_headcss).Replace("{$BODY}", m_body);
			}
		}

		private readonly string HTML_BASE =
			"!DOCTYPE html>\r\n" +
			"<html>\r\n" +
			"<head>\r\n" +
			"<style type=\"text/css\">\r\n" +
			"<!--\r\n" +
			"{$CSS}\r\n" +
			"-->\r\n" +
			"</style>\r\n" +
			"</head>\r\n" +
			"<body>\r\n" +
			"{$BODY}"+
			"</body>\r\n" +
			"</html>\r\n";
		public AlertHtml()
		{
			Clear();
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

							ret = true;
							string key = "body";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_body = (string)json[key];
								m_body = m_body.Replace("\r\n", "<br>\r\n").Trim();
							}
							key = "headcss";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_headcss = (string)json[key];
							}
							key = "isCenter";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_isCenter = (bool)json[key];
							}
							key = "left";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_left = (int)json[key];
							}
							key = "top";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_left = (int)json[key];
							}
							key = "width";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_width = (int)json[key];
							}
							key = "height";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_height = (int)json[key];
							}

							key = "title";
							if (((DynamicJson)json[key]).IsDefined(key) == true)
							{
								m_title = (string)json[key];
							}
						}
						catch
						{
							m_body = str.Replace("\r\n", "<br>\r\n");
						}
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
		// *****************************************************************************************

	}
}
