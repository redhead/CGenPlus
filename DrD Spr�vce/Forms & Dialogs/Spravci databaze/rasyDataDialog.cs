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
    public partial class rasyDataDialog : Form
    {
        public rasyDataDialog()
        {
            InitializeComponent();

            foreach (databaseDataSet.rasyRow row in Program.getDB().rasy)
            {
                listBox.Items.Add(row.jmeno.ToString());
            }
        }

        private void rasyDataDialog_Load(object sender, EventArgs e)
        {

        }

        private void newB_Click(object sender, EventArgs e)
        {
            newRasyDialog newras = new newRasyDialog();
            newras.Text = "Nová rasa";
            this.Hide();
            if (newras.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Add(newras.jmeno);
            }
            newras.Close();
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (Program.getDB().rasy.FindByjmeno(listBox.Text) == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat rasu ze seznamu.", "Vyberte rasu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newRasyDialog editras = new newRasyDialog(listBox.Text);
            editras.Text = "Úprava rasy";
            this.Hide();

            if (editras.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Insert(listBox.Items.IndexOf(editras.edit), editras.jmeno);
                listBox.Items.RemoveAt(listBox.Items.IndexOf(editras.edit));
            }
            this.Show();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (Program.getDB().rasy.FindByjmeno(listBox.Text) == null)
            {
                MessageBox.Show("Pro smazání musíte vybrat rasu ze seznamu.", "Vyberte rasu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (MessageBox.Show("Opravdu chcete povolání " + listBox.Text + " smazat?", "Smazat povolání?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.rasyRow row;
                row = Program.getDB().rasy.FindByjmeno(listBox.Text);
                row.Delete();
                //this.rasyTableAdapter.Update(Program.getDB().rasy);

                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
