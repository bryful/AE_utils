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

namespace AE_Util_skelton
{
    public class FootageList : ListBox
    {
        private string m_CurrentPath = "";
        // **************************************************************
        public FootageList()
        {
            if(m_TargetExt.Count<=0)
            {
                TargetExt = ".tga;.png;.jpg;.tif";
            }
        }
        // **************************************************************
        private List<string> m_TargetExt = new List<string>();
        public string TargetExt
        {
            get { return string.Join(";", m_TargetExt); }
            set
            {
                string s = value.Trim();
                string[] sa = s.Split(';');
                m_TargetExt.Clear();
                if (sa.Length > 0)
                {
                    foreach(string c in sa)
                    {
                        string c2 = c.Trim().ToLower();
                        if (c2 != "")
                            m_TargetExt.Add(c2);
                    }
                }
            }
        }
        // **************************************************************
        public void Listup(string p="")
        {
            if (p == "") p = m_CurrentPath;

            string [] fl = Directory.GetFiles(p);
            string[] dl = Directory.GetDirectories(p);
        }
        // **************************************************************
    }
}
