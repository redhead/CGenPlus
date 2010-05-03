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
    public partial class opravy : Form
    {
        private List<Oprava> opravi = new List<Oprava>();
        private Postava postava;

        public opravy(Postava pos)
        {
            InitializeComponent();
            Text += pos.jmeno;
            postava = pos;

            foreach (Oprava op in postava.opravy)
            {
                opravi.Add(new Oprava(op.vlastnost, op.name, op.bonus, op.custom));
            }

            UpdateList();
        }

        private void UpdateList()
        {
            list.Items.Clear();
            foreach (Oprava opr in opravi)
            {
                list.Items.Add((opr.custom == true ? "*" : "")+opr.vlastnost + " " + opr.getDescription() + "\t\t" + opr.getParsedBonus());
            }
        }

        private void newOpr_Click(object sender, EventArgs e)
        {
            opravyDialog dialog = new opravyDialog(postava);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                opravi.Add(dialog.opr);
                UpdateList();
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                int index = list.SelectedIndex;
                opravyDialog dialog = new opravyDialog(postava, opravi[list.SelectedIndex]);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    opravi.RemoveAt(index);
                    opravi.Insert(index, dialog.opr);
                    UpdateList();
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                opravi.RemoveAt(list.SelectedIndex);
                list.Items.RemoveAt(list.SelectedIndex);
            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                if (opravi[list.SelectedIndex].custom == true)
                {
                    edit.Visible = true;
                    delete.Visible = true;
                }
                else
                {
                    edit.Visible = false;
                    delete.Visible = false;
                }
            }
        }

        private void okB_Click(object sender, EventArgs e)
        {
            postava.opravy = opravi;
            Close();
            Program.getMainForm().setNew(postava);
        }
    }
}
