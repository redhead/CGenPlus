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
    public partial class dovednostiDataDialog : Form
    {
        public dovednostiDataDialog()
        {
            InitializeComponent();

            UpdateTree();
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newDovednostDialog dialog = new newDovednostDialog();
            this.Hide();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTree();
                //tree.SelectedNode = tree.Nodes.Find(dialog.jmeno, true)[0];
                tree.Focus();
            }
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat dovednost ze seznamu.", "Vyberte zbraň", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newDovednostDialog dialog = new newDovednostDialog(tree.SelectedNode.Text);
            this.Hide();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTree();
                //tree.SelectedNode = tree.Nodes.Find(dialog.jmeno, true)[0];
                tree.Focus();
            }
            this.Show();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show("Pro smazání musíte vybrat dovednost ze seznamu.", "Vyberte dovednost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete dovednost " + tree.SelectedNode.Text + " smazat?", "Smazat dovednost?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //databaseDataSetTableAdapters.dovednostiTableAdapter dovednostiTableAdapter = new databaseDataSetTableAdapters.dovednostiTableAdapter();
                //dovednostiTableAdapter.Fill(Program.getDB().dovednosti);

                databaseDataSet.dovednostiRow row;
                row = Program.getDB().dovednosti.FindByjmeno(tree.SelectedNode.Text);
                if (row != null)
                {
                    row.Delete();
                    //dovednostiTableAdapter.Update(Program.getDB().dovednosti);

                    tree.Nodes.Remove(tree.SelectedNode);
                }
                UpdateTree();
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            databaseDataSet.dovednostiRow row = Program.getDB().dovednosti.FindByjmeno(tree.SelectedNode.Text);

            if (row != null && tree.SelectedNode.Parent != null )
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
            {
                OrderedEnumerableRowCollection<databaseDataSet.dovednostiRow> en = db.dovednosti.OrderBy(row => row.typ);

                TreeNode node1 = tree.Nodes.Add("Fyzické");
                TreeNode node2 = tree.Nodes.Add("Psychické");
                TreeNode node3 = tree.Nodes.Add("Kombinované");

                foreach (databaseDataSet.dovednostiRow row in en)
                {
                    if (row.typ == "fyz")
                    {
                        node1.Nodes.Add(row.jmeno);
                    }
                    else if (row.typ == "psy")
                    {
                        node2.Nodes.Add(row.jmeno);
                    }
                    else
                    {
                        node3.Nodes.Add(row.jmeno);
                    }
                }
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
