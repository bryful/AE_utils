namespace AE_ScriptShortCut
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.combKeys1 = new AE_ScriptShortCut.CombKeys();
			this.combAEVersion1 = new AE_ScriptShortCut.CombAEVersion();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(597, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.saveAsToolStripMenuItem.Text = "SaveAs";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.aboutToolStripMenuItem.Text = "バージョン情報の表示";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 367);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(597, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(0, 48);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(577, 316);
			this.listBox1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(305, 164);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// combKeys1
			// 
			this.combKeys1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combKeys1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.combKeys1.FormattingEnabled = true;
			this.combKeys1.Items.AddRange(new object[] {
            " Enter",
            " Delete",
            " Backspace",
            " Tab",
            " Return",
            " Esc",
            " LeftArrow",
            " RightArrow",
            " UpArrow",
            " DownArrow",
            " Space",
            " !",
            " DoubleQuote",
            " #",
            " $",
            " %",
            " &",
            " SingleQuote",
            " LParen",
            " RParen",
            " *",
            " Plus",
            " Comma",
            " -",
            " .",
            " /",
            " 0",
            " 1",
            " 2",
            " 3",
            " 4",
            " 5",
            " 6",
            " 7",
            " 8",
            " 9",
            " :",
            " ;",
            " <",
            " =",
            " >",
            " ?",
            " @",
            " A",
            " B",
            " C",
            " D",
            " E",
            " F",
            " G",
            " H",
            " I",
            " J",
            " K",
            " L",
            " M",
            " N",
            " O",
            " P",
            " Q",
            " R",
            " S",
            " T",
            " U",
            " V",
            " W",
            " X",
            " Y",
            " Z",
            " [",
            " Backslash",
            " ]",
            " ^",
            " _",
            " `",
            " {",
            " |",
            " }",
            " ~",
            " Umlaut_A",
            " Ring_A",
            " Cedilla_C",
            " Acute_E",
            " Tilde_N",
            " Umlaut_O",
            " Umlaut_U",
            " Acute_a",
            " Grave_a",
            " Circumflex_a",
            " Umlaut_a",
            " Tilde_a",
            " Ring_a",
            " Cedilla_c",
            " Acute_e",
            " Grave_e",
            " Circumflex_e",
            " Umlaut_e",
            " Acute_i",
            " Grave_i",
            " Circumflex_i",
            " Umlaut_i",
            " Tilde_n",
            " Acute_o",
            " Grave_o",
            " Circumflex_o",
            " Umlaut_o",
            " Tilde_o",
            " Acute_u",
            " Grave_u",
            " Circumflex_u",
            " Umlaut_u",
            " Section",
            " German_dbl_s",
            " Acute",
            " Yen",
            " Grave_A",
            " Tilde_A",
            " Tilde_O",
            " Umlaut_y",
            " Umlaut_Y",
            " Circumflex_A",
            " Circumflex_E",
            " Acute_A",
            " Umlaut_E",
            " Grave_E",
            " Acute_I",
            " Circumflex_I",
            " Umlaut_I",
            " Grave_I",
            " Acute_O",
            " Circumflex_O",
            " Grave_O",
            " Acute_U",
            " Circumflex_U",
            " Grave_U",
            " PadDecimal",
            " PadComma",
            " PadMultiply",
            " PadPlus",
            " PadClear",
            " PadSlash",
            " PadMinus",
            " PadEqual",
            " PadInsert",
            " PadDelete",
            " PadHome",
            " PadEnd",
            " PadPageUp",
            " PadPageDown",
            " Pad0",
            " Pad1",
            " Pad2",
            " Pad3",
            " Pad4",
            " Pad5",
            " Pad6",
            " Pad7",
            " Pad8",
            " Pad9",
            " F1",
            " F2",
            " F3",
            " F4",
            " F5",
            " F6",
            " F7",
            " F8",
            " F9",
            " F10",
            " F11",
            " F12",
            " F13",
            " F14",
            " F15",
            " F16",
            " F17",
            " F18",
            " F19",
            " F20",
            " F21",
            " F22",
            " F23",
            " F24",
            " HELP",
            " HOME",
            " PageUP",
            " FwdDel",
            " END",
            " PageDOWN",
            " NumLock",
            " Insert",
            " Pause",
            " CapsLock"});
			this.combKeys1.Location = new System.Drawing.Point(314, 80);
			this.combKeys1.MinimumSize = new System.Drawing.Size(110, 0);
			this.combKeys1.Name = "combKeys1";
			this.combKeys1.Size = new System.Drawing.Size(133, 24);
			this.combKeys1.TabIndex = 4;
			// 
			// combAEVersion1
			// 
			this.combAEVersion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combAEVersion1.FormattingEnabled = true;
			this.combAEVersion1.Location = new System.Drawing.Point(28, 228);
			this.combAEVersion1.MinimumSize = new System.Drawing.Size(100, 0);
			this.combAEVersion1.Name = "combAEVersion1";
			this.combAEVersion1.Size = new System.Drawing.Size(557, 20);
			this.combAEVersion1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 389);
			this.Controls.Add(this.combAEVersion1);
			this.Controls.Add(this.combKeys1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private CombKeys combKeys1;
		private CombAEVersion combAEVersion1;
	}
}

