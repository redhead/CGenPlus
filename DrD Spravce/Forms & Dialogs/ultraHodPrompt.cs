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
    public partial class ultraHodPrompt : Form
    {
        public ultraHodPrompt(System.Text.RegularExpressions.MatchCollection matches)
        {
            InitializeComponent();

            list.Tag = matches;
            foreach (System.Text.RegularExpressions.Match m in matches)
            {
                list.Items.Add(m.Groups[0].ToString());
            }
            list.SelectedIndex = 0;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public string returnSelection()
        {
            return ((System.Text.RegularExpressions.MatchCollection)list.Tag)[list.SelectedIndex].Groups[1].ToString();
        }

        internal int selectedIndex()
        {
            if (dontNext.Checked)
            {
                return list.SelectedIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}
