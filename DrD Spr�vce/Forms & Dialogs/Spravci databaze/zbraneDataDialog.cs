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
    public partial class zbraneDataDialog : Form
    {
        private String selected;

        public zbraneDataDialog()
        {
            InitializeComponent();

            UpdateTree();
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newZbranDialog dialog = new newZbranDialog();
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
                MessageBox.Show("Pro úpravu musíte vybrat zbraň ze seznamu.", "Vyberte zbraň", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newZbranDialog dialog = new newZbranDialog(tree.SelectedNode.Text, selected);
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
                MessageBox.Show("Pro smazání musíte vybrat zbraň ze seznamu.", "Vyberte zbraň", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete zbraň " + tree.SelectedNode.Text + " smazat?", "Smazat zbraň?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (selected == "rucni")
                {
                    //databaseDataSetTableAdapters.zbraneTableAdapter zbraneTableAdapter = new databaseDataSetTableAdapters.zbraneTableAdapter();
                    //zbraneTableAdapter.Fill(Program.getDB().zbrane);

                    databaseDataSet.zbraneRow row;
                    row = Program.getDB().zbrane.FindByjmeno(tree.SelectedNode.Text);
                    if (row != null)
                    {
                        row.Delete();
                        //zbraneTableAdapter.Update(Program.getDB().zbrane);

                        tree.Nodes.Remove(tree.SelectedNode);
                    }
                    UpdateTree();
                }
                else
                {
                    //databaseDataSetTableAdapters.strelneTableAdapter strelneTableAdapter = new databaseDataSetTableAdapters.strelneTableAdapter();
                    //strelneTableAdapter.Fill(Program.getDB().strelne);
                    
                    databaseDataSet.strelneRow row;
                    row = Program.getDB().strelne.FindByjmeno(tree.SelectedNode.Text);
                    if (row != null)
                    {
                        row.Delete();
                        //strelneTableAdapter.Update(Program.getDB().strelne);

                        UpdateTree();
                    }
                }
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            databaseDataSet.zbraneRow row1 = Program.getDB().zbrane.FindByjmeno(tree.SelectedNode.Text);
            databaseDataSet.strelneRow row2 = Program.getDB().strelne.FindByjmeno(tree.SelectedNode.Text);

            if ((row1 != null || row2 != null) && tree.SelectedNode.Parent.Parent != null )
            {
                if (tree.SelectedNode.Parent.Parent.Text == "Zbraně na blízko")
                {
                    selected = "rucni";
                }
                else
                {
                    selected = "strelna";
                }

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
                OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);
                TreeNode top = tree.Nodes.Add("Zbraně na blízko");
                top.Expand();
                
                TreeNode node = top.Nodes.Add(en.ElementAt(0).kategorie);
                String s = en.ElementAt(0).kategorie;
                foreach (databaseDataSet.zbraneRow row in en)
                {
                    if (s == row.kategorie)
                    {
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                    else
                    {
                        node = top.Nodes.Add(row.kategorie);
                        s = row.kategorie;
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                }
            }
            {
                OrderedEnumerableRowCollection<databaseDataSet.strelneRow> en = db.strelne.OrderBy(row => row.kategorie);

                TreeNode top = tree.Nodes.Add("Střelné / vrhací zbraně");
                top.Expand();

                TreeNode node = top.Nodes.Add(en.ElementAt(0).kategorie);
                String s = en.ElementAt(0).kategorie == "" ? en.ElementAt(1).kategorie : en.ElementAt(0).kategorie;
                foreach (databaseDataSet.strelneRow row in en)
                {
                    if (s == row.kategorie)
                    {
                        node.Nodes.Add(row.jmeno, row.jmeno);
                    }
                    else
                    {
                        node = top.Nodes.Add(row.kategorie);
                        s = row.kategorie;
                        node.Nodes.Add(row.jmeno, row.jmeno);
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
