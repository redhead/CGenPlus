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
    public partial class newKombinace : Form
    {
        public String zJmeno;
        public String sJmeno;

        public short zSila;
        public short sSila;

        public short delka;
        public short omezeni;

        public short utocnost;
        public short zraneni;
        public String typ;
        public short zKryt;
        public short sKryt;

        public short dostrel;
        public short maxSila;

        public short zDovednost;
        public short sDovednost;

        private Postava postava;

        public newKombinace(Postava pos)
        {
            InitializeComponent();

            postava = pos;
            r1.Checked = true;
        }

        public newKombinace(Postava pos, Kombinace kombo)
        {
            InitializeComponent();

            postava = pos;
            r1.Checked = true;
            r1.Enabled = false;
            r2.Enabled = false;
            
            TreeNode[] nodes = tree.Nodes.Find(kombo.zbran, true);
            if (nodes.Length != 0)
            {
                tree.SelectedNode = nodes[0];
            }
            else
            {
                MessageBox.Show("V databázi neexistuje zbraň " + kombo.zbran);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
            list.SelectedIndex = list.FindString(kombo.stit);
            
            checkBox1.Checked = kombo.obouruc;
            if (Program.getDB().zbrane.FindByjmeno(kombo.zbran).obourucni == 1)
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }
            nazevKomba.Text = kombo.nazev;
        }

        public newKombinace(Postava pos, Strelna kombo)
        {
            InitializeComponent();

            postava = pos;

            r2.Checked = true;
            r1.Enabled = false;
            r2.Enabled = false;

            TreeNode[] nodes = tree.Nodes.Find(kombo.zbran, true);
            if (nodes.Length != 0)
            {
                tree.SelectedNode = nodes[0];
            }
            else
            {
                MessageBox.Show("V databázi neexistuje zbraň " + kombo.zbran);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
            nazevKomba.Text = kombo.nazev;
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            databaseDataSet db = Program.getDB();
            if (r1.Checked == true)
            {
                databaseDataSet.zbraneRow row = db.zbrane.FindByjmeno(tree.SelectedNode.Text);
                if (row != null)
                {
                    panel.Visible = true;
                    jmenoL.Text = row.jmeno;
                    pSilaL.Text = row.IspsilaNull() ? "-" : Program.parseBonus(row.psila);
                    delkaL.Text = row.delka.ToString();
                    utocL.Text = row.utocnost.ToString();
                    zraneniL.Text = Program.parseBonus(row.zraneni);
                    typL.Text = row.typ;
                    krytL.Text = row.kryt.ToString();

                    zJmeno = row.jmeno;
                    zSila = row.IspsilaNull() ? (short)-99 : row.psila;
                    delka = row.delka;
                    utocnost = row.utocnost;
                    zraneni = row.zraneni;
                    typ = row.typ;
                    zKryt = row.kryt;

                    if (delka > 0)
                    {
                        checkBox1.Visible = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox1.Visible = false;
                    }

                    if (row.obourucni == 1)
                    {
                        checkBox1.Checked = true;
                        checkBox1.Enabled = false;
                    }
                    else
                    {
                        checkBox1.Enabled = true;
                    }
                    int dov = postava.dovednostiMgr.getDovednost("Boj (" + row.kategorie + ")");
                    zDov.Text = "Dovednost se zbraní na " + (dov == 0 ? "žádném" : (dov.ToString() + ".")) + " stupni";
                    nazevKomba.Text = zJmeno;
                }
                else
                {
                    sJmeno = "";
                    panel.Visible = false;
                }
            }
            else
            {
                databaseDataSet.strelneRow row = db.strelne.FindByjmeno(tree.SelectedNode.Text);
                if (row != null)
                {
                    panel3.Visible = true;
                    jmenoL2.Text = row.jmeno;
                    pSilaL2.Text = Program.parseBonus(row.pSila) + (row.IsmaxSilaNull() == true ? "" : "/" + Program.parseBonus(row.maxSila));
                    utocL2.Text = row.utocnost.ToString();
                    zraneniL2.Text = Program.parseBonus(row.zraneni);
                    typL2.Text = row.typ;
                    dostelL2.Text = row.dostrel.ToString();

                    zJmeno = row.jmeno;
                    zSila = row.pSila;
                    maxSila = row.IsmaxSilaNull() ? (short)-99 : row.maxSila;
                    utocnost = row.utocnost;
                    zraneni = row.zraneni;
                    typ = row.typ;
                    dostrel = row.dostrel;

                    int dov = 0;
                    if (row.kategorie == "Luky")
                    {
                        dov = postava.dovednostiMgr.getDovednost("Boj s luky");
                    }
                    else if (row.kategorie == "Kuše")
                    {
                        dov = postava.dovednostiMgr.getDovednost("Boj s kušemi");
                    }
                    else
                    {
                        dov = postava.dovednostiMgr.getDovednost("Boj s vrhacími zbraněmi");
                    }
                    dov2.Text = "Dovednost se zbraní na " + (dov == 0 ? "žádném" : (dov.ToString() + ".")) + " stupni";
                    nazevKomba.Text = zJmeno;
                }
                else
                {
                    zJmeno = "";
                    panel3.Visible = false;
                }
            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            databaseDataSet db = Program.getDB();
            if (list.SelectedItem == null) return;
            databaseDataSet.stityRow row = db.stity.FindByjmeno(list.SelectedItem.ToString());
            if (row != null)
            {
                panel2.Visible = true;
                sJmenoL.Text = row.jmeno;
                spSilaL.Text = row.IspsilaNull() ? "-" : Program.parseBonus(row.psila);
                sOmezeniL.Text = row.omezeni.ToString();
                sUtocL.Text = row.utocnost.ToString();
                sZraneniL.Text = Program.parseBonus(row.zraneni);
                sTypL.Text = row.typ;
                sKrytL.Text = row.kryt.ToString();
                
                sJmeno = row.jmeno;
                sSila = row.IspsilaNull() ? (short)-99 : row.psila;
                omezeni = row.omezeni;
                sKryt = row.kryt;

                int dov = postava.dovednostiMgr.getDovednost("Používání štítu");
                sDov.Text = "Dovednost se štítem na " + (dov == 0 ? "žádném" : (dov.ToString() + ".")) + " stupni";
            }
            else
            {
                sJmeno = "";
                panel2.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            list.SelectedIndex = 0;
            list.Enabled = !checkBox1.Checked;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (zJmeno == "")
            {
                MessageBox.Show("Musíte vybrat zbraň ze seznamu.", "Vyberte zbraň", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void r1_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked == true)
            {
                panel.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                list.Visible = true;

                databaseDataSet db = Program.getDB();
                OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);

                tree.Nodes.Clear();
                TreeNode node = tree.Nodes.Add(en.ElementAt(0).kategorie);
                String s = en.ElementAt(0).kategorie;
                foreach (databaseDataSet.zbraneRow row in en)
                {
                    if (s == row.kategorie)
                    {
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                    else
                    {
                        node = tree.Nodes.Add(row.kategorie);
                        s = row.kategorie;
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                }
                tree.SelectedNode = tree.Nodes[0];

                list.Items.Clear();
                list.Items.Add("Žádný štít");
                foreach (databaseDataSet.stityRow row in Program.getDB().stity)
                {
                    list.Items.Add(row.jmeno);
                }
                list.SelectedIndex = 0;
            }
            else
            {
                panel.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                list.Visible = false;

                databaseDataSet db = Program.getDB();
                OrderedEnumerableRowCollection<databaseDataSet.strelneRow> en = db.strelne.OrderBy(row => row.kategorie);

                tree.Nodes.Clear();
                TreeNode node = tree.Nodes.Add(en.ElementAt(0).kategorie);
                String s = en.ElementAt(0).kategorie;
                foreach (databaseDataSet.strelneRow row in en)
                {
                    if (s == row.kategorie)
                    {
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                    else
                    {
                        node = tree.Nodes.Add(row.kategorie);
                        s = row.kategorie;
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                }
                tree.SelectedNode = tree.Nodes[0];
            }
        }
    }
}