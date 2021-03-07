using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AlertCall
{
	class Program
	{
		static void Main(string[] args)
		{
			bool err = true;
			if (args.Length > 0)
			{
				string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				string exeName =    Path.Combine( Path.GetDirectoryName(appPath),"Alert.exe");

				string cmdLine = "";
				if (args.Length > 0)
				{
					for (int i = 0; i < args.Length; i++)
					{
						cmdLine += "\"" + args[i] + "\"";
					}
				}
				System.Diagnostics.Process ps = System.Diagnostics.Process.Start(exeName, cmdLine);
				if (ps != null) err = false;
			}
			if (err == true) Console.WriteLine("error");
		}
	}
}
