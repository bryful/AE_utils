using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


using GetBigShellIcon; // https://www.ipentec.com/document/csharp-shell-namespace-get-big-icon-from-file-path 

namespace BRY
{
	public partial class AppInfoDialog : Form
	{
		public AppInfoDialog()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;

			// バージョン名（AssemblyInformationalVersion属性）を取得
			string appVersion = Application.ProductVersion;
			// 製品名（AssemblyProduct属性）を取得
			string appProductName = Application.ProductName;
			// 会社名（AssemblyCompany属性）を取得
			string appCompanyName = Application.CompanyName;

			// C#
			Assembly mainAssembly = Assembly.GetEntryAssembly();

			string appCopyright = "-";
			object[] CopyrightArray =
			  mainAssembly.GetCustomAttributes(
				typeof(AssemblyCopyrightAttribute), false);
			if ((CopyrightArray != null) && (CopyrightArray.Length > 0))
			{
				appCopyright =
				  ((AssemblyCopyrightAttribute)CopyrightArray[0]).Copyright;
			}

			// 詳細情報を取得
			string appDescription = "-";
			object[] DescriptionArray =
			  mainAssembly.GetCustomAttributes(
				typeof(AssemblyDescriptionAttribute), false);
			if ((DescriptionArray != null) && (DescriptionArray.Length > 0))
			{
				appDescription =
				  ((AssemblyDescriptionAttribute)DescriptionArray[0]).Description;
			}



			WindowsShellAPI.SHFILEINFO shinfo = new WindowsShellAPI.SHFILEINFO();

			IntPtr hImg = WindowsShellAPI.SHGetFileInfo(Application.ExecutablePath, 0, out shinfo, (uint)Marshal.SizeOf(typeof(WindowsShellAPI.SHFILEINFO)), WindowsShellAPI.SHGFI.SHGFI_SYSICONINDEX);

			WindowsShellAPI.SHIL currentshil = WindowsShellAPI.SHIL.SHIL_JUMBO;


			WindowsShellAPI.IImageList imglist = null;
			//int rsult = WindowsShellAPI.SHGetImageList(WindowsShellAPI.SHIL.SHIL_EXTRALARGE, ref WindowsShellAPI.IID_IImageList, out imglist);
			//int rsult = WindowsShellAPI.SHGetImageList(WindowsShellAPI.SHIL.SHIL_JUMBO, ref WindowsShellAPI.IID_IImageList, out imglist);
			int rsult = WindowsShellAPI.SHGetImageList(currentshil, ref WindowsShellAPI.IID_IImageList, out imglist);

			IntPtr hicon = IntPtr.Zero;
			imglist.GetIcon(shinfo.iIcon, (int)WindowsShellAPI.ImageListDrawItemConstants.ILD_TRANSPARENT, ref hicon);

			Icon myIcon = Icon.FromHandle(hicon);
			Bitmap buf = new Bitmap(128, 128);
			Graphics g = Graphics.FromImage(buf);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(myIcon.ToBitmap(), 0, 0, 128, 128);



			pictureBox1.Image = buf;




			/*
			Bitmap buf = new Bitmap(128, 128);
			Graphics g = Graphics.FromImage(buf);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(ico.ToBitmap(), 0, 0, 128, 128);
			*/

			Text = appProductName + " のバージョン情報";
			lbCanpany.Text = appCompanyName;
			lbProduct.Text = appProductName;
			lbVersion.Text = "Version " + appVersion;
			lbCopyright.Text = appCopyright;
			lbDescription.Text = appDescription;
		}
		static public void ShowAppInfoDialog()
		{
			using (AppInfoDialog dlg = new AppInfoDialog())
			{
				dlg.ShowDialog();
			}
		}

		private void AppInfoDialog_Load(object sender, EventArgs e)
		{

		}
	}


}
