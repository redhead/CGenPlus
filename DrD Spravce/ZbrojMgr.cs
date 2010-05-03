using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class ZbrojMgr
    {
        public String zJmeno;
        public String pJmeno;

        public int zOchrana;
        public int pOchrana;

        private int zOmezeni;
        private int pOmezeni;

        private int pSila;
        private int zSila;

        public float zVaha;
        public float pVaha;

        private Postava postava;

        public ZbrojMgr(Postava pos)
        {
            zJmeno = "Beze zbroje";
            pJmeno = "Bez pokrývky hlavy";

            zVaha = 0;
            pVaha = 0;

            postava = pos;
        }

        public void vybratZbrojB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vyberZbroje dialog = new vyberZbroje(postava, zJmeno, pJmeno);
            Main form = Program.getMainForm();
            if (dialog.ShowDialog(form) == DialogResult.OK)
            {
                zJmeno = dialog.zJmenoL.Text;
                pJmeno = dialog.pJmenoL.Text;

                zOmezeni = dialog.zomezeni;
                pOmezeni = dialog.pomezeni;

                zOchrana = int.Parse(dialog.zOchranaL.Text);
                pOchrana = int.Parse(dialog.pOchranaL.Text);

                pSila = dialog.zsila;
                zSila = dialog.psila;

                zVaha = dialog.zvaha;
                pVaha = dialog.pvaha;

                Calculate();
                Program.getMainForm().setNew(postava);
            }
        }

        public void Load(String zbroj, String prilba)
        {
            databaseDataSet db = Program.getDB();
            databaseDataSet.zbrojeRow row = db.zbroje.FindByjmeno(zbroj);
            if (row != null)
            {
                zJmeno = row.jmeno;
                zOmezeni = row.omezeni;
                zOchrana = row.ochrana;
                zSila = row.IspsilaNull() ? 0 : row.psila;
                zVaha = (float)row.vaha;
            }
            else
            {
                MessageBox.Show("Chyba: " + zbroj + " v databázi neexistuje!\nChyba nastala u postavy " + postava.jmeno, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            databaseDataSet.prilbyRow row2 = db.prilby.FindByjmeno(prilba);
            if (row != null)
            {
                pJmeno = row2.jmeno;
                pOmezeni = row2.omezeni;
                pOchrana = row2.ochrana;
                pSila = row2.IspsilaNull() ? 0 : row2.psila;
                pVaha = (float)row2.vaha;
            }
            else
            {
                MessageBox.Show("Chyba: " + prilba + " v databázi neexistuje!\nChyba nastala u postavy " + postava.jmeno, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Calculate();
        }

        public void Calculate()
        {
            Main form = Program.getMainForm();
            int chybi;
            int opravaObr = 0;

            int oprZ = 0;
            int oprP = 0;
            if (zSila != -99)
            {
                chybi = zSila - postava.getVlastnost("Sil") + (Program.getSettings().useCharacterSize ? postava.getVlastnostO("Vel") : 0);
                
                if (chybi <= 0)
                {
                    oprZ = 0;
                }
                else if (chybi > 0 && chybi <= 3)
                {
                    oprZ = -2;
                }
                else if (chybi <= 6)
                {
                    oprZ = -4;
                }
                else if (chybi <= 8)
                {
                    oprZ = -8;
                }
                else if (chybi <= 10)
                {
                    oprZ = -12;
                }
                else if (chybi > 10)
                {
                    oprZ = -99;
                    MessageBox.Show("Postava má příliš těžkou zbroj. Nemůže se hýbat.");
                }
            }
            if (pSila != -99)
            {
                chybi = pSila - postava.getVlastnost("Sil") + (Program.getSettings().useCharacterSize ? postava.getVlastnostO("Vel") : 0);

                if (chybi <= 0)
                {
                    oprP = 0;
                }
                else if (chybi > 0 && chybi <= 3)
                {
                    oprP = -2;
                }
                else if (chybi <= 6)
                {
                    oprP = -4;
                }
                else if (chybi <= 8)
                {
                    oprP = -8;
                }
                else if (chybi <= 10)
                {
                    oprP = -12;
                }
                else if (chybi > 10)
                {
                    oprP = -99;
                    MessageBox.Show("Postava má příliš těžkou přilbu. Nemůže se hýbat.");
                }
            }

            opravaObr = oprZ + oprP;

            int omezeni = zOmezeni + pOmezeni;

            int dovednost = postava.dovednostiMgr.getDovednost("Nošení zbroje");
            if (dovednost > 0)
            {
                if (omezeni + dovednost <= 0)
                {
                    omezeni += (dovednost <= 3 ? dovednost : 3);
                }
                else
                {
                    omezeni = 0;
                }
            }

            postava.setOprava("Obr", "za zbroj", opravaObr);
            postava.setOprava("Boj", "za zbroj", omezeni);
        }
    }
}
