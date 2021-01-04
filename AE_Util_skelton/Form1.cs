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
        NavBar m_navBar = new NavBar();
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

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
                //Size sz = pref.GetSize("Size", out ok);
                //if (ok) this.Size = sz;
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
            //pref.SetSize("Size", this.Size);
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
                    lbInstalled.Items.Add(s);
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
        private void btnInstalled_Click(object sender, EventArgs e)
        {
            
            string[] a = NFsAE.FindInstalledAfterFX();
            lbInstalled.Items.Clear();
            lbInstalled.Items.AddRange( NFsAE.CombineAE( a));
            
        }


		private void btnProcess_Click(object sender, EventArgs e)
		{
            
            string[] a = NFsAE.ProcessList();
            lbProcess.Items.Clear();
            lbProcess.Items.AddRange(a);
            
        }

		private void btnRun_Click(object sender, EventArgs e)
		{
            
            AEStutas aes = nFsAE1.Run();
            string mes = "";
            switch (aes)
			{
                case AEStutas.None: mes = "失敗？";break;
                case AEStutas.IsRunStart: mes = "起動成功！"; break;
                case AEStutas.IsRunning: mes = "すでに起動中"; break;
            }
            MessageBox.Show(mes);
            
        }

		private void btnScriptCode_Click(object sender, EventArgs e)
		{
            nFsAE1.ExecScriptCode(ttbScriptCode.Text);
		}

		private void btnProcess2_Click(object sender, EventArgs e)
		{
            
            
        }
    }
}
