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
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbInstalled = new System.Windows.Forms.ListBox();
			this.btnInstalled = new System.Windows.Forms.Button();
			this.cmbAE = new System.Windows.Forms.ComboBox();
			this.lbProcess = new System.Windows.Forms.ListBox();
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.ttbScriptCode = new System.Windows.Forms.TextBox();
			this.btnScriptCode = new System.Windows.Forms.Button();
			this.nFsAE1 = new BRY.NFsAE();
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
			this.menuStrip1.Size = new System.Drawing.Size(621, 24);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 412);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(621, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbInstalled
			// 
			this.lbInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbInstalled.FormattingEnabled = true;
			this.lbInstalled.ItemHeight = 12;
			this.lbInstalled.Location = new System.Drawing.Point(12, 37);
			this.lbInstalled.Name = "lbInstalled";
			this.lbInstalled.Size = new System.Drawing.Size(601, 52);
			this.lbInstalled.TabIndex = 2;
			// 
			// btnInstalled
			// 
			this.btnInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInstalled.Location = new System.Drawing.Point(12, 95);
			this.btnInstalled.Name = "btnInstalled";
			this.btnInstalled.Size = new System.Drawing.Size(601, 44);
			this.btnInstalled.TabIndex = 3;
			this.btnInstalled.Text = "インストールされているAEをリストアップ";
			this.btnInstalled.UseVisualStyleBackColor = true;
			this.btnInstalled.Click += new System.EventHandler(this.btnInstalled_Click);
			// 
			// cmbAE
			// 
			this.cmbAE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAE.FormattingEnabled = true;
			this.cmbAE.Location = new System.Drawing.Point(12, 278);
			this.cmbAE.Name = "cmbAE";
			this.cmbAE.Size = new System.Drawing.Size(244, 20);
			this.cmbAE.TabIndex = 4;
			// 
			// lbProcess
			// 
			this.lbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbProcess.FormattingEnabled = true;
			this.lbProcess.ItemHeight = 12;
			this.lbProcess.Location = new System.Drawing.Point(8, 157);
			this.lbProcess.Name = "lbProcess";
			this.lbProcess.Size = new System.Drawing.Size(601, 52);
			this.lbProcess.TabIndex = 6;
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Location = new System.Drawing.Point(8, 215);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(601, 44);
			this.btnProcess.TabIndex = 7;
			this.btnProcess.Text = "実行中のAEをリストアップ";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(273, 266);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(287, 43);
			this.btnRun.TabIndex = 8;
			this.btnRun.Text = "ドロップダウンで選んだAEを起動";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// ttbScriptCode
			// 
			this.ttbScriptCode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ttbScriptCode.Location = new System.Drawing.Point(12, 336);
			this.ttbScriptCode.Name = "ttbScriptCode";
			this.ttbScriptCode.Size = new System.Drawing.Size(244, 23);
			this.ttbScriptCode.TabIndex = 9;
			this.ttbScriptCode.Text = "writeLn(\"OK!\");";
			// 
			// btnScriptCode
			// 
			this.btnScriptCode.Location = new System.Drawing.Point(273, 328);
			this.btnScriptCode.Name = "btnScriptCode";
			this.btnScriptCode.Size = new System.Drawing.Size(287, 43);
			this.btnScriptCode.TabIndex = 10;
			this.btnScriptCode.Text = "ドロップダウンで選んだAEでスクリプト起動";
			this.btnScriptCode.UseVisualStyleBackColor = true;
			this.btnScriptCode.Click += new System.EventHandler(this.btnScriptCode_Click);
			// 
			// nFsAE1
			// 
			this.nFsAE1.CombTargetAE = this.cmbAE;
			this.nFsAE1.TargetAE = "CC 2019";
			this.nFsAE1.TargetAEIndex = 1;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 434);
			this.Controls.Add(this.btnScriptCode);
			this.Controls.Add(this.ttbScriptCode);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.lbProcess);
			this.Controls.Add(this.cmbAE);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnInstalled);
			this.Controls.Add(this.lbInstalled);
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
        private System.Windows.Forms.ListBox lbInstalled;
        private System.Windows.Forms.Button btnInstalled;
		private BRY.NFsAE nFsAE1;
		private System.Windows.Forms.ComboBox cmbAE;
		private System.Windows.Forms.ListBox lbProcess;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.TextBox ttbScriptCode;
		private System.Windows.Forms.Button btnScriptCode;
	}
}

