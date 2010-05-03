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
    public partial class newDovednostDialog : Form
    {
        public String jmeno;
        public String edit = "";
        public String typ;

        public newDovednostDialog()
        {
            InitializeComponent();
            this.Text = "Nová dovednost";
            fillUp();
        }

        public newDovednostDialog(String name)
        {
            InitializeComponent();
            fillUp();

            this.Text = "Úprava dovednosti";

            databaseDataSet.dovednostiRow row = Program.getDB().dovednosti.FindByjmeno(name);

            edit = jmeno = name;

            jmenoL.Text = jmeno;
            if (row.typ == "fyz")
            {
                typList.SelectedIndex = 0;
            }
            else if (row.typ == "psy")
            {
                typList.SelectedIndex = 1;
            }
            else
            {
                typList.SelectedIndex = 2;
            }
            popisT.Text = row.IspopisNull() ? "" : row.popis;
            popis1T.Text = row.Ispopis1Null() ? "" : row.popis1;
            popis2T.Text = row.Ispopis2Null() ? "" : row.popis2;
            popis3T.Text = row.Ispopis3Null() ? "" : row.popis3;
        }

        private void fillUp()
        {
            typList.Items.Add("Fyzická");
            typList.Items.Add("Psychická");
            typList.Items.Add("Kombinovaná");

            typList.SelectedIndex = 0;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (jmenoL.Text.Trim() == "")
            {
                MessageBox.Show("Zadejte název dovednosti.", "Název dovednosti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoL.Focus();
                return;
            }
            jmeno = jmenoL.Text;
            typ = typList.Text;

            databaseDataSet db = Program.getDB();
            databaseDataSet.dovednostiRow row = db.dovednosti.NewdovednostiRow();
            if (edit != "")
            {
                row = db.dovednosti.FindByjmeno(edit);
            }

            row.jmeno = jmeno;
            switch (typList.Text)
            {
                case "Fyzická": row.typ = "fyz"; break;
                case "Psychická": row.typ = "psy"; break;
                case "Kombinovaná": row.typ = "komb"; break;
            }
            row.popis = popisT.Text;
            row.popis1 = popis1T.Text;
            row.popis2 = popis2T.Text;
            row.popis3 = popis3T.Text;

            if (edit == "")
            {
                try
                {
                    db.dovednosti.AdddovednostiRow(row);
                }
                catch
                {
                    MessageBox.Show("Dovednost s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Dovednost již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jmenoL.Focus();
                    jmenoL.SelectAll();
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
