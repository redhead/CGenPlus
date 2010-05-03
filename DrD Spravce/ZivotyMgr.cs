using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class ZivotyMgr
    {
        private Label mezZraneniL;
        private NumericUpDown zraneniN;
        private FlowLayoutPanel zivotyPanel;
        private Panel zivotyLabels;
        private LinkLabel postihLink;
        private Label postihL;

        private List<CheckBox> boxes;

        private Postava postava;

        public ZivotyMgr(Postava pos, Label mzL, NumericUpDown zrN, FlowLayoutPanel bars, Panel labels, LinkLabel postihZLink, Label postihZL)
        {
            postava = pos;
            zivotyPanel = bars;
            mezZraneniL = mzL;
            zivotyLabels = labels;
            zraneniN = zrN;
            postihLink = postihZLink;
            postihL = postihZL;

            int mez = postava.getVlastnostO("Mez zranění");
            boxes = new List<CheckBox>();
            for (int i = 0; i < mez * 3; i++)
            {
                CheckBox box = new CheckBox();
                //box.ThreeState = true;
                box.Checked = false;
                box.Margin = new Padding(0);
                box.Parent = zivotyPanel;
                box.Width = box.Height = 15;
                box.Click += new EventHandler(changeCheck);
                box.Tag = i+1;
                boxes.Add(box);
            }
        }

        public void setZraneni(int zraneni)
        {
            if (zraneni > zraneniN.Maximum)
                zraneniN.Value = zraneniN.Maximum;
            else
                zraneniN.Value = zraneni;
            
            if (boxes.Count >= zraneni)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (i < zraneni)
                        boxes[i].Checked = true;
                    else
                        boxes[i].Checked = false;
                }
            }
            if (zraneni > postava.getVlastnostO("Mez zranění"))
            {
                postihLink.Visible = true;
                if(postihL.Text != "0")
                    postihL.Visible = true;
            }
            else
            {
                postihLink.Visible = false;
                postihL.Visible = false;
                postihL.Text = "0";
                postava.postihZ = 0;
            }
            postava.zraneni = zraneni;

        }
        
        public void Change()
        {
            int mez = postava.getVlastnostO("Mez zranění");
            mezZraneniL.Text = mez.ToString();
            foreach(CheckBox box in boxes)
            {
                box.Dispose();
            }
            boxes.Clear();
            zivotyPanel.Controls.Clear();
            for (int i = 0; i < mez * 3; i++)
            {
                CheckBox box = new CheckBox();
                //fixme: box.ThreeState = true;
                box.Checked = false;
                box.Margin = new Padding(0);
                box.Parent = zivotyPanel;
                box.Width = box.Height = 15;
                box.Click += new EventHandler(changeCheck);
                box.Tag = i+1;
                boxes.Add(box);
            }
            int zr = postava.zraneni;  //musi byt
            zraneniN.Maximum = 3 * mez;
            zivotyPanel.Width = mez * 15;
            zivotyLabels.Left = zivotyPanel.Width + zivotyPanel.Left;
            if (zr >= 0 && zr <= zraneniN.Maximum)
            {
                zraneniN.Value = zr;
            }
        }

        public void zraneniChanged(object sender, EventArgs e)
        {
            setZraneni((int)zraneniN.Value);
        }

        public void setNew()
        {
            Change();
        }

        private void changeCheck(object sender, EventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            foreach(CheckBox box in boxes)
            {
                if ((int)box.Tag <= (int)b.Tag)
                {
                    box.Checked = true;
                }
                else
                {
                    box.Checked = false;
                }
            }
            setZraneni((int)b.Tag);
        }

        public void postihClicked(object sender, EventArgs e)
        {
            int hod = postava.getVlastnostO("Vol")+Program.hod2k6(new Random());
            int post = 0;
            if (hod < 5)
                post = -3;
            else if (hod >= 5 && hod < 10)
                post = -2;
            else if (hod >= 10 && hod < 15)
                post = -1;
            else if (hod >= 15)
                post = 0;
            if (postava.zraneni > (int)postihL.Tag && post <= postava.postihZ)
            {
                MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih " + (postava.postihZ != post ? "se zvýšil na " : "zůstává ") + Program.parseBonus(post) + ".", "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postava.postihZ = post;
            }
            else if (postava.zraneni < (int)postihL.Tag && post >= postava.postihZ)
            {
                MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih " + (postava.postihZ != post ? "se snížil na " : "zůstává ") + Program.parseBonus(post) + ".", "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postava.postihZ = post;
            }
            else
            {
                if((int)postihL.Tag != postava.zraneni)
                    MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih se nemůže " + (postava.zraneni > (int)postihL.Tag ? "snížit." : "zvýšit."), "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postihL.Tag = postava.zraneni;
            }
        }
    }
}
