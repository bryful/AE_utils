namespace AE_Menu
{
	partial class ExportDialog
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
			this.rbAbs = new System.Windows.Forms.RadioButton();
			this.rbRel = new System.Windows.Forms.RadioButton();
			this.tbPath = new System.Windows.Forms.TextBox();
			this.btnFolder = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rbAbs
			// 
			this.rbAbs.AutoSize = true;
			this.rbAbs.Checked = true;
			this.rbAbs.Location = new System.Drawing.Point(48, 25);
			this.rbAbs.Name = "rbAbs";
			this.rbAbs.Size = new System.Drawing.Size(144, 16);
			this.rbAbs.TabIndex = 0;
			this.rbAbs.TabStop = true;
			this.rbAbs.Text = "フォルダを絶対パスで保存";
			this.rbAbs.UseVisualStyleBackColor = true;
			this.rbAbs.Click += new System.EventHandler(this.rbAbs_Click);
			// 
			// rbRel
			// 
			this.rbRel.AutoSize = true;
			this.rbRel.Location = new System.Drawing.Point(223, 25);
			this.rbRel.Name = "rbRel";
			this.rbRel.Size = new System.Drawing.Size(144, 16);
			this.rbRel.TabIndex = 1;
			this.rbRel.Text = "フォルダを相対パスで保存";
			this.rbRel.UseVisualStyleBackColor = true;
			this.rbRel.Click += new System.EventHandler(this.rbAbs_Click);
			// 
			// tbPath
			// 
			this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPath.Location = new System.Drawing.Point(38, 85);
			this.tbPath.Name = "tbPath";
			this.tbPath.ReadOnly = true;
			this.tbPath.Size = new System.Drawing.Size(582, 19);
			this.tbPath.TabIndex = 2;
			// 
			// btnFolder
			// 
			this.btnFolder.Location = new System.Drawing.Point(38, 56);
			this.btnFolder.Name = "btnFolder";
			this.btnFolder.Size = new System.Drawing.Size(75, 23);
			this.btnFolder.TabIndex = 3;
			this.btnFolder.Text = "set folder";
			this.btnFolder.UseVisualStyleBackColor = true;
			this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(413, 121);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(514, 121);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// ExportDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(648, 172);
			this.ControlBox = false;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFolder);
			this.Controls.Add(this.tbPath);
			this.Controls.Add(this.rbRel);
			this.Controls.Add(this.rbAbs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExportDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ExportDialog";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbAbs;
		private System.Windows.Forms.RadioButton rbRel;
		private System.Windows.Forms.TextBox tbPath;
		private System.Windows.Forms.Button btnFolder;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}