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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnFileOpen = new System.Windows.Forms.ToolStripButton();
			this.btnSelectFolder = new System.Windows.Forms.ToolStripButton();
			this.btnPrev = new System.Windows.Forms.ToolStripButton();
			this.btnNext = new System.Windows.Forms.ToolStripButton();
			this.btnScaaleHarf = new System.Windows.Forms.ToolStripButton();
			this.btnScale1 = new System.Windows.Forms.ToolStripButton();
			this.btnScale2 = new System.Windows.Forms.ToolStripButton();
			this.btnScale3 = new System.Windows.Forms.ToolStripButton();
			this.btnScale4 = new System.Windows.Forms.ToolStripButton();
			this.btnHor = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.pictureView1 = new AE_Util_skelton.PictureView();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureView1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileOpen,
            this.btnSelectFolder,
            this.btnPrev,
            this.btnNext,
            this.btnScaaleHarf,
            this.btnScale1,
            this.btnScale2,
            this.btnScale3,
            this.btnScale4,
            this.btnHor});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(484, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
			// 
			// btnFileOpen
			// 
			this.btnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnFileOpen.Image")));
			this.btnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFileOpen.Name = "btnFileOpen";
			this.btnFileOpen.Size = new System.Drawing.Size(40, 22);
			this.btnFileOpen.Text = "Open";
			this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
			// 
			// btnSelectFolder
			// 
			this.btnSelectFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFolder.Image")));
			this.btnSelectFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSelectFolder.Name = "btnSelectFolder";
			this.btnSelectFolder.Size = new System.Drawing.Size(44, 22);
			this.btnSelectFolder.Text = "Folder";
			this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click_1);
			// 
			// btnPrev
			// 
			this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
			this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(23, 22);
			this.btnPrev.Text = "前";
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnNext
			// 
			this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(23, 22);
			this.btnNext.Text = "次";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnScaaleHarf
			// 
			this.btnScaaleHarf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScaaleHarf.Image = ((System.Drawing.Image)(resources.GetObject("btnScaaleHarf.Image")));
			this.btnScaaleHarf.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScaaleHarf.Name = "btnScaaleHarf";
			this.btnScaaleHarf.Size = new System.Drawing.Size(52, 22);
			this.btnScaaleHarf.Text = "1/2表示";
			this.btnScaaleHarf.Click += new System.EventHandler(this.btnScale_Click);
			// 
			// btnScale1
			// 
			this.btnScale1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScale1.Image = ((System.Drawing.Image)(resources.GetObject("btnScale1.Image")));
			this.btnScale1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScale1.Name = "btnScale1";
			this.btnScale1.Size = new System.Drawing.Size(35, 22);
			this.btnScale1.Text = "等倍";
			this.btnScale1.Click += new System.EventHandler(this.btnScale_Click);
			// 
			// btnScale2
			// 
			this.btnScale2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScale2.Image = ((System.Drawing.Image)(resources.GetObject("btnScale2.Image")));
			this.btnScale2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScale2.Name = "btnScale2";
			this.btnScale2.Size = new System.Drawing.Size(35, 22);
			this.btnScale2.Text = "２倍";
			this.btnScale2.Click += new System.EventHandler(this.btnScale_Click);
			// 
			// btnScale3
			// 
			this.btnScale3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScale3.Image = ((System.Drawing.Image)(resources.GetObject("btnScale3.Image")));
			this.btnScale3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScale3.Name = "btnScale3";
			this.btnScale3.Size = new System.Drawing.Size(35, 22);
			this.btnScale3.Text = "３倍";
			this.btnScale3.Click += new System.EventHandler(this.btnScale_Click);
			// 
			// btnScale4
			// 
			this.btnScale4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScale4.Image = ((System.Drawing.Image)(resources.GetObject("btnScale4.Image")));
			this.btnScale4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScale4.Name = "btnScale4";
			this.btnScale4.Size = new System.Drawing.Size(35, 22);
			this.btnScale4.Text = "４倍";
			this.btnScale4.Click += new System.EventHandler(this.btnScale_Click);
			// 
			// btnHor
			// 
			this.btnHor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnHor.Image = ((System.Drawing.Image)(resources.GetObject("btnHor.Image")));
			this.btnHor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHor.Name = "btnHor";
			this.btnHor.Size = new System.Drawing.Size(47, 22);
			this.btnHor.Text = "水平線";
			this.btnHor.Click += new System.EventHandler(this.btnHor_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pictureView1
			// 
			this.pictureView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureView1.DrawHor = false;
			this.pictureView1.Location = new System.Drawing.Point(12, 28);
			this.pictureView1.Name = "pictureView1";
			this.pictureView1.Size = new System.Drawing.Size(460, 513);
			this.pictureView1.TabIndex = 2;
			this.pictureView1.TabStop = false;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 553);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.pictureView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "]ImageViwer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private AE_Util_skelton.PictureView pictureView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnFileOpen;
		private System.Windows.Forms.ToolStripButton btnSelectFolder;
		private System.Windows.Forms.ToolStripButton btnPrev;
		private System.Windows.Forms.ToolStripButton btnNext;
		private System.Windows.Forms.ToolStripButton btnScaaleHarf;
		private System.Windows.Forms.ToolStripButton btnScale1;
		private System.Windows.Forms.ToolStripButton btnScale2;
		private System.Windows.Forms.ToolStripButton btnScale3;
		private System.Windows.Forms.ToolStripButton btnScale4;
		private System.Windows.Forms.ToolStripButton btnHor;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}

