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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.colorBox10 = new AE_Util_skelton.ColorBox();
            this.colorBox15 = new AE_Util_skelton.ColorBox();
            this.colorBox14 = new AE_Util_skelton.ColorBox();
            this.colorBox13 = new AE_Util_skelton.ColorBox();
            this.colorBox12 = new AE_Util_skelton.ColorBox();
            this.colorBox11 = new AE_Util_skelton.ColorBox();
            this.colorBox9 = new AE_Util_skelton.ColorBox();
            this.colorBox8 = new AE_Util_skelton.ColorBox();
            this.colorBox7 = new AE_Util_skelton.ColorBox();
            this.colorBox6 = new AE_Util_skelton.ColorBox();
            this.colorBox5 = new AE_Util_skelton.ColorBox();
            this.colorBox4 = new AE_Util_skelton.ColorBox();
            this.colorBox3 = new AE_Util_skelton.ColorBox();
            this.colorBox2 = new AE_Util_skelton.ColorBox();
            this.colorBox1 = new AE_Util_skelton.ColorBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Paste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "スポイト";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(87, 182);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 19);
            this.numericUpDown1.TabIndex = 18;
            this.numericUpDown1.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(87, 207);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(64, 19);
            this.numericUpDown2.TabIndex = 19;
            this.numericUpDown2.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(87, 232);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(64, 19);
            this.numericUpDown3.TabIndex = 20;
            this.numericUpDown3.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // colorBox10
            // 
            this.colorBox10.BackColor = System.Drawing.Color.Transparent;
            this.colorBox10.Blue = this.numericUpDown3;
            this.colorBox10.Color = System.Drawing.Color.Gray;
            this.colorBox10.Green = this.numericUpDown2;
            this.colorBox10.Location = new System.Drawing.Point(6, 182);
            this.colorBox10.Name = "colorBox10";
            this.colorBox10.Red = this.numericUpDown1;
            this.colorBox10.SelectColor = System.Drawing.Color.Black;
            this.colorBox10.Selected = false;
            this.colorBox10.Size = new System.Drawing.Size(75, 69);
            this.colorBox10.TabIndex = 14;
            this.colorBox10.Tag = "4";
            this.colorBox10.Text = "colorBox10";
            this.colorBox10.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox15
            // 
            this.colorBox15.BackColor = System.Drawing.Color.Transparent;
            this.colorBox15.Blue = null;
            this.colorBox15.Color = System.Drawing.Color.Gray;
            this.colorBox15.Green = null;
            this.colorBox15.Location = new System.Drawing.Point(170, 27);
            this.colorBox15.Name = "colorBox15";
            this.colorBox15.Red = null;
            this.colorBox15.SelectColor = System.Drawing.Color.Black;
            this.colorBox15.Selected = false;
            this.colorBox15.Size = new System.Drawing.Size(32, 32);
            this.colorBox15.TabIndex = 13;
            this.colorBox15.Tag = "4";
            this.colorBox15.Text = "colorBox14";
            this.colorBox15.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox14
            // 
            this.colorBox14.BackColor = System.Drawing.Color.Transparent;
            this.colorBox14.Blue = null;
            this.colorBox14.Color = System.Drawing.Color.Gray;
            this.colorBox14.Green = null;
            this.colorBox14.Location = new System.Drawing.Point(135, 27);
            this.colorBox14.Name = "colorBox14";
            this.colorBox14.Red = null;
            this.colorBox14.SelectColor = System.Drawing.Color.Black;
            this.colorBox14.Selected = false;
            this.colorBox14.Size = new System.Drawing.Size(32, 32);
            this.colorBox14.TabIndex = 12;
            this.colorBox14.Tag = "3";
            this.colorBox14.Text = "colorBox15";
            this.colorBox14.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox13
            // 
            this.colorBox13.BackColor = System.Drawing.Color.Transparent;
            this.colorBox13.Blue = null;
            this.colorBox13.Color = System.Drawing.Color.Gray;
            this.colorBox13.Green = null;
            this.colorBox13.Location = new System.Drawing.Point(97, 27);
            this.colorBox13.Name = "colorBox13";
            this.colorBox13.Red = null;
            this.colorBox13.SelectColor = System.Drawing.Color.Black;
            this.colorBox13.Selected = false;
            this.colorBox13.Size = new System.Drawing.Size(32, 32);
            this.colorBox13.TabIndex = 11;
            this.colorBox13.Tag = "2";
            this.colorBox13.Text = "colorBox16";
            this.colorBox13.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox12
            // 
            this.colorBox12.BackColor = System.Drawing.Color.Transparent;
            this.colorBox12.Blue = null;
            this.colorBox12.Color = System.Drawing.Color.Gray;
            this.colorBox12.Green = null;
            this.colorBox12.Location = new System.Drawing.Point(59, 27);
            this.colorBox12.Name = "colorBox12";
            this.colorBox12.Red = null;
            this.colorBox12.SelectColor = System.Drawing.Color.Black;
            this.colorBox12.Selected = false;
            this.colorBox12.Size = new System.Drawing.Size(32, 32);
            this.colorBox12.TabIndex = 10;
            this.colorBox12.Tag = "1";
            this.colorBox12.Text = "colorBox17";
            this.colorBox12.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox11
            // 
            this.colorBox11.BackColor = System.Drawing.Color.Transparent;
            this.colorBox11.Blue = null;
            this.colorBox11.Color = System.Drawing.Color.Gray;
            this.colorBox11.Green = null;
            this.colorBox11.Location = new System.Drawing.Point(21, 27);
            this.colorBox11.Name = "colorBox11";
            this.colorBox11.Red = null;
            this.colorBox11.SelectColor = System.Drawing.Color.Black;
            this.colorBox11.Selected = false;
            this.colorBox11.Size = new System.Drawing.Size(32, 32);
            this.colorBox11.TabIndex = 9;
            this.colorBox11.Tag = "0";
            this.colorBox11.Text = "colorBox18";
            this.colorBox11.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox9
            // 
            this.colorBox9.BackColor = System.Drawing.Color.Transparent;
            this.colorBox9.Blue = null;
            this.colorBox9.Color = System.Drawing.Color.Gray;
            this.colorBox9.Green = null;
            this.colorBox9.Location = new System.Drawing.Point(6, 321);
            this.colorBox9.Name = "colorBox9";
            this.colorBox9.Red = null;
            this.colorBox9.SelectColor = System.Drawing.Color.Black;
            this.colorBox9.Selected = false;
            this.colorBox9.Size = new System.Drawing.Size(32, 32);
            this.colorBox9.TabIndex = 8;
            this.colorBox9.Tag = "7";
            this.colorBox9.Text = "colorBox9";
            this.colorBox9.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox8
            // 
            this.colorBox8.BackColor = System.Drawing.Color.Transparent;
            this.colorBox8.Blue = null;
            this.colorBox8.Color = System.Drawing.Color.Gray;
            this.colorBox8.Green = null;
            this.colorBox8.Location = new System.Drawing.Point(6, 283);
            this.colorBox8.Name = "colorBox8";
            this.colorBox8.Red = null;
            this.colorBox8.SelectColor = System.Drawing.Color.Black;
            this.colorBox8.Selected = false;
            this.colorBox8.Size = new System.Drawing.Size(32, 32);
            this.colorBox8.TabIndex = 7;
            this.colorBox8.Tag = "7";
            this.colorBox8.Text = "colorBox8";
            this.colorBox8.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox7
            // 
            this.colorBox7.BackColor = System.Drawing.Color.Transparent;
            this.colorBox7.Blue = null;
            this.colorBox7.Color = System.Drawing.Color.Gray;
            this.colorBox7.Green = null;
            this.colorBox7.Location = new System.Drawing.Point(6, 245);
            this.colorBox7.Name = "colorBox7";
            this.colorBox7.Red = null;
            this.colorBox7.SelectColor = System.Drawing.Color.Black;
            this.colorBox7.Selected = false;
            this.colorBox7.Size = new System.Drawing.Size(32, 32);
            this.colorBox7.TabIndex = 6;
            this.colorBox7.Tag = "6";
            this.colorBox7.Text = "colorBox7";
            this.colorBox7.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox6
            // 
            this.colorBox6.BackColor = System.Drawing.Color.Transparent;
            this.colorBox6.Blue = null;
            this.colorBox6.Color = System.Drawing.Color.Gray;
            this.colorBox6.Green = null;
            this.colorBox6.Location = new System.Drawing.Point(6, 207);
            this.colorBox6.Name = "colorBox6";
            this.colorBox6.Red = null;
            this.colorBox6.SelectColor = System.Drawing.Color.Black;
            this.colorBox6.Selected = false;
            this.colorBox6.Size = new System.Drawing.Size(32, 32);
            this.colorBox6.TabIndex = 5;
            this.colorBox6.Tag = "5";
            this.colorBox6.Text = "colorBox6";
            this.colorBox6.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox5
            // 
            this.colorBox5.BackColor = System.Drawing.Color.Transparent;
            this.colorBox5.Blue = null;
            this.colorBox5.Color = System.Drawing.Color.Gray;
            this.colorBox5.Green = null;
            this.colorBox5.Location = new System.Drawing.Point(6, 169);
            this.colorBox5.Name = "colorBox5";
            this.colorBox5.Red = null;
            this.colorBox5.SelectColor = System.Drawing.Color.Black;
            this.colorBox5.Selected = false;
            this.colorBox5.Size = new System.Drawing.Size(32, 32);
            this.colorBox5.TabIndex = 4;
            this.colorBox5.Tag = "4";
            this.colorBox5.Text = "colorBox5";
            this.colorBox5.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox4
            // 
            this.colorBox4.BackColor = System.Drawing.Color.Transparent;
            this.colorBox4.Blue = null;
            this.colorBox4.Color = System.Drawing.Color.Gray;
            this.colorBox4.Green = null;
            this.colorBox4.Location = new System.Drawing.Point(6, 131);
            this.colorBox4.Name = "colorBox4";
            this.colorBox4.Red = null;
            this.colorBox4.SelectColor = System.Drawing.Color.Black;
            this.colorBox4.Selected = false;
            this.colorBox4.Size = new System.Drawing.Size(32, 32);
            this.colorBox4.TabIndex = 3;
            this.colorBox4.Tag = "3";
            this.colorBox4.Text = "colorBox4";
            this.colorBox4.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox3
            // 
            this.colorBox3.BackColor = System.Drawing.Color.Transparent;
            this.colorBox3.Blue = null;
            this.colorBox3.Color = System.Drawing.Color.Gray;
            this.colorBox3.Green = null;
            this.colorBox3.Location = new System.Drawing.Point(6, 93);
            this.colorBox3.Name = "colorBox3";
            this.colorBox3.Red = null;
            this.colorBox3.SelectColor = System.Drawing.Color.Black;
            this.colorBox3.Selected = false;
            this.colorBox3.Size = new System.Drawing.Size(32, 32);
            this.colorBox3.TabIndex = 2;
            this.colorBox3.Tag = "2";
            this.colorBox3.Text = "colorBox3";
            this.colorBox3.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox2
            // 
            this.colorBox2.BackColor = System.Drawing.Color.Transparent;
            this.colorBox2.Blue = null;
            this.colorBox2.Color = System.Drawing.Color.Gray;
            this.colorBox2.Green = null;
            this.colorBox2.Location = new System.Drawing.Point(6, 55);
            this.colorBox2.Name = "colorBox2";
            this.colorBox2.Red = null;
            this.colorBox2.SelectColor = System.Drawing.Color.Black;
            this.colorBox2.Selected = false;
            this.colorBox2.Size = new System.Drawing.Size(32, 32);
            this.colorBox2.TabIndex = 1;
            this.colorBox2.Tag = "1";
            this.colorBox2.Text = "colorBox2";
            this.colorBox2.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // colorBox1
            // 
            this.colorBox1.BackColor = System.Drawing.Color.Transparent;
            this.colorBox1.Blue = null;
            this.colorBox1.Color = System.Drawing.Color.Gray;
            this.colorBox1.Green = null;
            this.colorBox1.Location = new System.Drawing.Point(6, 17);
            this.colorBox1.Name = "colorBox1";
            this.colorBox1.Red = null;
            this.colorBox1.SelectColor = System.Drawing.Color.Black;
            this.colorBox1.Selected = false;
            this.colorBox1.Size = new System.Drawing.Size(32, 32);
            this.colorBox1.TabIndex = 0;
            this.colorBox1.Tag = "0";
            this.colorBox1.Text = "colorBox1";
            this.colorBox1.SelectedChanged += new System.EventHandler(this.ColorBox_SelectedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorBox1);
            this.groupBox1.Controls.Add(this.colorBox2);
            this.groupBox1.Controls.Add(this.colorBox3);
            this.groupBox1.Controls.Add(this.colorBox4);
            this.groupBox1.Controls.Add(this.colorBox5);
            this.groupBox1.Controls.Add(this.colorBox6);
            this.groupBox1.Controls.Add(this.colorBox7);
            this.groupBox1.Controls.Add(this.colorBox8);
            this.groupBox1.Controls.Add(this.colorBox9);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(46, 362);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorBox10);
            this.groupBox2.Controls.Add(this.numericUpDown3);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(64, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 259);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EditColor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.colorBox14);
            this.groupBox3.Controls.Add(this.colorBox11);
            this.groupBox3.Controls.Add(this.colorBox12);
            this.groupBox3.Controls.Add(this.colorBox15);
            this.groupBox3.Controls.Add(this.colorBox13);
            this.groupBox3.Location = new System.Drawing.Point(64, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 97);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blend";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(31, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(29, 16);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(66, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(29, 16);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(101, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(29, 16);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "2";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.spuitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // spuitToolStripMenuItem
            // 
            this.spuitToolStripMenuItem.Name = "spuitToolStripMenuItem";
            this.spuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.spuitToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.spuitToolStripMenuItem.Text = "Spuit";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 400);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorBox colorBox1;
        private ColorBox colorBox2;
        private ColorBox colorBox3;
        private ColorBox colorBox4;
        private ColorBox colorBox5;
        private ColorBox colorBox6;
        private ColorBox colorBox7;
        private ColorBox colorBox8;
        private System.Windows.Forms.Button button1;
        private ColorBox colorBox9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private ColorBox colorBox14;
        private ColorBox colorBox13;
        private ColorBox colorBox12;
        private ColorBox colorBox11;
        private ColorBox colorBox15;
        private ColorBox colorBox10;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spuitToolStripMenuItem;
    }
}

