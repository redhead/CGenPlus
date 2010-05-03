using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public databaseDataSet database;

        public PostavyMgr postavyMgr;

        public int selected;

        public List<String> recent = new List<string>();
        public List<String> recentDrz = new List<string>();

        public Properties.Settings settings = new WindowsFormsApplication1.Properties.Settings();

        public String arg = "";

        private TabPage[] tabPages;
        private Pair<TabPage, bool>[] tabOrder;

        public Main()
        {
            Cursor = Cursors.WaitCursor;
            InitializeComponent();

            settings.Reload();

            this.Width = settings.width;
            this.Height = settings.height;
            this.WindowState = settings.maximized ? FormWindowState.Maximized : FormWindowState.Normal;


            //create database
            database = new databaseDataSet();
            database.ReadXml(Application.StartupPath + "\\db.xml");

            #region oldDBSets
            /*
            databaseDataSetTableAdapters.povolaniTableAdapter povolaniTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.povolaniTableAdapter();
            povolaniTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.tabZZTableAdapter tabZZTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.tabZZTableAdapter();
            povolaniTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.rasyTableAdapter rasyTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.rasyTableAdapter();
            rasyTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.tabZraneniUnavyTableAdapter tabZraneniUnavyTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.tabZraneniUnavyTableAdapter();
            tabZraneniUnavyTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.zbraneTableAdapter zbraneTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.zbraneTableAdapter();
            zbraneTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.zbrojeTableAdapter zbrojeTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.zbrojeTableAdapter();
            zbrojeTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.prilbyTableAdapter prilbyTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.prilbyTableAdapter();
            prilbyTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.stityTableAdapter stityTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.stityTableAdapter();
            stityTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.tabVzdalenostiTableAdapter tabVzdalenostiTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.tabVzdalenostiTableAdapter();
            tabVzdalenostiTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.tabRychlostiTableAdapter tabRychlostiTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.tabRychlostiTableAdapter();
            tabRychlostiTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.tabHmotnostiTableAdapter tabHmotnostiTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.tabHmotnostiTableAdapter();
            tabHmotnostiTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.predmetyTableAdapter predmetyTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.predmetyTableAdapter();
            predmetyTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.strelneTableAdapter strelneTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.strelneTableAdapter();
            predmetyTableAdapter.ClearBeforeFill = true;

            databaseDataSetTableAdapters.dovednostiTableAdapter dovednostiTableAdapter = new WindowsFormsApplication1.databaseDataSetTableAdapters.dovednostiTableAdapter();
            dovednostiTableAdapter.ClearBeforeFill = true;
            
            tabZraneniUnavyTableAdapter.Fill(this.database.tabZraneniUnavy);
            tabZZTableAdapter.Fill(this.database.tabZZ);
            povolaniTableAdapter.Fill(this.database.povolani);
            rasyTableAdapter.Fill(this.database.rasy);
            zbraneTableAdapter.Fill(this.database.zbrane);
            zbrojeTableAdapter.Fill(this.database.zbroje);
            prilbyTableAdapter.Fill(this.database.prilby);
            stityTableAdapter.Fill(this.database.stity);
            tabVzdalenostiTableAdapter.Fill(this.database.tabVzdalenosti);
            tabRychlostiTableAdapter.Fill(this.database.tabRychlosti);
            tabHmotnostiTableAdapter.Fill(this.database.tabHmotnosti);
            predmetyTableAdapter.Fill(this.database.predmety);
            strelneTableAdapter.Fill(this.database.strelne);
            dovednostiTableAdapter.Fill(this.database.dovednosti);
            */
            #endregion

            tabControl1.Visible = false;
            tabPages = new TabPage[tabControl1.TabPages.Count];
            int i;
            for (i = 0; i < tabControl1.TabPages.Count; i++)
                tabPages[i] = tabControl1.TabPages[i];

            if (tabControl1.TabPages.Count != settings.tabs.Length)
            {
                settings.tabs = "".PadLeft(tabControl1.TabPages.Count, "1".ToCharArray()[0]);
            }
            i = 0;
            tabOrder = new Pair<TabPage, bool>[tabPages.Length];
            while (i < tabControl1.TabPages.Count)
            {
                int vis = 1;
                int tab = i;
                if (i < settings.tabs.Length)
                {
                    tab = int.Parse(settings.tabsOrder.Substring(i, 1));
                    vis = int.Parse(settings.tabs.Substring(tab, 1));
                }
                tabPages[tab].Tag = (vis == 0 ? false : true);
                tabOrder[i] = new Pair<TabPage, bool>(tabPages[tab], (vis == 0 ? false : true));
                i++;
            }
            SetTabs();


            postavyMgr = new PostavyMgr(treeView1);
            Cursor = Cursors.Default;
        }

        private void SetTabs()
        {
            ContextMenu conm = new ContextMenu();
            MenuItem[] items = new MenuItem[tabPages.Length];
            int on = 0;
            MenuItem one = null;
            for (int i = 0; i < tabOrder.Length; i++)
            {
                tabOrder[i].first.Tag = tabOrder[i].second;
                items[i] = new MenuItem();
                items[i].Checked = tabOrder[i].second;
                items[i].Text = tabOrder[i].first.Text;
                items[i].Click += TabContextMenu_Click;
                items[i].Tag = i;
                if (tabOrder[i].second == true)
                {
                    on++;
                    one = items[i];
                }
            }
            if (on == 1)
                one.Enabled = false;
            conm.MenuItems.AddRange(items);
            conm.MenuItems.Add(new MenuItem("-"));
            conm.MenuItems.Add(new MenuItem("Pořadí...", TabContextMenu_Click));

            tabControl1.ContextMenu = conm;
            tabControl1.TabPages.Clear();
            foreach (Pair<TabPage, bool> page in tabOrder)
            {
                if (page.second == true)
                    tabControl1.TabPages.Add(page.first);
            }
        }

        private void TabContextMenu_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            switch (item.Text)
            {
                case "-":
                    return;
                case "Pořadí...":
                    tabOrderer dialog = new tabOrderer(tabOrder);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        tabOrder = dialog.tabOrder;
                        SetTabs();
                    }
                    return;
            }
            int i = (int)item.Tag;
            item.Checked = !item.Checked;
            tabOrder[i].second = item.Checked;
            SetTabs();
        }

        public Main(String argc) : this ()
        {
            arg = argc;
        }

        public void AddRecent(String filename)
        {
            for (int i = 0; i < recent.Count; i++)
            {
                if (recent[i] == filename)
                {
                    recent.RemoveAt(i);
                    recent.Insert(0, filename);
                    if (recent.Count > 3)
                    {
                        recent.RemoveRange(3, recent.Count - 3);
                    }
                    return;
                }
            }
            recent.Insert(0, filename);
            if(recent.Count > 5)
            {
                recent.RemoveRange(5, recent.Count - 5);
            }
        }

        public void AddRecentDrz(String filename)
        {
            for (int i = 0; i < recentDrz.Count; i++)
            {
                if (recentDrz[i] == filename)
                {
                    recentDrz.RemoveAt(i);
                    recentDrz.Insert(0, filename);
                    if (recentDrz.Count > 3)
                    {
                        recentDrz.RemoveRange(4, recentDrz.Count - 3);
                    }
                    return;
                }
            }
            recentDrz.Insert(0, filename);
            if (recentDrz.Count > 5)
            {
                recentDrz.RemoveRange(5, recentDrz.Count - 5);
            }
        }

        public void LoadRecent(String fn)
        {
            if (recent.Count > 4) return;
            String [] pathPart = fn.Split("\\".ToCharArray());
            String display = fn;
            if (fn.Length > 40 && pathPart.Length > 3)
            {
                display = pathPart[0] + "\\...\\" + pathPart[pathPart.Length - 2] + "\\" + pathPart[pathPart.Length - 1];
            }
            ToolStripItem item = m_recent.DropDownItems.Add(display);
            item.Tag = new Pair<String, int>(fn, 0);
            recent.Add(fn);
        }

        public void LoadRecentDrz(String fn)
        {
            if (recentDrz.Count > 4) return;
            if (recentDrz.Count == 0 && recent.Count != 0)
            {
                m_recent.DropDownItems.Add("-");
            }
            String[] pathPart = fn.Split("\\".ToCharArray());
            String display = fn;
            if (fn.Length > 40 && pathPart.Length > 3)
            {
                display = pathPart[0] + "\\...\\" + pathPart[pathPart.Length - 2] + "\\" + pathPart[pathPart.Length - 1];
            }
            ToolStripItem item = m_recent.DropDownItems.Add(display);
            item.Tag = new Pair<String, int>(fn, 1);
            recentDrz.Add(fn);
        }

        private void m_recent_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "") return;
            Pair<String, int> pair = (Pair<String, int>)e.ClickedItem.Tag;
            if (pair.second == 0)
            {
                nacist(pair.first);
            }
            else if (pair.second == 1)
            {
                postavyMgr.LoadDruzina(pair.first);
            }
        }

        public void nováPostavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            NovaPostavaDialog novaPostava = new NovaPostavaDialog(this, null);
            novaPostava.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        public void setHlavni(Postava pos)
        {
            SilL.Text = Program.parseBonus(pos.getVlastnostO("Sil"));
            ObrL.Text = Program.parseBonus(pos.getVlastnostO("Obr"));
            ZrcL.Text = Program.parseBonus(pos.getVlastnostO("Zrč"));
            VolL.Text = Program.parseBonus(pos.getVlastnostO("Vol"));
            IntL.Text = Program.parseBonus(pos.getVlastnostO("Int"));
            ChrL.Text = Program.parseBonus(pos.getVlastnostO("Chr"));

            toolTip.SetToolTip(SilL, getToolTipFor("Sil", pos));
            toolTip.SetToolTip(ObrL, getToolTipFor("Obr", pos));
            toolTip.SetToolTip(ZrcL, getToolTipFor("Zrč", pos));
            toolTip.SetToolTip(VolL, getToolTipFor("Vol", pos));
            toolTip.SetToolTip(IntL, getToolTipFor("Int", pos));
            toolTip.SetToolTip(ChrL, getToolTipFor("Chr", pos));
        }

        public void setVedlejsi(Postava pos)
        {
            OdlL.Text = Program.parseBonus(pos.getVlastnostO("Odl"));
            VdrL.Text = Program.parseBonus(pos.getVlastnostO("Vdr"));
            RchL.Text = Program.parseBonus(pos.getVlastnostO("Rch"));
            SmsL.Text = Program.parseBonus(pos.getVlastnostO("Sms"));
            VelL.Text = Program.parseBonus(pos.getVlastnostO("Vel"));
            HmpL.Text = Program.parseBonus(pos.getVlastnostO("Hmp"));
            VyskaL.Text = Program.parseBonus(pos.getVlastnostO("Výška"));

            KrsL.Text = Program.parseBonus(pos.getVlastnostO("Krs"));
            NbzL.Text = Program.parseBonus(pos.getVlastnostO("Nbz"));
            DstL.Text = Program.parseBonus(pos.getVlastnostO("Dst"));

            toolTip.SetToolTip(OdlL, getToolTipFor("Odl", pos));
            toolTip.SetToolTip(VdrL, getToolTipFor("Vdr", pos));
            toolTip.SetToolTip(RchL, getToolTipFor("Rch", pos));
            toolTip.SetToolTip(SmsL, getToolTipFor("Sms", pos));
            toolTip.SetToolTip(VelL, getToolTipFor("Vel", pos));
            toolTip.SetToolTip(HmpL, getToolTipFor("Hmp", pos));
            toolTip.SetToolTip(VyskaL, getToolTipFor("Výška", pos));

            toolTip.SetToolTip(KrsL, getToolTipFor("Krs", pos));
            toolTip.SetToolTip(NbzL, getToolTipFor("Nbz", pos));
            toolTip.SetToolTip(DstL, getToolTipFor("Dst", pos));
        }

        public void setBoj(Postava pos)
        {
            BojL.Text = Program.parseBonus(pos.getVlastnostO("Boj"));
            UtkL.Text = Program.parseBonus(pos.getVlastnostO("Útok"));
            StrL.Text = Program.parseBonus(pos.getVlastnostO("Střelba"));
            ObnL.Text = Program.parseBonus(pos.getVlastnostO("Obrana"));

            toolTip.SetToolTip(BojL, getToolTipFor("Boj", pos));
            toolTip.SetToolTip(UtkL, getToolTipFor("Útok", pos));
            toolTip.SetToolTip(StrL, getToolTipFor("Střelba", pos));
            toolTip.SetToolTip(ObnL, getToolTipFor("Obrana", pos));

            toolTip.SetToolTip(mezZraneniL, "Číslo z Tabulky zranění odpovídající Odl+10");

            pos.zivotyMgr.Change();
            pos.zivotyMgr.setZraneni(pos.zraneni);

            postihZL.Text = pos.postihZ.ToString();
            postihZL.Tag = pos.zraneni;
            if (pos.postihZ == 0)
                postihZL.Visible = false;
            else
                postihZL.Visible = true;

            zbrojL.Text = pos.zbrojMgr.zJmeno;
            prilbaL.Text = pos.zbrojMgr.pJmeno;
            ochranaZbrojeL.Text = pos.zbrojMgr.zOchrana + "/" + pos.zbrojMgr.pOchrana;

            pos.dovednostiMgr.UpdateAll();
            pos.kombinaceZbrani.UpdateAll();
            pos.vybaveniMgr.UpdateAll();
        }

        public void setPenize(Postava pos)
        {
            if (pos.penize <= (float)penizeN.Maximum)
            {
                penizeN.Value = (decimal)pos.penize;
            }
            else
            {
                penizeN.Value = penizeN.Maximum;
            }
        }

        public void setUroven(Postava pos)
        {
            urovenL.Text = pos.uroven.ToString();
            zkusenostiL.Text = pos.zkusenosti.ToString();
            zkNeededBar.Maximum = pos.zkusenostiNeeded;
            zkNeededBar.Value = pos.zkusenosti <= zkNeededBar.Maximum ? pos.zkusenosti : zkNeededBar.Maximum;
            if (zkNeededBar.Value == zkNeededBar.Maximum)
            {
                levelUpB.Visible = true;
            }
            else
            {
                levelUpB.Visible = false;
            }
        }

        public void setPohyb(Postava pos)
        {
            int bon = pos.getVlastnostO("Chůze");
            pohRch0L.Text = Program.parseBonus(bon) + " (" + Program.getTabRychlostiCell(bon) + " km/h)";  // Rch/2 + 23

            bon = pos.getVlastnostO("Spěch");
            pohRch1L.Text = Program.parseBonus(bon) + " (" + Program.getTabRychlostiCell(bon) + " km/h)";  // Rch/2 + 26

            bon = pos.getVlastnostO("Běh");
            pohRch2L.Text = Program.parseBonus(bon) + " (" + Program.getTabRychlostiCell(bon) + " km/h)";  // Rch/2 + 32

            bon = pos.getVlastnostO("Sprint");
            pohRch3L.Text = Program.parseBonus(bon) + " (" + Program.getTabRychlostiCell(bon) + " km/h)";  // Rch/2 + 36

            //Naklad
            double nakl = 0;
            foreach (Predmet p in pos.vybaveniMgr.vybavaList)
            {
                nakl += (double)Math.Round((p.vaha * p.pocet), 2);
            }
            foreach (Kombinace z in pos.kombinaceZbrani.kombinaceList)
            {
                nakl += (double)z.zVaha;
                nakl += (double)z.sVaha;
            }
            foreach (Strelna z in pos.kombinaceZbrani.strelneList)
            {
                nakl += (double)z.zVaha;
            }
            nakl += pos.zbrojMgr.zVaha;
            nakl += pos.zbrojMgr.pVaha;
            #region zjisteniBonusu
            int naklBon = 0;
            DataRowCollection rows = Program.getDB().tabHmotnosti.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                databaseDataSet.tabHmotnostiRow row1 = (databaseDataSet.tabHmotnostiRow)rows[i];
                if (row1.kg >= nakl)
                {
                    if (row1.kg == nakl)
                    {
                        naklBon = row1.bonus;
                        break;
                    }
                    else if (row1.kg > nakl && i - 1 >= 0)
                    {
                        databaseDataSet.tabHmotnostiRow row2 = (databaseDataSet.tabHmotnostiRow)rows[i - 1];
                        double kg1 = row1.kg;
                        double kg2 = row2.kg;
                        int i1 = (int)Math.Round(kg1 * 100 - nakl * 100, 0);
                        int i2 = (int)Math.Round(nakl * 100 - kg2 * 100, 0);
                        if (i1 <= i2)
                            naklBon = row1.bonus;
                        else
                            naklBon = row2.bonus;
                        break;
                    }
                    else
                    {
                        naklBon = row1.bonus;
                        break;
                    }
                }
            }
            #endregion
            nakl = Math.Round((double)nakl, 2);
            nakladL.Text = nakl.ToString() + " kg" + " (" + Program.parseBonus(naklBon) + ")";

            //Max naklad
            int max = pos.getVlastnostO("Max náklad");
            double kg = -99;
            databaseDataSet.tabHmotnostiRow row = Program.getDB().tabHmotnosti.FindBybonus(max);
            if (row != null)
            {
                kg = row.kg;
            }
            maxNakladL.Text = kg.ToString() + " kg" + " (" + Program.parseBonus(max) + ")";

            if (((int)nakl * 100 / kg) <= 100)
                nalozeniBar.Value = (int)(nakl * 100 / kg);
            else
                nalozeniBar.Value = 100;
            if (nalozeniBar.Value >= 100)
            {
                MessageBox.Show("Postava má příliš velké naložení. Neudělá ani krok.");
            }

            int chybSil = pos.parseMath(naklBon.ToString() + "-Sil");
            int atlet = pos.dovednostiMgr.getDovednost("Atletika");
            if (chybSil <= 0 + atlet)
                nalozeniL.Text = "žádné";
            else if (chybSil <= 6 + atlet)
                nalozeniL.Text = "mírné";
            else if (chybSil <= 12 + atlet)
                nalozeniL.Text = "střední";
            else if (chybSil <= 17 + atlet)
                nalozeniL.Text = "velké";
            else if (chybSil <= 21 + atlet)
                nalozeniL.Text = "extrémní";

            int nalPos = pos.parseMath(chybSil.ToString()+"/2");
            if (nalPos >= 0)
                nalozeniPostihL.Text = Program.parseBonus(-nalPos);
            else
                nalozeniPostihL.Text = "0";

            pos.unavaMgr.Change();
            pos.unavaMgr.setUnava(pos.unava);

            postihUL.Text = pos.postihU.ToString();
            postihUL.Tag = pos.unava;
            if (pos.postihU == 0)
                postihUL.Visible = false;
            else
                postihUL.Visible = true;

            toolTip.SetToolTip(pohRch0L, Program.getIniEx("Chůze") + "\nBod únavy za hodinu");
            toolTip.SetToolTip(pohRch1L, Program.getIniEx("Spěch") + "\nBod únavy za půl hodiny");
            toolTip.SetToolTip(pohRch2L, Program.getIniEx("Běh") + "\nBod únavy za 5 minut");
            toolTip.SetToolTip(pohRch3L, Program.getIniEx("Sprint") + "\nBod únavy za 2 kola");

            toolTip.SetToolTip(maxNakladL, "Sil + 21 [+ Atletika]");

            toolTip.SetToolTip(mezUnavyL, "Číslo z Tabulky únavy odpovídající Vdr+10");
        }

        private void setPoznamky(Postava pos)
        {
            for (int i=0; i < pos.pozn_names.Length; i++)
            {
                Control con = Controls.Find("poz_" + pos.pozn_names[i], true)[0];
                if (con.GetType() == typeof(TextBox))
                    con.Text = pos.poznamky[i];
                else if (con.GetType() == typeof(NumericUpDown))
                    ((NumericUpDown)con).Value = decimal.Parse(pos.poznamky[i]);
            }
        }

        public void setNew(Postava pos)
        {
            Cursor = Cursors.WaitCursor;
            jmenoPostavy.Text = pos.jmeno.Replace(" (*)", "");
            RasPov.Text = pos.rasa + " " + pos.povolani.ToLower();

            setHlavni(pos);
            pos.Calculate();

            setVedlejsi(pos);

            setBoj(pos);

            setPenize(pos);

            setUroven(pos);

            setPohyb(pos);

            setPoznamky(pos);

            pos.SetPovolaniSheet();

            tabControl1.Visible = true;
            Cursor = Cursors.Default;
        }

        private string getToolTipFor(string vlast, Postava pos)
        {
            String ttText = "";

            String ini = Program.getIniEx(vlast);
            if (vlast == "Boj")
                ini = Program.getDB().povolani.FindByjmeno(pos.povolani).oboj;
            if(ini != "")
                ttText += ini.Replace(":n", " (nahoru)").Replace(":d", " (dolů)") + "\n";

            List<Pair<String, int>> opravy;
            opravy = pos.getOpravyByVlast(vlast);
            foreach (Pair<String, int> opr in opravy)
            {
                if (opr.second == 0) continue;
                String posBon;
                if (opr.second < 0)
                    posBon = "Postih ";
                else
                    posBon = "Bonus ";
                ttText += posBon + Program.parseBonus(opr.second) + " " + opr.first.Substring(opr.first.IndexOf("|")+1) + "\n";
            }

            return ttText;
        }

        private void noFocus_Click(object sender, EventArgs e)
        {
            tabPage1.Focus();
        }

        private void ulozitPostavuClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            postavyMgr.SaveOpened();
            Cursor = Cursors.Default;
        }
        
        private void ulozitPostavuJakoClick(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                postavyMgr.GetOpened().xmlFileName = saveDialog.FileName;
                postavyMgr.SaveOpened();
                Cursor = Cursors.WaitCursor;
            }
        }

        private void nacistPostavuClick(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                String fn = openDialog.FileName.ToLower();
                if (fn.Substring(fn.Length - 3) == "drz")
                {
                    postavyMgr.LoadDruzina(openDialog.FileName);
                }
                else
                {
                    nacist(openDialog.FileName);
                }
                Cursor = Cursors.Default;
            }
        }

        public void nacist(String fn)
        {
            Cursor = Cursors.WaitCursor;
            Postava pos = new Postava();

            pos.xmlFileName = fn;
            postavyMgr.Add(pos);

            Cursor = Cursors.Default;
        }

        private void vybratZbrojB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            postavyMgr.GetOpened().zbrojMgr.vybratZbrojB_LinkClicked(sender, e);
        }

        private void newKombinaceB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            postavyMgr.GetOpened().kombinaceZbrani.newKombinaceB_LinkClicked(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zkusenosti dialog = new zkusenosti();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                int zk = 0;
                zk = (int)dialog.n1.Value + (int)dialog.n2.Value + (int)dialog.n3.Value + (int)dialog.n4.Value + (int)dialog.n5.Value;
                postavyMgr.GetOpened().zkusenosti += zk;
                setNew(postavyMgr.GetOpened());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chcete nechat postavu postoupit na vyšší úroveň?", "Postup na vyšší úroveň", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                postavyMgr.GetOpened().LevelUp();
                levelUp dialog = new levelUp(postavyMgr.GetOpened());
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {

                }
                setNew(postavyMgr.GetOpened());
                Cursor = Cursors.Default;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            foreach(String fn in files)
            {
                if (fn.Substring(fn.Length - 3) == "pos")
                {
                    nacist(fn);
                }
                else
                {
                    postavyMgr.LoadDruzina(fn);
                }
            }
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;

        }

        private void splitContainer1_DoubleClick(object sender, EventArgs e)
        {
            if (splitContainer1.SplitterDistance == 0)
            {
                splitContainer1.SplitterDistance = (int)splitContainer1.Tag;
            }
            else
            {
                splitContainer1.Tag = splitContainer1.SplitterDistance;
                splitContainer1.SplitterDistance = 0;
            }
            this.Refresh();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.Refresh();
        }

        private void nacistDruzinu()
        {
            if(openDialog2.ShowDialog(this) == DialogResult.OK)
            {
                postavyMgr.LoadDruzina(openDialog2.FileName);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType() != typeof(Postava)) return;
            Cursor = Cursors.WaitCursor;
            postavyMgr.OpenSelected();
            Cursor = Cursors.Default;
        }

        private void treeContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            treeContextMenu.Hide();
            switch (e.ClickedItem.Text)
            {
                case "Otevřít":
                    treeView1_NodeMouseDoubleClick(null, null);
                    break;
                case "Uložit":
                    Cursor = Cursors.WaitCursor;
                    postavyMgr.GetSelected().Save();
                    Cursor = Cursors.Default;
                    break;
                case "Zavřít":
                    DialogResult dr;
                    if ((dr = MessageBox.Show("Chcete postavu před zavřením uložit?", "Uložit postavu " + postavyMgr.GetSelected().jmeno + "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        postavyMgr.GetSelected().Save();
                        Cursor = Cursors.Default;
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        break;
                    }
                    postavyMgr.RemoveSelected();
                    break;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            treeMainMenu.Hide();
            switch (e.ClickedItem.Text)
            {
                case "Nová postava...":
                    nováPostavaToolStripMenuItem_Click(null, null);
                    break;
                case "Nová družina":
                    TreeNode node = postavyMgr.NewDruzina("Nová družina");
                    node.TreeView.LabelEdit = true;
                    node.BeginEdit();
                    postavyMgr.RenameDruzina(node);
                    break;
                case "Načíst družinu...":
                    nacistDruzinu();
                    break;
                case "Načíst postavu...":
                    nacistPostavuClick(null, null);
                    break;
                case "Uložit vše":
                    SaveAll();
                    break;
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length == 0)
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Název družiny nesmí být prázdný text", "Název družiny");
                    e.Node.BeginEdit();
                }
                e.Node.TreeView.LabelEdit = false;
            }
        }
        /*
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
            treeView1.SelectedNode = node;

            if (node != null && node.Tag != null && e.Button == MouseButtons.Left)
            {
                treeView1.DoDragDrop(node, DragDropEffects.Move);
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            TreeNode nodeSource = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (nodeSource != null && nodeSource.Tag != null)
            {
                e.Effect = DragDropEffects.None;

                Point pt = new Point(e.X, e.Y);
                pt = treeView1.PointToClient(pt);
                TreeNode nodeTarget = treeView1.GetNodeAt(pt);

                e.Effect = DragDropEffects.Move;
                treeView1.SelectedNode = nodeTarget;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            pt = treeView1.PointToClient(pt);
            TreeNode nodeTarget = treeView1.GetNodeAt(pt);
            TreeNode nodeSource = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (nodeTarget != null)
            {
                if (nodeSource != nodeTarget)
                {
                    if (nodeTarget.Parent == null)
                    {
                        nodeSource.Remove();
                        nodeTarget.Nodes.Add(nodeSource);
                    }
                    else
                    {
                        nodeSource.Remove();
                        nodeTarget.Parent.Nodes.Add(nodeSource);
                    }
                }
            }
            else
            {
                nodeSource.Remove();
                treeView1.Nodes.Add(nodeSource);
            }
        }
        */

        private void m_ulozitVse_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void m_povolaniData_Click(object sender, EventArgs e)
        {
            povolaniDataDialog data = new povolaniDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_rasyData_Click(object sender, EventArgs e)
        {
            rasyDataDialog data = new rasyDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_dovednostiData_Click(object sender, EventArgs e)
        {
            dovednostiDataDialog data = new dovednostiDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_zbraneData_Click(object sender, EventArgs e)
        {
            zbraneDataDialog data = new zbraneDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_zbrojeData_Click(object sender, EventArgs e)
        {
            zbrojeDataDialog data = new zbrojeDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_stityData_Click(object sender, EventArgs e)
        {
            stityDataDialog data = new stityDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void m_predmetyData_Click(object sender, EventArgs e)
        {
            predmetyDataDialog data = new predmetyDataDialog();
            data.ShowDialog(this);
            database.WriteXml("db.xml");
        }

        private void zraneniN_ValueChanged(object sender, EventArgs e)
        {
            if(postavyMgr.GetOpened() != null)
            {
                postavyMgr.GetOpened().zivotyMgr.zraneniChanged(sender, e);
            }
        }

        private void unavaN_ValueChanged(object sender, EventArgs e)
        {
            if (postavyMgr.GetOpened() != null)
            {
                postavyMgr.GetOpened().unavaMgr.unavaChanged(sender, e);
            }
        }

        private void penizeN_ValueChanged(object sender, EventArgs e)
        {
            Postava pos = postavyMgr.GetOpened();
            if (pos != null)
            {
                pos.penize = (float)penizeN.Value;
            }
        }

        private void m_konec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nastaveni dialog = new nastaveni();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void SaveAll()
        {
            foreach (TreeNode node in postavyMgr.tree.Nodes)
            {
                if (node.Tag.GetType() != typeof(Postava))
                {
                    postavyMgr.SaveDruzina(node);
                }
                else
                {
                    ((Postava)node.Tag).Save();
                }
            }
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            tabControl1.Tag = false;
            if (tabControl1.Visible == true)
            {
                tabControl1.Tag = true;
                tabControl1.Visible = false;
            }
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            if (((bool)tabControl1.Tag) == true)
            {
                tabControl1.Visible = true;
            }
            tabControl1.Refresh();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (settings.assoc == false)
            {
                settings.assoc = true;
                if (MessageBox.Show("Chcete asociovat soubory .pos a .drz k programu CCgen+ ?", "Asociovat soubory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    nastaveni nas = new nastaveni();
                    nas.button1_Click(null, null);
                }
            }

            if (arg != "")
            {
                if (arg.Substring(arg.Length - 3) == "pos")
                {
                    nacist(arg);
                }
                else
                {
                    postavyMgr.LoadDruzina(arg);
                }
            }

            Cursor = Cursors.WaitCursor;
            {
                String[] files = settings.recentPostavy.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (String s in files)
                {
                    LoadRecent(s);
                }
                files = settings.recentDruziny.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (String s in files)
                {
                    LoadRecentDrz(s);
                }
            }
            if (settings.loadLast && arg == "")
            {
                String[] files = settings.loadDruziny.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (String fn in files)
                {
                    postavyMgr.LoadDruzina(fn);
                }

                files = settings.loadPostavy.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (String fn in files)
                {
                    nacist(fn);
                }
            }
            //paint pxxs = new paint();
            //pxxs.Show();
            Cursor = Cursors.Default;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Chcete ukončit program?\nNeuložená data budou ztracena!", "Ukončit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Cursor = Cursors.WaitCursor;
            settings.maximized = this.WindowState == FormWindowState.Maximized ? true : false;
            this.WindowState = FormWindowState.Normal;
            settings.width = this.Width;
            settings.height = this.Height;
            

            String files = "";
            foreach (String s in recent)
            {
                files += s + "|";
            }
            settings.recentPostavy = files;
            
            files = "";
            foreach (String s in recentDrz)
            {
                files += s + "|";
            }
            settings.recentDruziny = files;


            if (settings.loadLast)
            {
                files = "";
                String druzs = "";
                foreach(TreeNode node in postavyMgr.tree.Nodes)
                {
                    if (node.Tag.GetType() == typeof(Postava))
                    {
                        files += ((Postava)node.Tag).xmlFileName + "|";
                    }
                    else
                    {
                        druzs += (String)node.Tag + "|";
                    }
                }
                if (files.Length > 1)
                    files = files.Remove(files.Length-1);
                if(druzs.Length > 1)
                    druzs = druzs.Remove(druzs.Length-1);

                settings.loadPostavy = files;
                settings.loadDruziny = druzs;
            }

            string tabs = "";
            foreach (TabPage page in tabPages)
            {
                if (((bool)page.Tag) == true)
                    tabs += "1";
                else
                    tabs += "0";
            }
            settings.tabs = tabs;

            tabs = "";
            foreach (Pair<TabPage, bool> pair in tabOrder)
            {
                TabPage page = pair.first;
                for (int i = 0; i < tabPages.Length; i++)
                {
                    if (page.Equals(tabPages[i]))
                        tabs += i.ToString();
                }
            }
            settings.tabsOrder = tabs;

            settings.Save();
            Cursor = Cursors.Default;
        }

        private void webSiteItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://cgenplus.utf-8.cz/");
        }

        private void m_about_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void m_exportDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Document|*.xml|Všechny soubory|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Program.getDB().WriteXml(sfd.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void m_importDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Document|*.xml|Všechny soubory|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                databaseDataSet tempDS = new databaseDataSet();
                tempDS.ReadXml(ofd.FileName);

                DialogResult dr = MessageBox.Show("Přejete si zachovat změny u existujících položek původní databáze?", "Zachovat změny?", MessageBoxButtons.YesNo);
                Program.getDB().Merge(tempDS, dr == DialogResult.Yes ? true : false);
            }
        }

        private void m_print_Click(object sender, EventArgs e)
        {
            PrintDialog pdd = new PrintDialog();
            pdd.AllowCurrentPage = true;
            pdd.AllowSelection = false;
            pdd.AllowSomePages = false;
            pdd.UseEXDialog = true;
            pdd.ShowDialog();
        }

        private void m_export_txt_Click(object sender, EventArgs e)
        {
            Exporter.ToTXT(postavyMgr.GetOpened());
        }

        private void m_nastroje_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "")
            {
                switch (e.ClickedItem.Name)
                {
                    case "m_hod2k6":
                        {
                            m_nastroje.HideDropDown();
                            Random rand = new Random();
                            MessageBox.Show("Padlo: \t" + Program.hod2k6(rand).ToString(), "Hod 2k6*");
                            m_nastroje.ShowDropDown();
                        }
                        break;

                    case "m_hod1k6":
                        {
                            m_nastroje.HideDropDown();
                            Random rand = new Random();
                            int x = rand.Next(1, 7);
                            MessageBox.Show("Padlo: \t" + x.ToString(), "Hod 1k6");
                            m_nastroje.ShowDropDown();
                        }
                        break;

                    case "m_hodPerc":
                        {
                            m_nastroje.HideDropDown();
                            Random rand = new Random();
                            int x = rand.Next(0, 101);
                            MessageBox.Show("Padlo: \t" + x.ToString() + "%", "Procentuální hod");
                            m_nastroje.ShowDropDown();
                        }
                        break;

                    case "m_ultraHod":
                        {
                            bool opened = false;
                            foreach(Form form in Application.OpenForms)
                            {
                                if (form.GetType() == typeof(ultraHod))
                                {
                                    form.Focus();
                                    opened = true;
                                }
                            }
                            if (opened) break;

                            ultraHod dialog = new ultraHod();
                            dialog.Show();
                        }
                        break;

                    case "m_opravyPos":
                        {
                            Postava pos = postavyMgr.GetOpened();
                            if (pos != null)
                            {
                                opravy dialog = new opravy(pos);
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {

                                }
                            }
                        }
                        break;

                    case "m_calc":
                        {
                            System.Diagnostics.Process.Start("calc");
                        }
                        break;
                }
            }
        }

        private void m_tabulky_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = 0;
            switch (e.ClickedItem.Name)
            {
                case "m_tableVzdalenosti": index = 0; break;
                case "m_tableRychlosti": index = 1; break;
                case "m_tableZranUnav": index = 2; break;
                case "m_tableVypZZ": index = 3; break;
                case "m_tableHmotnosti": index = 4; break;
            }
            bool opened = false;
            int indexed = index;
            tables fform;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(tables))
                {
                    fform = (tables)form;
                    fform.Focus();
                    indexed = fform.table;
                    opened = true;

                    if (index != indexed)
                    {
                        fform.table = index;
                        fform.tables_Load(null, null);
                    }
                    break;
                }
            }
            if(!opened)
                new tables(index).Show();
        }

        private void postihZLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            postavyMgr.GetOpened().zivotyMgr.postihClicked(sender, e);
        }

        private void postihULink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            postavyMgr.GetOpened().unavaMgr.postihClicked(sender, e);
        }

        private void poznamka_TextChanged(object sender, EventArgs e)
        {
            postavyMgr.GetOpened().setPoznamka(sender);
        }

        private void poz_vek_ValueChanged(object sender, EventArgs e)
        {
            postavyMgr.GetOpened().setPoznamka(sender);
        }

        private void treeMainMenu_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
