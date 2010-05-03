using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class PostavyMgr
    {
        public TreeView tree;
        public Postava opened;
        public ContextMenuStrip cmStrip = new ContextMenuStrip();
 
        public PostavyMgr(TreeView tree)
        {
            this.tree = tree;
            cmStrip.ItemClicked += new ToolStripItemClickedEventHandler(cmStrip_ItemClicked);
            
            ToolStripItem item;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));

            item = cmStrip.Items.Add("Nová postava...");
            item.Image = ((System.Drawing.Image)(resources.GetObject("m_novaPostava.Image")));
            item.ImageTransparentColor = System.Drawing.Color.Magenta;

            item = cmStrip.Items.Add("Vložit existující postavu...");
            item.Image = ((System.Drawing.Image)(resources.GetObject("m_nacistPostavu.Image")));
            item.ImageTransparentColor = System.Drawing.Color.Magenta;

            item = cmStrip.Items.Add("Uložit");
            item.Image = ((System.Drawing.Image)(resources.GetObject("m_ulozitPostavu.Image")));
            item.ImageTransparentColor = System.Drawing.Color.Magenta;

            item = cmStrip.Items.Add("Zavřít");
        }

        private void cmStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmStrip.Hide();
            switch (e.ClickedItem.Text)
            {
                case "Nová postava...":
                    {
                        Main main = Program.getMainForm();
                        main.Cursor = Cursors.WaitCursor;
                        NovaPostavaDialog novaPostava = new NovaPostavaDialog(main, tree.SelectedNode.Name);
                        novaPostava.ShowDialog(main);
                        main.Cursor = Cursors.Default;
                        break;
                    }
                case "Vložit existující postavu...":
                    {
                        Main main = Program.getMainForm();
                        OpenFileDialog dialog = main.openDialog;
                        if (dialog.ShowDialog(main) == DialogResult.OK)
                        {
                            Postava pos = new Postava();
                            pos.xmlFileName = dialog.FileName;
                            Add(pos, tree.SelectedNode.Name, true);
                        }
                        break;
                    }
                case "Uložit":
                    foreach (TreeNode node in tree.SelectedNode.Nodes)
                    {
                        ((Postava)node.Tag).Save();
                    }
                    if (tree.SelectedNode.Tag == null)
                    {
                        Main main = Program.getMainForm();
                        main.saveDialog2.FileName = tree.SelectedNode.Text;
                        if (main.saveDialog2.ShowDialog(main) == DialogResult.OK)
                        {
                            tree.SelectedNode.Tag = main.saveDialog2.FileName;
                            SaveDruzina(tree.SelectedNode);
                        }
                    }
                    else
                    {
                        SaveDruzina(tree.SelectedNode);
                    }
                    break;
                case "Zavřít":
                    RemoveDruzina(tree.SelectedNode);
                    break;
            }
        }

        public void RemoveDruzina(TreeNode tnode)
        {
            foreach (TreeNode node in tnode.Nodes)
            {
                if (node.Tag.GetType() == typeof(Postava))
                {
                    if (((Postava)node.Tag).Equals(opened))
                    {
                        Program.getMainForm().tabControl1.Visible = false;
                        opened = null;
                    }
                }
                node.Remove();
            }
            tnode.Remove();
        }

        public void SaveDruzina(TreeNode tnode)
        {
            String file = tnode.Tag.ToString();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));

            System.Xml.XmlElement root = doc.CreateElement("druzina");
            System.Xml.XmlAttribute att = doc.CreateAttribute("nazev");
            att.Value = tnode.Text;
            root.Attributes.Append(att);

            foreach (TreeNode n in tnode.Nodes)
            {
                ((Postava)n.Tag).Save();
                System.Xml.XmlNode node = doc.CreateElement("postava");
                node.AppendChild(doc.CreateTextNode(((Postava)n.Tag).xmlFileName));
                root.AppendChild(node);
            }
            doc.AppendChild(root);

            doc.Save(file);
        }

        public void LoadDruzina(String filename)
        {
            TreeNode drz = null;
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filename);

                System.Xml.XmlNode node = doc.GetElementsByTagName("druzina")[0];
                String name = node.Attributes["nazev"].Value;

                drz = NewDruzina(name);
                drz.Tag = filename;
                Program.getMainForm().AddRecentDrz(filename);

                for(int i = 0; i < node.ChildNodes.Count; i++)
                {
                    System.Xml.XmlElement n = (System.Xml.XmlElement)node.ChildNodes[i];
                    String fn = n.FirstChild.Value;

                    Postava pos = new Postava();
                    pos.xmlFileName = fn;

                    Add(pos, name, (i == node.ChildNodes.Count - 1 ? true : false));
                }
            }
            catch
            {
                if (drz != null)
                    RemoveDruzina(drz);
                MessageBox.Show("Soubor " + filename + " není platný soubor družiny pro program CGen+.", "Neplatný soubor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public Postava GetOpened()
        {
            return opened;
        }

        public Postava GetSelected()
        {
            return (Postava)tree.SelectedNode.Tag;
        }

        public List<Postava> GetAll()
        {
            List<Postava> postavy = new List<Postava>();
            foreach(TreeNode node in tree.Nodes)
            {
                if (node.Tag.GetType() != typeof(Postava))
                {
                    foreach (TreeNode nnode in node.Nodes)
                    {
                        if (node.Tag.GetType() != typeof(Postava))
                        {
                            postavy.Add((Postava)nnode.Tag);
                        }
                    }
                }
                else
                {

                    postavy.Add((Postava)node.Tag);
                }
            }
            return postavy;
        }

        public void Add(Postava pos)
        {
            TreeNode[] nodes;
            if ((nodes = tree.Nodes.Find(pos.xmlFileName, true)).Length == 0)
            {
                if (pos.Load(pos.xmlFileName) == -1)
                {
                    Program.getMainForm().Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    TreeNode node = tree.Nodes.Add(pos.xmlFileName, pos.jmeno);
                    node.Tag = pos;
                    node.ContextMenuStrip = Program.getMainForm().treeContextMenu;
                    tree.SelectedNode = node;
                    opened = pos;
                }

                Program.getMainForm().setNew(pos);
            }
            else
            {
                tree.SelectedNode = nodes[0];
                Program.getMainForm().setNew((Postava)nodes[0].Tag);
            }
        }

        public TreeNode Add(Postava pos, String druzina, bool setNew)
        {
            TreeNode[] nodes;
            if ((nodes = tree.Nodes.Find(pos.xmlFileName, true)).Length == 0)
            {
                if ((nodes = tree.Nodes.Find(druzina, true)).Length == 1)
                {
                    if (pos.Load(pos.xmlFileName) == -1)
                    {
                        Program.getMainForm().Cursor = Cursors.Default;
                        return null;
                    }
                    else
                    {
                        TreeNode node = nodes[0];
                        TreeNode posnode = node.Nodes.Add(pos.xmlFileName, pos.jmeno);
                        posnode.ContextMenuStrip = Program.getMainForm().treeContextMenu;
                        posnode.Tag = pos;
                        opened = pos;
                        tree.SelectedNode = posnode;
                        if (setNew)
                            Program.getMainForm().setNew(pos);

                        return posnode;
                    }
                }
            }
            else
            {
                if (setNew)
                {
                    tree.SelectedNode = nodes[0];
                    Program.getMainForm().setNew((Postava)nodes[0].Tag);
                }
            }
            return null;
        }

        public void AddNew(Postava pos)
        {
            TreeNode node = tree.Nodes.Add(pos.xmlFileName, pos.jmeno);
            node.Tag = pos;
            node.ContextMenuStrip = Program.getMainForm().treeContextMenu;
            tree.SelectedNode = node;
            opened = pos;

            Program.getMainForm().setNew(pos);
        }

        public void AddNew(Postava pos, String druzina)
        {
            TreeNode[] nodes = tree.Nodes.Find(druzina, true);
            if (nodes.Length > 0)
            {
                TreeNode node = nodes[0];
                TreeNode posnode = node.Nodes.Add(pos.xmlFileName, pos.jmeno);
                posnode.ContextMenuStrip = Program.getMainForm().treeContextMenu;
                posnode.Tag = pos;
                opened = pos;
                tree.SelectedNode = posnode;
                Program.getMainForm().setNew(pos);
            }
        }

        public void RemoveSelected()
        {
            Main main = Program.getMainForm();
            if (tree.SelectedNode.Tag == opened)
            {
                main.tabControl1.Visible = false;
                opened = null;
            }
            tree.SelectedNode.Remove();
        }

        public TreeNode NewDruzina(String name)
        {
            TreeNode node = tree.Nodes.Add(name, name);
            node.ContextMenuStrip = cmStrip;
            return node;
        }

        public void RenameDruzina(TreeNode node)
        {
            if (tree.Nodes.Find(node.Text, true).Length == 0)
            {
                node.Name = node.Text;
            }
            else
            {
                MessageBox.Show("Družina s tímto názvem již existuje. Zadejte jiný název.", "Družina již existuje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                node.BeginEdit();
            }
        }

        public void SaveOpened()
        {
            if (opened == null) return;
            opened.Save();
        }

        public void OpenSelected()
        {
            opened = (Postava)tree.SelectedNode.Tag;
            Program.getMainForm().setNew(opened);
        }

        public TreeNode GetNode(String key, String name)
        {
            TreeNode[] nodes = tree.Nodes.Find(key, true);
            foreach (TreeNode node in nodes)
            {
                if (((Postava)node.Tag).jmeno == name)
                {
                    return node;
                }
            }
            return null;
        }
    }
}
