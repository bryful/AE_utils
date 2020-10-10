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
			this.selectDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.editCaptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cellColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.peasteColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sizeSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenuTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iconButtonList1 = new AE_Menu.IconButtonList();
			this.editAllFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDirToolStripMenuItem,
            this.toolStripMenuItem4,
            this.buttonSizeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editCaptionToolStripMenuItem,
            this.cellColorToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.copyColorToolStripMenuItem,
            this.peasteColorToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sizeSettingToolStripMenuItem,
            this.editMenuTitleToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.allColorToolStripMenuItem,
            this.editAllFontToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exportToolStripMenuItem,
            this.exportPictToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 380);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// selectDirToolStripMenuItem
			// 
			this.selectDirToolStripMenuItem.Name = "selectDirToolStripMenuItem";
			this.selectDirToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.selectDirToolStripMenuItem.Text = "SelectDir";
			this.selectDirToolStripMenuItem.Click += new System.EventHandler(this.selectDirToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 6);
			// 
			// buttonSizeToolStripMenuItem
			// 
			this.buttonSizeToolStripMenuItem.Name = "buttonSizeToolStripMenuItem";
			this.buttonSizeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.buttonSizeToolStripMenuItem.Text = "EditPalette";
			this.buttonSizeToolStripMenuItem.Click += new System.EventHandler(this.buttonSizeToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
			// 
			// editCaptionToolStripMenuItem
			// 
			this.editCaptionToolStripMenuItem.Name = "editCaptionToolStripMenuItem";
			this.editCaptionToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.editCaptionToolStripMenuItem.Text = "EditCaption";
			this.editCaptionToolStripMenuItem.Click += new System.EventHandler(this.editCaptionToolStripMenuItem_Click);
			// 
			// cellColorToolStripMenuItem
			// 
			this.cellColorToolStripMenuItem.Name = "cellColorToolStripMenuItem";
			this.cellColorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.cellColorToolStripMenuItem.Text = "EditCellColor";
			this.cellColorToolStripMenuItem.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.fontToolStripMenuItem.Text = "EditFont";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
			// 
			// copyColorToolStripMenuItem
			// 
			this.copyColorToolStripMenuItem.Name = "copyColorToolStripMenuItem";
			this.copyColorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyColorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.copyColorToolStripMenuItem.Text = "CopyColor";
			this.copyColorToolStripMenuItem.Click += new System.EventHandler(this.copyColorToolStripMenuItem_Click);
			// 
			// peasteColorToolStripMenuItem
			// 
			this.peasteColorToolStripMenuItem.Name = "peasteColorToolStripMenuItem";
			this.peasteColorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.peasteColorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.peasteColorToolStripMenuItem.Text = "PeasteColor";
			this.peasteColorToolStripMenuItem.Click += new System.EventHandler(this.peasteColorToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
			// 
			// sizeSettingToolStripMenuItem
			// 
			this.sizeSettingToolStripMenuItem.Name = "sizeSettingToolStripMenuItem";
			this.sizeSettingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.sizeSettingToolStripMenuItem.Text = "SizeSetting";
			this.sizeSettingToolStripMenuItem.Click += new System.EventHandler(this.sizeSettingToolStripMenuItem_Click);
			// 
			// editMenuTitleToolStripMenuItem
			// 
			this.editMenuTitleToolStripMenuItem.Name = "editMenuTitleToolStripMenuItem";
			this.editMenuTitleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.editMenuTitleToolStripMenuItem.Text = "EditMenuTitle";
			this.editMenuTitleToolStripMenuItem.Click += new System.EventHandler(this.editMenuTitleToolStripMenuItem_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// allColorToolStripMenuItem
			// 
			this.allColorToolStripMenuItem.Name = "allColorToolStripMenuItem";
			this.allColorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.allColorToolStripMenuItem.Text = "AllColor";
			this.allColorToolStripMenuItem.Click += new System.EventHandler(this.allColorToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 6);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.exportToolStripMenuItem.Text = "ExportScript";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click_1);
			// 
			// exportPictToolStripMenuItem
			// 
			this.exportPictToolStripMenuItem.Name = "exportPictToolStripMenuItem";
			this.exportPictToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.exportPictToolStripMenuItem.Text = "ExportPict";
			this.exportPictToolStripMenuItem.Click += new System.EventHandler(this.exportIconToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// iconButtonList1
			// 
			this.iconButtonList1.BackColor = System.Drawing.SystemColors.Control;
			this.iconButtonList1.BackFFX = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
			this.iconButtonList1.BackJSX = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.iconButtonList1.BackJSXBIN = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.iconButtonList1.ButtonSize = new System.Drawing.Size(240, 20);
			this.iconButtonList1.ContextMenuStrip = this.contextMenuStrip1;
			this.iconButtonList1.ForeColor = System.Drawing.Color.Black;
			this.iconButtonList1.Form = this;
			this.iconButtonList1.Location = new System.Drawing.Point(0, 0);
			this.iconButtonList1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.iconButtonList1.MaximumSize = new System.Drawing.Size(400, 32);
			this.iconButtonList1.MenuName = "";
			this.iconButtonList1.MinimumSize = new System.Drawing.Size(400, 32);
			this.iconButtonList1.Name = "iconButtonList1";
			this.iconButtonList1.RelativePath = false;
			this.iconButtonList1.SelectedIndex = -1;
			this.iconButtonList1.Size = new System.Drawing.Size(400, 32);
			this.iconButtonList1.TabIndex = 2;
			this.iconButtonList1.TargetDir = "";
			this.iconButtonList1.Text = "iconButtonList1";
			this.iconButtonList1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			// 
			// editAllFontToolStripMenuItem
			// 
			this.editAllFontToolStripMenuItem.Name = "editAllFontToolStripMenuItem";
			this.editAllFontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editAllFontToolStripMenuItem.Text = "EditAllFont";
			this.editAllFontToolStripMenuItem.Click += new System.EventHandler(this.editAllFontToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 43);
			this.Controls.Add(this.iconButtonList1);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(266, 45);
			this.Name = "Form1";
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
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private IconButtonList iconButtonList1;
		private System.Windows.Forms.ToolStripMenuItem buttonSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sizeSettingToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editCaptionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editMenuTitleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem cellColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem peasteColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPictToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectDirToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem editAllFontToolStripMenuItem;
	}
}

