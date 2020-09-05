using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AE_ScriptShortCut
{
	public class ScriptShortCut : Control
	{
		//Ctrl+Shift+Alt
		private Label m_IDX = new Label();
		private TextBox m_tbSctiptName = new TextBox();
		private ComboBox m_CombKey = new ComboBox();
		private Button m_BtnEdit = new Button();


		private int m_IDXWidth = 30;
		public int IDXWidth
		{
			get { return m_IDXWidth; }
			set
			{
				if (m_IDXWidth != value)
				{
					m_IDXWidth = value;
					SizeChk();
				}
			}
		}

		private int m_CKWidth = 220;
		public int CKWidth
		{
			get { return m_CKWidth; }
			set
			{
				if (m_CKWidth != value)
				{
					m_CKWidth = value;
					SizeChk();
				}
			}
		}

		private int m_BEWidth = 40;
		public int BEWidth
		{
			get { return m_BEWidth; }
			set
			{
				if (m_BEWidth != value)
				{
					m_BEWidth = value;
					SizeChk();
				}
			}
		}

		private int m_Index = 0;
		public int Index
		{
			get { return m_Index; }
			set
			{
				if(m_Index!=value)
				{
					m_Index = value;
					m_IDX.Text = String.Format("{0:00}", m_Index);
				}
			}
		}

		public ScriptShortCut()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			Index = 1;
			this.Size = new Size(600, 24);

			m_IDX.AutoSize = false;
			m_IDX.TextAlign = ContentAlignment.MiddleRight;

			m_tbSctiptName.AutoSize = false;
			m_tbSctiptName.ReadOnly = true;

			m_CombKey.AutoSize = false;
			m_CombKey.DropDownStyle = ComboBoxStyle.DropDownList;

			m_BtnEdit.AutoSize = false;
			m_BtnEdit.Text = "Ed";

			SizeChk();

			this.Controls.Add(m_IDX);
			this.Controls.Add(m_tbSctiptName);
			this.Controls.Add(m_CombKey);
			this.Controls.Add(m_BtnEdit);


		}
		protected override void OnResize(EventArgs e)
		{
			//base.OnResize(e);
			SizeChk();
		}
		private void SizeChk()
		{
			int w = this.ClientSize.Width;
			int h = this.ClientSize.Height;

			int w2 = w - (m_IDXWidth + 2 +  m_CKWidth + 4 + m_BEWidth) -4;

			int h2 = h - 4;

			int x = 2;
			m_IDX.Size = new Size(m_IDXWidth, h2);
			m_IDX.Location = new Point(x, 2);
			x += m_IDXWidth + 2;
			m_tbSctiptName.Size = new Size(w2, h2);
			m_tbSctiptName.Location = new Point(x, 2);
			x += w2 + 4;
			m_CombKey.Size = new Size(m_CKWidth, h2);
			m_CombKey.Location = new Point(x, (h - m_CombKey.Height) / 2);
			x += m_CKWidth;
			m_BtnEdit.Size = new Size(m_BEWidth, h2);
			m_BtnEdit.Location = new Point(x, 2);



		}
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			m_IDX.Font = this.Font;
			m_tbSctiptName.Font = this.Font;
			m_CombKey.Font = this.Font;
			m_BtnEdit.Font = this.Font;

		}
	}
}
