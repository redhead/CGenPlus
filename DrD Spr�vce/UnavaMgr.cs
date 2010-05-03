using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class UnavaMgr
    {
        private Label mezUnavyL;
        private NumericUpDown unavaN;
        private FlowLayoutPanel unavaPanel;
        private Panel unavaLabels;
        private LinkLabel postihLink;
        private Label postihL;

        private List<CheckBox> boxes;

        private Postava postava;

        public UnavaMgr(Postava pos, Label muL, NumericUpDown unN, FlowLayoutPanel bars, Panel labels, LinkLabel postihULink, Label postihUL)
        {
            postava = pos;
            unavaPanel = bars;
            mezUnavyL = muL;
            unavaLabels = labels;
            unavaN = unN;
            postihLink = postihULink;
            postihL = postihUL;

            int mez = postava.getVlastnostO("Mez únavy");
            boxes = new List<CheckBox>();
            for (int i = 0; i < mez * 3; i++)
            {
                CheckBox box = new CheckBox();
                //box.ThreeState = true;
                box.Checked = false;
                box.Margin = new Padding(0);
                box.Parent = unavaPanel;
                box.Width = box.Height = 15;
                box.Click += new EventHandler(changeCheck);
                box.Tag = i+1;
                boxes.Add(box);
            }
        }

        public void setUnava(int unava)
        {
            if (unava > unavaN.Maximum)
                unavaN.Value = unavaN.Maximum;
            else
                unavaN.Value = unava;

            if (boxes.Count >= unava)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (i < unava)
                        boxes[i].Checked = true;
                    else
                        boxes[i].Checked = false;
                }
            }
            if (unava > postava.getVlastnostO("Mez únavy"))
            {
                postihLink.Visible = true;
                if (postihL.Text != "0")
                    postihL.Visible = true;
            }
            else
            {
                postihLink.Visible = false;
                postihL.Visible = false;
                postihL.Text = "0";
                postava.postihU = 0;
            }
            postava.unava = unava;
        }
        
        public void Change()
        {
            int mez = postava.getVlastnostO("Mez únavy");
            mezUnavyL.Text = mez.ToString();
            foreach(CheckBox box in boxes)
            {
                box.Dispose();
            }
            boxes.Clear();
            unavaPanel.Controls.Clear();
            for (int i = 0; i < mez * 3; i++)
            {
                CheckBox box = new CheckBox();
                //fixme: box.ThreeState = true;
                box.Checked = false;
                box.Margin = new Padding(0);
                box.Parent = unavaPanel;
                box.Width = box.Height = 15;
                box.Click += new EventHandler(changeCheck);
                box.Tag = i+1;
                boxes.Add(box);
            }
            int un = postava.unava; //musi byt
            unavaN.Maximum = 3 * mez;
            unavaPanel.Width = mez * 15;
            unavaLabels.Left = unavaPanel.Width + unavaPanel.Left;
            if (un >= 0 && un <= unavaN.Maximum)
            {
                unavaN.Value = un;
            }
        }

        public void unavaChanged(object sender, EventArgs e)
        {
            setUnava((int)unavaN.Value);
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
            setUnava((int)b.Tag);
        }

        public void postihClicked(object sender, EventArgs e)
        {
            int hod = postava.getVlastnostO("Vol") + Program.hod2k6(new Random());
            int post = 0;
            if (hod < 5)
                post = -3;
            else if (hod >= 5 && hod < 10)
                post = -2;
            else if (hod >= 10 && hod < 15)
                post = -1;
            else if (hod >= 15)
                post = 0;
            if (postava.unava > (int)postihL.Tag && post <= postava.postihU)
            {
                MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih " + (postava.postihU != post ? "se zvýšil na " : "zůstává ") + Program.parseBonus(post) + ".", "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postava.postihU = post;
            }
            else if (postava.unava < (int)postihL.Tag && post >= postava.postihU)
            {
                MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih " + (postava.postihU != post ? "se snížil na " : "zůstává ") + Program.parseBonus(post) + ".", "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postava.postihU = post;
            }
            else
            {
                if ((int)postihL.Tag != postava.unava)
                    MessageBox.Show("Na kostkách padlo " + hod.ToString() + ".\nPostih nelze " + (postava.unava > (int)postihL.Tag ? "snížit." : "zvýšit."), "Hod na postih", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postihL.Tag = postava.unava;
            }
        }
    }
}
