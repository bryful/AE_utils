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

using System.CodeDom.Compiler;
using System.Reflection;
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
                Size sz = pref.GetSize("Size", out ok);
                if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                string[] sa = pref.GetStringArray("Undo", out ok);
                if (ok) UndoList = sa.ToList<string>();
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
            pref.SetStringArray("Undo", UndoList.ToArray());
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
                    //listBox1.Items.Add(s);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            CalcExec();
        }

        private List<string> UndoList = new List<string>();
        private int UndoIndex = 0;
        public void CalcExec()
        {
            string changeStr(string str,string[][] sa)
            {
                if (sa.Length > 0)
                {
                    for ( int i=0; i< sa.Length; i++)
                    {
                        str = str.Replace(sa[i][0],sa[i][1]);
                    }
                }
                return str;
            }
            string[][] tbl = new string[][]
            {
                new string[]{ "（","(" },
                new string[]{ "）", "(" },
                new string[]{ "＋", "+" },
                new string[]{ "ー", "-" },
                new string[]{ "－", "-" },
                new string[]{ "×", "*" },
                new string[]{ "÷", "/" },
                new string[]{ "＊", "*" },
                new string[]{ "／", "/" },
                new string[]{ "１", "1" },
                new string[]{ "２", "2" },
                new string[]{ "３", "3" },
                new string[]{ "４", "4" },
                new string[]{ "５", "5" },
                new string[]{ "６", "6" },
                new string[]{ "７", "7" },
                new string[]{ "８", "8" },
                new string[]{ "９", "9" },
                new string[]{ "０", "0" }
            };
            string exp = tbLine.Text.Trim();
            if (exp != "")
            {
                string exp2 = changeStr(exp, tbl);

                string result = "";
                try
                {
                    JScriptEvaluator jscript = new JScriptEvaluator();
                    result = jscript.Eval(exp2);
                }
                catch
                {
                    result = "errer!";
                }
                UndoList.Add(exp);
                UndoIndex = 0;
                if (UndoList.Count > 40) UndoList.RemoveAt(0);
                tbLine.Text = result;
                tbLine.Select(tbLine.Text.Length, 0);

            }

        }
        public void UndoExec()
        {
            if(UndoList.Count>0)
            {
                int idx = UndoList.Count - 1 - (UndoIndex % UndoList.Count);
                if (idx < 0) idx = UndoList.Count + idx; 
                UndoIndex++;
                string str = UndoList[idx];
                tbLine.Text = str;
                tbLine.Select(tbLine.Text.Length, 0);
            }
        }
        private void tbLine_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            if((k==Keys.Return)|| (k == Keys.Enter))
            {
                CalcExec();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoExec();
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcExec();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = tbLine.Text.Trim();
            if (str != "")
            {
                Clipboard.SetText(str);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                tbLine.Text = Clipboard.GetText();
            }
        }
    }
}
