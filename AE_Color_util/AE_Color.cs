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
    public class AE_Color
    {
        public double A = 1;
        public double R = 10;
        public double G = 10;
        public double B = 10;
        public AE_Color()
        {

        }
        public double[] ToArray()
        {
            double[] ret = new double[3];
            ret[0] = A;
            ret[1] = R;
            ret[2] = G;
            ret[3] = B;

            return ret;
        }
        static public AE_Color FromArgb(double r,double g, double b)
        {
            AE_Color ret = new AE_Color();

            ret.A = 1.0;
            ret.R = r;
            ret.G = g;
            ret.B = b;
            return ret;
        }
        public void FromArry(double[] v)
        {
            if (v.Length > 0) A = v[0];
            if (v.Length > 1) R = v[1];
            if (v.Length > 2) G = v[2];
            if (v.Length > 3) B = v[3];
        }
        public Color ToColor()
        {
            return Color.FromArgb((int)(A + 0.5), (int)(R + 0.5), (int)(G + 0.5), (int)(B + 0.5));
        }
        public void FromColor(Color c)
        {
            A = (double)c.A;
            R = (double)c.R;
            G = (double)c.G;
            B = (double)c.B;
        }
        public string ToJson()
        {
            return String.Format("[{0},{1},{2},{3}]", A, R, G, B);
        }
        public void FromJson(string s)
        {
            s = s.Trim();
            if (s == "") return;
            if (s.IndexOf('[') == 0) s = s.Substring(1);
            if (s.LastIndexOf(']') == s.Length - 1) s = s.Substring(0, s.Length - 1);
            string[] sa = s.Split(',');
            if (sa.Length >= 4)
            {
                double v = -1;
                if( double.TryParse(sa[0],out v)) A = v;
                if (double.TryParse(sa[1], out v)) R = v;
                if (double.TryParse(sa[2], out v)) G = v;
                if (double.TryParse(sa[3], out v)) B = v;
            }
        }
    }
}
