using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class paint : Form
    {
        private bool clicked;
        private Image insertion;
        private bool showGrid;
        private Image selectedImg;
        private Color keyColor = Color.FromArgb(255, 0, 255);

        private Cell[][] cells;
        private List<cImage> images = new List<cImage>(); 

        private int toolStart = 6;

        bool save;

        int w = 20;

        Graphics gfx;

        public paint()
        {
            InitializeComponent();

            //BackColor = Color.FromArgb(65, 65, 65);

            cells = new Cell[20][];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell[w];
            }
            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells.Length; j++)
                {
                    cells[i][j] = new Cell();
                }
            }

            this.MouseWheel += new MouseEventHandler(paint_MouseWheel);

            tools.ShowItemToolTips = true;
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\fill.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\side.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\way.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\corner2.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\corner.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\paralel.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\corner_paralel.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\door.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\stairs.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\chest.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\enemy.gif"));
            tools.Items.Add(Image.FromFile(@"C:\Users\Radek\Documents\Visual Studio 2008\Projects\DrD+ Manager\DrD Správce\MapElements\column.gif"));

            for (int i = toolStart; i < tools.Items.Count; i++)
            {
                //tools.Items[i].BackColor = Color.White;
                //tools.Items[i].ImageTransparentColor = keyColor;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gfx = e.Graphics;

            int i = 0;
            int j = 0;
            for (i = 0; i < cells.Length; i++)
            {
                for (j = 0; j < cells[i].Length; j++)
                {
                    if (cells[i][j].image != null)
                    {
                        gfx.DrawImage(cells[i][j].image, new Point(i * 20, j * 20));
                    }
                }
            }
            foreach (cImage cimg in images)
            {
                gfx.DrawImage(cimg.image, cimg.position);
            }
            
            if (showGrid)
            {
                for (i = 0; i < cells.Length; i++)
                {
                    for (j = 0; j < cells[i].Length; j++)
                    {
                        gfx.DrawLine(new Pen(Color.Black, 1), 0, (j + 1) * w, cells.Length * 20, (j + 1) * w);
                    }
                    gfx.DrawLine(new Pen(Color.Black, 1), (i + 1) * w, 0, (i + 1) * w, cells[i].Length * 20);
                }
            }
        }

        private void tools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "rotateLeft" || e.ClickedItem.Name == "rotateRight")
            {
                RotateFlipType rotType;
                if (e.ClickedItem.Name == "rotateLeft")
                    rotType = RotateFlipType.Rotate270FlipNone;
                else
                    rotType = RotateFlipType.Rotate90FlipNone;

                for (int i = toolStart; i < tools.Items.Count; i++)
                {
                    tools.Items[i].Image.RotateFlip(rotType);
                }
                tools.Refresh();
                return;
            }
            if (e.ClickedItem.Name == "eraser")
            {
                selectedImg = null;
                return;
            }
            if (e.ClickedItem.Name == "showGridB")
            {
                showGrid = !showGridB.Checked;
                Refresh();
                return;
            }
            if (e.ClickedItem.Name == "insertImage")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    insertion = Image.FromFile(ofd.FileName);
                }
            }
            if (e.ClickedItem.Text != "-" && e.ClickedItem.Name != "rotateLeft" && e.ClickedItem.Name != "rotateRight")
            {
                selectedImg = e.ClickedItem.Image;
            }
        }

        private void paint_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked) return;
            if (insertion != null)
            {
                images.Add(new cImage(insertion, e.X - (int)(insertion.Width/2), e.Y - (int)(insertion.Height/2)));
                insertion = null;
                selectedImg = null;
                Refresh();
                return;
            }
            int x = (int)(e.X / w) * w;
            int y = (int)(e.Y / w) * w;

            int i = (int)(e.X / w);
            int j = (int)(e.Y / w);

            if(i < cells.Length && i >= 0 && j < cells[0].Length && j >= 0)
            {
                Image img;
                if (selectedImg == null)
                {
                    img = null;
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        Bitmap btm = ((Bitmap)selectedImg);
                        if (cells[i][j].image != null)
                        {
                            btm = Bitmap.FromHbitmap(((Bitmap)cells[i][j].image).GetHbitmap());
                            for (int xx = 0; xx < w; xx++)
                            {
                                for (int yy = 0; yy < w; yy++)
                                {
                                    Color px = ((Bitmap)selectedImg).GetPixel(xx, yy);
                                    if (px != keyColor)
                                    {
                                        btm.SetPixel(xx, yy, px);
                                    }
                                }
                            }
                        }
                        else
                        {
                            btm = new Bitmap(w, w);
                            AlphaToWhite(btm);
                        }
                        img = Image.FromHbitmap(btm.GetHbitmap());
                    }
                    else
                    {
                        Bitmap btm = new Bitmap(w, w);
                        AlphaToWhite(btm);
                        img = Image.FromHbitmap(btm.GetHbitmap());
                    }
                }
                cells[i][j] = new Cell(img, cType.FILL);
            }
            Refresh();
        }

        private void paint_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            paint_MouseMove(null, e);
            Refresh();
        }

        private void paint_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            Refresh();
        }

        private void paint_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                tools_ItemClicked(sender, new ToolStripItemClickedEventArgs(rotateLeft));
            }
            else
            {
                tools_ItemClicked(sender, new ToolStripItemClickedEventArgs(rotateRight));
            }
        }

        private void AlphaToWhite(Bitmap btm)
        {
            for (int xx = 0; xx < w; xx++)
            {
                for (int yy = 0; yy < w; yy++)
                {
                    Color c = ((Bitmap)selectedImg).GetPixel(xx, yy);
                    if (c == keyColor)
                    {
                        btm.SetPixel(xx, yy, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        btm.SetPixel(xx, yy, c);
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "m_saveAs": save = true; Refresh(); break;
            }
        }
    }

    public class Cell
    {
        public Image image;
        public int type;

        public Cell() { type = -1; }

        public Cell(Image img, int typ)
        {
            image = img;
            type = typ;
        }
    }

    public class cImage
    {
        public Image image;
        public Point position;

        public cImage(Image img, int x, int y)
        {
            image = img;
            position = new Point(x, y);
        }
    }

    public struct cType
    {
        public const int NONE = -1;
        public const int FILL = 0;
        public const int TOP = 1;
        public const int RIGHT = 2;
        public const int BOTTOM = 3;
        public const int LEFT = 4;
    }
}
