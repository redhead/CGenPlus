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
    public partial class levelUp : Form
    {
        private Postava postava;

        public levelUp(Postava pos)
        {
            InitializeComponent();

            postava = pos;

            String vlast1 = Program.getDB().povolani.FindByjmeno(postava.povolani).vlast1;
            String vlast2 = Program.getDB().povolani.FindByjmeno(postava.povolani).vlast2;

            foreach (Pair<String, int> pair in postava.zvyseniVlastnosti)
            {
                if (pair.first == vlast1 || pair.first == vlast2)
                {
                    if (pair.second != 2)
                    {
                        String used = "";
                        for (int i = 0; i < pair.second; i++)
                        {
                            used += "*";
                        }
                        hlavniList.Items.Add(getName(pair.first) + " " + used);
                    }
                }
                else
                {
                    if (pair.second != 1)
                    {
                        vedlejsiList.Items.Add(getName(pair.first));
                    }
                }
            }
            hlavniList.SelectedIndex = 0;
            vedlejsiList.SelectedIndex = 0;
        }

        private String getName(String vlast)
        {
            switch (vlast)
            {
                case "Sil": return "Síla";
                case "Obr": return "Obratnost";
                case "Zrč": return "Zručnost";
                case "Vol": return "Vůle";
                case "Int": return "Inteligence";
                case "Chr": return "Charisma";
            }
            return "";
        }

        private String getAbb(String vlast)
        {
            switch (vlast)
            {
                case "Síla": return "Sil";
                case "Obratnost": return "Obr";
                case "Zručnost": return "Zrč";
                case "Vůle": return "Vol";
                case "Inteligence": return "Int";
                case "Charisma": return "Chr";
            }
            return "Sil";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String zvys1 = getAbb(hlavniList.SelectedItem.ToString().Substring(0, hlavniList.SelectedItem.ToString().IndexOf(" ")));
            String zvys2 = getAbb(vedlejsiList.SelectedItem.ToString());

            skillsUp dialog = new skillsUp(postava, zvys1, zvys2);
            if (dialog.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                postava.setVlastnost(zvys1, postava.getVlastnost(zvys1) + 1);
                postava.setVlastnost(zvys2, postava.getVlastnost(zvys2) + 1);

                foreach (Pair<String, int> pair in postava.zvyseniVlastnosti)
                {
                    if (pair.first != zvys1 && pair.first != zvys2)
                    {
                        pair.second = 0;
                    }
                    else
                    {
                        pair.second++;
                    }
                }
                postava.Calculate();
                this.Close();
            }
        }
    }
}
