
namespace AfterFXControl
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
			this.btnRun = new System.Windows.Forms.Button();
			this.cmbInstalled = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.nFsAECmp1 = new BRY.NFsAECmp();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(140, 0);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(36, 20);
			this.btnRun.TabIndex = 3;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			// 
			// cmbInstalled
			// 
			this.cmbInstalled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInstalled.FormattingEnabled = true;
			this.cmbInstalled.Items.AddRange(new object[] {
            "CS6",
            "CC 2019",
            "2020"});
			this.cmbInstalled.Location = new System.Drawing.Point(54, 0);
			this.cmbInstalled.Name = "cmbInstalled";
			this.cmbInstalled.Size = new System.Drawing.Size(80, 20);
			this.cmbInstalled.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.CausesValidation = false;
			this.label1.Location = new System.Drawing.Point(0, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Installed";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.CausesValidation = false;
			this.label2.Location = new System.Drawing.Point(182, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "Running";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(320, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 21);
			this.button1.TabIndex = 9;
			this.button1.Text = "MAX";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(365, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(36, 21);
			this.button2.TabIndex = 10;
			this.button2.Text = "MIN";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "",
            "",
            ""});
			this.comboBox2.Location = new System.Drawing.Point(234, 0);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(80, 20);
			this.comboBox2.TabIndex = 8;
			// 
			// nFsAECmp1
			// 
			this.nFsAECmp1.AeWin = "aeWin.exe";
			this.nFsAECmp1.BtnRun = this.btnRun;
			this.nFsAECmp1.CombRunning = this.comboBox2;
			this.nFsAECmp1.CombTargetVersion = this.cmbInstalled;
			this.nFsAECmp1.InstalledAFXIndex = -1;
			this.nFsAECmp1.InstalledAFXStr = "";
			this.nFsAECmp1.ListBoxInstalled = null;
			this.nFsAECmp1.RunningAFXIndexChanged += new System.EventHandler(this.nFsAECmp1_RunningAFXIndexChanged);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 20);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbInstalled);
			this.Controls.Add(this.btnRun);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(400, 20);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 20);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnRun;
		private BRY.NFsAECmp nFsAECmp1;
		private System.Windows.Forms.ComboBox cmbInstalled;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}

