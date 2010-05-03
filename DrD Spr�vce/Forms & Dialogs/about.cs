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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label2.Text = "Verze " + Application.ProductVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cgenplus.utf-8.cz/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
