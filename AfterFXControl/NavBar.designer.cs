﻿
namespace AfterFXControl
{
	partial class NavBar
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
			this.components = new System.ComponentModel.Container();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuPosLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPosTopLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPosTopRight = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPostRight = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPostBottomRight = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPostBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(4, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(16, 20);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(50, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(16, 16);
			this.button1.TabIndex = 2;
			this.button1.Text = "X";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "AFX";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NavBar_MouseDown);
			this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NavBar_MouseMove);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPosLeft,
            this.MenuPosTopLeft,
            this.MenuPosTopRight,
            this.MenuPostRight,
            this.MenuPostBottomRight,
            this.MenuPostBottomLeft});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(142, 136);
			// 
			// MenuPosLeft
			// 
			this.MenuPosLeft.Name = "MenuPosLeft";
			this.MenuPosLeft.Size = new System.Drawing.Size(141, 22);
			this.MenuPosLeft.Text = "Left";
			this.MenuPosLeft.Click += new System.EventHandler(this.MenuPosLeft_Click);
			// 
			// MenuPosTopLeft
			// 
			this.MenuPosTopLeft.Name = "MenuPosTopLeft";
			this.MenuPosTopLeft.Size = new System.Drawing.Size(141, 22);
			this.MenuPosTopLeft.Text = "TopLeft";
			this.MenuPosTopLeft.Click += new System.EventHandler(this.MenuPosTopLeft_Click);
			// 
			// MenuPosTopRight
			// 
			this.MenuPosTopRight.Name = "MenuPosTopRight";
			this.MenuPosTopRight.Size = new System.Drawing.Size(141, 22);
			this.MenuPosTopRight.Text = "TopRight";
			this.MenuPosTopRight.Click += new System.EventHandler(this.MenuPosTopRight_Click);
			// 
			// MenuPostRight
			// 
			this.MenuPostRight.Name = "MenuPostRight";
			this.MenuPostRight.Size = new System.Drawing.Size(141, 22);
			this.MenuPostRight.Text = "Right";
			this.MenuPostRight.Click += new System.EventHandler(this.MenuPostRight_Click);
			// 
			// MenuPostBottomRight
			// 
			this.MenuPostBottomRight.Name = "MenuPostBottomRight";
			this.MenuPostBottomRight.Size = new System.Drawing.Size(141, 22);
			this.MenuPostBottomRight.Text = "BottomRight";
			this.MenuPostBottomRight.Click += new System.EventHandler(this.MenuPostBottomRight_Click);
			// 
			// MenuPostBottomLeft
			// 
			this.MenuPostBottomLeft.Name = "MenuPostBottomLeft";
			this.MenuPostBottomLeft.Size = new System.Drawing.Size(141, 22);
			this.MenuPostBottomLeft.Text = "BottomLeft";
			this.MenuPostBottomLeft.Click += new System.EventHandler(this.MenuPostBottomLeft_Click);
			// 
			// NavBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(70, 20);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(70, 20);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(70, 20);
			this.Name = "NavBar";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "NavBar";
			this.TopMost = true;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NavBar_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NavBar_MouseMove);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuPosLeft;
		private System.Windows.Forms.ToolStripMenuItem MenuPostRight;
		private System.Windows.Forms.ToolStripMenuItem MenuPosTopLeft;
		private System.Windows.Forms.ToolStripMenuItem MenuPosTopRight;
		private System.Windows.Forms.ToolStripMenuItem MenuPostBottomRight;
		private System.Windows.Forms.ToolStripMenuItem MenuPostBottomLeft;
	}
}