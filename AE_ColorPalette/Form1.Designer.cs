namespace AE_Util_skelton
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
			this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lock2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palette1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palette2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palette3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palette4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palette5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(223, 24);
			this.menuStrip1.TabIndex = 25;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.lock2ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.paletteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem3,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// lockToolStripMenuItem
			// 
			this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
			this.lockToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.lockToolStripMenuItem.Text = "lockしてペースト不可にする";
			this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
			// 
			// lock2ToolStripMenuItem
			// 
			this.lock2ToolStripMenuItem.Name = "lock2ToolStripMenuItem";
			this.lock2ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.lock2ToolStripMenuItem.Text = "起動時常にLock状態にする";
			this.lock2ToolStripMenuItem.Click += new System.EventHandler(this.lock2ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
			// 
			// paletteToolStripMenuItem
			// 
			this.paletteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.palette1ToolStripMenuItem,
            this.palette2ToolStripMenuItem,
            this.palette3ToolStripMenuItem,
            this.palette4ToolStripMenuItem,
            this.palette5ToolStripMenuItem});
			this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
			this.paletteToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.paletteToolStripMenuItem.Text = "Palette";
			// 
			// palette1ToolStripMenuItem
			// 
			this.palette1ToolStripMenuItem.Name = "palette1ToolStripMenuItem";
			this.palette1ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.palette1ToolStripMenuItem.Text = "Palette1";
			// 
			// palette2ToolStripMenuItem
			// 
			this.palette2ToolStripMenuItem.Name = "palette2ToolStripMenuItem";
			this.palette2ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.palette2ToolStripMenuItem.Text = "Palette2";
			// 
			// palette3ToolStripMenuItem
			// 
			this.palette3ToolStripMenuItem.Name = "palette3ToolStripMenuItem";
			this.palette3ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.palette3ToolStripMenuItem.Text = "Palette3";
			// 
			// palette4ToolStripMenuItem
			// 
			this.palette4ToolStripMenuItem.Name = "palette4ToolStripMenuItem";
			this.palette4ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.palette4ToolStripMenuItem.Text = "Palette4";
			// 
			// palette5ToolStripMenuItem
			// 
			this.palette5ToolStripMenuItem.Name = "palette5ToolStripMenuItem";
			this.palette5ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.palette5ToolStripMenuItem.Text = "Palette5";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.laodToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyHexToolStripMenuItem,
            this.pasteHexToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// copyHexToolStripMenuItem
			// 
			this.copyHexToolStripMenuItem.Name = "copyHexToolStripMenuItem";
			this.copyHexToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			this.copyHexToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.copyHexToolStripMenuItem.Text = "CopyHex";
			this.copyHexToolStripMenuItem.Click += new System.EventHandler(this.copyHexToolStripMenuItem_Click);
			// 
			// pasteHexToolStripMenuItem
			// 
			this.pasteHexToolStripMenuItem.Name = "pasteHexToolStripMenuItem";
			this.pasteHexToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
			this.pasteHexToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.pasteHexToolStripMenuItem.Text = "PasteHex";
			this.pasteHexToolStripMenuItem.Click += new System.EventHandler(this.pasteHexToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(223, 487);
			this.Controls.Add(this.menuStrip1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lock2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteHexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem palette1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem palette2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem palette3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem palette4ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem palette5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
	}
}

