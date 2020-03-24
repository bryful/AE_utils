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
        public string path = "";
        // *******************************************************
        public List<ColorBox> Items = new List<ColorBox>();
        public int Count { get { return Items.Count; } }
        // *******************************************************
        private int m_Rows = 5;
        public int Rows {  get { return m_Rows; } }
        private int m_Cols = 5;
        public int Cols { get { return m_Cols; } }
        private int m_SelectedIndex = -1;
        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
            set
            {
                SetSelectedIndex(value,true);
            }
        }
        // *******************************************************
        public void SetSelectedIndex(int idx,bool b)
        {
            if((idx>=0)&&(idx<Count))
            {
                if (b == true)
                {
                    if (m_SelectedIndex >= 0)
                    {
                        Items[m_SelectedIndex].SetSelected2(false, false);
                    }
  
                }
                m_SelectedIndex = idx;
                Items[m_SelectedIndex].SetSelected2(true, true);
            }
            else
            {
                if (m_SelectedIndex >= 0)
                {
                    Items[m_SelectedIndex].SetSelected2(false, true);
                    m_SelectedIndex = -1;
                }

            }
        }
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
                    cb.AE_Color = AEColor.FromArgb(10, 10, 10); ;
                    cb.Index = idx;
                    cb.MouseDown += Cb_MouseDown;
                    Items.Add(cb);
                    idx++;
                }
            }
        }

        private void Cb_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelectedIndex(((ColorBox)sender).Index,true);
        }

        private void InitColors(int r, int c)
        {
            if ((m_Cols == c) && (m_Rows == r)) return;
            int cnt = r * c;
            if (Count > cnt)
            {
                int st = Count - 1;
                for ( int i= st; i>=cnt;i--)
                {
                    Items[i].Dispose();
                    Items.RemoveAt(i);
                }
            }
            else
            {
                int st = Count ;
                for ( int i = st; i<cnt; i++)
                {
                    ColorBox cb = new ColorBox();
                    cb.Name = String.Format("Colorbox{0}", i);
                    cb.SelectColor = Color.Gray;
                    cb.AE_Color = AEColor.FromArgb(10, 10, 10); ;
                    cb.Index = i;
                    cb.MouseDown += Cb_MouseDown;
                    Items.Add(cb);
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

                var colors = new object[Count];
                for (int i = 0; i < Count; i++)
                {
                    colors[i] = Items[i].AE_Color.ToJson();
                }
                pref.SetObject("Colors",colors);


                if (p == "")
                {
                    p = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                    p = Path.Combine(Application.UserAppDataPath, p + "_color.json");
                }

                ret = pref.Save(p);
                path = p;
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
                if (p == "")
                {
                    p = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                    p = Path.Combine(Application.UserAppDataPath, p + "_color.json");
                }
                ret = pref.Load(p);
                path = p;
                if (ret == false) return ret;
                bool ok = false;
                int r = pref.GetInt("Rows", out ok);
                int c = 0;
                var  cols = new object[0];
                if (ok) c = pref.GetInt("Cols", out ok);
                if (ok) cols = pref.GetObjectArray("Colors", out ok);
                if (ok)
                {
                    InitColors(r, c);
                    for (int i = 0; i < Count; i++)
                    {
                        Items[i].AE_Color.FromJson(cols[i]);
                    }
                    ret = true;
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
