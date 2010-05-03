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
    public partial class vyberZbroje : Form
    {
        public int psila;
        public int zsila;

        public int pomezeni;
        public int zomezeni;

        public float pvaha;
        public float zvaha;

        private Postava postava;

        public vyberZbroje(Postava pos, String z, String p)
        {
            InitializeComponent();

            postava = pos;

            int stup = postava.dovednostiMgr.getDovednost("Nošení zbroje");
            dovednostL.Text = "Dovednost nošení zbroje na " + (stup == 0 ? "žádném" : (stup.ToString() + ".")) + " stupni";

            foreach (databaseDataSet.zbrojeRow row in Program.getDB().zbroje)
            {
                zbrojeList.Items.Add(row.jmeno.ToString());
            }
            foreach (databaseDataSet.prilbyRow row in Program.getDB().prilby)
            {
                prilbyList.Items.Add(row.jmeno.ToString());
            }
            zbrojeList.SelectedIndex = zbrojeList.Items.IndexOf(z);
            prilbyList.SelectedIndex = prilbyList.Items.IndexOf(p);
        }

        private void zbrojeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            databaseDataSet db = Program.getDB();
            databaseDataSet.zbrojeRow row = db.zbroje.FindByjmeno(zbrojeList.SelectedItem.ToString());
            if (row != null)
            {
                zJmenoL.Text = row.jmeno;
                zpSilaL.Text = row.IspsilaNull() ? "-" : Program.parseBonus(row.psila);
                zOmezeniL.Text = Program.parseBonus(row.omezeni);
                zOchranaL.Text = row.ochrana.ToString();
                zVahaL.Text = row.vaha.ToString();

                zomezeni = row.omezeni;
                zsila = row.IspsilaNull() ? -99 : row.psila;
                zvaha = (float)row.vaha;
            }
        }

        private void prilbyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            databaseDataSet db = Program.getDB();
            databaseDataSet.prilbyRow row = db.prilby.FindByjmeno(prilbyList.SelectedItem.ToString());
            if (row != null)
            {
                pJmenoL.Text = row.jmeno;
                ppSilaL.Text = row.IspsilaNull() ? "-" : Program.parseBonus(row.psila);
                pOmezeniL.Text = Program.parseBonus(row.omezeni);
                pOchranaL.Text = row.ochrana.ToString();
                pVahaL.Text = row.vaha.ToString();

                pomezeni = row.omezeni;
                psila = row.IspsilaNull() ? -99 : row.psila;
                pvaha = (float)row.vaha;
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
