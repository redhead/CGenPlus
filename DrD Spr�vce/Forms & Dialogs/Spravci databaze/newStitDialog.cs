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
    public partial class newStitDialog : Form
    {
        public String jmeno;
        public String edit = "";

        public newStitDialog()
        {
            InitializeComponent();

            this.Text = "Nový štít";
            typList.SelectedIndex = 0;
        }

        public newStitDialog(String name)
        {
            InitializeComponent();

            this.Text = "Úprava štítu";

            databaseDataSet.stityRow row = Program.getDB().stity.FindByjmeno(name);

            edit = jmeno = name;

            jmenoL.Text = jmeno;
            if (row.IspsilaNull() != true)
            {
                pSilaN.Value = (decimal)row.psila;
            }
            else
            {
                checkBox1.Checked = true;
            }
            omezeniN.Value = (decimal)row.omezeni;
            utocnostN.Value = (decimal)row.utocnost;
            zraneniN.Value = (decimal)row.zraneni;
            typList.SelectedIndex = typList.Items.IndexOf(row.typ);
            krytN.Value = (decimal)row.kryt;
            vahaN.Value = (decimal)row.vaha;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pSilaN.Enabled = !checkBox1.Checked;
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            if (jmenoL.Text.Trim() == "")
            {
                MessageBox.Show("Zadejte název předmětu.", "Název předmětu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoL.Focus();
                return;
            }
            jmeno = jmenoL.Text;

            databaseDataSet db = Program.getDB();
            databaseDataSet.stityRow row = db.stity.NewstityRow();
            if (edit != "")
            {
                row = db.stity.FindByjmeno(edit);
            }

            row.jmeno = jmeno;
            if (checkBox1.Checked != true)
            {
                row.psila = (short)pSilaN.Value;
            }
            else
            {
                row.SetpsilaNull();
            }
            row.omezeni = (short)omezeniN.Value;
            row.utocnost = (short)utocnostN.Value;
            row.zraneni = (short)zraneniN.Value;
            row.typ = typList.Text;
            row.kryt = (short)krytN.Value;
            row.vaha = (double)vahaN.Value;

            if (edit == "")
            {
                try
                {
                    db.stity.AddstityRow(row);
                }
                catch
                {
                    MessageBox.Show("Štít s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Štít již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    jmenoL.Focus();
                    jmenoL.SelectAll();
                    return;
                }
            }
            //stityTableAdapter.Update(db);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
