﻿using BRY;
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
namespace Alert
{
	public partial class Form1 : Form
	{
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			aeWeb1.Disp();
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
			cbTopMost.Checked = this.TopMost;
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref();
			if (pref.Load())
			{
				bool ok = false;
				Size sz = pref.GetSize("Size", out ok);
				if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;
				bool b = pref.GetBool("TopMost", out ok);
				if (ok)
				{
					cbTopMost.Checked = b;
					this.TopMost = b;
				}
				b = pref.GetBool("IsClear", out ok);
				if (ok)
				{
					cbIsClear.Checked = b;
					aeWeb1.IsClear = b;
				}

			}
			GetCommand(System.Environment.GetCommandLineArgs());
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
			pref.SetSize("Size", this.Size);
			pref.SetBool("TopMost", this.TopMost);
			pref.SetBool("IsClear", aeWeb1.IsClear);
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
					if ( LoadJson(s)==true)
					{
						break;
					}
				}
			}
		}
		//-------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		//-------------------------------------------------------------
		public bool LoadJson(string p)
		{
			bool ret = false;
			string ext = Path.GetExtension(p).ToLower();
			if (ext != ".json") return ret;
			if (aeWeb1.LoadJson(p) == true)
			{

				if (aeWeb1.title!="")
				{
					this.Text = aeWeb1.title;
				}

				if ( (aeWeb1.WinWidth>10)&&(aeWeb1.WinHeight>10))
				{
					this.Size = aeWeb1.WinSize;
				}
				if(aeWeb1.isCenter)
				{
					Center();
				}else if ((aeWeb1.WinLeft != 0) && (aeWeb1.WinTop != 0))
				{
					this.Location = aeWeb1.WinLocation;
				}
			}
			return ret; 
		}
		//-------------------------------------------------------------
		public void Center()
		{
			Rectangle rct = Screen.PrimaryScreen.Bounds;

			int x = (rct.Width - this.Width) / 2 + rct.X;
			int y = (rct.Height - this.Height) / 2 + rct.Y;
			this.Location = new Point(x, y);
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void cbTopMost_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = cbTopMost.Checked;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			aeWeb1.Clear();
		}

		private void cbIsClear_CheckedChanged(object sender, EventArgs e)
		{
			aeWeb1.IsClear = cbIsClear.Checked;
		}
		//-------------------------------------------------------------

	}
}
