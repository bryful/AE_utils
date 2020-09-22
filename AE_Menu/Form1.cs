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

using BRY;

using Codeplex.Data;
/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace AE_Menu
{
	public partial class Form1 : Form
	{
		private EditPalette m_EditPalette = null;
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			this.Text = iconButtonList1.MenuName;

		}
		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();

		}

		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref();
			if (pref.Load())
			{
				bool ok = false;
				//Size sz = pref.GetSize("Size", out ok);
				//if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;

				Size sz = pref.GetSize("ButtonSize", out ok);
				if (ok) iconButtonList1.ButtonSize = sz;

				int[] cols = pref.GetIntArray("Color", out ok);
				if(ok)
				{
					if (cols.Length >= 3)
					{
						iconButtonList1.BackJSX = Color.FromArgb(cols[0]);
						iconButtonList1.BackJSXBIN = Color.FromArgb(cols[1]);
						iconButtonList1.BackFFX = Color.FromArgb(cols[2]);
					}
				}
				bool b = pref.GetBool("RelativePath", out ok);
				if (ok)
				{
					iconButtonList1.RelativePath = b;
				}


				string ss = pref.GetString("TargetDir", out ok);
				if (ok)
				{
					if(Directory.Exists(ss)==true)
					{
						iconButtonList1.TargetDir = ss;
						this.Text = iconButtonList1.MenuName;
					}
				}
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref();
			pref.SetPoint("Point", this.Location);

			pref.SetString("TargetDir", iconButtonList1.TargetDir);
			pref.SetSize("ButtonSize", iconButtonList1.ButtonSize);

			int[] cols = new int[3];
			cols[0] = iconButtonList1.BackJSX.ToArgb();
			cols[1] = iconButtonList1.BackJSXBIN.ToArgb();
			cols[2] = iconButtonList1.BackFFX.ToArgb();

			pref.SetIntArray("Color", cols);

			pref.SetBool("RelativePath", iconButtonList1.RelativePath);

			pref.Save();

			iconButtonList1.BackupStore();

		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					if(Directory.Exists(s)==true)
					{
						if(iconButtonList1.Listup(s) == true)
						{
							break;
						}
					}
				}
			}
		}
		/// <summary>
		/// メニューの終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//-------------------------------------------------------------
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AppInfoDialog.ShowAppInfoDialog();
		}
		

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void iNportToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		public void ShowEditPalette()
		{
			if(m_EditPalette==null)
			{
				m_EditPalette = new EditPalette();
				m_EditPalette.IconButonList = iconButtonList1;

			}
			m_EditPalette.Location = Cursor.Position;
			m_EditPalette.Show();
		}

		private void buttonSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowEditPalette();
		}

		private void sizeSettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SizeDialog dlg = new SizeDialog();
			dlg.Exec(iconButtonList1);
		}

		private void fontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowFontDialog();
		}

		private void exportIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.ExportPict();
		}

		private void editCaptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowCaptionDialog();

		}

		private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			iconButtonList1.ExportPict();
			iconButtonList1.ExportJSX();
		}

		private void editMenuTitleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowTitleDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void allColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.AllColorDialog();
		}

		private void RelativePathToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.CellColorDialog();
		}

		private void copyColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.CopyColor();
		}

		private void peasteColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			iconButtonList1.PeasteColor();
		}
	}
}
