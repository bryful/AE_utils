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
    public class AE_Color
    {
        public double A = 255;
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
        public object ToJson()
        {
            var ret = new double[4];
            ret[0] = A;
            ret[1] = R;
            ret[2] = G;
            ret[3] = B;
            return ret;
        }
        public void FromJson(object v)
        {
            try
            {
                if (((DynamicJson)v).IsArray)
                {
                    double[] v2 = ((DynamicJson)v).Deserialize<double[]>(); ;

                    if (v2.Length >= 4)
                    {
                        A = v2[0];
                        R = v2[1];
                        G = v2[2];
                        B = v2[3];
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
        
    }
}
