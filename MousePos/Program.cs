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

namespace MousePos
{

	enum Mode{
		NONE = 0,
		AEJSON,
		JSON,
		SETCURSOR,
		USAGE
	}

	class Program
	{
		static void Usage()
		{
			string u = 
				"MousePos.exe - Disp Mouse Cursor Position.\r\n"+
				"    usage: MousePos [options]\r\n" +
				"  options:\r\n"+
				"           -a disp AE toSource() style (default)\r\n"+
				"           -j disp json style\r\n" +
				"           -s<xpos>,<ypos> set Pos // MousePos -s256,153 \r\n" +
				"           -h -? this Message\r\n" +
				"";

			Console.WriteLine(u);

		}
		
		static Mode GetCmd(string[] args,out Point p)
		{
			Mode ret = Mode.AEJSON;
			p = new Point(0, 0);

			if (args.Length>0)
			{
				for(int i=0; i< args.Length;i++)
				{
					string cm = args[i];
					if(cm.Length>=2)
					{
						cm = cm.ToLower();
						if((cm[0]=='/')|| (cm[0] == '-'))
						{
							switch (cm[1])
							{
								case '?':
								case 'h':
									ret = Mode.USAGE;
									break;
								case 'j':
									ret = Mode.JSON;
									break;
								case 's':
									string[] sa = cm.Substring(2).Split(',');
									if (sa.Length >= 2)
									{
										int x = 0;
										int y = 0;
										if (
											(int.TryParse(sa[0], out x))&& 
											(int.TryParse(sa[1], out y))
											)
										{
											p.X = x;
											p.Y = y;
											ret = Mode.SETCURSOR;
										}
										else
										{
											ret = Mode.USAGE;
										}
									}

									break;
								case 'a':
								default:
									ret = Mode.AEJSON;
									break;
							}
						}
					}
				}
			}




			return ret;
		}
		static void GetPosAEJson()
		{
			//X座標を取得する
			int x = System.Windows.Forms.Cursor.Position.X;
			int y = System.Windows.Forms.Cursor.Position.Y;

			string nd = "({x:$X, y:$Y})";

			nd = nd.Replace("$X", x.ToString());
			nd = nd.Replace("$Y", y.ToString());

			Console.WriteLine(nd);
		}
		static void GetPosJson()
		{
			//X座標を取得する
			int x = System.Windows.Forms.Cursor.Position.X;
			int y = System.Windows.Forms.Cursor.Position.Y;

			string nd = "{\"x\":$X, \"y\":$Y}";

			nd = nd.Replace("$X", x.ToString());
			nd = nd.Replace("$Y", y.ToString());
			Console.WriteLine(nd);
		}
		static void SetPos(Point p)
		{
			Cursor.Position = p;
		}

		static void Main(string[] args)
		{
			Point p = new Point(0, 0);
			Mode m = GetCmd(args, out p);
			switch (m)
			{
				case Mode.USAGE:
					Usage();
					break;
				case Mode.JSON:
					GetPosJson();
					break;
				case Mode.SETCURSOR:
					SetPos(p);
					break;
				case Mode.AEJSON:
				default:
					GetPosAEJson();
					break;
			}
		}
	}
}
