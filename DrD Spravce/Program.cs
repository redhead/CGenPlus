using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static List<Pair<String, String>> iniExpressions = new List<Pair<string, string>>();

        [STAThread]
        static void Main(string[] args)
        {
            RunOld2New();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            iniExpressions.Add(new Pair<string, string>("Odl", "Sil"));
            iniExpressions.Add(new Pair<string, string>("Vdr", "(Sil+Vol)/2"));
            iniExpressions.Add(new Pair<string, string>("Rch", "(Sil+Obr)/2"));
            iniExpressions.Add(new Pair<string, string>("Sms", "Zrč"));
            iniExpressions.Add(new Pair<string, string>("Útok", "Obr/2:d"));
            iniExpressions.Add(new Pair<string, string>("Obrana", "Obr/2:n"));
            iniExpressions.Add(new Pair<string, string>("Střelba", "Zrč/2:d"));
            iniExpressions.Add(new Pair<string, string>("Krs", "(Obr+Zrč)/2+Chr/2"));
            iniExpressions.Add(new Pair<string, string>("Nbz", "(Sil+Vol)/2+Chr/2"));
            iniExpressions.Add(new Pair<string, string>("Dst", "(Int+Vol)/2+Chr/2"));
            iniExpressions.Add(new Pair<string, string>("Chůze", "Rch/2+23"));
            iniExpressions.Add(new Pair<string, string>("Spěch", "Rch/2+26"));
            iniExpressions.Add(new Pair<string, string>("Běh", "Rch/2+32"));
            iniExpressions.Add(new Pair<string, string>("Sprint", "Rch/2+36"));

            Log("IniExpressons loaded...");

                Main main = null;
                if (args.Length > 0)
                {
                    main = new Main(args[0]);
                    Log("Args passed: " + args[0]);
                }
                else
                {
                    main = new Main();
                }

                Log("Running app...");
                    Application.Run(main); //run it
        }

        public static String getIniEx(String vlast)
        {
            foreach (Pair<String, String> p in iniExpressions)
            {
                if (vlast == p.first)
                {
                    return p.second;
                }
            }
            return "";
        }

        public static Properties.Settings getSettings()
        {
            return getMainForm().settings;
        }

        public static Main getMainForm()
        {
            return (Main)Application.OpenForms[0];
        }

        public static databaseDataSet getDB()
        {
            return Program.getMainForm().database;
        }

        public static object GetSetting(String setting)
        {
            return null;
        }

        public static int getZZCell(short first, short second)
        {
            databaseDataSet db = getDB();
            int index = db.tabZZ.Columns.IndexOf(second.ToString());
            if(first < -5)
                return int.Parse(db.tabZZ.Rows.Find(-5).ItemArray[index].ToString());
            else if(first > 20)
                return int.Parse(db.tabZZ.Rows.Find(20).ItemArray[index].ToString());
            else
                return int.Parse(db.tabZZ.Rows.Find(first).ItemArray[index].ToString());
        }

        public static object getRasyCell(String rasa, String colName)
        {
            databaseDataSet db = getDB();
            int index = db.rasy.Columns.IndexOf(colName);
            object obg = db.rasy.Rows.Find(rasa).ItemArray[index];
            return obg;
        }

        public static object getRasyCell(String rasa, int index)
        {
            databaseDataSet db = getDB();
            return db.rasy.Rows.Find(rasa).ItemArray[index];
        }

        public static object getPovolaniCell(String povolani, String colName)
        {
            databaseDataSet db = getDB();
            int index = db.povolani.Columns.IndexOf(colName);
            try
            {
                return db.povolani.Rows.Find(povolani).ItemArray[index];
            }
            catch
            {
                MessageBox.Show("Povolaní '" + povolani + "' nenalezeno. Pokud v databázi chybí, program nebude moct dále pracovat s tímto povoláním správně.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static object getPovolaniCell(String povolani, int index)
        {
            databaseDataSet db = getDB();
            return db.povolani.Rows.Find(povolani).ItemArray[index];
        }

        public static int getTabZraneniUnavyCell(int bonus)
        {
            databaseDataSet db = getDB();
            return (int)db.tabZraneniUnavy.FindBybonus((short)bonus).body;
        }

        public static int getTabRychlostiCell(int bonus)
        {
            databaseDataSet db = getDB();
            return (int)db.tabRychlosti.FindBybonus((short)bonus).kmh;
        }

        public static String parseBonus(int bon)
        {
            if (bon > 0)
            {
                return ("+" + bon.ToString());
            }
            else
            {
                return bon.ToString();
            }
        }

        public static int parseEquation(String eq)
        {
            String num = "";
            List<int> numbers = new List<int>();

            short round = -1;
            if (eq.EndsWith(":d"))
            {
                round = 0;
                eq = eq.Substring(0, eq.Length - 2);
            }
            else if (eq.EndsWith(":n"))
            {
                round = 1;
                eq = eq.Substring(0, eq.Length - 2);
            }
            
            check:
            int zavorky = 0;
            int first = -1;
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == "(")
                {
                    zavorky++;
                    first = i;
                }
                else if (eq[i].ToString() == ")")
                {
                    zavorky--;
                    if (zavorky == 0 && first >= 0)
                    {
                        String x = parseEquation(eq.Substring(first + 1, i - first - 1)).ToString();
                        eq = eq.Replace(eq.Substring(first, i - first + 1), x);
                        goto check;
                    }
                }
            }

            for (int i = eq.Length - 1; i >= 0; i--)
            {
                if (eq[i].ToString() != "+" && eq[i].ToString() != "*" && eq[i].ToString() != "/")
                {
                    num += eq[i];
                    if (i == 0 || eq[i].ToString() == "-")
                    {
                        String numR = "";
                        for (int j = num.Length - 1; j >= 0; j--)
                        {
                            numR += num[j];
                        }
                        numbers.Add(int.Parse(numR));
                        num = "";
                    }
                }
                else
                {
                    String numR = "";
                    for (int j = num.Length - 1; j >= 0; j--)
                    {
                        numR += num[j];
                    }
                    if (numR != "")
                    {
                        numbers.Add(int.Parse(numR));
                    }
                    num = "";
                }
            }
            numbers.Reverse();
            int pos1 = 0;
            int pos2 = 0;
            int k = 0;
            while (k < numbers.Count)
            {
                pos2 = eq.IndexOf(numbers[k].ToString(), pos1);
                string rep = "0";
                string n = "";
                if(pos2 - 1 >= 0)
                    if (eq.Substring(pos2 - 1, 1) != "*" && eq.Substring(pos2 - 1, 1) != "/")
                        n = eq.Substring(pos2, numbers[k].ToString().Length);
                if (n.StartsWith("-") && k != 0)
                    rep = "+0";
                eq = eq.Remove(pos2, numbers[k].ToString().Length);
                eq = eq.Insert(pos2, rep);
                pos1 = pos2 + 1;
                k++;
            }
            lookback:
            int operators = 0;
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == "*")
                {
                    operators++;
                    int x = numbers[i - operators] * numbers[i - operators + 1];
                    numbers[i - operators] = x;
                    numbers.RemoveAt(i - operators + 1);
                    eq = eq.Remove(i, 2);
                    operators--;
                    i--;
                }
                else if (eq[i].ToString() == "+" || eq[i].ToString() == "-" | eq[i].ToString() == "/")
                {
                    operators++;
                }
            }
            operators = 0;
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == "/")
                {
                    operators++;
                    if((double)numbers[i - operators + 1] == 0) return 0;
                    double y = (double)((double)numbers[i - operators] / (double)numbers[i - operators + 1]);
                    int x = (int)Math.Round(y, MidpointRounding.AwayFromZero);
                    if (round == 0) //zaokrouhli dolu
                    {
                        x = (int)y;
                        if (y < 0)
                        {
                            x = (int)Math.Round(y, MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (round == 1) //zaokrouhli nahoru
                    {
                        if (y == (int)y)
                        {
                            x = (int)y;
                        }
                        else
                        {
                            x = (int)y + 1;
                            if (y < 0)
                            {
                                x = (int)y;
                            }
                        }
                    }
                    numbers[i - operators] = x;
                    numbers.RemoveAt(i - operators + 1);
                    eq = eq.Remove(i, 2);
                    operators--;
                    i--;
                }
                else if (eq[i].ToString() == "+" || eq[i].ToString() == "-" || eq[i].ToString() == "*")
                {
                    operators++;
                }
            }
            int ij = 0;
            plusminus:
            operators = 0;
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == "+")
                {
                    operators++;
                    int x = numbers[i - operators] + numbers[i - operators + 1];
                    numbers[i - operators] = x;
                    numbers.RemoveAt(i - operators + 1);
                    eq = eq.Remove(i, 2);
                    operators--;
                    i--;
                }
                else if (eq[i].ToString() == "/" || eq[i].ToString() == "-" || eq[i].ToString() == "*")
                {
                    operators++;
                }
            }
            operators = 0;
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == "-")
                {
                    operators++;
                    if (i - operators < 0 || i == 0)
                        continue;
                    int x = numbers[i - operators] - numbers[i - operators + 1];
                    numbers[i - operators] = x;
                    numbers.RemoveAt(i - operators + 1);
                    eq = eq.Remove(i, 2);
                    operators--;
                    i--;
                }
                else if (eq[i].ToString() == "+" || eq[i].ToString() == "/" || eq[i].ToString() == "*")
                {
                    operators++;
                }
            }
            if (ij == 0 && numbers.Count > 1)
            {
                ij++;
                eq = "";
                for (int i = 0; i < numbers.Count; i++)
                {
                    eq += numbers[i].ToString();
                }
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < 0 && i != 0)
                    {
                        numbers[i] = -numbers[i];
                    }
                }
                k = 0;
                pos2 = 0;
                pos1 = 0;
                while (k < numbers.Count)
                {
                    pos2 = eq.IndexOf(numbers[k].ToString(), pos1);
                    string rep = "0";
                    string n = "";
                    if (pos2 - 1 >= 0)
                        if (eq.Substring(pos2 - 1, 1) != "*" && eq.Substring(pos2 - 1, 1) != "/")
                            eq.Substring(pos2, numbers[k].ToString().Length);
                    if (n.StartsWith("-") && k != 0)
                        rep = "+0";
                    eq = eq.Remove(pos2, numbers[k].ToString().Length);
                    eq = eq.Insert(pos2, rep);
                    pos1 = pos2 + 1;
                    k++;
                }
                goto plusminus;
            }
            if (numbers.Count > 1)
                goto lookback;
            return numbers[0];
        }

        private static int getVlastnost(Pair<String, int>[] array, String vlast)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].first == vlast)
                {
                    return array[i].second;
                }
            }
            return 0;
        }

        public static void vyrazHelp()
        {
            MessageBox.Show("Pozor! Všechna pole oprav musí obsahovat matematické operátory\n(+ plus, - minus, * krát, / děleno) s operandy jako vlastnosti\n(Odl, Vdr, Sms, ...) nebo celá čísla bez mezer a jiných znaků, kromě kulatých závorek.\n\nNepovinná možnost zaokrouhlení čísla po dělení dolů (přidáním ':d' na konec výrazu) nebo nahoru (přidáním ':n' na konec výrazu). \n\nSprávně: '(Sil+Zrč)/2'  'Obr'  'Obr/2:n'\nŠpatně: 'sil + obr:2'  'Obr  +  5'  'Obr/2 :n'", "Informace o výrazu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Log(string message)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "\\cgen.log", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\t" + message + "\r\n");
        }

        public static int hod2k6(Random rand)
        {
            int x = rand.Next(1, 7) + rand.Next(1, 7);
            if (x == 2)
            {
                int y;
                while ((y = rand.Next(1, 7)) <= 3)
                {
                    x--;
                }
            }
            else if (x == 12)
            {
                int y;
                while ((y = rand.Next(1, 7)) >= 4)
                {
                    x++;
                }
            }
            return x;
        }

        private static void RunOld2New()
        {
            System.IO.File.WriteAllText("cgen.log", "");
            Log("Starting CGen+...");

            if (System.IO.File.Exists("database.sdf"))
            {
                if (System.IO.File.Exists("old2new.exe"))
                {
                    Log("Old version of databse found. Starting old2new.exe to export it to temporary XML file.");
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start("old2new.exe");
                    Log("-> Waiting for old2new.exe to exit.");
                    p.WaitForExit();
                    if (System.IO.File.Exists("tempDB.xml"))
                    {
                        Log("Exported database file found. Merging it with new database file.");
                        databaseDataSet old = new databaseDataSet();
                        databaseDataSet neww = new databaseDataSet();
                        old.ReadXml("tempDB.xml");
                        neww.ReadXml("db.xml");
                        old.Merge(neww, false);
                        old.WriteXml("db.xml");
                        try
                        {
                            System.IO.File.Delete("database.sdf");
                            Log("Merged. Deleting old version database 'database.sdf'.");
                        }
                        catch { };
                    }
                }
            }
        }
    }
}
