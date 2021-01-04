using BRY;
using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace AfterFXControl
{
	public partial class Form1 : Form
	{
		private Point mousePoint = new Point(0,0);

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				mousePoint = new Point(e.X, e.Y);
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				int xx = e.X - mousePoint.X;
				int yy = e.Y - mousePoint.Y;
				this.Location = new Point(this.Location.X + xx, this.Location.Y + yy);
			}
		}

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
				int v = pref.GetInt("PosMode",out ok);
				if (ok) m_navBar.PosMode = (NavBar.ModePos)v;
				bool b = pref.GetBool("IsFront", out ok);
				if (ok) m_navBar.IsFront = b;

			}
			label1.MouseMove += RedirectMouseMove;
			label1.MouseDown += RedirectMouseDown;
			label2.MouseMove += RedirectMouseMove;
			label2.MouseDown += RedirectMouseDown;
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
			//pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);

			pref.SetInt("PosMode", (int)m_navBar.PosMode);
			pref.SetBool("IsFront", m_navBar.IsFront);

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

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void nFsAECmp1_RunningAFXIndexChanged(object sender, EventArgs e)
		{
			nFsAECmp1.ForegroundWindow();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			nFsAECmp1.WindowMax();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			nFsAECmp1.WindowMin();
		}
		private void RedirectMouseDown(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
			Point formPoint = PointToClient(screenPoint);
			MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
				formPoint.X, formPoint.Y, e.Delta);

			OnMouseDown(args);
		}

		private void RedirectMouseMove(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
			Point formPoint = PointToClient(screenPoint);
			MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
				formPoint.X, formPoint.Y, e.Delta);
			OnMouseMove(args);
		}
	}
}
