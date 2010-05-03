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
    public partial class UpravaPostavyDialog2 : Form
    {
        private String jmeno, rasa, pohlavi, povolani;
        private int[] vlastnosti;
        private int[] konstituce;
        private int vyjimecnost;
        private databaseDataSet database;

        private int[] body = new int[3];
        private int[] max = new int[3];
        private int[] pmax = new int[3];
        private int[] zbyva = new int[3];

        private int maxBodu;
        private int boduLeft;

        private String[] puvody = new String[9];
        private int[] majetky = new int[9];
        private short[][] dovednosti = new short[9][];

        private String druzina;

        public UpravaPostavyDialog2(String jmeno, String rasa, String pohlavi, String povolani,
                int[] vlastnosti, int vyj, int[] konstituce, String druzina)
        {
            InitializeComponent();

            this.database = Program.getDB();
            this.druzina = druzina;

            this.jmeno = jmeno;
            this.rasa = rasa;
            this.pohlavi = pohlavi;
            this.povolani = povolani;

            this.vlastnosti = vlastnosti;

            this.vyjimecnost = vyj;

            this.konstituce = konstituce;

            maxBodu = vyjimecnost * 5;
            boduLeft = maxBodu;
            body[0] = 0;
            body[1] = 0;
            body[2] = 0;

            max[0] = (maxBodu + 3 > 8 ? 8 : maxBodu);
            max[1] = (maxBodu + 3 > 8 ? 8 : maxBodu + 3);
            max[2] = (maxBodu + 3 > 8 ? 8 : maxBodu + 3);
            pmax[0] = (maxBodu + 3 > 8 ? 8 : maxBodu);
            pmax[1] = (maxBodu + 3 > 8 ? 8 : maxBodu + 3);
            pmax[2] = (maxBodu + 3 > 8 ? 8 : maxBodu + 3);

            puvody[0] = "Nalezenec";
            puvody[1] = "Sirotek";
            puvody[2] = "Z neúplné rodiny";
            puvody[3] = "Z pochybné rodiny";
            puvody[4] = "Ze slušné rodiny";
            puvody[5] = "Z dobré rodiny";
            puvody[6] = "Z velmi dobré a vlivné rodiny";
            puvody[7] = "Šlechtic";
            puvody[8] = "Šlechtic z dobrého rodu";

            majetky[0] = 1;
            majetky[1] = 3;
            majetky[2] = 10;
            majetky[3] = 30;
            majetky[4] = 100;
            majetky[5] = 300;
            majetky[6] = 1000;
            majetky[7] = 3000;
            majetky[8] = 10000;
            
            DataRow row = database.povolani.Rows.Find(this.povolani);
            for (int i = 0; i < 9; i++)
            {
                dovednosti[i] = new short[3];
                dovednosti[i][0] = short.Parse(row.ItemArray[i * 3 + 5].ToString());
                dovednosti[i][1] = short.Parse(row.ItemArray[i * 3 + 6].ToString());
                dovednosti[i][2] = short.Parse(row.ItemArray[i * 3 + 7].ToString());
            }

            setZbyva();
            setLabels();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            if (sender.Equals(Controls.Find("PuvodPlus", true)[0]))
            {
                if(boduLeft > 0  && zbyva[0] > 0)
                {
                    boduLeft--;
                    body[0]++;
                }
            }
            else if (sender.Equals(Controls.Find("MajetekPlus", true)[0]))
            {
                if (boduLeft > 0 && zbyva[1] > 0 && body[1] < max[1])
                {
                    boduLeft--;
                    body[1]++;
                }
            }
            else if (sender.Equals(Controls.Find("DovednostiPlus", true)[0]))
            {
                if (boduLeft > 0 && zbyva[2] > 0 && body[2] < max[2])
                {
                    boduLeft--;
                    body[2]++;
                }
            }

            setZbyva();
            setLabels();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (sender.Equals(Controls.Find("PuvodMinus", true)[0]))
            {
                if (boduLeft < maxBodu && zbyva[0] < max[0])
                {
                    boduLeft++;
                    body[0]--;
                    if (body[1] > body[0] + 3)
                    {
                        body[1] = body[0] + 3;
                        boduLeft++;
                    }
                    if (body[2] > body[0] + 3)
                    {
                        body[2] = body[0] + 3;
                        boduLeft++;
                    }
                }
            }
            else if (sender.Equals(Controls.Find("MajetekMinus", true)[0]))
            {
                if (boduLeft < maxBodu && zbyva[1] <= max[1] && body[1] > 0)
                {
                    boduLeft++;
                    body[1]--;
                }
            }
            else if (sender.Equals(Controls.Find("DovednostiMinus", true)[0]))
            {
                if (boduLeft < maxBodu && zbyva[2] <= max[2] && body[2] > 0)
                {
                    boduLeft++;
                    body[2]--;
                }
            }

            setZbyva();
            setLabels();
        }

        private void setZbyva()
        {
            zbyva[0] = max[0] - body[0];
            zbyva[1] = body[0] + 3 - body[1];
            zbyva[2] = body[0] + 3 - body[2];
            if (zbyva[0] > 8)
            {
                zbyva[0] = 8;
            }
            if (zbyva[1] > 8)
            {
                zbyva[1] = 8;
            }
            if (zbyva[2] > 8)
            {
                zbyva[2] = 8;
            }
            if (zbyva[0] > boduLeft)
            {
                zbyva[0] = boduLeft;
            }
            if (zbyva[1] > boduLeft)
            {
                zbyva[1] = boduLeft;
            }
            if (zbyva[2] > boduLeft)
            {
                zbyva[2] = boduLeft;
            }

            max[1] = body[0] + 3;
            max[2] = body[0] + 3;
            if (max[1] > 8)
            {
                max[1] = 8;
            }
            if (max[1] < boduLeft)
                    max[1] = boduLeft;
            if (max[2] > 8)
            {
                max[2] = 8;
            }
            if (max[2] < boduLeft)
                    max[2] = boduLeft;

            //zbyva[1] = max[1] - body[1];
            //zbyva[2] = max[2] - body[2];

            zPuvodL.Text = (zbyva[0]).ToString();
            zMajetekL.Text = (zbyva[1]).ToString();
            zDovednostiL.Text = (zbyva[2]).ToString();
        }

        private void setLabels()
        {
            switch (vyjimecnost)
            {
                case 1:
                    vyjimecnostL.Text = "Výjimečné vlastnosti";
                    break;
                case 2:
                    vyjimecnostL.Text = "Kombinace vlastností a zázemí";
                    break;
                case 3:
                    vyjimecnostL.Text = "Dobré zázemí";
                    break;
            }
            boduZazemiL.Text = boduLeft.ToString();

            PuvodBody.Text = body[0].ToString();
            MajetekBody.Text = body[1].ToString();
            DovednostiBody.Text = body[2].ToString();

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";

            puvodL.Text = puvody[body[0]];
            majetekL.Text = majetky[body[1]].ToString() + " zlatých";
            fyzL.Text = dovednosti[body[2]][0].ToString();
            psyL.Text = dovednosti[body[2]][1].ToString();
            kombL.Text = dovednosti[body[2]][2].ToString();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void createB_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Postava pos = new Postava();
            pos.jmeno = jmeno;
            pos.povolani = povolani;
            pos.zena = (pohlavi == "Žena" ? true : false);
            pos.rasa = rasa;
            pos.setUroven(1);
            pos.setZkusenosti(0);
            pos.setZakladniVlastnosti(vlastnosti);
            pos.setVlastnost("Vel", konstituce[0]);
            pos.setVlastnost("Hmp", konstituce[1]);
            pos.setVlastnost("Výška", konstituce[2]);
            pos.penize = majetky[body[1]];
            pos.Calculate();

            this.Hide();
            UpravaPostavyDialog3 uprava = new UpravaPostavyDialog3(pos, druzina, dovednosti[body[2]][0], dovednosti[body[2]][1], dovednosti[body[2]][2]);
            DialogResult dres;
            if ((dres = uprava.ShowDialog(Program.getMainForm())) == DialogResult.Retry)
            {
                this.Show();
                Cursor = Cursors.Default;
                return;
            }
            else if (dres == DialogResult.Cancel)
            {
                this.Close();
            }
            Cursor = Cursors.Default;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
