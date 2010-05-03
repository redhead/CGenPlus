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
    public partial class newZbrojDialog : Form
    {
        public String jmeno;
        public String edit = "";
        private int w;

        public newZbrojDialog(int w)
        {
            InitializeComponent();

            this.w = w;
        }

        public newZbrojDialog(String name, int w)
        {
            InitializeComponent();

            this.w = w;
            edit = jmeno = name;

            jmenoL.Text = jmeno;

            if (w == 0)
            {
                databaseDataSet.zbrojeRow row = Program.getDB().zbroje.FindByjmeno(name);
                if (row.IspsilaNull() == true)
                {
                    pSilaN.Value = 0;
                    checkBox1.Checked = true;
                }
                else
                {
                    pSilaN.Value = row.psila;
                    checkBox1.Checked = false;
                }
                omezeniN.Value = row.omezeni;
                ochranaN.Value = row.ochrana;
                vahaN.Value = (decimal)row.vaha;
            }
            else
            {
                databaseDataSet.prilbyRow row = Program.getDB().prilby.FindByjmeno(name);
                if (row.IspsilaNull() == true)
                {
                    pSilaN.Value = 0;
                    checkBox1.Checked = true;
                }
                else
                {
                    pSilaN.Value = row.psila;
                    checkBox1.Checked = false;
                }
                omezeniN.Value = row.omezeni;
                ochranaN.Value = row.ochrana;
                vahaN.Value = (decimal)row.vaha;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pSilaN.Enabled = !checkBox1.Checked;
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            if (jmenoL.Text.Trim() == "")
            {
                MessageBox.Show("Zadejte název.", "Zadejte název", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoL.Focus();
                return;
            }
            jmeno = jmenoL.Text;

            databaseDataSet db = Program.getDB();
            if (w == 0)
            {
                databaseDataSet.zbrojeRow row = db.zbroje.NewzbrojeRow();
                if (edit != "")
                {
                    row = db.zbroje.FindByjmeno(edit);
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
                row.ochrana = (short)ochranaN.Value;
                row.vaha = (double)vahaN.Value;

                if (edit == "")
                {
                    try
                    {
                        db.zbroje.AddzbrojeRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Zbroj nebo přilba s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Zbroj nebo přilba již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        jmenoL.Focus();
                        jmenoL.SelectAll();
                        return;
                    }
                }
                //zbrojeTableAdapter1.Update(db);
            }
            else
            {
                databaseDataSet.prilbyRow row = db.prilby.NewprilbyRow();
                if (edit != "")
                {
                    row = db.prilby.FindByjmeno(edit);
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
                row.ochrana = (short)ochranaN.Value;
                row.vaha = (double)vahaN.Value;

                if (edit == "")
                {
                    try
                    {
                        db.prilby.AddprilbyRow(row);
                    }
                    catch
                    {
                        MessageBox.Show("Zbroj nebo přilba s názvem " + jmeno + " již v databázi existuje. Zadejte jiný název.", "Zbroj nebo přilba již existuje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        jmenoL.Focus();
                        jmenoL.SelectAll();
                        return;
                    }
                }
                //prilbyTableAdapter1.Update(db);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
