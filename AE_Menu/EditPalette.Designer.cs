namespace AE_Menu
{
	partial class EditPalette
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnEditCaption = new System.Windows.Forms.Button();
			this.btnFont = new System.Windows.Forms.Button();
			this.btnCellColor = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUp.Location = new System.Drawing.Point(2, 12);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(137, 32);
			this.btnUp.TabIndex = 3;
			this.btnUp.Text = "UP";
			this.btnUp.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDown.Location = new System.Drawing.Point(2, 54);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(137, 32);
			this.btnDown.TabIndex = 4;
			this.btnDown.Text = "DOWN";
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(76, 285);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(63, 30);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnEditCaption
			// 
			this.btnEditCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditCaption.Location = new System.Drawing.Point(2, 113);
			this.btnEditCaption.Name = "btnEditCaption";
			this.btnEditCaption.Size = new System.Drawing.Size(137, 32);
			this.btnEditCaption.TabIndex = 8;
			this.btnEditCaption.Text = "Edit Caption";
			this.btnEditCaption.UseVisualStyleBackColor = true;
			// 
			// btnFont
			// 
			this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFont.Location = new System.Drawing.Point(2, 151);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(137, 32);
			this.btnFont.TabIndex = 10;
			this.btnFont.Text = "Edit Font";
			this.btnFont.UseVisualStyleBackColor = true;
			// 
			// btnCellColor
			// 
			this.btnCellColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCellColor.Location = new System.Drawing.Point(2, 189);
			this.btnCellColor.Name = "btnCellColor";
			this.btnCellColor.Size = new System.Drawing.Size(137, 32);
			this.btnCellColor.TabIndex = 11;
			this.btnCellColor.Text = "Edit CellColor";
			this.btnCellColor.UseVisualStyleBackColor = true;
			// 
			// EditPalette
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(151, 327);
			this.ControlBox = false;
			this.Controls.Add(this.btnCellColor);
			this.Controls.Add(this.btnFont);
			this.Controls.Add(this.btnEditCaption);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditPalette";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "EditPalette";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnEditCaption;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.Button btnCellColor;
	}
}