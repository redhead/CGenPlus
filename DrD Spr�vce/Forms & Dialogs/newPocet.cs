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
    public partial class newPocet : Form
    {
        public int pocet;

        public newPocet(int pocet)
        {
            InitializeComponent();

            this.pocet = pocet;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (r1.Checked == true)
            {
                pocet = (int)pocetN.Value;
            }
            else if (r2.Checked == true)
            {
                pocet += (int)pocetN.Value;
            }
            else
            {
                if (pocet - (int)pocetN.Value <= 0)
                {
                    if (MessageBox.Show("Výsledný počet je menší než jedna. Předmět bude proto smazán z inventáře.\nPokračovat?", "Smazat?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pocet -= (int)pocetN.Value;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    pocet -= (int)pocetN.Value;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
