using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_Util_skelton
{
    public class ColorBox : Control
    {
        private bool m_IsLocked = false;
        public bool IsLocked
        {
            get { return m_IsLocked; }
            set
            {
                m_IsLocked = value;
                this.Invalidate();
            }
        }

        // **************************************************************************
        // データを持たないイベントデリゲートの宣言
        public event EventHandler SelectedChanged;

        protected virtual void OnSelectedChanged(EventArgs e)
        {
            if (SelectedChanged != null)
            {
                SelectedChanged(this, e);
            }
        }
        // **************************************************************************
        public int Index = -1;
        private bool m_Selected = false;
        public bool Selected
        {
            get { return m_Selected; }
            set { SetSelected(value); }
        }
        public void SetSelected(bool b)
        {
            if (m_Selected == b) return;
            if (b == true) {
                if (this.Parent != null)
                {
                    if (this.Parent.Controls.Count > 0)
                    {
                        foreach (Control c in this.Parent.Controls)
                        {
                            if (this.GetType().Equals(c.GetType()))
                            {
                                if (c.Name != this.Name)
                                {
                                    ColorBox cc = (ColorBox)c;
                                    if (cc.m_Selected == true)
                                    {
                                        cc.m_Selected = false;
                                        cc.Invalidate();
                                    }
                                }
                            }

                        }
                    }
                }
             }
             m_Selected = b;
            OnSelectedChanged(new EventArgs());
            this.Invalidate();

        }
        // **************************************************************************
        private NumericUpDown m_Red = null;
        public NumericUpDown Red
        {
            get { return m_Red; }
            set
            {
                m_Red = value;
                if(m_Red != null)
                {
                    m_Red.Maximum = 255;
                    m_Red.Minimum = 0;
                    m_Red.Value = m_Color.R;
                    m_Red.ValueChanged += M_Red_ValueChanged;
                    m_Red.KeyPress += M_Blue_KeyPress;

                    this.Invalidate();
                }
            }
        }
        // **************************************************************************
        private NumericUpDown m_Green = null;
        public NumericUpDown Green
        {
            get { return m_Green; }
            set
            {
                m_Green = value;
                if (m_Green != null)
                {
                    m_Green.Maximum = 255;
                    m_Green.Minimum = 0;
                    m_Green.Value = m_Color.G;
                    m_Green.ValueChanged += M_Green_ValueChanged;
                    m_Green.KeyPress += M_Blue_KeyPress;
                    this.Invalidate();
                }
            }
        }
        // **************************************************************************
        private NumericUpDown m_Blue = null;
        public NumericUpDown Blue
        {
            get { return m_Blue; }
            set
            {
                m_Blue = value;
                if (m_Blue != null)
                {
                    m_Blue.Maximum = 255;
                    m_Blue.Minimum = 0;
                    m_Blue.Value = m_Color.B;
                    m_Blue.ValueChanged += M_Blue_ValueChanged;
                    m_Blue.KeyPress += M_Blue_KeyPress;
                    this.Invalidate();
                }
            }
        }
        // **************************************************************************
        private void M_Blue_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Invalidate();
        }

        // **************************************************************************
        private void M_Blue_ValueChanged(object sender, EventArgs e)
        {
            if (m_Blue != null)
            {
                SetBlue((int)m_Blue.Value);
            }
        }
        // **************************************************************************
        private void M_Green_ValueChanged(object sender, EventArgs e)
        {
            if (m_Green != null)
            {
                SetGreen((int)m_Green.Value);
            }
        }
        // **************************************************************************
        private void M_Red_ValueChanged(object sender, EventArgs e)
        {
            if (m_Red != null)
            {
                SetRed((int)m_Red.Value);
            }
        }

        // **************************************************************************
        public void SetBlue(int b)
        {
            if (m_Color.B != b)
            {
                if (m_IsLocked == false)
                {
                    m_Color = Color.FromArgb(m_Color.R, m_Color.G, b);
                }
            }
            this.Invalidate();
        }
        // **************************************************************************
        public void SetGreen(int g)
        {
            if (m_Color.G != g)
            {
                if (m_IsLocked == false)
                {
                    m_Color = Color.FromArgb(m_Color.R, g, m_Color.B);
                }
            }
            this.Invalidate();
        }
        // **************************************************************************
        public void SetRed(int r)
        {
            if (m_Color.R != r)
            {
                if (m_IsLocked == false)
                {
                    m_Color = Color.FromArgb(r, m_Color.G, m_Color.B);
                }
            }
            this.Invalidate();
        }
        // **************************************************************************
        public void SetColor(int r, int g, int b)
        {
            if ((m_Color.R == r) && (m_Color.G == g) && (m_Color.B == b)) return;
            if (m_IsLocked == false)
            {

                m_Color = Color.FromArgb(r, g, b);
            }
            this.Invalidate();
        }
        // **************************************************************************
        private Color m_Color = Color.Gray;
        public Color Color
        {
            get { return m_Color; }
            set { SetColor(value); }
        }
        // **************************************************************************
        public void SetColor(Color c)
        {
            int r, g, b;
            r = c.R;g = c.G;b = c.B;
            if ((m_Color.R == r) && (m_Color.G == g) && (m_Color.B == b)) return;
            if (m_IsLocked == false)
            {
                m_Color = c;

                if (m_Red != null) m_Red.Value = r;
                if (m_Green != null) m_Green.Value = g;
                if (m_Blue != null) m_Blue.Value = b;
            }
            this.Invalidate();

        }
        // **************************************************************************
        private Color m_SelectColor = Color.Black;
        public Color SelectColor
        {
            get { return m_SelectColor; }
            set { m_SelectColor = value; this.Invalidate(); }
        }
        // **************************************************************************
        public ColorBox()
        {
            this.Size = new Size(32, 32);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            this.Click += ColorBox_Click;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        // **************************************************************************
        private void ColorBox_Click(object sender, EventArgs e)
        {
            SetSelected(!m_Selected);
        }

        // **************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Transparent);
            Pen p = new Pen(Color.Black);
            p.Width = 2;
            try
            {
                Rectangle rct = this.ClientRectangle; ;

                sb.Color = Color.Transparent;
                g.FillRectangle(sb, rct);

                rct.Width -= 7;
                rct.Height -= 7;
                rct.Location = new Point(rct.Left + 3, rct.Top + 3);
                sb.Color = m_Color;
                g.FillRectangle(sb, rct);

                if (m_Selected == true)
                {
                    rct = this.ClientRectangle;
                    rct.Width -= 3;
                    rct.Height -= 3;
                    rct.Location = new Point(rct.Left + 1, rct.Top + 1);
                    p.Color = SelectColor;
                    g.DrawRectangle(p, rct);
                }

            }
            finally
            {
                sb.Dispose();
                p.Dispose();
            }

        }
    }
}
