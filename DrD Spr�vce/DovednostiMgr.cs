using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public class Dovednost
    {
        private Panel parentPanel = new Panel();
        public LinkLabel label = new LinkLabel();

        public String dovednost;
        public int stupen;

        private DovednostiMgr mgr;

        public Dovednost(DovednostiMgr mgr, FlowLayoutPanel flowPanel, String dovednost, int stupen)
        {
            this.mgr = mgr;
            this.dovednost = dovednost;
            this.stupen = stupen;

            parentPanel.AutoSize = true;
            parentPanel.Margin = new Padding(3);
            parentPanel.Parent = flowPanel;

            label.AutoSize = true;
            label.VisitedLinkColor = Color.Blue;
            label.LinkBehavior = LinkBehavior.HoverUnderline;
            label.LinkClicked += new LinkLabelLinkClickedEventHandler(label_LinkClicked);
            label.Parent = parentPanel;

            Calculate();
        }

        public void Calculate()
        {
            setLabels();
        }

        private void label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Panel details = mgr.details;

            details.Show();

            ((Label)details.Controls.Find("dovName", true)[0]).Text = dovednost + "       " + GetStupen() + ". stupeň";
            TextBox popis = (TextBox)details.Controls.Find("dovPopis", true)[0];
            popis.Clear();
            databaseDataSet.dovednostiRow row = Program.getDB().dovednosti.FindByjmeno(dovednost);
            if (row != null)
            {
                if (!row.IspopisNull())
                    popis.Text = row.popis + "\r\n\r\n";
                if (stupen == 1)
                {
                    if (!row.Ispopis1Null())
                        popis.Text += row.popis1;
                }
                else if (stupen == 2)
                {
                    if (!row.Ispopis2Null())
                        popis.Text += row.popis2;
                }
                else
                {
                    if (!row.Ispopis3Null())
                        popis.Text += row.popis3;
                }
            }
        }

        private void setLabels()
        {
            label.Text = dovednost + " (" + GetStupen() + ")";
        }

        public String GetStupen()
        {
            switch (stupen)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
            }
            return "?";
        }

        public void Dispose()
        {
            parentPanel.Dispose();
            label.Dispose();
        }
    }


    public class DovednostiMgr
    {
        public List<Dovednost> fyzList = new List<Dovednost>();
        public List<Dovednost> psyList = new List<Dovednost>();
        public List<Dovednost> kombList = new List<Dovednost>();
        
        private FlowLayoutPanel p1, p2, p3;

        public Panel details;
        
        public Postava postava;

        public DovednostiMgr(FlowLayoutPanel fp1, FlowLayoutPanel fp2, FlowLayoutPanel fp3, Panel dets, Postava pos)
        {
            postava = pos;
            details = dets;

            this.p1 = fp1;
            this.p2 = fp2;
            this.p3 = fp3;

            this.p1.Controls.Clear();
            this.p2.Controls.Clear();
            this.p3.Controls.Clear();
        }

        public void AddFyz(String nazev, int stupen)
        {
            foreach (Dovednost d in fyzList)
            {
                if (d.dovednost == nazev)
                {
                    d.stupen = stupen;
                    d.Calculate();
                    return;
                }
            }
            fyzList.Add(new Dovednost(this, p1, nazev, stupen));
        }

        public void AddPsy(String nazev, int stupen)
        {
            foreach (Dovednost d in psyList)
            {
                if (d.dovednost == nazev)
                {
                    d.stupen = stupen;
                    d.Calculate();
                    return;
                }
            }
            psyList.Add(new Dovednost(this, p2, nazev, stupen));
        }

        public void AddKomb(String nazev, int stupen)
        {
            foreach (Dovednost d in kombList)
            {
                if (d.dovednost == nazev)
                {
                    d.stupen = stupen;
                    d.Calculate();
                    return;
                }
            }
            kombList.Add(new Dovednost(this, p3, nazev, stupen));
        }

        public void Clear()
        {
            foreach (Dovednost p in fyzList)
            {
                p.Dispose();
                fyzList.Remove(p);
                return;
            }
            foreach (Dovednost p in psyList)
            {
                p.Dispose();
                psyList.Remove(p);
                return;
            }
            foreach (Dovednost p in kombList)
            {
                p.Dispose();
                kombList.Remove(p);
                return;
            }
        }

        public void UpdateAll()
        {
            {
                List<Pair<String, int>> temp = new List<Pair<String, int>>();
                foreach (Dovednost p in fyzList)
                {
                    Pair<String, int> pair = new Pair<string, int>();
                    pair.first = p.dovednost;
                    pair.second = p.stupen;
                    temp.Add(pair);
                }
                temp = temp.OrderBy(d => d.first).ToList();
                p1.Controls.Clear();
                fyzList.Clear();
                foreach (Pair<String, int> pair in temp)
                {
                    Dovednost x = new Dovednost(this, p1, pair.first, pair.second);
                    x.Calculate();
                    fyzList.Add(x);
                }
            }
            {
                List<Pair<String, int>> temp = new List<Pair<String, int>>();
                foreach (Dovednost p in psyList)
                {
                    Pair<String, int> pair = new Pair<string, int>();
                    pair.first = p.dovednost;
                    pair.second = p.stupen;
                    temp.Add(pair);
                }
                temp = temp.OrderBy(d => d.first).ToList();
                p2.Controls.Clear();
                psyList.Clear();
                foreach (Pair<String, int> pair in temp)
                {
                    Dovednost x = new Dovednost(this, p2, pair.first, pair.second);
                    x.Calculate();
                    psyList.Add(x);
                }
            }
            {
                List<Pair<String, int>> temp = new List<Pair<String, int>>();
                foreach (Dovednost p in kombList)
                {
                    Pair<String, int> pair = new Pair<string, int>();
                    pair.first = p.dovednost;
                    pair.second = p.stupen;
                    temp.Add(pair);
                }
                temp = temp.OrderBy(d => d.first).ToList();
                p3.Controls.Clear();
                kombList.Clear();
                foreach (Pair<String, int> pair in temp)
                {
                    Dovednost x = new Dovednost(this, p3, pair.first, pair.second);
                    x.Calculate();
                    kombList.Add(x);
                }
            }
            details.Hide();
        }

        public int getDovednost(String name)
        {
            foreach (Dovednost dov in fyzList)
            {
                if (dov.dovednost == name)
                {
                    return dov.stupen;
                }
            }
            foreach (Dovednost dov in kombList)
            {
                if (dov.dovednost == name)
                {
                    return dov.stupen;
                }
            }
            foreach (Dovednost dov in psyList)
            {
                if (dov.dovednost == name)
                {
                    return dov.stupen;
                }
            }
            return 0;
        }
    }
}
