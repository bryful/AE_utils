using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace CreatePictIcon
{
	class Program
	{
		static void Main(string[] args)
		{
			CreatePictIcon cp = new CreatePictIcon();
			cp.LoadPref();
			if (cp.GetCommand(args) == true)
			{
				cp.ListupJsxFile();
			}
			cp.SavePref();

			if(cp.JsonDispFlag==true)
			{
				Console.WriteLine(cp.ToJson());
			}
		}
	}
}
