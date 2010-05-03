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
    public partial class newZbranDialog : Form
    {
        public String edit = "";
        public String jmeno;

        public newZbranDialog()
        {
            InitializeComponent();

            r1.Checked = true;

            databaseDataSet db = Program.getDB();
            {
                OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);
                
                String s = en.ElementAt(0).kategorie;
                zKategorieList.Items.Add(en.ElementAt(0).kategorie);
                foreach (databaseDataSet.zbraneRow row in en)
                {
                    if (s != row.kategorie)
                    {
                        zKategorieList.Items.Add(row.kategorie);
                        s = row.kategorie;
                    }
                }
            }
            {
                OrderedEnumerableRowCollection<databaseDataSet.strelneRow> en = db.strelne.OrderBy(row => row.kategorie);

                String s = en.ElementAt(0).kategorie;
                sKategorieList.Items.Add(en.ElementAt(0).kategorie);
                foreach (databaseDataSet.strelneRow row in en)
                {
                    if (s != row.kategorie)
                    {
                        sKategorieList.Items.Add(row.kategorie);
                        s = row.kategorie;
                    }
                }
            }

            sKategorieList.SelectedIndex = 0;
            zTypList.SelectedIndex = 0;
            sTypList.SelectedIndex = 0;
        }

        public newZbranDialog(String name, String typ)
        {
            InitializeComponent();

            databaseDataSet db = Program.getDB();
            {
                OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);

                String s = en.ElementAt(0).kategorie;
                zKategorieList.Items.Add(en.ElementAt(0).kategorie);
                foreach (databaseDataSet.zbraneRow row in en)
                {
                    if (s != row.kategorie)
                    {
                        zKategorieList.Items.Add(row.kategorie);
                        s = row.kategorie;
                    }
                }
            }
            {
                OrderedEnumerableRowCollection<databaseDataSet.strelneRow> en = db.strelne.OrderBy(row => row.kategorie);

                String s = en.ElementAt(0).kategorie;
                sKategorieList.Items.Add(en.ElementAt(0).kategorie);
                foreach (databaseDataSet.strelneRow row in en)
                {
                    if (s != row.kategorie)
                    {
                        sKategorieList.Items.Add(row.kategorie);
                        s = row.kategorie;
                    }
                }
            }

            edit = jmeno = name;

            if (typ == "rucni")
            {
                r1.Checked = true;

                databaseDataSet.zbraneRow row = db.zbrane.FindByjmeno(jmeno);

                zJmenoL.Text = jmeno;
                zKategorieList.SelectedIndex = zKategorieList.Items.IndexOf(row.kategorie);
                if (row.IspsilaNull() == true)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                    zpSilaN.Value = row.psila;
                }
                zDelkaN.Value = row.delka;
                zUtocnostN.Value = row.utocnost;
                zZraneniN.Value = row.zraneni;
                zTypList.SelectedIndex = zTypList.Items.IndexOf(row.typ);
                zKrytN.Value = row.kryt;
                checkBox2.Checked = (row.obourucni == 1 ? true : false);
                zVaha.Value = (decimal)row.vaha;
            }
            else
            {
                r2.Checked = true;

                databaseDataSet.strelneRow row = db.strelne.FindByjmeno(jmeno);

                sJmenoL.Text = jmeno;
                sKategorieList.SelectedIndex = sKategorieList.Items.IndexOf(row.kategorie);
                spSilaN.Value = row.pSila;
                sMaxSilaN.Value = row.IsmaxSilaNull() == true ? 0 : row.maxSila;
                sUtocnostN.Value = row.utocnost;
                sZraneniN.Value = row.zraneni;
                sTypList.SelectedIndex = sTypList.Items.IndexOf(row.typ);
                sDostrelN.Value = row.dostrel;
                sVaha.Value = (decimal)row.vaha;
            }

            r1.Enabled = false;
            r2.Enabled = false;
        }

        private void r1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = r1.Checked;
            panel2.Enabled = r2.Checked;
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            databaseDataSet db = Program.getDB();

            if (r1.Checked == true)
            {
                //databaseDataSetTableAdapters.zbraneTableAdapter zbraneTableAdapter = new databaseDataSetTableAdapters.zbraneTableAdapter();

                databaseDataSet.zbraneRow row = db.zbrane.NewzbraneRow();
                if (edit != "")
                {
                    row = db.zbrane.FindByjmeno(edit);
                }

                row.jmeno = zJmenoL.Text;
                row.kategorie = zKategorieList.Text;
                if (checkBox1.Checked == true)
                {
                    row.SetpsilaNull();
                }
                else
                {
                    row.psila = (short)zpSilaN.Value;
                }
                row.delka = (short)zDelkaN.Value;
                row.utocnost = (short)zUtocnostN.Value;
                row.zraneni = (short)zZraneniN.Value;
                row.typ = zTypList.SelectedItem.ToString();
                row.kryt = (short)zKrytN.Value;
                row.obourucni = (byte)(checkBox2.Checked == true ? 1 : 0);
                row.vaha = (double)zVaha.Value;

                if (edit == "")
                {
                    try
                    {
                        db.zbrane.AddzbraneRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Zbraň s názvem " + jmeno + " již existuje. Zadejte jiný název.", "Zbraň již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        zJmenoL.Focus();
                        zJmenoL.SelectAll();
                        return;
                    }
                }
                //zbraneTableAdapter.Update(db);
            }
            else
            {
                //databaseDataSetTableAdapters.strelneTableAdapter strelneTableAdapter = new databaseDataSetTableAdapters.strelneTableAdapter();

                databaseDataSet.strelneRow row = db.strelne.NewstrelneRow();
                if (edit != "")
                {
                    row = db.strelne.FindByjmeno(edit);
                }

                row.jmeno = sJmenoL.Text;
                row.kategorie = sKategorieList.SelectedItem.ToString();
                row.pSila = (short)spSilaN.Value;
                if (sKategorieList.SelectedItem.ToString() == "Luky")
                {
                    row.maxSila = (short)sMaxSilaN.Value;
                }
                else
                {
                    row.SetmaxSilaNull();
                }
                row.utocnost = (short)sUtocnostN.Value;
                row.zraneni = (short)sZraneniN.Value;
                row.typ = sTypList.SelectedItem.ToString();
                row.dostrel = (short)sDostrelN.Value;
                row.vaha = (double)sVaha.Value;

                if (edit == "")
                {
                    try
                    {
                        db.strelne.AddstrelneRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Zbraň s názvem " + jmeno + " již existuje. Zadejte jiný název.", "Zbraň již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sJmenoL.Focus();
                        sJmenoL.SelectAll();
                        return;
                    }
                }
                //strelneTableAdapter.Update(db);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            zpSilaN.Enabled = !checkBox1.Checked;
        }
    }
}
