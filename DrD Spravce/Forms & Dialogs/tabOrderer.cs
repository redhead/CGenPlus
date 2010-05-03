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
    public partial class tabOrderer : Form
    {
        public Pair<TabPage, bool>[] tabOrder;

        public tabOrderer(Pair<TabPage, bool>[] tabOrder)
        {
            InitializeComponent();

            this.tabOrder = tabOrder;

            foreach (Pair<TabPage, bool> tab in tabOrder)
            {
                list.Items.Add(tab.first.Text);
            }
        }

        private void upB_Click(object sender, EventArgs e)
        {
            if (list.SelectedItem == null) return;

            string item = (string)list.SelectedItem;
            int index = list.Items.IndexOf(item);
            if (index - 1 >= 0)
            {
                list.Items.Remove(item);
                list.Items.Insert(index - 1, item);
                list.SelectedIndex = index - 1;
            }
        }

        private void downB_Click(object sender, EventArgs e)
        {
            if (list.SelectedItem == null) return;

            string item = (string)list.SelectedItem;
            int index = list.Items.IndexOf(item);
            if (index + 1 < list.Items.Count)
            {
                list.Items.Remove(item);
                list.Items.Insert(index + 1, item);
                list.SelectedIndex = index + 1;
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            Pair<TabPage, bool>[] temp = new Pair<TabPage,bool>[tabOrder.Length];
            for (int i = 0; i < list.Items.Count; i++)
            {
                foreach (Pair<TabPage, bool> tab in tabOrder)
                {
                    if ((string)list.Items[i] == tab.first.Text)
                    {
                        temp[i] = tab;
                    }
                }
            }
            tabOrder = temp;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
