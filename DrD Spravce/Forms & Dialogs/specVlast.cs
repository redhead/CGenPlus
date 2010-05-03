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
    public partial class specVlast : Form
    {
        public List<NumericUpDown> numbers = new List<NumericUpDown>();
        public List<Oprava> opravy = new List<Oprava>();

        public specVlast(String predName, List<Oprava> oprs)
        {
            InitializeComponent();

            LoadList();

            if (oprs.Count == 0)
            {
                oprName.Text = predName;
            }
            else
            {
                oprName.Text = oprs[0].getDescription();
                foreach (NumericUpDown con in numbers)
                {
                    foreach (Oprava opr in oprs)
                    {
                        if ((String)con.Tag == opr.vlastnost)
                        {
                            con.Value = (decimal)opr.bonus;
                        }
                    }
                }
            }
        }

        public void LoadList()
        {
            numbers.Add(Sil);
            numbers.Add(Obr);
            numbers.Add(Zrc);
            numbers.Add(Vol);
            numbers.Add(Intel);
            numbers.Add(Chr);
            numbers.Add(Odl);
            numbers.Add(Vdr);
            numbers.Add(Rch);
            numbers.Add(Sms);
            numbers.Add(Dst);
            numbers.Add(Nbz);
            numbers.Add(Krs);
            numbers.Add(Vel);
            numbers.Add(Hmp);
            numbers.Add(Vyska);
        }

        public specVlast(Predmet predmet)
        {
            InitializeComponent();

            LoadList();

            if (predmet.opravy.Count > 0)
            {
                oprName.Text = predmet.opravy[0].name.Substring(predmet.opravy[0].name.IndexOf("|za ") + 4);
                oprName.Enabled = false;
            }
            else
            {
                oprName.Text = predmet.ownName == "" ? predmet.predmet : predmet.ownName;
            }

            foreach (NumericUpDown con in numbers)
            {
                foreach (Oprava opr in predmet.opravy)
                {
                    if ((String)con.Tag == opr.vlastnost)
                    {
                        con.Value = (decimal)opr.bonus;
                    }
                }
            }
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okB_Click(object sender, EventArgs e)
        {
            opravy.Clear();
            foreach (NumericUpDown con in numbers)
            {
                opravy.Add(new Oprava((String)con.Tag, ((String)con.Tag).ToLower() + "|za " + oprName.Text, (int)con.Value));
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
