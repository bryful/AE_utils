using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Codeplex.Data;
using System.Collections;

namespace AE_Util_skelton
{
    public class AEColor
    {
        private double RoundD(double b)
        {
            if (b < 0) b = 0;
            return b;
        }

        private double m_A = 255;
        private double m_R = 128;
        private double m_G = 128;
        private double m_B = 128;
        public double A { get { return m_A; } set { m_A = RoundD(value); } }
        public double R { get { return m_R; } set { m_R = RoundD(value); } }
        public double G { get { return m_G; } set { m_G = RoundD(value); } }
        public double B { get { return m_B; } set { m_B = RoundD(value); } }

        // **********************************************************************
        public AEColor()
        {

        }
        // **********************************************************************
        public AEColor(double a, double r, double g, double b)
        {
            m_A = a; m_R = r; m_G = g; m_B = b;
        }
        // **********************************************************************
        public AEColor( double r, double g, double b)
        {
            m_A = 255; m_R = r; m_G = g; m_B = b;
        }
        // **********************************************************************
        public double[] ToArray()
        {
            double[] ret = new double[3];
            ret[0] = m_A;
            ret[1] = m_R;
            ret[2] = m_G;
            ret[3] = m_B;

            return ret;
        }
        // **********************************************************************
        static public AEColor FromArgb(double r,double g, double b)
        {
            AEColor ret = new AEColor();

            ret.m_A = 255.0;
            ret.m_R = r;
            ret.m_G = g;
            ret.m_B = b;
            return ret;
        }
        // **********************************************************************
        public void FromArry(double[] v)
        {
            if (v.Length > 0) m_A = v[0];
            if (v.Length > 1) m_R = v[1];
            if (v.Length > 2) m_G = v[2];
            if (v.Length > 3) m_B = v[3];
        }
        // **********************************************************************
        public Color ToColor()
        {
            return Color.FromArgb((int)(m_A + 0.5), (int)(m_R + 0.5), (int)(m_G + 0.5), (int)(m_B + 0.5));
        }
        // **********************************************************************
        public void FromColor(Color c)
        {
            m_A = (double)c.A;
            m_R = (double)c.R;
            m_G = (double)c.G;
            m_B = (double)c.B;
        }
        // **********************************************************************
        public object ToJson()
        {
            var ret = new double[4];
            ret[0] = m_A;
            ret[1] = m_R;
            ret[2] = m_G;
            ret[3] = m_B;
            return ret;
        }
        // **********************************************************************
        public void FromJson(object v)
        {
            try
            {
                if (((DynamicJson)v).IsArray)
                {
                    double[] v2 = ((DynamicJson)v).Deserialize<double[]>(); ;

                    if (v2.Length >= 4)
                    {
                        m_A = v2[0];
                        m_R = v2[1];
                        m_G = v2[2];
                        m_B = v2[3];
                    }
                    else
                    {

                    }
                }
            }
            catch
            {

            }
        }
        // **********************************************************************
        public bool Equals(AEColor c)
        {
            return ((m_A == c.m_A) && (m_R == c.m_R) && (m_G == c.m_G) && (m_B == c.m_B));
        }

    }
}
