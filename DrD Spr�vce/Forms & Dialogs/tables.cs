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
    public partial class tables : Form
    {
        public int table;

        public tables(int _table)
        {
            InitializeComponent();

            table = _table;
        }

        public void tables_Load(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            this.Text = "Tabulka ";
            switch (table)
            {
                case 0: LoadTableVzdalenosti(); break;
                case 1: LoadTableRychlosti(); break;
                case 2: LoadTableZranUnav(); break;
                case 3: LoadTableVypZZ(); break;
                case 4: LoadTableHmotnosti(); break;
            }
        }

        private void LoadTableVzdalenosti()
        {
            this.Text += "vzdaleností";
            databaseDataSet.tabVzdalenostiDataTable table = Program.getDB().tabVzdalenosti;
            foreach(DataColumn c in table.Columns)
            {
                dataGrid.Columns.Add(c.ColumnName, getHeader(c.ColumnName));
            }
            foreach (DataRow r in table.Rows)
            {
                dataGrid.Rows.Add(r.ItemArray);
            }
        }

        private void LoadTableRychlosti()
        {
            this.Text += "rychlostí";
            databaseDataSet.tabRychlostiDataTable table = Program.getDB().tabRychlosti;
            foreach (DataColumn c in table.Columns)
            {
                dataGrid.Columns.Add(c.ColumnName, getHeader(c.ColumnName));
            }
            foreach (DataRow r in table.Rows)
            {
                dataGrid.Rows.Add(r.ItemArray);
            }
        }

        private void LoadTableZranUnav()
        {
            this.Text += "únavy a zranění";
            databaseDataSet.tabZraneniUnavyDataTable table = Program.getDB().tabZraneniUnavy;
            foreach (DataColumn c in table.Columns)
            {
                dataGrid.Columns.Add(c.ColumnName, getHeader(c.ColumnName));
            }
            foreach (DataRow r in table.Rows)
            {
                dataGrid.Rows.Add(r.ItemArray);
            }
        }

        private void LoadTableVypZZ()
        {
            this.Text += "výpočtu ZZ";
            this.Width = 800;
            databaseDataSet.tabZZDataTable table = Program.getDB().tabZZ;
            foreach (DataColumn c in table.Columns)
            {
                dataGrid.Columns.Add(c.ColumnName, getHeader(c.ColumnName));
            }
            foreach (DataRow r in table.Rows)
            {
                dataGrid.Rows.Add(r.ItemArray);
            }
        }

        private void LoadTableHmotnosti()
        {
            this.Text += "hmotnosti";
            databaseDataSet.tabHmotnostiDataTable table = Program.getDB().tabHmotnosti;
            foreach (DataColumn c in table.Columns)
            {
                dataGrid.Columns.Add(c.ColumnName, getHeader(c.ColumnName));
            }
            foreach (DataRow r in table.Rows)
            {
                dataGrid.Rows.Add(r.ItemArray);
            }
        }
        private string getHeader(string name)
        {
            switch (name)
            {
                case "bonus": return "Bonus";
                case "rows": return "(+)";
                case "metru": return "Metry";
                case "kmh": return "km/h";
                case "body": return "Bod únavy nebo zranění";
            }
            return name;
        }
    }
}
