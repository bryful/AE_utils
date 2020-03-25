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
        static public readonly int Yoko = 6;
        static public readonly int Tate = 12;

        private string PalettePath = "AE_ColorPalette.json";

        NavBar m_navBar = new NavBar();

        ColorBoxs m_ColorBoxs = new ColorBoxs(Tate,Yoko);

        //int m_SelectedIndex = -1;
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();


            for (int i=0; i<m_ColorBoxs.Items.Count;i++)
            {
                this.Controls.Add(m_ColorBoxs.Items[i]);
                m_ColorBoxs.Items[i].SelectedChanged += ColorBox_SelectedChanged;
            }
            m_ColorBoxs.SetLoc(10, 30, ColorBox.BoxLength, ColorBox.BoxLength);
            this.ClientSize = new Size(ColorBox.BoxLength * 6 + 20, ColorBox.BoxLength * 12 + 35);


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
                //Size sz = pref.GetSize("Size", out ok);
                //if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                bool b = pref.GetBool("IsFront", out ok);
                if (ok) m_navBar.IsFront = b;
                b = pref.GetBool("IsLocked", out ok);
                if (ok)
                {
                    m_ColorBoxs.IsLocked = b;
                    lockToolStripMenuItem.Checked = b;
                }
                b = pref.GetBool("IsLocked2", out ok);
                if (ok)
                {
                    if (b == true)
                    {
                        m_ColorBoxs.IsLocked = true;
                        lockToolStripMenuItem.Checked = true;
                    }
                    lock2ToolStripMenuItem.Checked = b;
                }

                string path = pref.GetString("PalettePath",out ok);
                if (ok) PalettePath = path;


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
            pref.SetString("PalettePath", PalettePath);
            pref.SetBool("IsLocked", m_ColorBoxs.IsLocked);
            pref.SetBool("IsLocked2", lock2ToolStripMenuItem.Checked);
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
            //this.Text = String.Format("SelectedIndex{0}", m_ColorBoxs.SelectedIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorFromClip();
        }
        // *******************************************************
        public void ColorFromClip()
        {
            AE_ClipData clipData = new AE_ClipData();

            AEColor[] cols = clipData.ColorFromClip();
            if (cols.Length > 0)
            {
                if (cols.Length == 1)
                {
                    if (m_ColorBoxs.SelectedIndex >= 0)
                    {
                        m_ColorBoxs.Items[m_ColorBoxs.SelectedIndex].AE_Color = cols[0];
                    }
                }
                else
                {
                    if (m_ColorBoxs.SelectedIndex >= 0)
                    {
                        for (int i = 0; i < cols.Length; i++)
                        {
                            int idx = m_ColorBoxs.SelectedIndex + i;
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
            if (m_ColorBoxs.SelectedIndex < 0) return;
            AE_ClipData clipData = new AE_ClipData();

            clipData.ColorToClip(m_ColorBoxs.Items[m_ColorBoxs.SelectedIndex].AE_Color);
    

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
            lockToolStripMenuItem.Checked = !lockToolStripMenuItem.Checked;
            m_ColorBoxs.IsLocked = lockToolStripMenuItem.Checked;
        }
        private void lock2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock2ToolStripMenuItem.Checked = !lock2ToolStripMenuItem.Checked;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = Path.GetFileName(PalettePath);
            sfd.InitialDirectory = Path.GetDirectoryName(PalettePath);
            if (sfd.InitialDirectory == "")
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            sfd.Filter = "Jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                m_ColorBoxs.Save(sfd.FileName);
                PalettePath = sfd.FileName;
            }
        }

        private void laodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = Path.GetFileName(PalettePath);
            ofd.InitialDirectory = Path.GetDirectoryName(PalettePath);
            if (ofd.InitialDirectory == "")
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            ofd.Filter = "Jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_ColorBoxs.Load(ofd.FileName);
                PalettePath = ofd.FileName;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            if (k == Keys.Right)
            {

            }
        }

      
    }
}
