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
    public partial class newRasyDialog : Form
    {
        NumericUpDown[] vlastnosti = new NumericUpDown[6];
        NumericUpDown[] opravy = new NumericUpDown[6];

        public String edit = "";
        public String jmeno;
        private String Smysl = "-";

        private bool neoblibeny;

        public newRasyDialog()
        {
            InitializeComponent();

            for (int i = 0; i < 6; i++)
            {
                vlastnosti[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 1).ToString(), true)[0];
            }
            for (int i = 0; i < 6; i++)
            {
                opravy[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 7).ToString(), true)[0];
            }
        }

        public newRasyDialog(String name)
        {
            InitializeComponent();

            for (int i = 0; i < 6; i++)
            {
                vlastnosti[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 1).ToString(), true)[0];
            }
            for (int i = 0; i < 6; i++)
            {
                opravy[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 7).ToString(), true)[0];
            }

            databaseDataSet db = Program.getDB();
            databaseDataSet.rasyRow row = db.rasy.FindByjmeno(name);

            neoblibeny = false;
            if(name.IndexOf(" (*)") != -1)
            {
                jmeno = name.Replace(" (*)", "");
                edit = name;
                neoblibeny = true;
            }
            else
            {
                edit = jmeno = name;
            }

            jmenoL.Text = jmeno;
            popisL.Text = row.IsNull("popis") ? "" : row.popis;

            VelN.Value = (decimal)row.vel;
            HmpN.Value = (decimal)row.hmt;
            vyskaN.Value = (decimal)row.vyska;

            for (int i = 0; i < 6; i++)
            {
                vlastnosti[i].Value = (decimal)int.Parse(row[i + 2].ToString());
            }
            for (int i = 0; i < 6; i++)
            {
                opravy[i].Value = (decimal)int.Parse(row[i + 22].ToString());
            }
            oblibenostCh.Checked = neoblibeny == true ? true : false;

            oOdlN.Value = row.IsoodlNull() == true ? 0 : (decimal)int.Parse(row.oodl);
            oVdrN.Value = row.IsovdrNull() == true ? 0 : (decimal)int.Parse(row.ovdr);
            oSmsN.Value = row.IsosmsNull() == true ? 0 : (decimal)int.Parse(row.osms);

            if (row.smysl == "-")
            {
                radioButton1.Checked = true;
            }
            else
            {
                for (int i = 2; i < 7; i++)
                {
                    RadioButton rad;
                    if ((rad = (RadioButton)this.Controls.Find("radioButton" + (i).ToString(), true)[0]).Text == row.smysl)
                    {
                        rad.Checked = true;
                        break;
                    }
                    else
                    {
                        radioButton7.Checked = true;
                        smyslL.Text = row.smysl;
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            smyslL.Enabled = radioButton7.Checked;

            for (int i = 0; i < 7; i++)
            {
                RadioButton rad = (RadioButton)this.Controls.Find("radioButton" + (i + 1).ToString(), true)[0];
                if(rad.Checked == true)
                {
                    Smysl = rad.Text;
                    break;
                }
            }
            if (radioButton1.Checked == true)
            {
                Smysl = "-";
            }
            if (radioButton7.Checked == true)
            {
                Smysl = smyslL.Text;
            }
        }

        private void smyslL_TextChanged(object sender, EventArgs e)
        {
            Smysl = smyslL.Text;
        }

        private void helpB_Click(object sender, EventArgs e)
        {
            Program.vyrazHelp();
        }

        private void saveB_Click(object sender, EventArgs e)
        {

            bool ok = true;
            if (jmenoL.Text == "")
            {
                MessageBox.Show("Musíte vyplnit název povolání", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                jmenoL.Focus();
                ok = false;
            }
            if (radioButton7.Checked == true && smyslL.Text == "")
            {
                MessageBox.Show("Musíte zadat jiný význačný smysl, pokud není v nabídce.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                smyslL.Focus();
                ok = false;
            }
            if (ok == true)
            {
                databaseDataSet db = Program.getDB();
                //databaseDataSetTableAdapters.rasyTableAdapter rasyTableAdapter = new databaseDataSetTableAdapters.rasyTableAdapter();

                databaseDataSet.rasyRow row = db.rasy.NewrasyRow();
                if (edit != "")
                {
                    row = db.rasy.FindByjmeno(edit);
                }
                row.jmeno = jmeno = jmenoL.Text;
                if (oblibenostCh.Checked == true) row.jmeno = jmeno += " (*)";
                row.popis = popisL.Text;

                row.sil = (short)vlastnosti[0].Value;
                row.obr = (short)vlastnosti[1].Value;
                row.zrc = (short)vlastnosti[2].Value;
                row.vol = (short)vlastnosti[3].Value;
                row._int = (short)vlastnosti[4].Value;
                row.chr = (short)vlastnosti[5].Value;
                
                row.psil = (short)opravy[0].Value;
                row.pobr = (short)opravy[1].Value;
                row.pzrc = (short)opravy[2].Value;
                row.pvol = (short)opravy[3].Value;
                row.pint = (short)opravy[4].Value;
                row.pchr = (short)opravy[5].Value;

                row.oodl = oOdlN.Value.ToString();
                row.ovdr = oVdrN.Value.ToString();
                row.osms = oSmsN.Value.ToString();

                row.vel = (int)VelN.Value;
                row.hmt = (int)HmpN.Value;
                row.vyska = (int)vyskaN.Value;

                row.smysl = Smysl;

                if (edit == "")
                {
                    try
                    {
                        db.rasy.AddrasyRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Rasa s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Rasa již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        jmenoL.Focus();
                        jmenoL.SelectAll();
                        return;
                    }
                }
                //rasyTableAdapter.Update(db);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
