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
    public partial class predmetyDataDialog : Form
    {
        public predmetyDataDialog()
        {
            InitializeComponent();

            UpdateTree();
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newPredmetDialog dialog = new newPredmetDialog();
            this.Hide();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTree();
                tree.SelectedNode = tree.Nodes.Find(dialog.jmeno, true)[0];
                tree.Focus();
            }
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat předmět ze seznamu.", "Vyberte předmět", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newPredmetDialog dialog = new newPredmetDialog(tree.SelectedNode.Text);
            this.Hide();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTree();
                tree.SelectedNode = tree.Nodes.Find(dialog.jmeno, true)[0];
                tree.Focus();
            }
            this.Show();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show("Pro smazání musíte vybrat předmět ze seznamu.", "Vyberte předmět", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete předmět " + tree.SelectedNode.Text + " smazat?", "Smazat předmět?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.predmetyRow row;
                row = Program.getDB().predmety.FindByjmeno(tree.SelectedNode.Text);
                if (row != null && tree.SelectedNode.Parent != null)
                {
                    row.Delete();
                    //this.predmetyTableAdapter.Update(Program.getDB().predmety);

                    if (tree.SelectedNode.Parent.Nodes.Count == 1)
                    {
                        tree.SelectedNode.Parent.Remove();
                    }
                    else
                    {
                        tree.Nodes.Remove(tree.SelectedNode);
                    }
                }
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            databaseDataSet.predmetyRow row;
            row = Program.getDB().predmety.FindByjmeno(tree.SelectedNode.Text);
            if (row != null)
            {
                editB.Visible = true;
                deleteB.Visible = true;
            }
            else
            {
                editB.Visible = false;
                deleteB.Visible = false;
            }
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

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
