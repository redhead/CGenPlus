using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace old2new
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prosim pockejte nez program vytvori novou verzi databaze.");
            Console.WriteLine();
            Console.WriteLine("Hledam starou verzi databaze: 'database.sdf'.");
            if (File.Exists("database.sdf"))
            {
                Console.WriteLine("Soubor 'database.sdf' existuje.");
                Console.WriteLine("Exportuji databázi do dočasneho souboru.");
                try
                {
                    databaseDataSet database = new databaseDataSet();

                    databaseDataSetTableAdapters.povolaniTableAdapter povolaniTableAdapter = new databaseDataSetTableAdapters.povolaniTableAdapter();
                    povolaniTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.tabZZTableAdapter tabZZTableAdapter = new databaseDataSetTableAdapters.tabZZTableAdapter();
                    povolaniTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.rasyTableAdapter rasyTableAdapter = new databaseDataSetTableAdapters.rasyTableAdapter();
                    rasyTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.tabZraneniUnavyTableAdapter tabZraneniUnavyTableAdapter = new databaseDataSetTableAdapters.tabZraneniUnavyTableAdapter();
                    tabZraneniUnavyTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.zbraneTableAdapter zbraneTableAdapter = new databaseDataSetTableAdapters.zbraneTableAdapter();
                    zbraneTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.zbrojeTableAdapter zbrojeTableAdapter = new databaseDataSetTableAdapters.zbrojeTableAdapter();
                    zbrojeTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.prilbyTableAdapter prilbyTableAdapter = new databaseDataSetTableAdapters.prilbyTableAdapter();
                    prilbyTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.stityTableAdapter stityTableAdapter = new databaseDataSetTableAdapters.stityTableAdapter();
                    stityTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.tabVzdalenostiTableAdapter tabVzdalenostiTableAdapter = new databaseDataSetTableAdapters.tabVzdalenostiTableAdapter();
                    tabVzdalenostiTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.predmetyTableAdapter predmetyTableAdapter = new databaseDataSetTableAdapters.predmetyTableAdapter();
                    predmetyTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.strelneTableAdapter strelneTableAdapter = new databaseDataSetTableAdapters.strelneTableAdapter();
                    predmetyTableAdapter.ClearBeforeFill = true;

                    databaseDataSetTableAdapters.dovednostiTableAdapter dovednostiTableAdapter = new databaseDataSetTableAdapters.dovednostiTableAdapter();
                    dovednostiTableAdapter.ClearBeforeFill = true;

                    tabZraneniUnavyTableAdapter.Fill(database.tabZraneniUnavy);
                    tabZZTableAdapter.Fill(database.tabZZ);
                    povolaniTableAdapter.Fill(database.povolani);
                    rasyTableAdapter.Fill(database.rasy);
                    zbraneTableAdapter.Fill(database.zbrane);
                    zbrojeTableAdapter.Fill(database.zbroje);
                    prilbyTableAdapter.Fill(database.prilby);
                    stityTableAdapter.Fill(database.stity);
                    tabVzdalenostiTableAdapter.Fill(database.tabVzdalenosti);
                    predmetyTableAdapter.Fill(database.predmety);
                    strelneTableAdapter.Fill(database.strelne);
                    dovednostiTableAdapter.Fill(database.dovednosti);

                    database.WriteXml("tempDB.xml");
                    Console.WriteLine("\nDatabaze byla uspesne vyexportovana. CGen+ ji slouci s novou verzi databaze.");

                    return;
                }
                catch
                {
                    Console.WriteLine("!!! NASTALA CHYBA PRI NAPLONOVANI DB DATAMA !!!");
                }
            }
            else
            {
                Console.WriteLine("Databáze nenalezena.");
            }
            Console.ReadKey();
        }
    }
}
