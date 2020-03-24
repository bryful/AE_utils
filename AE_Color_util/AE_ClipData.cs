using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AE_Util_skelton
{
    public class AE_ClipData
    {
        private string m_ClipData_template =
            "Adobe After Effects 8.0 Keyframe Data\r\n"
            + "\r\n"
            + "\tUnits Per Second\t24\r\n"
            + "\tSource Width\t1440\r\n"
            + "\tSource Height\t810\r\n"
            + "\tSource Pixel Aspect Ratio\t1\r\n"
            + "\tComp Pixel Aspect Ratio\t1\r\n"
            + "\r\n"
            + "$DATA"
            //+ "Effects\tカラー制御 #2\tカラー #2\r\n"
            //+ "\tFrame\talpha \tred \tgreen \tblue \t\r\n"
            //+ "\t\t255\t0\t255\t0\t\r\n"
            //+ "\r\n"
            + "\r\n"
            + "\r\n"
            +"End of Keyframe Data\r\n";
        private string m_ClipData_ColH1 = "Effects\tカラー制御 #2\tカラー #2";
        private string m_ClipData_ColH2 = "\tFrame\talpha \tred \tgreen \tblue \t";
        private string m_ClipData_ColH3 = "\t\t$ALPHA\t$RED\t$GREEN\t$BLUE\t";

        private string m_ClipData_HEADER = "Adobe After Effects 8.0 Keyframe Data";
        private string m_ClipData_FOOTER = "End of Keyframe Data";

        // ****************************************************************************************
        public AE_ClipData()
        {

        }
        // ****************************************************************************************
        private string[] GetClip()
        {
            string [] ret = new string[0];
            if( Clipboard.ContainsText()==true)
            {
                string s = Clipboard.GetText().Trim();
                if (s == "") return ret;
                string[] sa = s.Split('\n');
                if (sa.Length < 8) return ret;

                if (sa[0].IndexOf("Adobe After Effects") != 0) return ret;
                for(int i=0; i<sa.Length;i++)
                {
                    sa[i] = sa[i].Replace("\r", "");
                }
                ret = sa;
            }
            return ret;
        }
        // ****************************************************************************************
        private int FindEffectsColor(string[] sa, int st = 0)
        {
            int ret = -1;
            for (int i= st; i<sa.Length-2; i++)
            {
                if (sa[i].IndexOf("Effects")==0)
                {
                    if (sa[i+1] == m_ClipData_ColH2)
                    {
                        ret = i+2;
                        break;
                    }

                }
            }
            return ret;
        }
        // ****************************************************************************************
        private AE_Color [] AnalysisColors(string [] sa)
        {
            List<AE_Color> ret = new List<AE_Color>();


            int idx = 0;

            do
            {
                idx = FindEffectsColor(sa, idx);
                if (idx < 0) break;
                string[] c = sa[idx].Split('\t');
                if (c.Length>6)
                {
                    double a = 255;
                    double r = -1;
                    double g = -1;
                    double b = -1;
                    double v = -1;
                    if (double.TryParse(c[2], out v) == true)
                    {
                        a = v;
                    }
                    if (double.TryParse(c[3], out v) == true)
                    {
                        r = v;
                    }
                    if (double.TryParse(c[4], out v) == true)
                    {
                        g = v;
                    }
                    if (double.TryParse(c[5], out v) == true)
                    {
                        b = v;
                    }
                    if((a>=0)&&(r>=0)&& (g >= 0)&& (b >= 0))
                    {
                        AE_Color cc = new AE_Color();
                        cc.A = a; cc.R = r; cc.G = g; cc.B = b;
                        ret.Add(cc);
                    }
                }
                idx += 1;
            } while ((idx >= 0) && (idx < sa.Length));

            return ret.ToArray();

        }
        // ****************************************************************************************
        public AE_Color[] ColorFromClip()
        {
            AE_Color[] ret = new AE_Color[0];

            string[] sa = GetClip();
            if (sa.Length < 8) return ret.ToArray();
            ret = AnalysisColors(sa);
            return ret;
        }
        // ****************************************************************************************
        public void ColorToClip(AE_Color col)
        {
            string str =
            "Adobe After Effects 8.0 Keyframe Data\r\n"
            + "\r\n"
            + "	Units Per Second	24\r\n"
            + "	Source Width	1440\r\n"
            + "	Source Height	810\r\n"
            + "	Source Pixel Aspect Ratio	1\r\n"
            + "	Comp Pixel Aspect Ratio	1\r\n"
            + "\r\n"
            + "Effects	カラー制御 #2	カラー #2\r\n"
            + "	Frame	alpha 	red 	green 	blue 	\r\n"
            + "		$A	$R	$G	$B	\r\n"
            + "\r\n"
            + "\r\n"
            + "End of Keyframe Data\r\n";


            str = str.Replace("$A", col.A.ToString());
            str = str.Replace("$R", col.R.ToString());
            str = str.Replace("$G", col.G.ToString());
            str = str.Replace("$B", col.B.ToString());

            Clipboard.SetText(str);

        }
    }
}
