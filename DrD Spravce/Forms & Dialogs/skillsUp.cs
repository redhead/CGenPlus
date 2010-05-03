using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class skillsUp : Form
    {
        private String vlast1, vlast2;
        private String typ1, typ2;
        private List<String> nazvy1 = new List<String>();
        private List<String> nazvy2 = new List<String>();
        private Postava postava;

        public skillsUp(Postava pos, String vlast1, String vlast2)
        {
            InitializeComponent();

            this.vlast1 = vlast1;
            this.vlast2 = vlast2;
            this.postava = pos;

            typ1 = Fill(list1, this.vlast1, nazvy1);
            typ2 = Fill(list2, this.vlast2, nazvy2);
        }

        private String Fill(ListBox list, String vlast, List<String> nazvy)
        {
            databaseDataSet.dovednostiDataTable dovednosti = Program.getDB().dovednosti;
            if (vlast == "Sil" || vlast == "Obr")
            {
                databaseDataSet db = Program.getDB();
                OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);

                list.Items.Add("Boj (" + en.ElementAt(0).kategorie + ")");
                nazvy.Add("Boj (" + en.ElementAt(0).kategorie + ")");
                String s = en.ElementAt(0).kategorie;
                foreach (databaseDataSet.zbraneRow row in en)
                {
                    if (s != row.kategorie)
                    {
                        list.Items.Add("Boj (" + row.kategorie + ")");
                        nazvy.Add("Boj (" + row.kategorie + ")");
                        s = row.kategorie;
                    }
                }
                list.Items.Add("Boj s vrhacími zbraněmi");
                nazvy.Add("Boj s vrhacími zbraněmi");
                list.Items.Add("Nošení zbroje");
                nazvy.Add("Nošení zbroje");
                list.Items.Add("Používání štítu");
                nazvy.Add("Používání štítu");
                foreach (databaseDataSet.dovednostiRow row in dovednosti)
                {
                    if (row.typ == "fyz")
                    {
                        list.Items.Add(row.jmeno);
                        nazvy.Add(row.jmeno);
                    }
                }
                foreach (Dovednost d in postava.dovednostiMgr.fyzList)
                {
                    if (d.stupen == 3)
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items.RemoveAt(index);
                        nazvy.RemoveAt(index);
                    }
                    else
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items[index] = d.dovednost + " (" + d.GetStupen() + ")";
                    }
                }
                return "fyz";
            }
            else if (vlast == "Vol" || vlast == "Int")
            {
                foreach (databaseDataSet.dovednostiRow row in dovednosti)
                {
                    if (row.typ == "psy")
                    {
                        list.Items.Add(row.jmeno);
                        nazvy.Add(row.jmeno);
                    }
                }
                foreach (Dovednost d in postava.dovednostiMgr.psyList)
                {
                    if (d.stupen == 3)
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items.RemoveAt(index);
                        nazvy.RemoveAt(index);
                    }
                    else
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items[index] = d.dovednost + " (" + d.GetStupen() + ")";
                    }
                }
                return "psy";
            }
            else
            {
                list.Items.Add("Boj s luky");
                list.Items.Add("Boj s kušemi");
                nazvy.Add("Boj s luky");
                nazvy.Add("Boj s kušemi");
                foreach (databaseDataSet.dovednostiRow row in dovednosti)
                {
                    if (row.typ == "komb")
                    {
                        list.Items.Add(row.jmeno);
                        nazvy.Add(row.jmeno);
                    }
                }
                foreach (Dovednost d in postava.dovednostiMgr.kombList)
                {
                    if (d.stupen == 3)
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items.RemoveAt(index);
                        nazvy.RemoveAt(index);
                    }
                    else
                    {
                        int index = list.Items.IndexOf(d.dovednost);
                        list.Items[index] = d.dovednost + " (" + d.GetStupen() + ")";
                    }
                }
                return "komb";
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (list1.SelectedItem == null || list2.SelectedItem == null)
            {
                MessageBox.Show("Musíte vybrat dvě dovednosti, kterým se má zvýšit stupeň.", "Výběr dovedností", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (list1.SelectedItem.ToString() == list2.SelectedItem.ToString())
            {
                MessageBox.Show("Nelze navýšit jednu dovednost o 2 stupně.", "Navýšení", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (list1.SelectedItem.ToString() == nazvy1[list1.SelectedIndex])
            {
                if (typ1 == "fyz")
                {
                    postava.dovednostiMgr.AddFyz(nazvy1[list1.SelectedIndex], 1);
                }
                else if (typ1 == "psy")
                {
                    postava.dovednostiMgr.AddPsy(nazvy1[list1.SelectedIndex], 1);
                }
                else
                {
                    postava.dovednostiMgr.AddKomb(nazvy1[list1.SelectedIndex], 1);
                }
            }
            else
            {
                if (typ1 == "fyz")
                {
                    foreach (Dovednost d in postava.dovednostiMgr.fyzList)
                    {
                        if (d.dovednost == nazvy1[list1.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
                else if (typ1 == "psy")
                {
                    foreach (Dovednost d in postava.dovednostiMgr.psyList)
                    {
                        if (d.dovednost == nazvy1[list1.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Dovednost d in postava.dovednostiMgr.kombList)
                    {
                        if (d.dovednost == nazvy1[list1.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
            }

            if (list2.SelectedItem.ToString() == nazvy2[list2.SelectedIndex])
            {
                if (typ2 == "fyz")
                {
                    postava.dovednostiMgr.AddFyz(nazvy2[list2.SelectedIndex], 1);
                }
                else if (typ2 == "psy")
                {
                    postava.dovednostiMgr.AddPsy(nazvy2[list2.SelectedIndex], 1);
                }
                else
                {
                    postava.dovednostiMgr.AddKomb(nazvy2[list2.SelectedIndex], 1);
                }
            }
            else
            {
                if (typ2 == "fyz")
                {
                    foreach (Dovednost d in postava.dovednostiMgr.fyzList)
                    {
                        if (d.dovednost == nazvy2[list2.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
                else if (typ2 == "psy")
                {
                    foreach (Dovednost d in postava.dovednostiMgr.psyList)
                    {
                        if (d.dovednost == nazvy2[list2.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Dovednost d in postava.dovednostiMgr.kombList)
                    {
                        if (d.dovednost == nazvy2[list2.SelectedIndex])
                        {
                            d.stupen++;
                            break;
                        }
                    }
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
