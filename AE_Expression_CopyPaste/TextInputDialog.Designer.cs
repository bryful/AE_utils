namespace AE_Util_skelton
{
    partial class TextInputDialog
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
            this.tbExpStr = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tbExpCap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnREDO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbExpStr
            // 
            this.tbExpStr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExpStr.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbExpStr.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbExpStr.ForeColor = System.Drawing.Color.White;
            this.tbExpStr.Location = new System.Drawing.Point(37, 66);
            this.tbExpStr.Multiline = true;
            this.tbExpStr.Name = "tbExpStr";
            this.tbExpStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbExpStr.Size = new System.Drawing.Size(745, 347);
            this.tbExpStr.TabIndex = 0;
            this.tbExpStr.TextChanged += new System.EventHandler(this.tbExpCap_TextChanged);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(656, 419);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(575, 419);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // tbExpCap
            // 
            this.tbExpCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExpCap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbExpCap.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbExpCap.ForeColor = System.Drawing.Color.White;
            this.tbExpCap.Location = new System.Drawing.Point(37, 41);
            this.tbExpCap.Name = "tbExpCap";
            this.tbExpCap.Size = new System.Drawing.Size(745, 23);
            this.tbExpCap.TabIndex = 3;
            this.tbExpCap.TextChanged += new System.EventHandler(this.tbExpCap_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "新しい見出し";
            // 
            // btnREDO
            // 
            this.btnREDO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnREDO.Location = new System.Drawing.Point(39, 419);
            this.btnREDO.Name = "btnREDO";
            this.btnREDO.Size = new System.Drawing.Size(75, 23);
            this.btnREDO.TabIndex = 5;
            this.btnREDO.Text = "戻す";
            this.btnREDO.UseVisualStyleBackColor = true;
            this.btnREDO.Click += new System.EventHandler(this.btnREDO_Click);
            // 
            // TextInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(812, 477);
            this.Controls.Add(this.btnREDO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbExpCap);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.tbExpStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInputDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExpStr;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox tbExpCap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnREDO;
    }
}