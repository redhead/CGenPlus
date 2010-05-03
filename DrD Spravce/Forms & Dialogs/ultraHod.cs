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
    public partial class ultraHod : Form
    {
        ContextMenuStrip menu;
        ContextMenuStrip pasteMenu;

        public ultraHod()
        {
            InitializeComponent();
            this.TopLevel = true;
        }

        private void ultraHod_Load(object sender, EventArgs e)
        {
            List<Postava> poss = Program.getMainForm().postavyMgr.GetAll();
            foreach (Postava pos in poss)
            {
                TreeNode node = posList.Nodes.Add(pos.jmeno);
                node.Tag = pos;
            }

            menu = new ContextMenuStrip();
            menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked);

            menu.Items.Add("Uložit").Name = "saveBxyz_k9yz13";
            menu.Items.Add("-").Name = "separatorxyz_k9yz13";

            System.IO.FileStream str = new System.IO.FileStream("cinnosti.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(str);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                int pos = line.IndexOf("\t");
                if (pos != -1)
                {
                    String name = line.Substring(0, pos);
                    String val = line.Substring(pos + 1);
                    if (name.Trim() != "" && val.Trim() != "")
                    {
                        ToolStripItem item = menu.Items.Add(name);
                        item.Name = name;
                        item.Tag = val;
                    }
                }
            }
            sr.Close();
            str.Close();

            if (menu.Items.Count > 2)
            {
                nazevT.Text = menu.Items[2].Text;
                exprT.Text = (String)menu.Items[2].Tag;
            }

            //::::::::::::: VLASTNOSTI ::::::::::::::
            pasteMenu = new ContextMenuStrip();
            ToolStripMenuItem itm;
            if (posList.Nodes.Count > 0)
            {
                itm = new ToolStripMenuItem();
                itm.Text = "Vlastnosti postavy";
                itm.DropDownItemClicked += new ToolStripItemClickedEventHandler(pasteItem_Clicked);
                pasteMenu.Items.AddRange(new ToolStripItem[] { itm });
                foreach (Pair<string, int> pair in ((Postava)posList.Nodes[0].Tag).getAllVlastnosti())
                {
                    itm.DropDownItems.Add(pair.first).Tag = pair.first;
                }
            }

            //::::::::::::: DOVEDNOSTI ::::::::::::::
            itm = new ToolStripMenuItem();
            itm.Text = "Dovednosti";
            pasteMenu.Items.AddRange(new ToolStripItem[] { itm });
            ToolStripMenuItem itm1 = new ToolStripMenuItem();
            ToolStripMenuItem itm2 = new ToolStripMenuItem();
            ToolStripMenuItem itm3 = new ToolStripMenuItem();
            itm1.Text = "Fyzické";
            itm2.Text = "Psychické";
            itm3.Text = "Kombinované";
            itm1.DropDownItemClicked += new ToolStripItemClickedEventHandler(pasteItem_Clicked);
            itm2.DropDownItemClicked += new ToolStripItemClickedEventHandler(pasteItem_Clicked);
            itm3.DropDownItemClicked += new ToolStripItemClickedEventHandler(pasteItem_Clicked);
            itm.DropDownItems.AddRange(new ToolStripItem[] { itm1, itm2, itm3 });
            OrderedEnumerableRowCollection<databaseDataSet.dovednostiRow> en = Program.getDB().dovednosti.OrderBy(row => row.typ);
            foreach (databaseDataSet.dovednostiRow row in en)
            {
                if (row.typ == "fyz")
                {
                    itm1.DropDownItems.Add(row.jmeno).Tag = "dov(" + row.jmeno + ")";
                }
                else if (row.typ == "psy")
                {
                    itm2.DropDownItems.Add(row.jmeno).Tag = "dov(" + row.jmeno + ")";
                }
                else
                {
                    itm3.DropDownItems.Add(row.jmeno).Tag = "dov(" + row.jmeno + ")";
                }
            }

            //::::::::::::: KOSTKY ::::::::::::::
            itm = new ToolStripMenuItem();
            itm.Text = "Hody kostkou";
            itm.DropDownItemClicked += new ToolStripItemClickedEventHandler(pasteItem_Clicked);
            pasteMenu.Items.AddRange(new ToolStripItem[] { itm });
            itm1 = new ToolStripMenuItem();
            itm1.Text = "2k6*";
            itm1.Tag = "2k6*";
            itm2 = new ToolStripMenuItem();
            itm2.Text = "1k6";
            itm2.Tag = "1k6";
            itm.DropDownItems.AddRange(new ToolStripItem[] { itm1, itm2 });
        }

        private void optionB_Click(object sender, EventArgs e)
        {
            menu.Show(optionB, new Point(0, 23));
        }

        private void pasteB_Click(object sender, EventArgs e)
        {
            pasteMenu.Show(pasteB, new Point(0, 23));
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "")
            {
                menu.Hide();
                switch (e.ClickedItem.Text)
                {
                    case "Uložit":
                        if (nazevT.Text.Trim() == "")
                        {
                            MessageBox.Show("Musíte zadat název činnosti.", "Zadejte název", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            {
                                nazevT.Focus();
                                nazevT.SelectAll();
                            }
                            break;
                        }
                        if (menu.Items.Find(nazevT.Text, false).Length > 0)
                        {
                            if (MessageBox.Show("Tento název činnosti již existuje, chcete jej přepsat?", "Přepsat?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                nazevT.Focus();
                                nazevT.SelectAll();
                            }
                            break;
                        }
                        ToolStripItem i =  menu.Items.Add(nazevT.Text);
                        i.Name = nazevT.Text;
                        i.Tag = exprT.Text;
                        Save();
                        break;
                    default:
                        nazevT.Text = e.ClickedItem.Text;
                        exprT.Text = (String)e.ClickedItem.Tag;
                        break;
                }
            }
        }

        private void pasteItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string expr = (string)e.ClickedItem.Tag;
            if (expr != null)
            {
                int start = exprT.SelectionStart;
                if (exprT.SelectionLength == 0)
                    exprT.Text = exprT.Text.Insert(start, expr);
                else
                {
                    exprT.Text = exprT.Text.Remove(start, exprT.SelectionLength);
                    exprT.Text = exprT.Text.Insert(start, expr);
                }
                exprT.Select(start + expr.Length, 0);
                exprT.Focus();
            }
        }

        private void Save()
        {
            System.IO.FileStream str = new System.IO.FileStream("cinnosti.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(str);
            for (int i = 2; i < menu.Items.Count; i++)
            {
                sw.WriteLine(menu.Items[i].Text + "\t" + (String)menu.Items[i].Tag);
            }
            sw.Close();
            str.Close();
        }

        private void okB_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void hoditB_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            String exp = exprT.Text;
            List<String> res = new List<String>();
            int askNext = -1;

            foreach (TreeNode node in posList.Nodes)
            {
                if (node.Checked)
                {
                    String xexp;
                    xexp = exp.Replace("2k6*", Program.hod2k6(rand).ToString());
                    xexp = xexp.Replace("1k6", rand.Next(1, 7).ToString());
                    
                    Postava pos = ((Postava)node.Tag);
                    try
                    {
                        int pos1 = 0;
                        int pos2 = 0;
                        while ((pos1 = xexp.IndexOf("dov(", pos2)) != -1)
                        {
                            int parth = xexp.IndexOf(")", pos1);
                            string dov = xexp.Substring(pos1 + 4, parth - (pos1 + 4));
                            string result = "0";
                            int stupen;
                            if ((stupen = pos.dovednostiMgr.getDovednost(dov)) > 0)
                            {
                                databaseDataSet.dovednostiRow row = Program.getDB().dovednosti.FindByjmeno(dov);
                                if (row != null)
                                {
                                    string popis = "";
                                    switch (stupen)
                                    {
                                        case 1: popis = row.popis1; break;
                                        case 2: popis = row.popis2; break;
                                        case 3: popis = row.popis2; break;
                                    }
                                    System.Text.RegularExpressions.MatchCollection match;
                                    match = System.Text.RegularExpressions.Regex.Matches(popis, @".+: \+?(\-?\d+)");
                                    if (match.Count == 1 && match[0].Success == true)
                                    {
                                        result = match[0].Groups[1].ToString();
                                    }
                                    else if (match.Count > 1)
                                    {
                                        if (askNext == -1)
                                        {
                                            ultraHodPrompt dialog = new ultraHodPrompt(match);
                                            if (dialog.ShowDialog() == DialogResult.OK)
                                            {
                                                result = dialog.returnSelection();
                                                askNext = dialog.selectedIndex();
                                            }
                                        }
                                        else
                                        {
                                            result = match[askNext].Groups[1].ToString();
                                        }
                                    }
                                }
                            }
                            xexp = xexp.Remove(pos1, parth - pos1 + 1);
                            xexp = xexp.Insert(pos1, result);
                            pos2 = pos1;
                        }
                        res.Add(pos.jmeno + "\t " + Program.parseBonus(pos.parseMath(xexp)) + "\t" + xexp);
                    }
                    catch
                    {
                        MessageBox.Show("Vyskytla se chyba při parsování výrazu hodu.\nUjistěte se, že jste napsali výraz správně.", "Chyba ve výrazu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        exprT.Focus();
                        exprT.SelectAll();
                        break;
                    }
                }
            }
            resultT.Lines = res.ToArray();
        }
    }
}
