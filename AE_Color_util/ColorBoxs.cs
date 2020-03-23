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
using System.IO;

using BRY;
namespace AE_Util_skelton
{
    public class ColorBoxs
    {
        // *******************************************************
        public List<ColorBox> Items = new List<ColorBox>();
        public int Count { get { return Items.Count; } }
        // *******************************************************
        private int m_Rows = 5;
        public int Rows {  get { return m_Rows; } }
        private int m_Cols = 5;
        public int Cols { get { return m_Cols; } }
        // *******************************************************
        public bool IsLocked
        {
            get { return Items[0].IsLocked; }
            set
            {
                for (int i=0;i< Count;i++)
                {
                    Items[i].IsLocked = value;
                }
            }
        }
        // *******************************************************
        public ColorBoxs(int r=5, int c=5)
        {
            CreateColors(r, c);
        }
        // *******************************************************
        private void CreateColors(int r, int c)
        {
            m_Rows = r;
            if (m_Rows < 1) m_Rows = 1;
            m_Cols = c;
            if (m_Cols < 1) m_Cols = 1;
            int idx = 0;
            for (int j = 0; j < r; j++)
            {
                for (int i = 0; i < c; i++)
                {
                    ColorBox cb = new ColorBox();
                    cb.Name = String.Format("Colorbox{0}", idx);
                    cb.SelectColor = Color.Gray;
                    cb.Color = Color.FromArgb(10, 10, 10); ;
                    cb.Index = idx;
                    Items.Add(cb);
                    idx++;
                }
            }
        }
        // *******************************************************
        public void SetLoc(int x, int y, int w,int h)
        {
            int idx = 0;
            int y2 = y;
            for (int j = 0; j < m_Rows; j++)
            {
                int x2 = x;
                for (int i = 0; i < m_Cols; i++)
                {
                    Items[idx].Location = new Point(x2, y2);
                    x2 += w;
                    idx++;
                }
                y2 += h;
            }
        }
        // *******************************************************
        public bool Save(string p = "")
        {
            bool ret = false;
            JsonPref pref = new JsonPref();

            try
            {
                pref.SetInt("Rows", m_Rows);
                pref.SetInt("Cols", m_Cols);

                Color[] colors = new Color[Count];
                for (int i = 0; i < Count; i++)
                {
                    colors[i] = Items[i].Color;
                }
                pref.SetColorArray("Colors",colors);


                if(p=="") p = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                p = Path.Combine(Application.UserAppDataPath,p + "_color.json");

                ret = pref.Save(p);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        // *******************************************************
        public bool Load(string p="")
        {
            bool ret = false;
            JsonPref pref = new JsonPref();

            try
            {
                if (p == "") p = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                p = Path.Combine(Application.UserAppDataPath, p + "_color.json");
                ret = pref.Load(p);
                if (ret == false) return ret;
                bool ok = false;
                int r = pref.GetInt("Rows", out ok);
                if (ok) m_Rows = r;
                int c = pref.GetInt("Cols", out ok);
                if (ok) m_Cols = c;
                Color[] cols = pref.GetColorArray("Colors", out ok);
                if(ok)
                {
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
