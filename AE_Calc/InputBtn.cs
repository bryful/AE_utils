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

using BRY;

namespace AE_Util_skelton
{
    public class InputBtn : Control
    {
        private bool m_IsMouseDown = false;
        private Color m_DownColor = SystemColors.Control;
        public Color DownColor { get { return m_DownColor; } set { m_DownColor = value; this.Invalidate(); } }
        public InputBtn()
        {
            this.Size = new Size(35, 35);
            this.BackColor = SystemColors.ControlDarkDark;

            this.MouseDown += InputBtn_MouseDown;
            this.MouseUp += InputBtn_MouseUp;
        }

        // *********************************************************************
        private void InputBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_IsMouseDown = false;
            this.Invalidate();
        }

        // *********************************************************************
        private void InputBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_IsMouseDown = true;
            this.Invalidate();
        }

        // *********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                if (m_IsMouseDown) { sb.Color = m_DownColor; } else { sb.Color = this.BackColor; }

                g.FillRectangle(sb,this.ClientRectangle);

                sb.Color = this.ForeColor;
                g.DrawString(this.Text, this.Font, sb, this.ClientRectangle, sf);
            }
            finally
            {
                sb.Dispose();
            }
            
        }
        // *********************************************************************
    }
}
