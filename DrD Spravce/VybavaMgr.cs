using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Predmet
    {
        private Panel parentPanel = new Panel();
        private TextBox predmetT = new TextBox();
        public Button optionsB = new Button();
        private Button plusB = new Button();
        private Button minusB = new Button();
        private Label pocetL = new Label();
        private Label vahaL = new Label();
        private Label cenaL = new Label();

        public String predmet;
        public String ownName;
        public int pocet;
        public float vaha;
        public float cena;

        public List<Oprava> opravy = new List<Oprava>();

        private VybavaMgr mgr;

        public Predmet(VybavaMgr mgr, FlowLayoutPanel flowPanel, String predmet, int pocet, String ownName, List<Oprava> oprs)
        {
            this.mgr = mgr;
            this.predmet = predmet;
            this.pocet = pocet;
            this.ownName = ownName;
            #region inicializace

            parentPanel.Width = 355;
            parentPanel.Height = 21;
            parentPanel.Left = 0;
            parentPanel.Top = 0;
            parentPanel.Parent = flowPanel;

            predmetT.Width = 140;
            predmetT.Height = 20;
            predmetT.Left = 3;
            predmetT.Top = 0;
            predmetT.ReadOnly = true;
            predmetT.Parent = parentPanel;

            optionsB.Width = 24;
            optionsB.Height = 20;
            optionsB.Left = 147;
            optionsB.Top = 0;
            optionsB.Text = "...";
            optionsB.Parent = parentPanel;
            optionsB.Tag = this;

            plusB.Width = 20;
            plusB.Height = 20;
            plusB.Left = 173;
            plusB.Top = 0;
            plusB.Text = "+";
            plusB.Click += new EventHandler(this.plusB_Clicked);
            plusB.Parent = parentPanel;

            minusB.Width = 20;
            minusB.Height = 20;
            minusB.Left = 192;
            minusB.Top = 0;
            minusB.Text = "-";
            minusB.Click += new EventHandler(this.minusB_Clicked);
            minusB.Parent = parentPanel;

            pocetL.Width = 40;
            pocetL.Height = 13;
            pocetL.Left = 221;
            pocetL.Top = 4;
            pocetL.TextAlign = ContentAlignment.TopCenter;
            pocetL.Parent = parentPanel;

            vahaL.Width = 37;
            vahaL.Height = 13;
            vahaL.Left = 267;
            vahaL.Top = 4;
            vahaL.TextAlign = ContentAlignment.TopCenter;
            vahaL.Parent = parentPanel;

            cenaL.Width = 37;
            cenaL.Height = 13;
            cenaL.Left = 309;
            cenaL.Top = 4;
            cenaL.TextAlign = ContentAlignment.TopCenter;
            cenaL.Parent = parentPanel;
            
            #endregion

            setOpravy(oprs);

            Calculate();
        }

        public void optionsB_Clicked(object sender, EventArgs e)
        {
            newPredmet dialog = new newPredmet(mgr.postava);
            if(dialog.ShowDialog(Program.getMainForm()) == DialogResult.OK)
            {
                if (predmet == "")
                {
                    mgr.InsertBlank();
                }
                predmet = dialog.predmet;
                ownName = dialog.ownName;
                pocet = (int)dialog.ksN.Value;
                deleteAllOpravy();
                setOpravy(dialog.opravy);
                Program.getMainForm().setNew(mgr.postava);
                Calculate();
            }
        }

        public void setOpravy(List<Oprava> oprs)
        {
            opravy.Clear();
            foreach (Oprava opr in oprs)
            {
                Oprava oprava = new Oprava(opr.vlastnost, opr.name, opr.bonus);
                if (opr.bonus != 0)
                {
                    opravy.Add(oprava);
                }
                mgr.postava.setOprava(oprava);
            }
        }

        private void plusB_Clicked(object sender, EventArgs e)
        {
            pocet++;
            Calculate();
            Program.getMainForm().setPohyb(mgr.postava);
        }

        private void minusB_Clicked(object sender, EventArgs e)
        {
            pocet--;
            if (pocet < 1) pocet = 1;
            Calculate();
            Program.getMainForm().setPohyb(mgr.postava);
        }

        public void Calculate()
        {
            databaseDataSet.predmetyRow row = Program.getDB().predmety.FindByjmeno(predmet);
            if (row != null)
            {
                vaha = (float)row.vaha;
                cena = (float)row.cena;
            }
            else
            {
                vaha = 0;
                cena = 0;
            }

            setLabels();
        }
        
        private void setLabels()
        {
            predmetT.Text = ownName == "" ? predmet : ownName;
            pocetL.Text = pocet.ToString();
            vahaL.Text = (vaha * pocet).ToString() + " kg";
            cenaL.Text = (cena * pocet).ToString() + " zl";
            if (predmet == "")
            {
                optionsB.Click -= new EventHandler(mgr.ShowContextMenu);
                optionsB.Click -= new EventHandler(optionsB_Clicked);
                optionsB.Click += new EventHandler(optionsB_Clicked);
                optionsB.Text = "«";
                plusB.Enabled = false;
                minusB.Enabled = false;
                cenaL.Text = "";
                vahaL.Text = "";
                pocetL.Text = "";
            }
            else
            {
                optionsB.Click -= new EventHandler(optionsB_Clicked);
                optionsB.Click -= new EventHandler(mgr.ShowContextMenu);
                optionsB.Click += new EventHandler(mgr.ShowContextMenu);
                optionsB.Text = "...";
                plusB.Enabled = true;
                minusB.Enabled = true;
            }
        }

        private void deleteAllOpravy()
        {
            for (int i = opravy.Count - 1; i >= 0; i--)
            {
                mgr.postava.deleteOprava(opravy[i]);
                opravy.RemoveAt(i);
            }
        }

        public void Dispose()
        {
            deleteAllOpravy();
            parentPanel.Dispose();
            predmetT.Dispose();
            optionsB.Dispose();
            plusB.Dispose();
            minusB.Dispose();
            pocetL.Dispose();
            vahaL.Dispose();
            cenaL.Dispose();
        }
    }
    
    public class VybavaMgr
    {
        public List<Predmet> vybavaList = new List<Predmet>();
        private FlowLayoutPanel flowPanel;
        public Postava postava;

        public VybavaMgr(FlowLayoutPanel flowPanel, Postava pos)
        {
            postava = pos;
            this.flowPanel = flowPanel;
            this.flowPanel.Controls.Clear();
        }

        public void ShowContextMenu(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripItem item;

            item = menu.Items.Add("Vybrat předmět...");
            item.Image = Program.getMainForm().tabImageList.Images[Program.getMainForm().tabImageList.Images.IndexOfKey("selectEqip.ico")];
            item.ImageTransparentColor = Color.Magenta;
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler( ((Predmet)((Button)sender).Tag).optionsB_Clicked );

            item = menu.Items.Add("Změnit počet...");
            item.Image = Program.getMainForm().tabImageList.Images[Program.getMainForm().tabImageList.Images.IndexOfKey("countEqip.ico")];
            item.ImageTransparentColor = Color.Magenta;
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler(pocet_Clicked);

            item = menu.Items.Add("Prodat předmět(y)...");
            item.Image = Program.getMainForm().tabImageList.Images[Program.getMainForm().tabImageList.Images.IndexOfKey("sellEqip.ico")];
            item.ImageTransparentColor = Color.Magenta;
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler(sell_Click);

            item = menu.Items.Add("Nakoupit předmět(y)...");
            item.Image = Program.getMainForm().tabImageList.Images[Program.getMainForm().tabImageList.Images.IndexOfKey("buyEqip.ico")];
            item.ImageTransparentColor = Color.Magenta;
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler(buy_Click);

            item = menu.Items.Add("Změnit speciální vlastnosti...");
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler(changeSpecial_Click);

            item = menu.Items.Add("Odebrat");
            //item.Image = Program.getMainForm().tabImageList.Images[Program.getMainForm().tabImageList.Images.IndexOfKey("selectEqip.ico")];
            //item.ImageTransparentColor = Color.Magenta;
            item.Tag = (Predmet)((Button)sender).Tag;
            item.Click += new EventHandler(delete_Click);

            menu.Show((Control)sender, new Point(0, 20));
        }

        private void sell_Click(object sender, EventArgs e)
        {
            sellDialog dialog = new sellDialog(postava, ((Predmet)((ToolStripMenuItem)sender).Tag), false);
            if (dialog.ShowDialog(flowPanel.TopLevelControl) == DialogResult.Ignore)
            {
                DeletePredmet((Predmet)((ToolStripMenuItem)sender).Tag);
                Program.getMainForm().setNew(postava);
            }
            else
            {
                Update((Predmet)((ToolStripMenuItem)sender).Tag);
                Program.getMainForm().setPohyb(postava);
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            sellDialog dialog = new sellDialog(postava, ((Predmet)((ToolStripMenuItem)sender).Tag), true);
            if (dialog.ShowDialog(flowPanel.TopLevelControl) == DialogResult.Ignore)
            {
                DeletePredmet((Predmet)((ToolStripMenuItem)sender).Tag);
                Program.getMainForm().setNew(postava);
            }
            else
            {
                Update((Predmet)((ToolStripMenuItem)sender).Tag);
                Program.getMainForm().setPohyb(postava);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete předmět odebrat z vybavení?", "Odebrat?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeletePredmet((Predmet)((ToolStripMenuItem)sender).Tag);
                Program.getMainForm().setNew(postava);
            }
        }

        private void pocet_Clicked(object sender, EventArgs e)
        {
            newPocet dialog = new newPocet(((Predmet)((ToolStripMenuItem)sender).Tag).pocet);
            if (dialog.ShowDialog(flowPanel.TopLevelControl) == DialogResult.OK)
            {
                if (dialog.pocet <= 0)
                {
                    DeletePredmet((Predmet)((ToolStripMenuItem)sender).Tag);
                }
                else
                {
                    Predmet p = ((Predmet)((ToolStripMenuItem)sender).Tag);
                    p.pocet = dialog.pocet;
                    p.Calculate();
                }
                Program.getMainForm().setPohyb(postava);
            }
        }

        private void changeSpecial_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)((ToolStripItem)sender).Tag;
            specVlast dialog = new specVlast(p);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                p.setOpravy(dialog.opravy);
                Program.getMainForm().setNew(postava);
            }
        }

        public void AddPredmet(String nazev, int pocet, String ownName, List<Oprava> oprs)
        {
            vybavaList.Add(new Predmet(this, flowPanel, nazev, pocet, ownName, oprs));
            if(nazev != "" && pocet != 0)
                Program.getMainForm().setPohyb(postava);
        }

        public void AddPredmetOnLoad(String nazev, int pocet, String ownName, List<Oprava> oprs)
        {
            vybavaList.Add(new Predmet(this, flowPanel, nazev, pocet, ownName, oprs));
        }

        public void InsertBlank()
        {
            AddPredmet("", 0, "", new List<Oprava>());
        }

        public void Clear()
        {
            for (int i = vybavaList.Count - 1; i >= 0; i--)
            {
                vybavaList[i].Dispose();
                vybavaList.RemoveAt(i);
            }
            return;
        }

        public void Update(Predmet pr)
        {
            pr.Calculate();
        }

        public void UpdateAll()
        {
            List<Pair<String, int>> temp = new List<Pair<String, int>>();
            List<String> ownNames = new List<string>();
            List<List<Oprava>> oprs = new List<List<Oprava>>();
            foreach (Predmet p in vybavaList)
            {
                Pair<String, int> pair = new Pair<String,int>();
                pair.first = p.predmet;
                pair.second = p.pocet;
                ownNames.Add(p.ownName);
                temp.Add(pair);
                oprs.Add(new List<Oprava>(p.opravy));
            }
            flowPanel.Controls.Clear();
            Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                Predmet x = new Predmet(this, flowPanel, temp[i].first, temp[i].second, ownNames[i], oprs[i]);
                x.Calculate();
                vybavaList.Add(x);
            }
        }

        public void DeletePredmet(Predmet predmet)
        {
            for (int i = vybavaList.Count -1; i >= 0; i--)
            {
                if (vybavaList[i].Equals(predmet))
                {
                    vybavaList[i].Dispose();
                    vybavaList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
