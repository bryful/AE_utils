namespace AE_Menu
{
	partial class ColorEditDialog
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.colorBox1 = new AE_Menu.ColorBox();
			this.btnFore = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(100, 84);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 28);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(181, 84);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 28);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// colorBox1
			// 
			this.colorBox1.BackColor = System.Drawing.Color.DarkGray;
			this.colorBox1.DispText = "JSXファイル";
			this.colorBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.colorBox1.ForeColor = System.Drawing.Color.White;
			this.colorBox1.Location = new System.Drawing.Point(12, 12);
			this.colorBox1.Name = "colorBox1";
			this.colorBox1.Size = new System.Drawing.Size(218, 49);
			this.colorBox1.TabIndex = 0;
			this.colorBox1.TargetColor = System.Drawing.Color.DarkGray;
			this.colorBox1.Text = "colorBox1";
			this.colorBox1.TextColor = System.Drawing.Color.White;
			// 
			// btnFore
			// 
			this.btnFore.Location = new System.Drawing.Point(12, 84);
			this.btnFore.Name = "btnFore";
			this.btnFore.Size = new System.Drawing.Size(52, 28);
			this.btnFore.TabIndex = 5;
			this.btnFore.Text = "文字";
			this.btnFore.UseVisualStyleBackColor = true;
			this.btnFore.Click += new System.EventHandler(this.btnFore_Click);
			// 
			// ColorEditDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(279, 124);
			this.ControlBox = false;
			this.Controls.Add(this.btnFore);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.colorBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColorEditDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ColorEditDialog";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private ColorBox colorBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnFore;
	}
}