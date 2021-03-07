
namespace Alert
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
			this.btnOK = new System.Windows.Forms.Button();
			this.cbTopMost = new System.Windows.Forms.CheckBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.aeWeb1 = new BRY.AEWeb();
			this.cbIsClear = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(368, 211);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(140, 37);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// cbTopMost
			// 
			this.cbTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbTopMost.AutoSize = true;
			this.cbTopMost.Checked = true;
			this.cbTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTopMost.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cbTopMost.Location = new System.Drawing.Point(93, 211);
			this.cbTopMost.Name = "cbTopMost";
			this.cbTopMost.Size = new System.Drawing.Size(57, 16);
			this.cbTopMost.TabIndex = 2;
			this.cbTopMost.Text = "手前に";
			this.cbTopMost.UseVisualStyleBackColor = true;
			this.cbTopMost.CheckedChanged += new System.EventHandler(this.cbTopMost_CheckedChanged);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnClear.Location = new System.Drawing.Point(12, 211);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 37);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "clear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// aeWeb1
			// 
			this.aeWeb1.AllowNavigation = false;
			this.aeWeb1.AllowWebBrowserDrop = false;
			this.aeWeb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aeWeb1.body = "";
			this.aeWeb1.headcss = "";
			this.aeWeb1.IsClear = true;
			this.aeWeb1.Location = new System.Drawing.Point(4, 13);
			this.aeWeb1.Margin = new System.Windows.Forms.Padding(4);
			this.aeWeb1.MinimumSize = new System.Drawing.Size(30, 27);
			this.aeWeb1.Name = "aeWeb1";
			this.aeWeb1.ScriptErrorsSuppressed = true;
			this.aeWeb1.ScrollBarsEnabled = false;
			this.aeWeb1.Size = new System.Drawing.Size(513, 187);
			this.aeWeb1.TabIndex = 0;
			this.aeWeb1.WebBrowserShortcutsEnabled = false;
			// 
			// cbIsClear
			// 
			this.cbIsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbIsClear.AutoSize = true;
			this.cbIsClear.Checked = true;
			this.cbIsClear.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIsClear.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cbIsClear.Location = new System.Drawing.Point(93, 232);
			this.cbIsClear.Name = "cbIsClear";
			this.cbIsClear.Size = new System.Drawing.Size(90, 16);
			this.cbIsClear.TabIndex = 4;
			this.cbIsClear.Text = "クリアして表示";
			this.cbIsClear.UseVisualStyleBackColor = true;
			this.cbIsClear.CheckedChanged += new System.EventHandler(this.cbIsClear_CheckedChanged);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(521, 261);
			this.Controls.Add(this.cbIsClear);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.cbTopMost);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.aeWeb1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(360, 250);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alert";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnOK;
		private BRY.AEWeb aeWeb1;
		private System.Windows.Forms.CheckBox cbTopMost;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.CheckBox cbIsClear;
	}
}

