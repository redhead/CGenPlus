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
    public partial class povolaniDataDialog : Form
    {
        public povolaniDataDialog()
        {
            InitializeComponent();

            foreach (databaseDataSet.povolaniRow row in Program.getDB().povolani)
            {
                listBox.Items.Add(row.jmeno.ToString());
            }
        }

        private void povolaniDataDialog_Load(object sender, EventArgs e)
        {

        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pro smazání musíte vybrat povolání ze seznamu.", "Vyberte povolání", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete povolání " + listBox.Text + " smazat?", "Smazat povolání?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.povolaniRow row;
                row = Program.getDB().povolani.FindByjmeno(listBox.Text);
                row.Delete();
                //this.povolaniTableAdapter.Update(Program.getDB().povolani);

                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newPovolaniDialog newpov = new newPovolaniDialog();
            newpov.Text = "Nové povolání";
            this.Hide();
            if (newpov.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Add(newpov.jmeno);
            }
            newpov.Close();
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pro úpravu musíte vybrat povolání ze seznamu.", "Vyberte povolání", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newPovolaniDialog editpov = new newPovolaniDialog(listBox.Text);
            editpov.Text = "Úprava povolání";
            this.Hide();
            if (editpov.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Insert(listBox.Items.IndexOf(editpov.edit), editpov.jmeno);
                listBox.Items.RemoveAt(listBox.Items.IndexOf(editpov.edit));
            }
            this.Show();
        }
    }
}
