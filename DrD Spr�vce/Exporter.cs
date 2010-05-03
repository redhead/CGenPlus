using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public static class Exporter
    {
        public static void ToTXT(Postava pos)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Textový soubor|*.txt|Všechny soubory|*.*";
            sfd.AddExtension = true;
            sfd.FileName = pos.jmeno;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName);
                sw.WriteLine(pos.jmeno);
                sw.WriteLine(pos.rasa + " " + pos.povolani.ToLower());
                sw.WriteLine();

                sw.WriteLine("Úroveň\t\t" + pos.uroven.ToString());
                sw.WriteLine("Zkušenosti\t" + pos.zkusenosti.ToString());
                sw.WriteLine();

                int i = 0;
                foreach (Pair<String, int> vlast in pos.getAllVlastnosti())
                {
                    String zvys = "";
                    if (i < 6)
                        for (int j = 0; j < pos.zvyseniVlastnosti[i].second; j++)
                            zvys += "*";
                    sw.WriteLine(vlast.first + zvys +  ":\t\t" + Program.parseBonus(vlast.second));
                    i++;
                    if (i == 6) sw.WriteLine();
                    if (i == 10) sw.WriteLine();
                    if (i == 13) sw.WriteLine();
                    if (i == 17) sw.WriteLine();
                    if (i == 19) sw.WriteLine();
                }

                //foreach(pos.

                sw.Flush();
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }
    }
}
