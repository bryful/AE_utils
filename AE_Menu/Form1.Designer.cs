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
			this.selectDirMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.ShowEditPatelleMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.editCaptionMI = new System.Windows.Forms.ToolStripMenuItem();
			this.EditCellColorMI = new System.Windows.Forms.ToolStripMenuItem();
			this.EditCellFontMI = new System.Windows.Forms.ToolStripMenuItem();
			this.CopyMI = new System.Windows.Forms.ToolStripMenuItem();
			this.PeasteMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ShowSizeSettingMI = new System.Windows.Forms.ToolStripMenuItem();
			this.EditMenuTitleMI = new System.Windows.Forms.ToolStripMenuItem();
			this.EditAllColorMI = new System.Windows.Forms.ToolStripMenuItem();
			this.EditAllFontMI = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearM = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportScriptMI = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportPictOnlyMI = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitMI = new System.Windows.Forms.ToolStripMenuItem();
			this.iconButtonList1 = new AE_Menu.IconButtonList();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDirMI,
            this.toolStripMenuItem4,
            this.ShowEditPatelleMI,
            this.toolStripMenuItem2,
            this.editCaptionMI,
            this.EditCellColorMI,
            this.EditCellFontMI,
            this.CopyMI,
            this.PeasteMI,
            this.toolStripMenuItem1,
            this.ShowSizeSettingMI,
            this.EditMenuTitleMI,
            this.EditAllColorMI,
            this.EditAllFontMI,
            this.ClearM,
            this.toolStripMenuItem3,
            this.ExportScriptMI,
            this.ExportPictOnlyMI,
            this.ExitMI});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(206, 380);
			// 
			// selectDirMI
			// 
			this.selectDirMI.Name = "selectDirMI";
			this.selectDirMI.Size = new System.Drawing.Size(180, 22);
			this.selectDirMI.Text = "SelectScriptDir";
			this.selectDirMI.Click += new System.EventHandler(this.SelectDirMI_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
			// 
			// ShowEditPatelleMI
			// 
			this.ShowEditPatelleMI.Name = "ShowEditPatelleMI";
			this.ShowEditPatelleMI.Size = new System.Drawing.Size(180, 22);
			this.ShowEditPatelleMI.Text = "Show_EditPalette";
			this.ShowEditPatelleMI.Click += new System.EventHandler(this.ShowEditPaletteMI_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
			// 
			// editCaptionMI
			// 
			this.editCaptionMI.Name = "editCaptionMI";
			this.editCaptionMI.Size = new System.Drawing.Size(180, 22);
			this.editCaptionMI.Text = "EditCaption";
			this.editCaptionMI.Click += new System.EventHandler(this.ShowEditCaptionMI_Click);
			// 
			// EditCellColorMI
			// 
			this.EditCellColorMI.Name = "EditCellColorMI";
			this.EditCellColorMI.Size = new System.Drawing.Size(180, 22);
			this.EditCellColorMI.Text = "EditCellColor";
			this.EditCellColorMI.Click += new System.EventHandler(this.EditCellColorMI_Click);
			// 
			// EditCellFontMI
			// 
			this.EditCellFontMI.Name = "EditCellFontMI";
			this.EditCellFontMI.Size = new System.Drawing.Size(180, 22);
			this.EditCellFontMI.Text = "EditCellFont";
			this.EditCellFontMI.Click += new System.EventHandler(this.EditCellFontMI_Click);
			// 
			// CopyMI
			// 
			this.CopyMI.Name = "CopyMI";
			this.CopyMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.CopyMI.Size = new System.Drawing.Size(205, 22);
			this.CopyMI.Text = "CopyColor_Font";
			this.CopyMI.Click += new System.EventHandler(this.CopyMI_Click);
			// 
			// PeasteMI
			// 
			this.PeasteMI.Name = "PeasteMI";
			this.PeasteMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.PeasteMI.Size = new System.Drawing.Size(205, 22);
			this.PeasteMI.Text = "PeasteColor_Font";
			this.PeasteMI.Click += new System.EventHandler(this.PasteMI_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
			// 
			// ShowSizeSettingMI
			// 
			this.ShowSizeSettingMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.ShowSizeSettingMI.Name = "ShowSizeSettingMI";
			this.ShowSizeSettingMI.Size = new System.Drawing.Size(180, 22);
			this.ShowSizeSettingMI.Text = "ShowSizeSetting";
			this.ShowSizeSettingMI.Click += new System.EventHandler(this.ShowSizeSettingMI_Click);
			// 
			// EditMenuTitleMI
			// 
			this.EditMenuTitleMI.Name = "EditMenuTitleMI";
			this.EditMenuTitleMI.Size = new System.Drawing.Size(180, 22);
			this.EditMenuTitleMI.Text = "EditMenuTitle";
			this.EditMenuTitleMI.Click += new System.EventHandler(this.EditTitleMI_Click);
			// 
			// EditAllColorMI
			// 
			this.EditAllColorMI.Name = "EditAllColorMI";
			this.EditAllColorMI.Size = new System.Drawing.Size(180, 22);
			this.EditAllColorMI.Text = "EditAllColor";
			this.EditAllColorMI.Click += new System.EventHandler(this.EditAllColorMI_Click);
			// 
			// EditAllFontMI
			// 
			this.EditAllFontMI.Name = "EditAllFontMI";
			this.EditAllFontMI.Size = new System.Drawing.Size(180, 22);
			this.EditAllFontMI.Text = "EditAllFont";
			this.EditAllFontMI.Click += new System.EventHandler(this.EditAllFontMI_Click);
			// 
			// ClearM
			// 
			this.ClearM.Name = "ClearM";
			this.ClearM.Size = new System.Drawing.Size(180, 22);
			this.ClearM.Text = "Clear";
			this.ClearM.Click += new System.EventHandler(this.ClearMI_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
			// 
			// ExportScriptMI
			// 
			this.ExportScriptMI.Name = "ExportScriptMI";
			this.ExportScriptMI.Size = new System.Drawing.Size(180, 22);
			this.ExportScriptMI.Text = "ExportScript";
			this.ExportScriptMI.Click += new System.EventHandler(this.ExportScriptMI_Click);
			// 
			// ExportPictOnlyMI
			// 
			this.ExportPictOnlyMI.Name = "ExportPictOnlyMI";
			this.ExportPictOnlyMI.Size = new System.Drawing.Size(180, 22);
			this.ExportPictOnlyMI.Text = "ExportPictOnly";
			this.ExportPictOnlyMI.Click += new System.EventHandler(this.ExportPictOnlyMI_Click);
			// 
			// ExitMI
			// 
			this.ExitMI.Name = "ExitMI";
			this.ExitMI.Size = new System.Drawing.Size(180, 22);
			this.ExitMI.Text = "Exit";
			this.ExitMI.Click += new System.EventHandler(this.ExitMI_Click);
			// 
			// iconButtonList1
			// 
			this.iconButtonList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
			this.iconButtonList1.ButtonSize = new System.Drawing.Size(240, 20);
			this.iconButtonList1.ContextMenuStrip = this.contextMenuStrip1;
			this.iconButtonList1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButtonList1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.iconButtonList1.Form = this;
			this.iconButtonList1.Location = new System.Drawing.Point(0, 0);
			this.iconButtonList1.Margin = new System.Windows.Forms.Padding(5);
			this.iconButtonList1.MaximumSize = new System.Drawing.Size(240, 20);
			this.iconButtonList1.MenuName = "";
			this.iconButtonList1.MinimumSize = new System.Drawing.Size(240, 20);
			this.iconButtonList1.Name = "iconButtonList1";
			this.iconButtonList1.RelativePath = false;
			this.iconButtonList1.SelectedIndex = -1;
			this.iconButtonList1.Size = new System.Drawing.Size(240, 20);
			this.iconButtonList1.TabIndex = 2;
			this.iconButtonList1.TargetDir = "";
			this.iconButtonList1.Text = "iconButtonList1";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 20);
			this.Controls.Add(this.iconButtonList1);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5);
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
		private System.Windows.Forms.ToolStripMenuItem ExitMI;
		private IconButtonList iconButtonList1;
		private System.Windows.Forms.ToolStripMenuItem ShowEditPatelleMI;
		private System.Windows.Forms.ToolStripMenuItem ExportScriptMI;
		private System.Windows.Forms.ToolStripMenuItem ShowSizeSettingMI;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem EditCellFontMI;
		private System.Windows.Forms.ToolStripMenuItem editCaptionMI;
		private System.Windows.Forms.ToolStripMenuItem EditMenuTitleMI;
		private System.Windows.Forms.ToolStripMenuItem EditAllColorMI;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem EditCellColorMI;
		private System.Windows.Forms.ToolStripMenuItem CopyMI;
		private System.Windows.Forms.ToolStripMenuItem PeasteMI;
		private System.Windows.Forms.ToolStripMenuItem ExportPictOnlyMI;
		private System.Windows.Forms.ToolStripMenuItem ClearM;
		private System.Windows.Forms.ToolStripMenuItem selectDirMI;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem EditAllFontMI;
	}
}

