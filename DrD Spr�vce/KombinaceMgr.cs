using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Kombinace
    {
        private GroupBox parentPanel = new GroupBox();
        private Label label1 = new Label();
        private Label bcL = new Label();
        private Label label2 = new Label();
        private Label uczzL = new Label();
        private Label label3 = new Label();
        private Label ocKrytL = new Label();

        private LinkLabel editB = new LinkLabel();
        private LinkLabel deleteB = new LinkLabel();

        public String nazev;
        public String zbran;
        public String stit;
        public int bc;
        public int uc;
        public int zz;
        public int oc;
        public String typ;
        public int zKryt;
        public int sKryt;
        public float zVaha;
        public float sVaha;

        public bool obouruc;

        private KombinaceMgr mgr;

        public Kombinace(KombinaceMgr mgr, FlowLayoutPanel parent, String nazev, String zbran, String stit, bool obouruc)
        {
            this.mgr = mgr;

            this.nazev = nazev;
            this.zbran = zbran;
            this.stit = stit;
            this.obouruc = obouruc;

            #region inicializace
            parentPanel.Parent = parent;
            parentPanel.Left = parentPanel.Top = 0;
            parentPanel.AutoSize = true;
            //parentPanel.Font = new Font("Arial", 10);

            label1.Top = 20;
            label1.Left = 10;
            label1.AutoSize = true;
            label1.Text = "BČ";
            label1.Parent = parentPanel;

            bcL.Top = 36;
            bcL.Left = 10;
            bcL.AutoSize = true;
            bcL.Parent = parentPanel;

            label2.Left = 56 + 10;
            label2.Top = 20;
            label2.AutoSize = true;
            label2.Text = "ÚČ/ZZ";
            label2.Parent = parentPanel;

            uczzL.Left = 44 + 10;
            uczzL.Top = 36;
            uczzL.TextAlign = ContentAlignment.TopRight;
            uczzL.AutoSize = false;
            uczzL.Width = 48;
            uczzL.Height = 13;
            uczzL.Parent = parentPanel;

            label3.Left = 49 + 10;
            label3.Top = 54;
            label3.AutoSize = true;
            label3.Text = "OČ (kryt)";
            label3.Parent = parentPanel;

            ocKrytL.Left = 46 + 10;
            ocKrytL.Top = 70;
            ocKrytL.TextAlign = ContentAlignment.TopRight;
            ocKrytL.AutoSize = false;
            ocKrytL.Width = 48;
            ocKrytL.Height = 13;
            ocKrytL.Parent = parentPanel;
            
            editB.Left = 10;
            editB.Top = 90;
            editB.AutoSize = true;
            editB.Text = "Upravit";
            editB.Parent = parentPanel;
            editB.VisitedLinkColor = Color.Blue;
            editB.LinkBehavior = LinkBehavior.HoverUnderline;
            editB.LinkClicked += new LinkLabelLinkClickedEventHandler(editB_Click);

            deleteB.Left = 63;
            deleteB.Top = 90;
            deleteB.AutoSize = true;
            deleteB.Text = "Smazat";
            deleteB.Parent = parentPanel;
            deleteB.VisitedLinkColor = Color.Blue;
            deleteB.LinkBehavior = LinkBehavior.HoverUnderline;
            deleteB.LinkClicked += new LinkLabelLinkClickedEventHandler(deleteB_Click);

            #endregion
        }

        public void editB_Click(object sender, LinkLabelLinkClickedEventArgs args)
        {
            newKombinace dialog = new newKombinace(mgr.postava, this);
            if (dialog.ShowDialog(Program.getMainForm()) == DialogResult.OK)
            {
                Postava postava = mgr.postava;

                nazev = dialog.nazevKomba.Text;
                zbran = dialog.zJmeno;
                stit = dialog.sJmeno;
                obouruc = dialog.checkBox1.Checked;

                Calculate();
                Program.getMainForm().setPohyb(postava);
            }
        }

        public void deleteB_Click(object sender, LinkLabelLinkClickedEventArgs args)
        {
            if (MessageBox.Show("Chcete kombinaci " + nazev + " smazat?", "Smazat kombinaci?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                parentPanel.Controls.Clear();
                parentPanel.Dispose();
                mgr.DeleteKomb(this);
                Program.getMainForm().setPohyb(mgr.postava);
            }
        }

        public void Calculate()
        {
            databaseDataSet.zbraneRow zRow = Program.getDB().zbrane.FindByjmeno(zbran);
            databaseDataSet.stityRow sRow = null;
            
            if (stit != "")
            {
                try
                {
                    sRow = Program.getDB().stity.FindByjmeno(stit);
                }
                catch
                {
                    MessageBox.Show("V databázi neexistuje " + stit + ".\nChyba nastala u postavy " + mgr.postava.jmeno, "Štít neexistuje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stit = "";
                }
            }


            if (zRow != null)
            {
                bc = mgr.postava.getVlastnostO("Boj") + zRow.delka;
                uc = mgr.postava.getVlastnostO("Útok") + zRow.utocnost;
                zz = (int)Program.getZZCell((short)mgr.postava.getVlastnostO("Sil"), zRow.zraneni) + (obouruc == true ? 2 : 0);
                oc = mgr.postava.getVlastnostO("Obrana");
                zKryt = zRow.kryt;
                sKryt = (stit != "" ? sRow.kryt : 0);
                typ = zRow.typ;
                zVaha = (float)zRow.vaha;
                sVaha = 0;

                if (zRow.IspsilaNull() == false)
                {
                    int pSila = zRow.psila - mgr.postava.getVlastnostO("Sil") - (obouruc == true ? 2 : 0);

                    #region OpravyZaChybejiciSilu
                    switch (pSila)
                    {
                        case 1:
                            bc -= 1;
                            break;
                        case 2:
                            bc -= 1;
                            uc -= 1;
                            break;
                        case 3:
                            bc -= 2;
                            uc -= 1;
                            oc -= 1;
                            break;
                        case 4:
                            bc -= 2;
                            uc -= 2;
                            oc -= 1;
                            zz -= 1;
                            break;
                        case 5:
                            bc -= 3;
                            uc -= 2;
                            oc -= 2;
                            zz -= 1;
                            break;
                        case 6:
                            bc -= 3;
                            uc -= 3;
                            oc -= 2;
                            zz -= 2;
                            break;
                        case 7:
                            bc -= 4;
                            uc -= 3;
                            oc -= 3;
                            zz -= 2;
                            break;
                        case 8:
                            bc -= 4;
                            uc -= 4;
                            oc -= 3;
                            zz -= 3;
                            break;
                        case 9:
                            bc -= 5;
                            uc -= 4;
                            oc -= 4;
                            zz -= 3;
                            break;
                        case 10:
                            bc -= 5;
                            uc -= 5;
                            oc -= 4;
                            zz -= 4;
                            break;
                        default:
                            if (pSila >= 11)
                            {
                                bc -= 90;
                                uc -= 90;
                                oc -= 90;
                                zz -= 90;
                                MessageBox.Show("Kombinace "+ nazev +" je nepoužitelná, postavě chybí potřebná síla.", "Chybí potřebná síla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                    if (stit != "")
                    {
                        pSila = sRow.psila - mgr.postava.getVlastnostO("Sil");

                        switch (pSila)
                        {
                            case 1:
                                bc -= 1;
                                break;
                            case 2:
                                bc -= 1;
                                uc -= 1;
                                break;
                            case 3:
                                bc -= 2;
                                uc -= 1;
                                oc -= 1;
                                break;
                            case 4:
                                bc -= 2;
                                uc -= 2;
                                oc -= 1;
                                zz -= 1;
                                break;
                            case 5:
                                bc -= 3;
                                uc -= 2;
                                oc -= 2;
                                zz -= 1;
                                break;
                            case 6:
                                bc -= 3;
                                uc -= 3;
                                oc -= 2;
                                zz -= 2;
                                break;
                            case 7:
                                bc -= 4;
                                uc -= 3;
                                oc -= 3;
                                zz -= 2;
                                break;
                            case 8:
                                bc -= 4;
                                uc -= 4;
                                oc -= 3;
                                zz -= 3;
                                break;
                            case 9:
                                bc -= 5;
                                uc -= 4;
                                oc -= 4;
                                zz -= 3;
                                break;
                            case 10:
                                bc -= 5;
                                uc -= 5;
                                oc -= 4;
                                zz -= 4;
                                break;
                            default:
                                {
                                    if (pSila >= 11)
                                    {
                                        bc -= 90;
                                        uc -= 90;
                                        oc -= 90;
                                        zz -= 90;
                                        MessageBox.Show("Kombinace " + nazev + " je nepoužitelná, postavě chybí potřebná síla.", "Chybí potřebná síla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                break;
                        }
                    }
                    #endregion
                }
                int dov = mgr.postava.dovednostiMgr.getDovednost("Boj (" + zRow.kategorie + ")");
                switch (dov)
                {
                    case 0:
                        bc -= 3;
                        uc -= 3;
                        zKryt -= 2;
                        zz -= 1;
                        break;
                    case 1:
                        bc -= 2;
                        uc -= 2;
                        zKryt -= 1;
                        zz -= 1;
                        break;
                    case 2:
                        bc -= 1;
                        uc -= 1;
                        zKryt -= 1;
                        break;
                }

                if (stit != "")
                {
                    int omezeni = sRow.omezeni;
                    switch (mgr.postava.dovednostiMgr.getDovednost("Používání štítu"))
                    {
                        case 0: sKryt -= 2; break;
                        case 1: omezeni += 1; sKryt -= 1; break;
                        case 2: omezeni += 2; sKryt -= 1; break;
                        case 3: omezeni += 3; break;
                    }
                    if (omezeni > 0)
                    {
                        omezeni = 0;
                    }
                    bc += omezeni;
                    sVaha = (float)sRow.vaha;
                }
            }
            else
            {
                MessageBox.Show("V databázi neexistuje zbraň " + zbran + ".\nChyba nastala u postavy " + mgr.postava.jmeno, "Zbraň neexistuje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentPanel.Controls.Clear();
                parentPanel.Dispose();
                mgr.DeleteKomb(this);
            }
            setLabels();
        }

        public void setLabels()
        {
            parentPanel.Text = nazev;
            bcL.Text = bc.ToString();
            Program.getMainForm().toolTip.SetToolTip(bcL, "");
            uczzL.Text = uc.ToString() + " / " + zz.ToString() +  " " + typ;

            ocKrytL.Text = oc.ToString() + " (";
            ocKrytL.Text += zKryt.ToString();
            if (stit != "")
            {
                ocKrytL.Text += ", " + sKryt.ToString();
            }
            ocKrytL.Text += ")";
        }
    }
    public class Strelna
    {
        private GroupBox parentPanel = new GroupBox();
        private Label label1 = new Label();
        private Label bcL = new Label();
        private Label label2 = new Label();
        private Label uczzL = new Label();
        private Label label3 = new Label();
        private Label ocKrytL = new Label();

        private LinkLabel editB = new LinkLabel();
        private LinkLabel deleteB = new LinkLabel();

        public String nazev;
        public String zbran;
        public int bc;
        public int kol;
        public int uc;
        public int zz;
        public int sd;
        public int oc;
        public String typ;
        public int zKryt;
        public float zVaha;

        private KombinaceMgr mgr;

        public Strelna(KombinaceMgr mgr, FlowLayoutPanel parent, String nazev, String zbran)
        {
            this.mgr = mgr;

            this.nazev = nazev;
            this.zbran = zbran;
            this.zKryt = 2;

            #region inicializace
            parentPanel.Parent = parent;
            parentPanel.Left = parentPanel.Top = 0;
            parentPanel.AutoSize = true;

            label1.Top = 20;
            label1.Left = 10;
            label1.AutoSize = true;
            label1.Text = "BČ";
            label1.Parent = parentPanel;

            bcL.Top = 36;
            bcL.Left = 10;
            bcL.AutoSize = true;
            bcL.Parent = parentPanel;

            label2.Left = 56 + 10;
            label2.Top = 20;
            label2.AutoSize = true;
            label2.Text = "ÚČ/ZZ/SD";
            label2.Parent = parentPanel;

            uczzL.Left = 44;
            uczzL.Top = 36;
            uczzL.TextAlign = ContentAlignment.TopRight;
            uczzL.AutoSize = false;
            uczzL.Width = 80;
            uczzL.Height = 13;
            uczzL.Parent = parentPanel;

            label3.Left = 49 + 27;
            label3.Top = 54;
            label3.AutoSize = true;
            label3.Text = "OČ (kryt)";
            label3.Parent = parentPanel;

            ocKrytL.Left = 46 + 29;
            ocKrytL.Top = 70;
            ocKrytL.TextAlign = ContentAlignment.TopRight;
            ocKrytL.AutoSize = false;
            ocKrytL.Width = 48;
            ocKrytL.Height = 13;
            ocKrytL.Parent = parentPanel;

            editB.Left = 10;
            editB.Top = 90;
            editB.AutoSize = true;
            editB.Text = "Upravit";
            editB.Parent = parentPanel;
            editB.VisitedLinkColor = Color.Blue;
            editB.LinkBehavior = LinkBehavior.HoverUnderline;
            editB.LinkClicked += new LinkLabelLinkClickedEventHandler(editB_Click);

            deleteB.Left = 80;
            deleteB.Top = 90;
            deleteB.AutoSize = true;
            deleteB.Text = "Smazat";
            deleteB.Parent = parentPanel;
            deleteB.VisitedLinkColor = Color.Blue;
            deleteB.LinkBehavior = LinkBehavior.HoverUnderline;
            deleteB.LinkClicked += new LinkLabelLinkClickedEventHandler(deleteB_Click);

            #endregion
        }

        public void editB_Click(object sender, LinkLabelLinkClickedEventArgs args)
        {
            newKombinace dialog = new newKombinace(mgr.postava, this);
            if (dialog.ShowDialog(Program.getMainForm()) == DialogResult.OK)
            {
                Postava postava = mgr.postava;

                nazev = dialog.nazevKomba.Text;
                zbran = dialog.zJmeno;

                Calculate();
            }
        }

        public void deleteB_Click(object sender, LinkLabelLinkClickedEventArgs args)
        {
            if (MessageBox.Show("Chcete kombinaci " + nazev + " smazat?", "Smazat kombinaci?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                parentPanel.Controls.Clear();
                parentPanel.Dispose();
                mgr.DeleteStrelna(this);
            }
        }

        public void Calculate()
        {
            databaseDataSet.strelneRow row = Program.getDB().strelne.FindByjmeno(zbran);

            if (row != null)
            {
                zVaha = (float)row.vaha;
                bc = mgr.postava.getVlastnostO("Boj");
                if (row.kategorie == "Luky" || row.kategorie == "Kuše")
                {
                    uc = mgr.postava.getVlastnostO("Střelba") + row.utocnost;
                }
                else
                {
                    uc = mgr.postava.getVlastnostO("Útok") + row.utocnost;
                }

                if (row.kategorie == "Luky")
                {
                    int sil = mgr.postava.getVlastnostO("Sil");
                    zz = (int)Program.getZZCell((short)(sil > row.maxSila ? row.maxSila : sil), row.zraneni);
                }
                else if (row.kategorie == "Kuše")
                {
                    zz = (int)Program.getZZCell(row.pSila, row.zraneni);
                }
                else
                {
                    zz = (int)Program.getZZCell((short)mgr.postava.getVlastnostO("Sil"), row.zraneni);
                }
                oc = mgr.postava.getVlastnostO("Obrana");
                databaseDataSet.zbraneRow row2;
                if ((row2 = Program.getDB().zbrane.FindByjmeno(zbran)) != null)
                {
                    zKryt = row2.kryt;
                }
                else
                {
                    zKryt = 2;
                }

                if (row.kategorie == "Luky")
                {
                    int sil = mgr.postava.getVlastnostO("Sil");
                    sd = (sil > row.maxSila ? row.maxSila : sil) + row.dostrel;
                }
                else if (row.kategorie == "Kuše")
                {
                    sd = row.dostrel;
                }
                else
                {
                    sd = mgr.postava.parseMath("Rch/2") + row.dostrel;
                }
                typ = row.typ;

                #region OpravyZaChybejiciSilu
                int pSila = row.pSila - mgr.postava.getVlastnostO("Sil");
                kol = 1;
                switch (pSila)
                {
                    case 1:
                        bc -= 1;
                        break;
                    case 2:
                        bc -= 2;
                        uc -= 1;
                        break;
                    case 3:
                        bc -= 3;
                        uc -= 1;
                        sd -= 1;
                        break;
                    case 4:
                        bc -= 4;
                        uc -= 2;
                        sd -= 1;
                        zz -= 1;
                        break;
                    case 5:
                        bc -= 5;
                        uc -= 2;
                        sd -= 2;
                        zz -= 1;
                        break;
                    case 6:
                        bc -= 6;
                        uc -= 3;
                        sd -= 2;
                        zz -= 2;
                        break;
                    case 7:
                        bc -= 1;
                        uc -= 3;
                        sd -= 3;
                        zz -= 2;
                        kol = 2;
                        break;
                    case 8:
                        bc -= 1;
                        uc -= 4;
                        sd -= 3;
                        zz -= 3;
                        kol = 2;
                        break;
                    case 9:
                        bc -= 2;
                        uc -= 4;
                        sd -= 4;
                        zz -= 3;
                        kol = 2;
                        break;
                    case 10:
                        bc -= 3;
                        uc -= 5;
                        sd -= 4;
                        zz -= 4;
                        kol = 2;
                        break;
                    default:
                        if (pSila >= 11)
                        {
                            bc -= 90;
                            uc -= 90;
                            sd -= 90;
                            zz -= 90;
                            kol = 90;
                            MessageBox.Show("Kombinace " + zbran + " je nepoužitelná, postavě chybí potřebná síla.", "Chybí potřebná síla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
                #endregion

                int dov = 0;
                if (row.kategorie == "Luky")
                {
                    dov = mgr.postava.dovednostiMgr.getDovednost("Boj s luky");
                }
                else if (row.kategorie == "Kuše")
                {
                    dov = mgr.postava.dovednostiMgr.getDovednost("Boj s kušemi");
                }
                else
                {
                    dov = mgr.postava.dovednostiMgr.getDovednost("Boj s vrhacími zbraněmi"); ;
                }
                switch (dov)
                {
                    case 0:
                        bc -= 3;
                        uc -= 3;
                        zKryt -= 2;
                        zz -= 1;
                        break;
                    case 1:
                        bc -= 2;
                        uc -= 2;
                        zKryt -= 1;
                        zz -= 1;
                        break;
                    case 2:
                        bc -= 1;
                        uc -= 1;
                        zKryt -= 1;
                        break;
                }
            }
            else
            {
                MessageBox.Show("V databázi neexistuje zbraň " + zbran + ".\nChyba nastala u postavy " + mgr.postava.jmeno, "Zbraň neexistuje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentPanel.Controls.Clear();
                parentPanel.Dispose();
                mgr.DeleteStrelna(this);
            }
            setLabels();
        }

        public void setLabels()
        {
            parentPanel.Text = nazev;
            bcL.Text = bc.ToString() + "\n" + kol + (kol == 1 ? " kolo" : " kol");
            uczzL.Text = uc.ToString() + " / " + zz.ToString() + " " + typ + " / " + Program.parseBonus(sd);

            ocKrytL.Text = oc.ToString() + " (";
            ocKrytL.Text += zKryt.ToString();
            ocKrytL.Text += ")";
        }
    }

    public class KombinaceMgr
    {
        public List<Kombinace> kombinaceList = new List<Kombinace>();
        public List<Strelna> strelneList = new List<Strelna>();

        private FlowLayoutPanel flowPanel;
        public Postava postava;

        public KombinaceMgr(FlowLayoutPanel flowPanel, Postava pos)
        {
            postava = pos;
            this.flowPanel = flowPanel;
            this.flowPanel.Controls.Clear();
        }

        public void newKombinaceB_LinkClicked(object sender, EventArgs e)
        {
            if (kombinaceList.Count >= 6)
            {
                MessageBox.Show("Pro rychlejší chod programu je maximální počet kombinací 6.", "Maximum kombinací", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            newKombinace dialog = new newKombinace(postava);
            Main form = Program.getMainForm();
            if (dialog.ShowDialog(form) == DialogResult.OK)
            {
                if (dialog.r1.Checked == true)
                {
                    String nazev;
                    String zbran;
                    String stit;

                    nazev = dialog.nazevKomba.Text;
                    zbran = dialog.zJmeno;
                    stit = dialog.sJmeno;

                    kombinaceList.Add(new Kombinace(this, flowPanel, nazev, zbran, stit, dialog.checkBox1.Checked));
                }
                else
                {
                    String nazev;
                    String zbran;

                    nazev = dialog.nazevKomba.Text;
                    zbran = dialog.zJmeno;

                    strelneList.Add(new Strelna(this, flowPanel, nazev, zbran));
                }
                UpdateAll();
                Program.getMainForm().setPohyb(postava);
            }
        }

        public void UpdateAll()
        {
            List<String> nazvy = new List<String>();
            List<String> zbrane = new List<String>();
            List<String> stity = new List<String>();
            List<bool> obouruc = new List<bool>();

            List<String> nazvy2 = new List<String>();
            List<String> zbrane2 = new List<String>();
            
            foreach (Kombinace k in kombinaceList)
            {
                nazvy.Add(k.nazev);
                zbrane.Add(k.zbran);
                stity.Add(k.stit);
                obouruc.Add(k.obouruc);
            }
            foreach (Strelna k in strelneList)
            {
                nazvy2.Add(k.nazev);
                zbrane2.Add(k.zbran);
            }
            flowPanel.Controls.Clear();
            kombinaceList.Clear();
            strelneList.Clear();

            for (int i = 0; i < nazvy.Count; i++)
            {
                AddKomb(nazvy[i], zbrane[i], stity[i], obouruc[i]);
            }

            for (int i = 0; i < nazvy2.Count; i++)
            {
                AddKomb(nazvy2[i], zbrane2[i]);
            }
        }

        public void AddKomb(String nazev, String zbran, String stit, bool obouruc)
        {
            Kombinace kom = new Kombinace(this, flowPanel, nazev, zbran, stit, obouruc);
            kombinaceList.Add(kom);
            kom.Calculate();
        }

        public void AddKomb(String nazev, String zbran)
        {
            Strelna kom = new Strelna(this, flowPanel, nazev, zbran);
            strelneList.Add(kom);
            kom.Calculate();
        }

        public void DeleteKomb(Kombinace kombo)
        {
            foreach (Kombinace k in kombinaceList)
            {
                if(k.Equals(kombo))
                {
                    kombinaceList.Remove(k);
                    return;
                }
            }
        }

        public void DeleteStrelna(Strelna kombo)
        {
            foreach (Strelna k in strelneList)
            {
                if (k.Equals(kombo))
                {
                    strelneList.Remove(k);
                    return;
                }
            }
        }
    }
}
