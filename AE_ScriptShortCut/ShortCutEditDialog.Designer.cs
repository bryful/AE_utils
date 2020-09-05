namespace AE_ScriptShortCut
{
	partial class ShortCutEditDialog
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
			this.cbCtrl = new System.Windows.Forms.CheckBox();
			this.cbAlt = new System.Windows.Forms.CheckBox();
			this.cbShift = new System.Windows.Forms.CheckBox();
			this.combKeys1 = new AE_ScriptShortCut.CombKeys();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnYes = new System.Windows.Forms.Button();
			this.BtnOK = new System.Windows.Forms.Button();
			this.tbScriptName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbCtrl
			// 
			this.cbCtrl.AutoSize = true;
			this.cbCtrl.Location = new System.Drawing.Point(39, 43);
			this.cbCtrl.Name = "cbCtrl";
			this.cbCtrl.Size = new System.Drawing.Size(43, 16);
			this.cbCtrl.TabIndex = 1;
			this.cbCtrl.Text = "Ctrl";
			this.cbCtrl.UseVisualStyleBackColor = true;
			// 
			// cbAlt
			// 
			this.cbAlt.AutoSize = true;
			this.cbAlt.Location = new System.Drawing.Point(88, 43);
			this.cbAlt.Name = "cbAlt";
			this.cbAlt.Size = new System.Drawing.Size(39, 16);
			this.cbAlt.TabIndex = 2;
			this.cbAlt.Text = "Alt";
			this.cbAlt.UseVisualStyleBackColor = true;
			// 
			// cbShift
			// 
			this.cbShift.AutoSize = true;
			this.cbShift.Location = new System.Drawing.Point(133, 43);
			this.cbShift.Name = "cbShift";
			this.cbShift.Size = new System.Drawing.Size(48, 16);
			this.cbShift.TabIndex = 3;
			this.cbShift.Text = "Shift";
			this.cbShift.UseVisualStyleBackColor = true;
			// 
			// combKeys1
			// 
			this.combKeys1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combKeys1.FormattingEnabled = true;
			this.combKeys1.Items.AddRange(new object[] {
            "None",
            "Enter",
            "Delete",
            "Backspace",
            "Tab",
            "Return",
            "Esc",
            "LeftArrow",
            "RightArrow",
            "UpArrow",
            "DownArrow",
            "Space",
            "!",
            "DoubleQuote",
            "#",
            "$",
            "%",
            "&",
            "SingleQuote",
            "LParen",
            "RParen",
            "*",
            "Plus",
            "Comma",
            "-",
            ".",
            "/",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            ":",
            ";",
            "<",
            "=",
            ">",
            "?",
            "@",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "[",
            "Backslash",
            "]",
            "^",
            "_",
            "`",
            "{",
            "|",
            "}",
            "~",
            "Umlaut_A",
            "Ring_A",
            "Cedilla_C",
            "Acute_E",
            "Tilde_N",
            "Umlaut_O",
            "Umlaut_U",
            "Acute_a",
            "Grave_a",
            "Circumflex_a",
            "Umlaut_a",
            "Tilde_a",
            "Ring_a",
            "Cedilla_c",
            "Acute_e",
            "Grave_e",
            "Circumflex_e",
            "Umlaut_e",
            "Acute_i",
            "Grave_i",
            "Circumflex_i",
            "Umlaut_i",
            "Tilde_n",
            "Acute_o",
            "Grave_o",
            "Circumflex_o",
            "Umlaut_o",
            "Tilde_o",
            "Acute_u",
            "Grave_u",
            "Circumflex_u",
            "Umlaut_u",
            "Section",
            "German_dbl_s",
            "Acute",
            "Yen",
            "Grave_A",
            "Tilde_A",
            "Tilde_O",
            "Umlaut_y",
            "Umlaut_Y",
            "Circumflex_A",
            "Circumflex_E",
            "Acute_A",
            "Umlaut_E",
            "Grave_E",
            "Acute_I",
            "Circumflex_I",
            "Umlaut_I",
            "Grave_I",
            "Acute_O",
            "Circumflex_O",
            "Grave_O",
            "Acute_U",
            "Circumflex_U",
            "Grave_U",
            "PadDecimal",
            "PadComma",
            "PadMultiply",
            "PadPlus",
            "PadClear",
            "PadSlash",
            "PadMinus",
            "PadEqual",
            "PadInsert",
            "PadDelete",
            "PadHome",
            "PadEnd",
            "PadPageUp",
            "PadPageDown",
            "Pad0",
            "Pad1",
            "Pad2",
            "Pad3",
            "Pad4",
            "Pad5",
            "Pad6",
            "Pad7",
            "Pad8",
            "Pad9",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "HELP",
            "HOME",
            "PageUP",
            "FwdDel",
            "END",
            "PageDOWN",
            "NumLock",
            "Insert",
            "Pause",
            "CapsLock"});
			this.combKeys1.Location = new System.Drawing.Point(187, 41);
			this.combKeys1.MinimumSize = new System.Drawing.Size(100, 0);
			this.combKeys1.Name = "combKeys1";
			this.combKeys1.Size = new System.Drawing.Size(156, 20);
			this.combKeys1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(88, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnYes.Location = new System.Drawing.Point(187, 80);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.TabIndex = 6;
			this.btnYes.Text = "Add";
			this.btnYes.UseVisualStyleBackColor = true;
			// 
			// BtnOK
			// 
			this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnOK.Location = new System.Drawing.Point(268, 80);
			this.BtnOK.Name = "BtnOK";
			this.BtnOK.Size = new System.Drawing.Size(75, 23);
			this.BtnOK.TabIndex = 7;
			this.BtnOK.Text = "Overwrite";
			this.BtnOK.UseVisualStyleBackColor = true;
			// 
			// tbScriptName
			// 
			this.tbScriptName.Location = new System.Drawing.Point(23, 13);
			this.tbScriptName.Name = "tbScriptName";
			this.tbScriptName.ReadOnly = true;
			this.tbScriptName.Size = new System.Drawing.Size(320, 19);
			this.tbScriptName.TabIndex = 0;
			// 
			// ShortCutEditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 110);
			this.ControlBox = false;
			this.Controls.Add(this.tbScriptName);
			this.Controls.Add(this.BtnOK);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.combKeys1);
			this.Controls.Add(this.cbShift);
			this.Controls.Add(this.cbAlt);
			this.Controls.Add(this.cbCtrl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShortCutEditDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit　ShortCutKey";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbCtrl;
		private System.Windows.Forms.CheckBox cbAlt;
		private System.Windows.Forms.CheckBox cbShift;
		private CombKeys combKeys1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button BtnOK;
		private System.Windows.Forms.TextBox tbScriptName;
	}
}