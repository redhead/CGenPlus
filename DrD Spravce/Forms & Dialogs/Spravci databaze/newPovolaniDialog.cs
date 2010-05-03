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
    public partial class newPovolaniDialog : Form
    {
        NumericUpDown[] bodyDovednosti = new NumericUpDown[27];
        public String edit = "";
        public String jmeno;

        public newPovolaniDialog()
        {
            InitializeComponent();

            for (int i = 0; i < bodyDovednosti.Length; i++)
            {
                bodyDovednosti[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 1).ToString(), true)[0];
            }
            vlast1L.SelectedIndex = 0;
            vlast2L.SelectedIndex = 1;
        }

        public newPovolaniDialog(String name)
        {
            InitializeComponent();
            
            for (int i = 0; i < bodyDovednosti.Length; i++)
            {
                bodyDovednosti[i] = (NumericUpDown)this.Controls.Find("NumericUpDown" + (i + 1).ToString(), true)[0];
            }

            databaseDataSet db = Program.getDB();
            databaseDataSet.povolaniRow row = db.povolani.FindByjmeno(name);

            edit = jmeno = name;

            jmenoL.Text = edit;
            popisL.Text = row.IsNull("popis") ? "" : row.popis;
            vlast1L.SelectedIndex = getVlastnostIndex(row.vlast1);
            vlast2L.SelectedIndex = getVlastnostIndex(row.vlast2);
            oBojL.Text = row.oboj;

            for (int i = 0; i < bodyDovednosti.Length; i++)
            {
                bodyDovednosti[i].Value = (decimal)int.Parse(row[i + 5].ToString());
            }
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
            if(vlast1L.Text == vlast2L.Text)
            {
                MessageBox.Show("Hlavní vlastnosti povolání nesmí být stejné", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vlast2L.Focus();
                ok = false;
            }
            if (oBojL.Text == "")
            {
                MessageBox.Show("Pole Určení Boje nesmí být prázdné.\nNápovědu k výrazu zobrazíte, kliknutím na tlačítko vykřičníku vedle pole.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                oBojL.Focus();
                ok = false;
            }
            if (ok == true)
            {
                databaseDataSet db = Program.getDB();
                //databaseDataSetTableAdapters.povolaniTableAdapter povolaniTableAdapter = new databaseDataSetTableAdapters.povolaniTableAdapter();

                databaseDataSet.povolaniRow row = db.povolani.NewpovolaniRow();
                if (edit != "")
                {
                    row = db.povolani.FindByjmeno(edit);
                }
                row.jmeno = jmeno = jmenoL.Text;
                row.popis = popisL.Text;
                row.vlast1 = getVlastnost(vlast1L.Text);
                row.vlast2 = getVlastnost(vlast2L.Text);
                row.oboj = oBojL.Text;
                row.b0_fyz = (short)bodyDovednosti[0].Value;
                row.b0_psy = (short)bodyDovednosti[1].Value;
                row.b0_kom = (short)bodyDovednosti[2].Value;
                row.b1_fyz = (short)bodyDovednosti[3].Value;
                row.b1_psy = (short)bodyDovednosti[4].Value;
                row.b1_kom = (short)bodyDovednosti[5].Value;
                row.b2_fyz = (short)bodyDovednosti[6].Value;
                row.b2_psy = (short)bodyDovednosti[7].Value;
                row.b2_kom = (short)bodyDovednosti[8].Value;
                row.b3_fyz = (short)bodyDovednosti[9].Value;
                row.b3_psy = (short)bodyDovednosti[10].Value;
                row.b3_kom = (short)bodyDovednosti[11].Value;
                row.b4_fyz = (short)bodyDovednosti[12].Value;
                row.b4_psy = (short)bodyDovednosti[13].Value;
                row.b4_kom = (short)bodyDovednosti[14].Value;
                row.b5_fyz = (short)bodyDovednosti[15].Value;
                row.b5_psy = (short)bodyDovednosti[16].Value;
                row.b5_kom = (short)bodyDovednosti[17].Value;
                row.b6_fyz = (short)bodyDovednosti[18].Value;
                row.b6_psy = (short)bodyDovednosti[19].Value;
                row.b6_kom = (short)bodyDovednosti[20].Value;
                row.b7_fyz = (short)bodyDovednosti[21].Value;
                row.b7_psy = (short)bodyDovednosti[22].Value;
                row.b7_kom = (short)bodyDovednosti[23].Value;
                row.b8_fyz = (short)bodyDovednosti[24].Value;
                row.b8_psy = (short)bodyDovednosti[25].Value;
                row.b8_kom = (short)bodyDovednosti[26].Value;

                if (edit == "")
                {
                    try
                    {
                        db.povolani.AddpovolaniRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Povolání s názvem " + jmeno + " již existuje. Zadejte jiný název.", "Povolání již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        jmenoL.Focus();
                        jmenoL.SelectAll();
                        return;
                    }
                }
                //povolaniTableAdapter.Update(db);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pozor! Pole Určení Boje musí obsahovat matematické operátory\n(+ plus, - minus, * krát, / děleno) s operandy jako vlastnosti\n(Sil, Obr, Zrč, ...) nebo celá čísla bez mezer a jiných znaků, kromě kulatých závorek.\n\nNepovinná možnost zaokrouhlení čísla po dělení dolů (přidáním ':d' na konec výrazu) nebo nahoru (přidáním ':n' na konec výrazu). \n\nSprávně: '(Sil+Zrč)/2'  'Obr'  'Obr/2:n'\nŠpatně: 'sil + obr:2'  'Obr  +  5'  'Obr/2 :n'", "Informace o výrazu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private String getVlastnost(String vlast)
        {
            switch (vlast)
            {
                case "Síla": return "Sil";
                case "Obratnost": return "Obr";
                case "Zručnost": return "Zrč";
                case "Vůle": return "Vol";
                case "Inteligence": return "Int";
                case "Charisma": return "Chr";
                default: return "Sil";
            }
        }
        private int getVlastnostIndex(String vlast)
        {
            switch (vlast)
            {
                case "Sil": return 0;
                case "Obr": return 1;
                case "Zrč": return 2;
                case "Vol": return 3;
                case "Int": return 4;
                case "Chr": return 5;
                default: return 0;
            }
        }
    }
}
