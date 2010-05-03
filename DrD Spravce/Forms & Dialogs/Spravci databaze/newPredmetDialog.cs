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
    public partial class newPredmetDialog : Form
    {
        public String jmeno;
        public String edit = "";
        public String kategorie;

        public newPredmetDialog()
        {
            InitializeComponent();
            this.Text = "Nový předmět";
        }

        public newPredmetDialog(String name)
        {
            InitializeComponent();

            this.Text = "Úprava předmětu";

            databaseDataSet.predmetyRow row = Program.getDB().predmety.FindByjmeno(name);

            edit = jmeno = name;

            jmenoL.Text = jmeno;
            vahaL.Value = (decimal)row.vaha;
            cenaL.Value = (decimal)row.cena;
            kategorieList.Text = row.kategorie;
        }

        private void newPredmetDialog_Load(object sender, EventArgs e)
        {
            OrderedEnumerableRowCollection<databaseDataSet.predmetyRow> en = Program.getDB().predmety.OrderBy(row => row.kategorie);

            String s = en.ElementAt(0).kategorie;
            foreach (databaseDataSet.predmetyRow row in en)
            {
                if (s != row.kategorie)
                {
                    kategorieList.Items.Add(row.kategorie);
                    s = row.kategorie;
                }
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (jmenoL.Text.Trim() == "")
            {
                MessageBox.Show("Zadejte název předmětu.", "Název předmětu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoL.Focus();
                return;
            }
            jmeno = jmenoL.Text;
            kategorie = kategorieList.Text;

            databaseDataSet db = Program.getDB();
            databaseDataSet.predmetyRow row = db.predmety.NewpredmetyRow();
            if (edit != "")
            {
                row = db.predmety.FindByjmeno(edit);
            }

            row.jmeno = jmeno;
            row.vaha = (double)vahaL.Value;
            row.cena = (double)cenaL.Value;
            row.kategorie = kategorieList.Text;

            if (edit == "")
            {
                try
                {
                    db.predmety.AddpredmetyRow(row);
                }
                catch
                {
                    MessageBox.Show("Předmět s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Předmět již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jmenoL.Focus();
                    jmenoL.SelectAll();
                    return;
                }
            }
            //predmetyTableAdapter.Update(db);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
