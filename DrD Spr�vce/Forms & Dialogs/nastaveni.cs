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
    public partial class nastaveni : Form
    {
        private bool change;
        public nastaveni()
        {
            InitializeComponent();
            startUpLoad.Checked = Program.getSettings().loadLast;
            includeSize.Checked = change = Program.getSettings().useCharacterSize;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            Program.getSettings().loadLast = startUpLoad.Checked;
            Program.getSettings().useCharacterSize = this.includeSize.Checked;
            Program.getSettings().useCharacterSize = this.includeSize.Checked;
            if (change != includeSize.Checked)
            {
                List<Postava> postavy = Program.getMainForm().postavyMgr.GetAll();
                foreach (Postava pos in postavy)
                {
                    pos.zbrojMgr.Calculate();
                }
                Program.getMainForm().setNew(Program.getMainForm().postavyMgr.GetOpened());
            }
            this.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            {
                Org.Mentalis.Utilities.FileAssociation fa = new Org.Mentalis.Utilities.FileAssociation();
                fa.Extension = ".pos";
                fa.FullName = "Soubor postavy CGen+";
                fa.ProperName = "POS File";
                fa.AddCommand("open", Application.ExecutablePath + " %1");
                fa.IconPath = Application.StartupPath + "\\posIcon.ico";
                fa.Create();
            }
            {
                Org.Mentalis.Utilities.FileAssociation fa = new Org.Mentalis.Utilities.FileAssociation();
                fa.Extension = ".drz";
                fa.FullName = "Soubor družiny CGen+";
                fa.ProperName = "DRZ File";
                fa.AddCommand("open", Application.ExecutablePath + " %1");
                fa.IconPath = Application.StartupPath + "\\drzIcon.ico";
                fa.Create();
            }
        }
    }
}
