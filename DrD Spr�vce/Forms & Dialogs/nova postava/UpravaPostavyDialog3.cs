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
    public partial class UpravaPostavyDialog3 : Form
    {
        private int fyz, psy, komb;
        private List<Pair<int, Pair<int, int>>> stupne = new List<Pair<int, Pair<int, int>>>();
        private Postava postava;
        private String druzina;

        public UpravaPostavyDialog3(Postava pos, String druzina, int fyz, int psy, int komb)
        {
            InitializeComponent();

            this.postava = pos;
            this.fyz = fyz;
            this.psy = psy;
            this.komb = komb;
            this.druzina = druzina;

            TreeNode node1 = tree.Nodes.Add("Fyzické");
            TreeNode node2 = tree.Nodes.Add("Psychické");
            TreeNode node3 = tree.Nodes.Add("Kombinované");

            databaseDataSet db = Program.getDB();
            OrderedEnumerableRowCollection<databaseDataSet.zbraneRow> en = db.zbrane.OrderBy(row => row.kategorie);

            node1.Nodes.Add("Boj (" + en.ElementAt(0).kategorie + ")").Tag = "Boj (" + en.ElementAt(0).kategorie + ")";
            String s = en.ElementAt(0).kategorie;
            foreach (databaseDataSet.zbraneRow row in en)
            {
                if (s != row.kategorie)
                {
                    node1.Nodes.Add("Boj (" + row.kategorie + ")").Tag = "Boj (" + row.kategorie + ")";
                    s = row.kategorie;
                }
            }
            node1.Nodes.Add("Boj s vrhacími zbraněmi").Tag = "Boj s vrhacími zbraněmi";
            node1.Nodes.Add("Nošení zbroje").Tag = "Nošení zbroje";
            node1.Nodes.Add("Používání štítu").Tag = "Používání štítu";
            node3.Nodes.Add("Boj s luky").Tag = "Boj s luky";
            node3.Nodes.Add("Boj s kušemi").Tag = "Boj s kušemi";
            foreach (databaseDataSet.dovednostiRow row in Program.getDB().dovednosti)
            {
                if (row.typ == "fyz")
                {
                    node1.Nodes.Add(row.jmeno).Tag = row.jmeno;
                }
                else if (row.typ == "psy")
                {
                    node2.Nodes.Add(row.jmeno).Tag = row.jmeno;
                }
                else
                {
                    node3.Nodes.Add(row.jmeno).Tag = row.jmeno;
                }
            }

            fyzL.Text = fyz.ToString();
            psyL.Text = psy.ToString();
            kombL.Text = komb.ToString();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                databaseDataSet.dovednostiDataTable dovs = Program.getDB().dovednosti;
                databaseDataSet.dovednostiRow row = dovs.FindByjmeno(e.Node.Tag.ToString());
                panel.Visible = true;
                setStupen(e.Node);
                if (row != null)
                {
                    details.Text = row.jmeno + "\n";
                    if (e.Node.Tag.ToString() != e.Node.Text)
                    {
                        for (int i = 0; i < stupne.Count; i++)
                        {
                            if (stupne[i].first == e.Node.Index)
                            {
                                if (stupne[i].second.second == 1 && !row.Ispopis1Null())
                                {
                                    details.Text += row.popis1;
                                }
                                else if (stupne[i].second.second == 2 && !row.Ispopis2Null())
                                {
                                    details.Text += row.popis2;
                                }
                                else if (stupne[i].second.second == 3 && !row.Ispopis3Null())
                                {
                                    details.Text += row.popis3;
                                }
                                return;
                            }
                        }
                    }
                }
                else
                {
                    details.Text = e.Node.Tag.ToString() + "\n";
                }
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void setStupen(TreeNode node)
        {
            stupenL.Text = "Žádný stupeň";
            foreach (Pair<int, Pair<int, int>> pair in stupne)
            {
                if (pair.first == node.Parent.Index && pair.second.first == node.Index)
                {
                    stupenL.Text = pair.second.second + ". stupeň";
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tree.SelectedNode.Parent.Text)
            {
                case "Fyzické":
                    if (int.Parse(fyzL.Text) == 0)
                    {
                        return;
                    }
                    break;
                case "Psychické":
                    if (int.Parse(psyL.Text) == 0)
                    {
                        return;
                    }
                    break;
                case "Kombinované":
                    if (int.Parse(kombL.Text) == 0)
                    {
                        return;
                    }
                    break;
            }
            for (int i = 0; i < stupne.Count; i++)
            {
                if (stupne[i].first == tree.SelectedNode.Parent.Index && stupne[i].second.first == tree.SelectedNode.Index)
                {
                    if (stupne[i].second.second != 3)
                    {
                        stupne[i].second.second++;
                        switch (tree.SelectedNode.Parent.Text)
                        {
                            case "Fyzické": fyzL.Text = (int.Parse(fyzL.Text)-1).ToString(); break;
                            case "Psychické": psyL.Text = (int.Parse(psyL.Text)-1).ToString(); break;
                            case "Kombinované": kombL.Text = (int.Parse(kombL.Text)-1).ToString(); break;
                        }
                    }
                    tree.SelectedNode.Text = tree.SelectedNode.Tag.ToString() + " (";
                    for (int j = 0; j < stupne[i].second.second; j++)
                    {
                        tree.SelectedNode.Text += "I";
                    }
                    tree.SelectedNode.Text += ")";
                    setStupen(tree.SelectedNode);
                    return;
                }
            }
            Pair<int, Pair<int, int>> pair = new Pair<int, Pair<int, int>>();
            pair.first = tree.SelectedNode.Parent.Index;
            pair.second = new Pair<int, int>();
            pair.second.first = tree.SelectedNode.Index;
            pair.second.second = 1;
            stupne.Add(pair);
            tree.SelectedNode.Text = tree.SelectedNode.Tag.ToString() + " (I)";
            switch (tree.SelectedNode.Parent.Text)
            {
                case "Fyzické": fyzL.Text = (int.Parse(fyzL.Text) - 1).ToString(); break;
                case "Psychické": psyL.Text = (int.Parse(psyL.Text) - 1).ToString(); break;
                case "Kombinované": kombL.Text = (int.Parse(kombL.Text) - 1).ToString(); break;
            }
            setStupen(tree.SelectedNode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stupne.Count; i++)
            {
                if (stupne[i].first == tree.SelectedNode.Parent.Index && stupne[i].second.first == tree.SelectedNode.Index)
                {
                    if (stupne[i].second.second != 0)
                    {
                        stupne[i].second.second--;
                        switch (tree.SelectedNode.Parent.Text)
                        {
                            case "Fyzické": fyzL.Text = (int.Parse(fyzL.Text)+1).ToString(); break;
                            case "Psychické": psyL.Text = (int.Parse(psyL.Text)+1).ToString(); break;
                            case "Kombinované": kombL.Text = (int.Parse(kombL.Text)+1).ToString(); break;
                        }
                    }
                    if (stupne[i].second.second != 0)
                    {
                        tree.SelectedNode.Text = tree.SelectedNode.Tag.ToString() + " (";
                        for (int j = 0; j < stupne[i].second.second; j++)
                        {
                            tree.SelectedNode.Text += "I";
                        }
                        tree.SelectedNode.Text += ")";
                    }
                    else
                    {
                        tree.SelectedNode.Text = tree.SelectedNode.Tag.ToString();
                        stupne.RemoveAt(i);
                    }
                    setStupen(tree.SelectedNode);
                    return;
                }
            }
        }

        private void createB_Click(object sender, EventArgs e)
        {
            if (druzina == null)
            {
                Program.getMainForm().postavyMgr.AddNew(postava);
            }
            else
            {
                Program.getMainForm().postavyMgr.AddNew(postava, druzina);
            }
            for (int i = 0; i < stupne.Count; i++)
            {
                switch (tree.Nodes[stupne[i].first].Nodes[stupne[i].second.first].Parent.Text)
                {
                    case "Fyzické":
                        postava.dovednostiMgr.AddFyz(tree.Nodes[0].Nodes[stupne[i].second.first].Tag.ToString(), stupne[i].second.second);
                        break;
                    case "Psychické":
                        postava.dovednostiMgr.AddPsy(tree.Nodes[1].Nodes[stupne[i].second.first].Tag.ToString(), stupne[i].second.second);
                        break;
                    case "Kombinované":
                        postava.dovednostiMgr.AddKomb(tree.Nodes[2].Nodes[stupne[i].second.first].Tag.ToString(), stupne[i].second.second);
                        break;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
