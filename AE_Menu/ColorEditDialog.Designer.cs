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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.colorBox3 = new AE_Menu.ColorBox();
			this.colorBox2 = new AE_Menu.ColorBox();
			this.colorBox1 = new AE_Menu.ColorBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 150);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(372, 150);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "Jsxファイルの背景色";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(329, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "JsxBinファイルの背景色";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(170, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "ffxファイルの背景色";
			// 
			// colorBox3
			// 
			this.colorBox3.BackColor = System.Drawing.Color.DarkGray;
			this.colorBox3.DispText = "JSXBINファイル";
			this.colorBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.colorBox3.ForeColor = System.Drawing.Color.White;
			this.colorBox3.Location = new System.Drawing.Point(331, 31);
			this.colorBox3.Name = "colorBox3";
			this.colorBox3.Size = new System.Drawing.Size(136, 92);
			this.colorBox3.TabIndex = 2;
			this.colorBox3.TargetColor = System.Drawing.Color.DarkGray;
			this.colorBox3.Text = "colorBox3";
			// 
			// colorBox2
			// 
			this.colorBox2.BackColor = System.Drawing.Color.DarkGray;
			this.colorBox2.DispText = "FFXファイル";
			this.colorBox2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.colorBox2.ForeColor = System.Drawing.Color.White;
			this.colorBox2.Location = new System.Drawing.Point(172, 31);
			this.colorBox2.Name = "colorBox2";
			this.colorBox2.Size = new System.Drawing.Size(136, 92);
			this.colorBox2.TabIndex = 1;
			this.colorBox2.TargetColor = System.Drawing.Color.DarkGray;
			this.colorBox2.Text = "colorBox2";
			// 
			// colorBox1
			// 
			this.colorBox1.BackColor = System.Drawing.Color.DarkGray;
			this.colorBox1.DispText = "JSXファイル";
			this.colorBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.colorBox1.ForeColor = System.Drawing.Color.White;
			this.colorBox1.Location = new System.Drawing.Point(21, 31);
			this.colorBox1.Name = "colorBox1";
			this.colorBox1.Size = new System.Drawing.Size(136, 92);
			this.colorBox1.TabIndex = 0;
			this.colorBox1.TargetColor = System.Drawing.Color.DarkGray;
			this.colorBox1.Text = "colorBox1";
			// 
			// ColorEditDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(485, 188);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.colorBox3);
			this.Controls.Add(this.colorBox2);
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
			this.PerformLayout();

		}

		#endregion

		private ColorBox colorBox1;
		private ColorBox colorBox2;
		private ColorBox colorBox3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}