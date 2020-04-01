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
        static public readonly int BoxWidth = 27;
        static public readonly int BoxLength = 29;

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
        public void SetSelected2(bool b,bool ev=true)
        {
            m_Selected = b;
            Invalidate();
            if(ev) OnSelectedChanged(new EventArgs());
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
        public void SetColor(double r, double g, double b)
        {
            if ((m_Color.R == r) && (m_Color.G == g) && (m_Color.B == b)) return;

            if (m_IsLocked == false)
            {

                m_Color = AEColor.FromArgb(r, g, b);
            }
            this.Invalidate();
        }
        // **************************************************************************
        private AEColor m_Color = new AEColor();

        public AEColor AE_Color
        {
            get { return m_Color; }
            set { SetColor(value); }
        }
        public string HexColor
        {
            get { return m_Color.Hex; }
            set { m_Color.Hex = value; }
        }
        // **************************************************************************
        public void SetColor(AEColor c)
        {
            double r, g, b;
            r = c.R; g = c.G;b = c.B;

            if (m_Color.Equals(c) == true) return;
            if (m_IsLocked == false)
            {
                m_Color = c;
            }
            this.Invalidate();

        }
        // **************************************************************************
        private Color m_SelectColor = Color.Red;
        public Color SelectColor
        {
            get { return m_SelectColor; }
            set { m_SelectColor = value; this.Invalidate(); }
        }
        // **************************************************************************
        public ColorBox()
        {
            this.Size = new Size(BoxWidth, BoxWidth);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            this.MouseDown += ColorBox_Click;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        // **************************************************************************
        private void ColorBox_Click(object sender, EventArgs e)
        {
            SetSelected(true);
        }

        // **************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Transparent);
            Pen p = new Pen(Color.Black);
            p.Width = 1;
            try
            {
                Rectangle rct = this.ClientRectangle; ;

                sb.Color = Color.Transparent;
                g.FillRectangle(sb, rct);

                rct.Width -= 5;
                rct.Height -= 5;
                rct.Location = new Point(rct.Left + 3, rct.Top + 3);
                sb.Color = m_Color.ToColor();
                g.FillRectangle(sb, rct);

                if (m_Selected == true)
                {
                    rct = this.ClientRectangle;
                    rct.Width -= 2;
                    rct.Height -= 2;
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
