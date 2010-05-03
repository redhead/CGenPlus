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
    public partial class stityDataDialog : Form
    {
        public stityDataDialog()
        {
            InitializeComponent();

            foreach (databaseDataSet.stityRow row in Program.getDB().stity)
            {
                listBox.Items.Add(row.jmeno.ToString());
            }
        }

        private void stityDataDialog_Load(object sender, EventArgs e)
        {
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newStitDialog dialog = new newStitDialog();
            this.Hide();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Add(dialog.jmeno);
            }
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (Program.getDB().stity.FindByjmeno(listBox.Text) == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat štít ze seznamu.", "Vyberte štít", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newStitDialog dialog = new newStitDialog(listBox.Text);
            this.Hide();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                listBox.Items.Insert(listBox.Items.IndexOf(dialog.edit), dialog.jmeno);
                listBox.Items.RemoveAt(listBox.Items.IndexOf(dialog.edit));
            }
            this.Show();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pro smazání musíte vybrat štít ze seznamu.", "Vyberte štít", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete štít smazat?", "Smazat štít?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.stityRow row;
                row = Program.getDB().stity.FindByjmeno(listBox.SelectedItem.ToString());
                if (row != null)
                {
                    row.Delete();
                    //this.stityTableAdapter.Update(Program.getDB().stity);

                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
