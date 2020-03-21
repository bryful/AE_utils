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

        List<ColorBox> m_ColorBoxs = new List<ColorBox>();
        int m_SelectedIndex = -1;
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();


            AddColorBox(colorBox1);
            AddColorBox(colorBox2);
            AddColorBox(colorBox3);
            AddColorBox(colorBox4);
            AddColorBox(colorBox5);
            AddColorBox(colorBox6);
            AddColorBox(colorBox7);
            AddColorBox(colorBox8);
            AddColorBox(colorBox9);
            AddColorBox(colorBox10);
            AddColorBox(colorBox11);
            AddColorBox(colorBox12);
            AddColorBox(colorBox13);
            AddColorBox(colorBox14);
            AddColorBox(colorBox15);

            m_SelectedIndex = 0;
            colorBox1.Selected = true;

            NavBarSetup();
        }
        //-------------------------------------------------------------
        private void AddColorBox(ColorBox cb)
        {
            m_ColorBoxs.Add(cb);
            m_ColorBoxs[m_ColorBoxs.Count - 1].Index = m_ColorBoxs.Count - 1;
            m_ColorBoxs[m_ColorBoxs.Count - 1].SelectedChanged += ColorBox_SelectedChanged;
        }
        //-------------------------------------------------------------
        private void NavBarSetup()
        {
            m_navBar.Form = this;
            m_navBar.LocSet();
            //m_navBar.SizeSet();
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
                   // listBox1.Items.Add(s);
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

        private void ColorBox_SelectedChanged(object sender, EventArgs e)
        {
            int idx = ((ColorBox)sender).Index;
            if ((idx >= 0) && (idx < m_ColorBoxs.Count))
            {
                if (m_ColorBoxs[idx].Selected == true)
                {
                    m_SelectedIndex = idx;
                }
                else
                {
                    m_SelectedIndex = -1;
                }
            }
            this.Text = String.Format("SelectedIndex{0}", m_SelectedIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorFromClip();
        }
        // *******************************************************
        public void ColorFromClip()
        {
            AE_ClipData clipData = new AE_ClipData();

            Color[] cols = clipData.ColorFromClip();
            if (cols.Length > 0)
            {
                if (cols.Length == 1)
                {
                    if (m_SelectedIndex >= 0)
                    {
                        m_ColorBoxs[m_SelectedIndex].Color = cols[0];
                    }
                }
                else
                {
                    if (m_SelectedIndex >= 0)
                    {
                        for (int i = 0; i < cols.Length; i++)
                        {
                            int idx = m_SelectedIndex + i;
                            if (idx >= m_ColorBoxs.Count) break;
                            m_ColorBoxs[idx].Color = cols[i];

                        }
                    }
                }

            }

        }
        // *******************************************************
        public void ColorToClip()
        {
            if (m_SelectedIndex < 0) return;
            AE_ClipData clipData = new AE_ClipData();

            clipData.ColorToClip(m_ColorBoxs[m_SelectedIndex].Color);
    

        }
        // *******************************************************
        private void button2_Click(object sender, EventArgs e)
        {
            ColorToClip();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorToClip();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorFromClip();
        }
    }
}
