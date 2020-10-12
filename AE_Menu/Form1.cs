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
			this.ClientSize = iconButtonList1.Size;

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
			string pp = "";

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
					if (cols.Length >= 2)
					{
						iconButtonList1.ForeColor = Color.FromArgb(cols[0]);
						iconButtonList1.BackColor = Color.FromArgb(cols[1]);
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
						pp = ss;
					}
				}
				Font f = iconButtonList1.Font;
				string fn = f.Name;
				float fsz = f.Size;
				FontStyle sty = f.Style;


				ss = pref.GetString("Font", out ok);
				if(ok){fn = ss;}
				double dd = pref.GetDouble("FontSize", out ok);
				if (ok) { fsz = (float)dd; }
				int vv = pref.GetInt("FontStyle", out ok);
				if (ok) { sty = (FontStyle)vv; }

				iconButtonList1.Font = new Font(fn, fsz, sty);


			}
			iconButtonList1.ChkJsxTemplate();


			string[] cmds = System.Environment.GetCommandLineArgs();
			if (cmds.Length > 1)
			{
				AnalysisCommand(cmds);
				pp = "";
			}

			if (pp != "")
			{
				iconButtonList1.TargetDir = pp;
				this.Text = iconButtonList1.MenuName;
			}
			else
			{
				this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

			}

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
			cols[0] = iconButtonList1.ForeColor.ToArgb();
			cols[1] = iconButtonList1.BackColor.ToArgb();

			pref.SetIntArray("Color", cols);

			pref.SetString("Font", iconButtonList1.Font.Name);
			pref.SetDouble("FontSize", (double)iconButtonList1.Font.Size);
			pref.SetInt("FontStyle", (int)iconButtonList1.Font.Style);


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
			GetCommand(files);
		}
		//-------------------------------------------------------------
		public void AnalysisCommand(string[] cmd)
		{
			int cnt = cmd.Length;
			if (cnt <= 1) return;

			string fld = "";
			int width = iconButtonList1.ButtonSize.Width;
			int height = iconButtonList1.ButtonSize.Height;
			bool scriptFlag = false;
			bool pictOnlyFlag = false;

			int idx = 1;
			do
			{
				string c = cmd[idx];
				// opttion
				if ((c[0] == '/') || (c[0] == '-'))
				{
					string p = c.Substring(1).ToLower();
					if (p == "e")
					{
						pictOnlyFlag = true;
						scriptFlag = true;
					}
					else if (p == "p")
					{
						pictOnlyFlag = true;
					}
					else if (p == "w")
					{
						if (idx + 1 < cnt)
						{
							int v = 0;
							if (int.TryParse(cmd[idx + 1], out v))
							{
								if (v > 100)
								{
									width = v;
									idx++;
								}
							}
						}
					}
					else if (p == "h")
					{
						if (idx + 1 < cnt)
						{
							int v = 0;
							if (int.TryParse(cmd[idx + 1], out v))
							{
								if (v > 10)
								{
									height = v;
									idx++;
								}
							}
						}
					}
				}
				else
				{
					if (fld == "")
					{
						if (Directory.Exists(cmd[idx]) == true)
						{
							fld = cmd[idx];

						}
					}
				}
				idx++;

			} while (idx < cnt);


			if ((width != iconButtonList1.ButtonSize.Width)||(height != iconButtonList1.ButtonSize.Height))
			{
				iconButtonList1.SetButtonSize(new Size(width, height));
			}

			if (fld !="")
			{
				if (iconButtonList1.Listup(fld))
				{
					this.Text = iconButtonList1.MenuName;
					bool b = true;
					if (scriptFlag)
					{
						b = iconButtonList1.ExportJSXDialog();
					}
					if (pictOnlyFlag && b) iconButtonList1.ExportPict();

					if (pictOnlyFlag || scriptFlag)
					{
						Application.Exit();
					}
				}
			}

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
		private void ExitMI_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		//-------------------------------------------------------------
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

		//-------------------------------------------------------------
		private void ShowEditPaletteMI_Click(object sender, EventArgs e)
		{
			ShowEditPalette();
		}

		private void ShowSizeSettingMI_Click(object sender, EventArgs e)
		{
			SizeDialog dlg = new SizeDialog();
			dlg.Exec(iconButtonList1);
		}

		private void EditCellFontMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowFontDialog();
		}

		private void  ExportPictOnlyMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.ExportPict();
		}

		private void ShowEditCaptionMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowCaptionDialog();

		}

		private void ExportScriptMI_Click(object sender, EventArgs e)
		{
			if (iconButtonList1.ExportJSXDialog())
			{
				iconButtonList1.ExportPict();
			}
		}

		private void EditTitleMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowTitleDialog();
		}

		private void EditAllColorMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.AllColorDialog();
		}

		private void EditCellColorMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.CellColorDialog();
		}

		private void CopyMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.CopyColor();
		}

		private void PasteMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.PeasteColor();
		}

		private void ClearMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.Clear();
		}

		private void SelectDirMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.SelectDirDialog();
		}

		private void EditAllFontMI_Click(object sender, EventArgs e)
		{
			iconButtonList1.ShowAllFontDialog();
		}
	}
}
