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
    public partial class UpravaPostavyDialog : Form
    {
        private Main parent;
        //opravy za pohlavi
        private int[] opravyPohlavi = new int[6];
        //vlastnosti
        private int[] vlastnosti = new int[6];
        //zbyvajici zmeny
        private int[] zbyva = new int[6];
        //minima/maxima jednotlivych vlastnosti
        private int[] min = new int[6];
        private int[] max = new int[6];
        //minima/maxima puvodnich vlastnosti
        private int[] pmin = new int[6];
        private int[] pmax = new int[6];
        //nazvy (zratky) vlastnosti
        private String[] nazvy = new String[6];

        private bool nahazeno = false;

        //nadpisy vlastnosti
        private Label[] captionL = new Label[6];
        //stupen vlastnosti
        private Label[] vlastnostL = new Label[6];
        //zbyva navyseni (max. 3 na zacatek)
        private Label[] zbyvaL = new Label[6];

        String vlast1;
        String vlast2;

        private int vyjimecnost;

        private int[] konstituce = new int[3];
        private int[] pKonstituce = new int[3];

        databaseDataSet database;
        private String druzina;

        public UpravaPostavyDialog(Main nparent, String njmeno, String nrasa, String npohlavi, String npovolani, String druzina)
        {
            InitializeComponent();
            parent = nparent;
            this.database = Program.getDB();

            this.druzina = druzina;

            //pridani controls do array
            captionL[0] = (Label)this.Controls.Find("SilL", true)[0];
            captionL[1] = (Label)this.Controls.Find("ObrL", true)[0];
            captionL[2] = (Label)this.Controls.Find("ZrcL", true)[0];
            captionL[3] = (Label)this.Controls.Find("VolL", true)[0];
            captionL[4] = (Label)this.Controls.Find("IntL", true)[0];
            captionL[5] = (Label)this.Controls.Find("ChrL", true)[0];
            vlastnostL[0] = (Label)this.Controls.Find("Sil", true)[0];
            vlastnostL[1] = (Label)this.Controls.Find("Obr", true)[0];
            vlastnostL[2] = (Label)this.Controls.Find("Zrc", true)[0];
            vlastnostL[3] = (Label)this.Controls.Find("Vol", true)[0];
            vlastnostL[4] = (Label)this.Controls.Find("Int", true)[0];
            vlastnostL[5] = (Label)this.Controls.Find("Chr", true)[0];
            zbyvaL[0] = (Label)this.Controls.Find("zSilL", true)[0];
            zbyvaL[1] = (Label)this.Controls.Find("zObrL", true)[0];
            zbyvaL[2] = (Label)this.Controls.Find("zZrcL", true)[0];
            zbyvaL[3] = (Label)this.Controls.Find("zVolL", true)[0];
            zbyvaL[4] = (Label)this.Controls.Find("zIntL", true)[0];
            zbyvaL[5] = (Label)this.Controls.Find("zChrL", true)[0];

            //kontrola "mužství", jinak opravy za pohlavi
            if (npohlavi == "Muž")
            {
                opravyPohlaviCh.Checked = false;
                opravyPohlaviCh.Enabled = false;
            }
            else
            {
                opravyPohlaviCh.Checked = true;
                opravyPohlaviCh.Enabled = true;
            }
            //inicializace
            jmenoPos.Text = njmeno;
            rasaPos.Text = nrasa;
            pohlaviPos.Text = npohlavi;
            povolaniPos.Text = npovolani;

            //konstituce postavy
            konstituce[0] = (int)Program.getRasyCell(nrasa, "vel");
            konstituce[1] = (int)Program.getRasyCell(nrasa, "hmt");
            konstituce[2] = (int)Program.getRasyCell(nrasa, "vyska");

            pKonstituce[0] = konstituce[0];
            pKonstituce[1] = konstituce[1];
            pKonstituce[2] = konstituce[2];

            vyskaN.Maximum = pKonstituce[2] + 15;
            vyskaN.Minimum = pKonstituce[2] - 15;
            vyskaN.Value = pKonstituce[2];

            //určení názvů (zkratek) vlastnosti
            nazvy[0] = "Sil";
            nazvy[1] = "Obr";
            nazvy[2] = "Zrč";
            nazvy[3] = "Vol";
            nazvy[4] = "Int";
            nazvy[5] = "Chr";

            // 3 body ke kazde vlastnosti
            for (int i = 0; i < 6; i++)
            {
                zbyva[i] = 3;
            }
            //zakladni vlastnosti podle rasy
            for (int i = 0, j = 2; i < 6; i++, j++)
            {
                vlastnosti[i] = int.Parse(Program.getRasyCell(nrasa, j).ToString());
            }
            //oprava podle pohlavi
            if (npohlavi == "Žena")
            {
                for (int i = 0, j = 22; i < 6; i++, j++)
                {
                    vlastnosti[i] += opravyPohlavi[i] = int.Parse(Program.getRasyCell(nrasa, j).ToString());
                }
            }
            //hlavni vlastnosti podle povolani
            vlast1 = Program.getPovolaniCell(npovolani, "vlast1").ToString();
            vlast2 = Program.getPovolaniCell(npovolani, "vlast2").ToString();
            for (int i = 0; i < 6; i++)
            {
                if (vlast1 == nazvy[i])
                {
                    vlastnosti[i]++;
                    zbyva[i]--;
                    captionL[i].Font = new Font(captionL[i].Font, FontStyle.Bold);
                }
                if (vlast2 == nazvy[i])
                {
                    vlastnosti[i]++;
                    zbyva[i]--;
                    captionL[i].Font = new Font(captionL[i].Font, FontStyle.Bold);
                }

                // minima/maxima
                min[i] = vlastnosti[i];
                max[i] = zbyva[i] + vlastnosti[i];
                pmin[i] = vlastnosti[i];
                pmax[i] = zbyva[i] + vlastnosti[i];
            }

            hracR.Checked = true;
            nahodneB.Visible = false;
            kombinaceR.Checked = true;
            
            nahazeno = false;

            setVlastnosti();
        }

        private void opravyPohlaviCh_CheckedChanged(object sender, EventArgs e)
        {
            if (opravyPohlaviCh.Checked == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    vlastnosti[i] += opravyPohlavi[i];
                    min[i] += opravyPohlavi[i];
                    max[i] += opravyPohlavi[i];
                    pmin[i] += opravyPohlavi[i];
                    pmax[i] += opravyPohlavi[i];
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    vlastnosti[i] -= opravyPohlavi[i];
                    min[i] -= opravyPohlavi[i];
                    max[i] -= opravyPohlavi[i];
                    pmin[i] -= opravyPohlavi[i];
                    pmax[i] -= opravyPohlavi[i];
                }
            }

            setVlastnosti();
        }

        private void nahodaR_CheckedChanged(object sender, EventArgs e)
        {
            nahodneB.Visible = !nahodneB.Visible;
            nahazeno = false;
            for (int i = 0; i < 6; i++)
            {
                min[i] = pmin[i];
                max[i] = pmax[i];
                vlastnosti[i] = min[i];
            }
            vlivChanged(null, null);
            setVlastnosti();
        }

        private void hracR_CheckedChanged(object sender, EventArgs e)
        {
            tabulkaBoduP.Visible = hracR.Checked;
            for (int i = 0; i < 6; i++)
            {
                min[i] = pmin[i];
                max[i] = pmax[i];
                vlastnosti[i] = min[i];
            }
            vlivChanged(null, null);
            setVlastnosti();
        }

        private void setVlastnosti()
        {
            for (int i = 0; i < 6; i++)
            {
                vlastnostL[i].Text = Program.parseBonus(vlastnosti[i]);
                zbyvaL[i].Text = zbyva[i].ToString();
            }
            if (vlastnosti[0] == pmax[0])
            {
                konstituce[0] = pKonstituce[0] + 1 + (opravyPohlaviCh.Checked ? int.Parse(Program.getRasyCell(rasaPos.Text, "psil").ToString()) : 0);
            }
            else if (vlastnosti[0] == pmin[0])
            {
                konstituce[0] = pKonstituce[0] - 1 + (opravyPohlaviCh.Checked ? int.Parse(Program.getRasyCell(rasaPos.Text, "psil").ToString()) : 0);
            }
            else
            {
                konstituce[0] = pKonstituce[0] + (opravyPohlaviCh.Checked ? int.Parse(Program.getRasyCell(rasaPos.Text, "psil").ToString()) : 0);
            }
            konstituce[1] = pKonstituce[1] + (opravyPohlaviCh.Checked ? int.Parse(Program.getRasyCell(rasaPos.Text, "psil").ToString()) : 0);

            VelL.Text = Program.parseBonus(konstituce[0]);
            HmpL.Text = Program.parseBonus(konstituce[1]);
            VyskaL.Text = Program.parseBonus(konstituce[2]);
        }

        private void vlivChanged(object sender, EventArgs e)
        {
            //reinicializace rozsahu
            for (int i = 0; i < 6; i++)
            {
                min[i] = pmin[i];
                max[i] = pmax[i];
            }
            if (vlastnostiR.Checked == true)
            {
                bodyHlavL.Text = "3";
                bodyVedlL.Text = "6";
                bodyMaxVedlL.Text = "3";
                bodyHlavL.Tag = 3;
                bodyVedlL.Tag = 6;
                bodyMaxVedlL.Tag = 3;
                vyjimecnost = 1;
                for (int i = 0; i < 6; i++)
                {
                    vlastnosti[i] = min[i];
                    if (nazvy[i] == vlast1 || nazvy[i] == vlast2)
                    {
                        max[i] = min[i] + 2;
                    }
                    else
                    {
                        max[i] = min[i] + 3;
                    }
                }
            }
            else if (kombinaceR.Checked == true)
            {
                bodyHlavL.Text = "2";
                bodyVedlL.Text = "4";
                bodyMaxVedlL.Text = "2";
                bodyHlavL.Tag = 2;
                bodyVedlL.Tag = 4;
                bodyMaxVedlL.Tag = 2;
                vyjimecnost = 2;
                for (int i = 0; i < 6; i++)
                {
                    vlastnosti[i] = min[i];
                    if (nazvy[i] == vlast1 || nazvy[i] == vlast2)
                    {
                        max[i] = min[i] + 2;
                    }
                    else
                    {
                        max[i] = min[i] + 2;
                    }
                }
            }
            else if (zazemiR.Checked == true)
            {
                bodyHlavL.Text = "1";
                bodyVedlL.Text = "2";
                bodyMaxVedlL.Text = "1";
                bodyHlavL.Tag = 1;
                bodyVedlL.Tag = 2;
                bodyMaxVedlL.Tag = 1;
                vyjimecnost = 3;
                for (int i = 0; i < 6; i++)
                {
                    vlastnosti[i] = min[i];
                    if (nazvy[i] == vlast1 || nazvy[i] == vlast2)
                    {
                        max[i] = min[i] + 1;
                    }
                    else
                    {
                        max[i] = min[i] + 1;
                    }
                }
            }
            if (nahodaR.Checked == true)
            {
                nahodneB_Click(null, null);
            }
            setZbyva();
            setVlastnosti();
        }
        private void plus_Clicked(object sender, EventArgs e)
        {
            String vl = ((String)((Button)sender).Tag);
            bool hlav = false;
            if (vl == vlast1 || vl == vlast2)
            {
                hlav = true;
            }
            for (int i = 0; i < 6; i++)
            {
                if (nazvy[i] == vl)
                {
                    if (hlav == true)
                    {
                        if (vlastnosti[i] + 1 <= max[i] && int.Parse(bodyHlavL.Text) - 1 >= 0)
                        {
                            vlastnosti[i]++;
                            bodyHlavL.Text = (int.Parse(bodyHlavL.Text) - 1).ToString();
                        }
                    }
                    else
                    {
                        if (vlastnosti[i] + 1 <= max[i] && int.Parse(bodyVedlL.Text) - 1 >= 0)
                        {
                            vlastnosti[i]++;
                            bodyVedlL.Text = (int.Parse(bodyVedlL.Text) - 1).ToString();
                        }
                    }
                    break;
                }
            }
            setZbyva();
            setVlastnosti();
        }
        private void minus_Clicked(object sender, EventArgs e)
        {
            String vl = ((String)((Button)sender).Tag);
            bool hlav = false;
            if (vl == vlast1 || vl == vlast2)
            {
                hlav = true;
            }
            for (int i = 0; i < 6; i++)
            {
                if (nazvy[i] == vl)
                {
                    if (hlav == true)
                    {
                        if (vlastnosti[i] - 1 >= min[i] && int.Parse(bodyHlavL.Text) + 1 <= ((int)bodyHlavL.Tag))
                        {
                            vlastnosti[i]--;
                            bodyHlavL.Text = (int.Parse(bodyHlavL.Text) + 1).ToString();
                        }
                    }
                    else
                    {
                        if (vlastnosti[i] - 1 >= min[i] && int.Parse(bodyVedlL.Text) + 1 <= ((int)bodyVedlL.Tag))
                        {
                            vlastnosti[i]--;
                            bodyVedlL.Text = (int.Parse(bodyVedlL.Text) + 1).ToString();
                        }
                    }
                    break;
                }
            }
            setZbyva();
            setVlastnosti();
        }

        private void setZbyva()
        {
            for (int i = 0; i < 6; i++)
            {
                if (nazvy[i] == vlast1 || nazvy[i] == vlast2)
                {
                    if (max[i] - vlastnosti[i] < int.Parse(bodyHlavL.Text))
                    {
                        zbyva[i] = max[i] - vlastnosti[i];
                    }
                    else
                    {
                        zbyva[i] = int.Parse(bodyHlavL.Text);
                        if (max[i] == vlastnosti[i])
                        {
                            zbyva[i] = 0;
                        }
                    }
                }
                else
                {
                    if (max[i] - vlastnosti[i] < int.Parse(bodyVedlL.Text))
                    {
                        zbyva[i] = max[i] - vlastnosti[i];
                    }
                    else
                    {
                        zbyva[i] = int.Parse(bodyVedlL.Text);
                    }
                }
            }
        }

        private void nahodneB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                vlastnosti[i] = min[i];
            }
            Random rand = new Random();
            if(vlastnostiR.Checked == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (vlastnostL[i].Name == vlast1 || vlastnostL[i].Name == vlast2)
                    {
                        int r = rand.Next(1, 7);
                        switch (r)
                        {
                            case 1:
                            case 2:
                            case 3:
                                r = 1;
                                break;
                            case 4:
                            case 5:
                            case 6:
                                r = 2;
                                break;
                        }
                        for (int j = 1; j <= r; j++)
                        {
                            if (vlastnosti[i] + 1 <= max[i])
                            {
                                vlastnosti[i]++;
                            }
                        }
                    }
                    else
                    {
                        int r = rand.Next(1, 7);
                        switch (r)
                        {
                            case 1:
                                r = 0;
                                break;
                            case 2:
                            case 3:
                                r = 1;
                                break;
                            case 4:
                            case 5:
                                r = 2;
                                break;
                            case 6:
                                r = 3;
                                break;
                        }
                        for (int j = 1; j <= r; j++)
                        {
                            if (vlastnosti[i] + 1 <= max[i])
                            {
                                vlastnosti[i]++;
                            }
                        }
                    }
                }
            }
            else if (kombinaceR.Checked == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    int r = rand.Next(1, 7);
                    switch (r)
                    {
                        case 1:
                        case 2:
                            r = 0;
                            break;
                        case 4:
                        case 5:
                            r = 1;
                            break;
                        case 3:
                        case 6:
                            r = 2;
                            break;
                    }
                    for(int j=1; j <= r; j++)
                    {
                        if (vlastnosti[i] + 1 <= max[i])
                        {
                            vlastnosti[i]++;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    int r = rand.Next(1, 7);
                    switch (r)
                    {
                        case 1:
                        case 2:
                        case 4:
                            r = 0;
                            break;
                        case 5:
                        case 3:
                        case 6:
                            r = 1;
                            break;
                    }
                    for (int j = 1; j <= r; j++)
                    {
                        if (vlastnosti[i] + 1 <= max[i])
                        {
                            vlastnosti[i]++;
                        }
                    }
                }
            }
            nahazeno = true;
            setVlastnosti();
        }

        private void vyskaL_ValueChanged(object sender, EventArgs e)
        {
            double metru1 = 180;
            double metru2 = 180;
            int bonus1 = 5;
            int bonus2 = 5;
            int i = 0;
            foreach (databaseDataSet.tabVzdalenostiRow row in Program.getDB().tabVzdalenosti.Rows)
            {
                if (row.metru * 100 <= (double)vyskaN.Value && i != 1)
                {
                    metru1 = row.metru * 100;
                    bonus1 = row.bonus;
                }
                if (row.metru * 100 > (double)vyskaN.Value && i != 1)
                {
                    metru2 = row.metru * 100;
                    bonus2 = row.bonus;
                    break;
                }
            }
            double rozdil1 = (double)vyskaN.Value - metru1;
            double rozdil2 = metru2 - (double)vyskaN.Value;

            int bonus;
            if (rozdil1 < rozdil2)
            {
                bonus = bonus1;
            }
            else
            {
                bonus = bonus2;
            }
            konstituce[2] = bonus;
            setVlastnosti();
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if ((hracR.Checked == true && bodyHlavL.Text == "0" && bodyVedlL.Text == "0") 
                    || (nahodaR.Checked == true && nahazeno == true))
            {
                this.Hide();
                Cursor = Cursors.WaitCursor;
                UpravaPostavyDialog2 uprava = new UpravaPostavyDialog2(jmenoPos.Text, rasaPos.Text, pohlaviPos.Text, povolaniPos.Text, vlastnosti, vyjimecnost, konstituce, druzina);
                DialogResult dres;
                if ((dres = uprava.ShowDialog(Program.getMainForm())) == DialogResult.Retry)
                {
                    this.Show();
                }
                else if (dres == DialogResult.Cancel)
                {
                    this.Close();
                }
                Cursor = Cursors.Default;
            }
            else
            {
                if (hracR.Checked == true)
                {
                    MessageBox.Show("Ještě máte zbývající body, které musíte \npřiřadit k základním vlastnostem", "Zbývají úpravy vlastností", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Musíte nechat náhodně upravit vlastnosti.\nStiskněte tlačítko \"Hodit kostkami\" nebo si vyberte\nmožnost \"Rozhodnutí hráče\" pro určení úprav vámi samotnými.", "Žádné náhodné úpravy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
