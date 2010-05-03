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
    public partial class zbrojeDataDialog : Form
    {
        public zbrojeDataDialog()
        {
            InitializeComponent();

            int i = 0;
            foreach (databaseDataSet.zbrojeRow row in Program.getDB().zbroje)
            {
                i++;
                if (i == 1) continue;
                list1.Items.Add(row.jmeno.ToString());
            }
            i = 0;
            foreach (databaseDataSet.prilbyRow row in Program.getDB().prilby)
            {
                i++;
                if (i == 1) continue;
                list2.Items.Add(row.jmeno.ToString());
            }
        }

        private void newB_Click(object sender, EventArgs e)
        {
            newZbrojDialog newras = new newZbrojDialog(0);
            newras.Text = "Nová zbroj";
            this.Hide();
            if (newras.ShowDialog(this) == DialogResult.OK)
            {
                list1.Items.Add(newras.jmeno);
            }
            newras.Close();
            this.Show();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if (Program.getDB().zbroje.FindByjmeno(list1.Text) == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat zbroj ze seznamu.", "Vyberte zbroj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newZbrojDialog editras = new newZbrojDialog(list1.Text, 0);
            editras.Text = "Úprava zbroje";
            this.Hide();

            if (editras.ShowDialog(this) == DialogResult.OK)
            {
                list1.Items.Insert(list1.Items.IndexOf(editras.edit), editras.jmeno);
                list1.Items.RemoveAt(list1.Items.IndexOf(editras.edit));
            }
            this.Show();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (Program.getDB().zbroje.FindByjmeno(list1.Text) == null)
            {
                MessageBox.Show("Pro smazání musíte vybrat zbroj ze seznamu.", "Vyberte zbroj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete zbroj " + list1.Text + " smazat?", "Smazat zbroj?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.zbrojeRow row;
                row = Program.getDB().zbroje.FindByjmeno(list1.Text);
                row.Delete();
                //zbrojeTableAdapter.Update(Program.getDB().zbroje);

                list1.Items.RemoveAt(list1.SelectedIndex);
            }
        }

        private void newB2_Click(object sender, EventArgs e)
        {
            newZbrojDialog newras = new newZbrojDialog(1);
            newras.Text = "Nová přilba";
            this.Hide();
            if (newras.ShowDialog(this) == DialogResult.OK)
            {
                list2.Items.Add(newras.jmeno);
            }
            newras.Close();
            this.Show();
        }

        private void editB2_Click(object sender, EventArgs e)
        {
            if (Program.getDB().prilby.FindByjmeno(list2.Text) == null)
            {
                MessageBox.Show("Pro úpravu musíte vybrat přilbu ze seznamu.", "Vyberte přilbu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            newZbrojDialog editras = new newZbrojDialog(list2.Text, 1);
            editras.Text = "Úprava přilby";
            this.Hide();

            if (editras.ShowDialog(this) == DialogResult.OK)
            {
                list2.Items.Insert(list2.Items.IndexOf(editras.edit), editras.jmeno);
                list2.Items.RemoveAt(list2.Items.IndexOf(editras.edit));
            }
            this.Show();
        }

        private void deleteB2_Click(object sender, EventArgs e)
        {
            if (Program.getDB().prilby.FindByjmeno(list2.Text) == null)
            {
                MessageBox.Show("Pro smazání musíte vybrat přilbu ze seznamu.", "Vyberte přilbu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Opravdu chcete přilbu " + list2.Text + " smazat?", "Smazat přilbu?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                databaseDataSet.prilbyRow row;
                row = Program.getDB().prilby.FindByjmeno(list2.Text);
                row.Delete();
                //prilbyTableAdapter.Update(Program.getDB().prilby);

                list2.Items.RemoveAt(list2.SelectedIndex);
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
