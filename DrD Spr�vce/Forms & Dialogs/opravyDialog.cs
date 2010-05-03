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
    public partial class opravyDialog : Form
    {
        public Oprava opr;
        private Postava postava;

        public opravyDialog(Postava pos)
        {
            InitializeComponent();

            this.opr = new Oprava("", "", 0);
            this.Text = "Nová opravy";
            postava = pos;

            listUpdate();
        }

        public opravyDialog(Postava pos, Oprava opr)
        {
            InitializeComponent();

            this.opr = opr;
            this.Text = "Nová opravy";
            postava = pos;

            listUpdate();
            setLabels();
        }

        private void listUpdate()
        {
            foreach (Pair<string, int> pair in postava.getAllVlastnosti())
            {
                list.Items.Add(pair.first);
            }
            list.SelectedIndex = 0;
        }

        private void setLabels()
        {
            if (opr != null)
            {
                list.SelectedItem = opr.vlastnost;
                descript.Text = opr.getDescription().Substring(2);
                bonus.Value = (decimal)opr.bonus;
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (descript.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Musíte zadat jedinečný popis (název) opravy", "Zadejte popis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bonus.Value == 0)
            {
                MessageBox.Show("Musíte zadat nenulovou hodnotu. Jinak by nebylo opravy potřeba", "Špatná hodnota opravy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            opr.vlastnost = (string)list.SelectedItem;
            opr.name = opr.vlastnost.ToLower() + "_0*|za " + descript.Text.Trim();
            opr.bonus = (int)bonus.Value;
            opr.custom = true;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
