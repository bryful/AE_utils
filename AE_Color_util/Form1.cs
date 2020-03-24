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

        ColorBoxs m_ColorBoxs = new ColorBoxs(12,6);

        int m_SelectedIndex = -1;
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();


            m_SelectedIndex = 0;

            for (int i=0; i<m_ColorBoxs.Items.Count;i++)
            {
                this.Controls.Add(m_ColorBoxs.Items[i]);
                m_ColorBoxs.Items[i].SelectedChanged += ColorBox_SelectedChanged;
            }
            m_ColorBoxs.SetLoc(15, 30, 34, 34);



            NavBarSetup();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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
                if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                bool b = pref.GetBool("IsFront", out ok);
                if (ok) m_navBar.IsFront = b;


            }
            m_ColorBoxs.Load();
            //this.Text = m_ColorBoxs.path;

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
            pref.SetBool("IsFront", m_navBar.IsFront);
            pref.Save();

            m_ColorBoxs.Save();
        }
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
            if ((idx >= 0) && (idx < m_ColorBoxs.Items.Count))
            {
                if (m_ColorBoxs.Items[idx].Selected == true)
                {
                    m_SelectedIndex = idx;
                }
                else
                {
                    m_SelectedIndex = -1;
                }
            }
            //this.Text = String.Format("SelectedIndex{0}", m_SelectedIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorFromClip();
        }
        // *******************************************************
        public void ColorFromClip()
        {
            AE_ClipData clipData = new AE_ClipData();

            AE_Color[] cols = clipData.ColorFromClip();
            if (cols.Length > 0)
            {
                if (cols.Length == 1)
                {
                    if (m_SelectedIndex >= 0)
                    {
                        m_ColorBoxs.Items[m_SelectedIndex].AE_Color = cols[0];
                    }
                }
                else
                {
                    if (m_SelectedIndex >= 0)
                    {
                        for (int i = 0; i < cols.Length; i++)
                        {
                            int idx = m_SelectedIndex + i;
                            if (idx >= m_ColorBoxs.Items.Count) break;
                            m_ColorBoxs.Items[idx].AE_Color = cols[i];

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

            clipData.ColorToClip(m_ColorBoxs.Items[m_SelectedIndex].AE_Color);
    

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

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockToolStripMenuItem.Checked = ! lockToolStripMenuItem.Checked;
            m_ColorBoxs.IsLocked = lockToolStripMenuItem.Checked;
        }
    }
}
