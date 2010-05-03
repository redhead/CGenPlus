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
    public partial class sellDialog : Form
    {
        private Postava postava;
        private Predmet predmet;
        private bool koupit;

        public sellDialog(Postava pos, Predmet pred, bool nakoupit)
        {
            InitializeComponent();

            postava = pos;
            predmet = pred;
            koupit = nakoupit;

            if (koupit == true)
            {
                this.Text = "Nakoupit";
                this.sellB.Text = "Nakoupit";
            }

            penezN.Value = (decimal)predmet.cena;
            if (koupit == false)
            {
                ksN.Maximum = (decimal)predmet.pocet;
            }
            else
            {
                ksN.Maximum = 10000;
            }
            ksN.Minimum = 1;
            ksN.Value = 1;
        }

        private void sellB_Click(object sender, EventArgs e)
        {
            if (koupit == false)
            {
                postava.penize += (float)((float)penezN.Value * (float)ksN.Value);
                predmet.pocet -= (int)ksN.Value;

                if (ksN.Value == ksN.Maximum)
                {
                    DialogResult = DialogResult.Ignore;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (postava.penize < (float)((float)penezN.Value * (float)ksN.Value))
                {
                    DialogResult dr = MessageBox.Show("Postava nemá dost peněz na zaplacení předmětu.\nChcete za předmět zaplatit? Postava bude mít nula zlatých.", "Zaplacení", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        postava.penize = 0;
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    postava.penize -= (float)((float)penezN.Value * (float)ksN.Value);
                }
                predmet.pocet += (int)ksN.Value;
            }
            Program.getMainForm().setPenize(postava);
            this.Close();
        }
    }
}
