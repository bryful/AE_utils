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
namespace AE_Triangle
{
    public class TriangleDrawBox : Control
    {
        public enum TriangleDir
        {
            RightBottom =0,
            LeftBottom,
            RightTop,
            LeftTop
        }

        #region Property

        private bool m_TargetHor = true;
        public bool TargetHor
        {
            get { return m_TargetHor; }
            set
            {
                if (m_TargetHor != value)
                {
                    m_TargetHor = value;
                    this.Invalidate();
                    if(m_CbTargetHor!=null)
                    {
                        if (m_TargetHor)
                        {
                            m_CbTargetHor.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            m_CbTargetHor.CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }
        }
        private CheckBox m_CbTargetHor = null;
        public CheckBox CbTargetHor
        {
            get { return m_CbTargetHor; }
            set
            {
                m_CbTargetHor = value;
                if(m_CbTargetHor!=null)
                {
                    if (m_TargetHor)
                    {
                        m_CbTargetHor.CheckState = CheckState.Checked;
                    }
                    else {
                        m_CbTargetHor.CheckState = CheckState.Unchecked;
                    }
                    m_CbTargetHor.CheckedChanged += M_CbTargetHor_CheckedChanged;
                }
            }
        }

        private void M_CbTargetHor_CheckedChanged(object sender, EventArgs e)
        {
            if (m_CbTargetHor != null)
            {
                m_TargetHor = (m_CbTargetHor.CheckState == CheckState.Checked);
                this.Invalidate();
            }
        }

        private ComboBox m_CmbDir = null;
        /*
        public ComboBox CmbDir
        {
            get { return m_CmbDir; }
            set
            {
                m_CmbDir = value;
                if(m_CmbDir!=null)
                {
                    if (m_CmbDir.Items.Count < (int)TriangleDir.LeftTop)
                    {
                        int st = m_CmbDir.Items.Count;
                        int v = (int)TriangleDir.LeftTop + 1 - st;

                        for (int i =0; i<v;i++)
                        {
                            m_CmbDir.Items.Add(string.Format("{0}", st + i));
                        }
                    }
                    m_CmbDir.SelectedIndexChanged += M_Dir_SelectedIndexChanged;
                }
            }
        }
    */    
    // ************************************************
        private void M_Dir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CmbDir == null) return;
            if(m_Mode != (TriangleDir)m_CmbDir.SelectedIndex)
            {
                m_Mode = (TriangleDir)m_CmbDir.SelectedIndex;
                this.Invalidate();
            }
        }
        // ************************************************
        private TriangleDir m_Mode = 0;
        public TriangleDir Mode
        {
            get { return m_Mode; }
            set
            {
                int v = Math.Abs((int)value) % 4;
                if(m_Mode !=(TriangleDir)v)
                {
                    m_Mode = (TriangleDir)v;
                    this.Invalidate();
                }
                /*if(m_CmbDir!=null)
                {
                    m_CmbDir.SelectedIndex = (int)m_Mode;
                }*/
            }
        }
        #endregion
        // ************************************************
        public TriangleDrawBox()
        {
            this.Size = new Size(200, 200);

            this.SizeChanged += TriangleDrawBox_SizeChanged;
        }

        private void TriangleDrawBox_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // ************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.White);
            Pen p = new Pen(Color.Black);

            try
            {
                Rectangle rct = new Rectangle(0, 0, this.Width, this.Height);
                g.FillRectangle(sb, rct);
                rct.Width -= 3;
                rct.Height -= 3;
                rct.Location = new Point(rct.Left + 1, rct.Top + 1);
                g.DrawRectangle(p, rct);



                int margin = 20;
                int w,h = 0;
                w = this.Width - margin * 2;
                h = this.Height - margin * 2;

                int rw = 80;
 
                p.Width = 2;
                Point p0 = new Point(margin, margin);
                Point p1 = new Point(margin + w, margin);
                Point p2 = new Point(margin, margin + h);
                string s0 = "A";
                string s1 = "B";
                string s2 = "B";
                switch (m_Mode)
                {
                    case TriangleDir.LeftTop:
                        p0 = new Point(margin, margin);
                        p1 = new Point(margin + w, margin + h);
                        p2 = new Point(margin, margin + h);
                        if (m_TargetHor)
                        {
                            double r = Math.Atan((double)h / (double)w) * 180 / Math.PI;
                            g.DrawArc(p, p1.X - rw / 2, p1.Y - rw / 2, rw, rw, (float)(180), (float)r);
                        }
                        else
                        {
                            double r = Math.Atan((double)w / (double)h) * 180 / Math.PI;
                            g.DrawArc(p, p0.X - rw / 2, p0.Y - rw / 2, rw, rw, (float)(90-r), (float)r);
                        }
                        s0 = "C";
                        s1 = "A";
                        s2 = "B";

                        break;
                    case TriangleDir.RightTop:
                        p0 = new Point(margin, margin+h);
                        p1 = new Point(margin + w, margin);
                        p2 = new Point(margin + w, margin + h);
                        if (m_TargetHor)
                        {
                            double r = Math.Atan((double)h / (double)w) * 180 / Math.PI;
                            g.DrawArc(p, p0.X - rw / 2, p0.Y - rw / 2, rw, rw, (float)(360 - r), (float)r);
                        }
                        else
                        {
                            double r = Math.Atan((double)w / (double)h) * 180 / Math.PI;
                            g.DrawArc(p, p1.X - rw / 2, p1.Y - rw / 2, rw, rw, (float)(90), (float)r);
                        }
                        s0 = "A";
                        s1 = "C";
                        s2 = "B";
                        break;
                    case TriangleDir.LeftBottom:
                        p0 = new Point(margin, margin);
                        p1 = new Point(margin + w, margin);
                        p2 = new Point(margin + w, margin + h);
                        if (m_TargetHor)
                        {
                            double r = Math.Atan((double)h / (double)w) * 180 / Math.PI;
                            g.DrawArc(p, p0.X - rw / 2, p0.Y - rw / 2, rw, rw, (float)(0), (float)r);
                        }
                        else
                        {
                            double r = Math.Atan((double)w / (double)h) * 180 / Math.PI;
                            g.DrawArc(p, p2.X - rw / 2, p2.Y - rw / 2, rw, rw, (float)(270-r), (float)r);
                        }
                        s0 = "A";
                        s1 = "B";
                        s2 = "C";
                        break;
                    case TriangleDir.RightBottom:
                    default:
                        p0 = new Point(margin, margin);
                        p1 = new Point(margin+w, margin);
                        p2 = new Point(margin, margin+ h);
                        if (m_TargetHor)
                        {
                            double r = Math.Atan((double)h / (double)w) * 180 / Math.PI;
                            g.DrawArc(p, p1.X - rw / 2, p1.Y - rw / 2, rw, rw, (float)(180 - r), (float)r);
                        }
                        else
                        {
                            double r = Math.Atan((double)w / (double)h) * 180 / Math.PI;
                            g.DrawArc(p, p2.X - rw / 2, p2.Y - rw / 2, rw, rw, (float)(270), (float)r);
                        }

                        s0 = "B";
                        s1 = "A";
                        s2 = "C";

                        break;
                }
                sb.Color = Color.Red;
                g.DrawString(s0, this.Font, sb, p0.X - 20, p0.Y - 10);
                g.DrawString(s1, this.Font, sb, p1.X, p1.Y );
                g.DrawString(s2, this.Font, sb, p2.X ,p2.Y);

                g.DrawLine(p, p0, p1);
                g.DrawLine(p, p1, p2);
                g.DrawLine(p, p2, p0);


            }
            finally
            {
                sb.Dispose();
            }

        }
    }
}
