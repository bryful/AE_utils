namespace BRY
{
	partial class AppInfoDialog
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbCanpany = new System.Windows.Forms.Label();
			this.lbVersion = new System.Windows.Forms.Label();
			this.lbCopyright = new System.Windows.Forms.Label();
			this.lbDescription = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.lbProduct = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(21, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(128, 128);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lbCanpany
			// 
			this.lbCanpany.AutoSize = true;
			this.lbCanpany.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbCanpany.Location = new System.Drawing.Point(155, 22);
			this.lbCanpany.Name = "lbCanpany";
			this.lbCanpany.Size = new System.Drawing.Size(70, 19);
			this.lbCanpany.TabIndex = 1;
			this.lbCanpany.Text = "bry-ful ";
			// 
			// lbVersion
			// 
			this.lbVersion.AutoSize = true;
			this.lbVersion.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbVersion.Location = new System.Drawing.Point(155, 106);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(167, 19);
			this.lbVersion.TabIndex = 2;
			this.lbVersion.Text = "Version 215435454";
			// 
			// lbCopyright
			// 
			this.lbCopyright.AutoSize = true;
			this.lbCopyright.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbCopyright.Location = new System.Drawing.Point(156, 129);
			this.lbCopyright.Name = "lbCopyright";
			this.lbCopyright.Size = new System.Drawing.Size(78, 16);
			this.lbCopyright.TabIndex = 3;
			this.lbCopyright.Text = "コピーライト";
			// 
			// lbDescription
			// 
			this.lbDescription.AutoSize = true;
			this.lbDescription.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbDescription.Location = new System.Drawing.Point(18, 160);
			this.lbDescription.Name = "lbDescription";
			this.lbDescription.Size = new System.Drawing.Size(40, 16);
			this.lbDescription.TabIndex = 4;
			this.lbDescription.Text = "説明";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(289, 170);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 33);
			this.button1.TabIndex = 5;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// lbProduct
			// 
			this.lbProduct.AutoSize = true;
			this.lbProduct.BackColor = System.Drawing.Color.DarkGray;
			this.lbProduct.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbProduct.Location = new System.Drawing.Point(155, 59);
			this.lbProduct.Name = "lbProduct";
			this.lbProduct.Size = new System.Drawing.Size(97, 27);
			this.lbProduct.TabIndex = 6;
			this.lbProduct.Text = "bry-ful ";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
			this.pictureBox2.Location = new System.Drawing.Point(3, 46);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(389, 55);
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			// 
			// AppInfoDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 215);
			this.Controls.Add(this.lbProduct);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbDescription);
			this.Controls.Add(this.lbCopyright);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.lbCanpany);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AppInfoDialog";
			this.Text = "AppInfoDialog";
			this.Load += new System.EventHandler(this.AppInfoDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbCanpany;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Label lbCopyright;
		private System.Windows.Forms.Label lbDescription;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbProduct;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}