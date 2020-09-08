namespace AE_Menu
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
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iNportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iconButtonList1 = new AE_Menu.IconButtonList();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uPToolStripMenuItem,
            this.downToolStripMenuItem,
            this.buttonSizeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addToolStripMenuItem,
            this.iNportToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(139, 242);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.addToolStripMenuItem.Text = "AddScript";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// iNportToolStripMenuItem
			// 
			this.iNportToolStripMenuItem.Name = "iNportToolStripMenuItem";
			this.iNportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.iNportToolStripMenuItem.Text = "InportScript";
			this.iNportToolStripMenuItem.Click += new System.EventHandler(this.iNportToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// uPToolStripMenuItem
			// 
			this.uPToolStripMenuItem.Name = "uPToolStripMenuItem";
			this.uPToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.uPToolStripMenuItem.Text = "UP";
			// 
			// downToolStripMenuItem
			// 
			this.downToolStripMenuItem.Name = "downToolStripMenuItem";
			this.downToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.downToolStripMenuItem.Text = "Down";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(135, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.exportToolStripMenuItem.Text = "ExportScript";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// buttonSizeToolStripMenuItem
			// 
			this.buttonSizeToolStripMenuItem.Name = "buttonSizeToolStripMenuItem";
			this.buttonSizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.buttonSizeToolStripMenuItem.Text = "ButtonSize";
			// 
			// iconButtonList1
			// 
			this.iconButtonList1.ContextMenuStrip = this.contextMenuStrip1;
			this.iconButtonList1.Form = this;
			this.iconButtonList1.Location = new System.Drawing.Point(0, 0);
			this.iconButtonList1.MaximumSize = new System.Drawing.Size(150, 0);
			this.iconButtonList1.Name = "iconButtonList1";
			this.iconButtonList1.Size = new System.Drawing.Size(150, 54);
			this.iconButtonList1.TabIndex = 2;
			this.iconButtonList1.Text = "iconButtonList1";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 124);
			this.Controls.Add(this.iconButtonList1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(166, 0);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Form1";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem uPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iNportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private IconButtonList iconButtonList1;
		private System.Windows.Forms.ToolStripMenuItem buttonSizeToolStripMenuItem;
	}
}

