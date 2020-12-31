using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using BRY;

namespace aeStatus
{
	
	class Program
	{
		
		static void Main(string[] args)
		{
			string ret = "";

			ProcessAE[] lst = NFsAE.ProcessAEList();

			foreach(ProcessAE aes in lst)
			{
				if (ret != "") ret += ",";
				ret += aes.ToAEJson;
			}

			Console.WriteLine("([" + ret + "])");

		}
	}
}
