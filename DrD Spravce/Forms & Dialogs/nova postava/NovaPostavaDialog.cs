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
    public partial class NovaPostavaDialog : Form
    {
        private Main parent;
        private String druzina;

        public NovaPostavaDialog(Main form, String druzina)
        {
            InitializeComponent();
            parent = form;
            this.druzina = druzina;
        }
        
        private void NovaPostava_Load(object sender, EventArgs e)
        {
            pohlavi.SelectedIndex = 0;
            databaseDataSet db = Program.getDB();
            foreach (databaseDataSet.rasyRow row in db.rasy)
            {
                rasa.Items.Add(row.jmeno);
            }
            foreach (databaseDataSet.povolaniRow row in db.povolani)
            {
                povolani.Items.Add(row.jmeno);
            }
            rasa.SelectedIndex = 0;
            povolani.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jmenoPostavy.Text.Length > 0)
            {
                this.Hide();
                Cursor = Cursors.WaitCursor;
                UpravaPostavyDialog uprava = new UpravaPostavyDialog(parent, jmenoPostavy.Text, rasa.Text, pohlavi.Text, povolani.Text, druzina);
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
            } else {
                MessageBox.Show("Musíte vyplnit jméno", "Prázdné pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
