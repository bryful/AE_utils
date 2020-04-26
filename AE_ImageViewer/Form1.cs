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
namespace AE_Util_skelton
{
	public partial class Form1 : Form
	{
		private PictureFileList m_Plist = new PictureFileList();

		NavBar m_navBar = new NavBar();
		private Size orgSize = new Size(0, 0);
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			btnScaaleHarf.Tag = 0;
			btnScale1.Tag = 1;
			btnScale2.Tag = 2;
			btnScale3.Tag = 3;
			btnScale4.Tag = 4;
			orgSize = new Size(this.Width, this.Height);


			NavBarSetup();
		}
		//-------------------------------------------------------------
		private void NavBarSetup()
		{
			m_navBar.Form = this;
			m_navBar.SizeSet();
			m_navBar.LocSet();
			m_navBar.Show();

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
				Size sz = pref.GetSize("Size", out ok);
				if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			m_navBar.Caption = this.Text;
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
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);
			pref.Save();

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
				e.Effect = DragDropEffects.Copy;
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
			string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			GetCommand(fileNames);
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
				for (int i = 0; i < cmd.Length; i++)
                {
                    string ext = System.IO.Path.GetExtension(cmd[i]);
                    if ((string.Compare(ext, ".tga") == 0) || (string.Compare(ext, ".jpg") == 0) || (string.Compare(ext, ".png") == 0) || (string.Compare(ext, ".tif") == 0))
                    {
                        m_Plist.Path = cmd[i];
                        if (m_Plist.Count > 0)
                        {
                            DispPicture();
                            return;
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
		
		//********************************************************************
		public void PrevPicture()
		{
			if ((m_Plist.Count > 0))
			{
				int idx = m_Plist.Index - 1;
				if (idx < 0) idx = m_Plist.Count - 1;
				m_Plist.Index = idx;
				DispPicture();
			}
		}
		//********************************************************************
		public void NextPicture()
		{
			if ((m_Plist.Count > 0))
			{
				int idx = m_Plist.Index + 1;
				if (idx >= m_Plist.Count) idx = 0;
				m_Plist.Index = idx;
				DispPicture();
			}
		}
		//********************************************************************
		public void DispPicture()
		{
			string s = "";
			if ((m_Plist.Count > 0))
			{
				s = m_Plist.TargetFileName + " " + (m_Plist.Index + 1).ToString() + "/" + m_Plist.Count.ToString();
				pictureView1.OpenFile(m_Plist.TargetFileNameFull);

				btnNext.Enabled = btnPrev.Enabled = true;
				btnScaaleHarf.Enabled =
				btnScale1.Enabled =
				btnScale2.Enabled =
				btnScale3.Enabled =
				btnScale4.Enabled = true;
				this.Text = s;
			}
			else
			{
				btnNext.Enabled = btnPrev.Enabled = false;
				btnScaaleHarf.Enabled =
				btnScale1.Enabled =
				btnScale2.Enabled =
				btnScale3.Enabled =
				btnScale4.Enabled = false;
				this.Text = this.Name;
			}

		}
		 //********************************************************************
		private void btnSelectFolder_Click_1(object sender, EventArgs e)
		{
			
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Plist.Path = folderBrowserDialog1.SelectedPath;
				if (m_Plist.Count > 0)
				{
					DispPicture();
				}
			}
			
		}

		//********************************************************************
		private void btnFileOpen_Click(object sender, EventArgs e)
		{
			
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{

				m_Plist.Path = openFileDialog1.FileName;
				if (m_Plist.Count > 0)
				{
					DispPicture();
				}
			}
			

		}
		//********************************************************************
		private void btnPrev_Click(object sender, EventArgs e)
		{
			PrevPicture();
		}

        //********************************************************************
        private void btnNext_Click(object sender, EventArgs e)
		{
			NextPicture();
		}

        //********************************************************************
        private void btnScale_Click(object sender, EventArgs e)
		{
			int v = (int)((ToolStripButton)sender).Tag;
			
			btnScaaleHarf.Checked = false;
			btnScale1.Checked = false;
			btnScale2.Checked = false;
			btnScale3.Checked = false;
			btnScale4.Checked = false;

			float sl = 1.0f;
			switch (v)
			{
				case 0: 
					sl = 0.5f; 
					btnScaaleHarf.Checked = true;
					break;
				case 2:
					sl = 2f;
					btnScale2.Checked = true;
					break;
				case 3:
					sl = 3f;
					btnScale3.Checked = true;
					break;
				case 4:
					sl = 4f;
					btnScale4.Checked = true;
					break;
				case 1: 
				default:
					sl = 1f;
					btnScale1.Checked = true;
					break;
			}
			pictureView1.SetRatio(sl);

		}

  
	
        //********************************************************************
        private void btnHor_Click(object sender, EventArgs e)
		{
			pictureView1.DrawHor = !pictureView1.DrawHor;
			btnHor.Checked = pictureView1.DrawHor;
		}
		//********************************************************************
		

		//********************************************************************
		private void cntrol_Enter(object sender, EventArgs e)
        {
            pictureView1.Focus();
        }


 

		private void ModeMenu_Click(object sender, EventArgs e)
		{
			int v = (int)((ToolStripMenuItem)sender).Tag;
			
		}


		private void closeMenu_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}

        private void DisposePicture()
        {
            if ( m_Plist.Count>0) m_Plist.Clear();
            pictureView1.ClearPicture();
            pictureView1.Invalidate();
        }

        private void DisposePictureMenu_Click(object sender, EventArgs e)
        {
            DisposePicture();
        }



	}
}
