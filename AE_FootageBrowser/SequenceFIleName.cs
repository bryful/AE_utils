using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AE_FootageBrowser
{
    public class SequenceFileName
    {
        private string m_Parent = "";
        private string m_Node = "";
        private string m_Frame = "";
        private string m_Ext = "";
        private int m_StartFrame = 0;
        private int m_LastFrame = 0;
        public SequenceFileName()
        {

        }
        public SequenceFileName(string s)
        {

        }
        static public string[] Analysis(string s)
        {
            string[] ret = new string[4];
            ret[0] = ret[1] = ret[2] = ret[3] = "";
            if (s == "") return ret;
            string p = Path.GetDirectoryName(s);
            string e = Path.GetExtension(s);
            string tmp = Path.GetFileNameWithoutExtension(s);

            string n = "";
            string f = "";

            int idx = -1;
            for ( int i= tmp.Length-1; i>=0;i--)
            {
                char c = tmp[i];
                if ((c < '0') || (c > '9'))
                {
                    idx = i;
                    break;
                }
            }

            //fff001
            //012345
            if (idx <= 0)
            {
                //全部数字
                f = tmp;
            }else if (idx== tmp.Length - 1)
            {
                //数字なし
                n = tmp;
            }
            else
            {
                n = tmp.Substring(0, idx + 1);
                f = tmp.Substring(idx + 1);
            }
            ret[0] = p;
            ret[1] = n;
            ret[2] = f;
            ret[3] = e;

            return ret;
        }

    }
}
