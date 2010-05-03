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
    public partial class newPredmet : Form
    {
        public String predmet = "";
        public String ownName = "";
        public List<Oprava> opravy = new List<Oprava>();

        private Postava postava;

        public newPredmet(Postava pos)
        {
            InitializeComponent();

            postava = pos;
            zaplatitCh.Checked = true;
            zaplatitCh.Checked = false;

            UpdateTree();
        }

        private void UpdateTree()
        {
            tree.Nodes.Clear();
            databaseDataSet db = Program.getDB();
            OrderedEnumerableRowCollection<databaseDataSet.predmetyRow> en = db.predmety.OrderBy(row => row.kategorie);

            TreeNode node = tree.Nodes.Add(en.ElementAt(0).kategorie);
            String s = en.ElementAt(0).kategorie;
            foreach (databaseDataSet.predmetyRow row in en)
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
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            databaseDataSet db = Program.getDB();
            databaseDataSet.predmetyRow row = db.predmety.FindByjmeno(tree.SelectedNode.Text);
            if (row != null && tree.SelectedNode.Parent != null)
            {
                panel1.Visible = true;
                jmenoL.Text = row.jmeno;
                vahaL.Text = row.vaha.ToString() + " kg";
                cenaL.Text = row.cena.ToString() + " zl";
                cenaL.Tag = row.cena;
                cenaks.Value = (decimal)row.cena;
                celkemL.Text = ((double)((double)cenaks.Value * (double)ksN.Value)).ToString() + " zl";

                predmet = row.jmeno;
            }
            else
            {
                predmet = "";
                panel1.Visible = false;
            }
        }

        private void ksN_ValueChanged(object sender, EventArgs e)
        {
            celkemL.Text = ((double)((double)cenaks.Value * (double)ksN.Value)).ToString() + " zl";
        }

        private void zaplatitCh_CheckedChanged(object sender, EventArgs e)
        {
            cenaks.Enabled = zaplatitCh.Checked;
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newPredmetDialog dialog = new newPredmetDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTree();
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (predmet != "")
            {
                if (zaplatitCh.Checked == true)
                {
                    if (postava.penize < (double)cenaL.Tag * (double)ksN.Value)
                    {
                        DialogResult dr = MessageBox.Show("Postava nemá dost peněz na zaplacení předmětu.\nChcete za předmět zaplatit? Postava bude mít nula zlatých.", "Zaplacení", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            postava.penize = 0;
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        postava.penize -= (float)((double)cenaks.Value * (double)ksN.Value);
                    }
                    Program.getMainForm().setPenize(postava);
                }
                ownName = owNameT.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Musíte vybrat předmět, který chcete přidat do vybavení.", "Vyberte předmět", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void specB_Click(object sender, EventArgs e)
        {
            specVlast spec = new specVlast(predmet, opravy);
            if (spec.ShowDialog() == DialogResult.OK)
            {
                opravy = spec.opravy;
            }
        }
    }
}
