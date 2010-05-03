namespace WindowsFormsApplication1
{
    partial class paint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(paint));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.rotateLeft = new System.Windows.Forms.ToolStripButton();
            this.rotateRight = new System.Windows.Forms.ToolStripButton();
            this.eraser = new System.Windows.Forms.ToolStripButton();
            this.showGridB = new System.Windows.Forms.ToolStripButton();
            this.insertImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.m_soubor = new System.Windows.Forms.ToolStripMenuItem();
            this.m_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tools.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BackColor = System.Drawing.SystemColors.Control;
            this.tools.Dock = System.Windows.Forms.DockStyle.Right;
            this.tools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateLeft,
            this.rotateRight,
            this.eraser,
            this.showGridB,
            this.insertImage,
            this.toolStripSeparator1});
            this.tools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tools.Location = new System.Drawing.Point(414, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(49, 295);
            this.tools.TabIndex = 0;
            this.tools.Text = "tools";
            this.tools.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tools_ItemClicked);
            // 
            // rotateLeft
            // 
            this.rotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("rotateLeft.Image")));
            this.rotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeft.Name = "rotateLeft";
            this.rotateLeft.Size = new System.Drawing.Size(24, 24);
            this.rotateLeft.Text = "Otočit vpravo";
            // 
            // rotateRight
            // 
            this.rotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRight.Image = ((System.Drawing.Image)(resources.GetObject("rotateRight.Image")));
            this.rotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRight.Name = "rotateRight";
            this.rotateRight.Size = new System.Drawing.Size(24, 24);
            this.rotateRight.Text = "toolStripButton2";
            // 
            // eraser
            // 
            this.eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraser.Image = ((System.Drawing.Image)(resources.GetObject("eraser.Image")));
            this.eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(24, 24);
            this.eraser.Text = "Guma";
            // 
            // showGridB
            // 
            this.showGridB.CheckOnClick = true;
            this.showGridB.Image = ((System.Drawing.Image)(resources.GetObject("showGridB.Image")));
            this.showGridB.Name = "showGridB";
            this.showGridB.Size = new System.Drawing.Size(24, 24);
            // 
            // insertImage
            // 
            this.insertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.insertImage.Image = ((System.Drawing.Image)(resources.GetObject("insertImage.Image")));
            this.insertImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertImage.Name = "insertImage";
            this.insertImage.Size = new System.Drawing.Size(24, 24);
            this.insertImage.Text = "Vložit obrázek...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(46, 10);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_soubor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 295);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(463, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // m_soubor
            // 
            this.m_soubor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_saveAs});
            this.m_soubor.Name = "m_soubor";
            this.m_soubor.Size = new System.Drawing.Size(57, 20);
            this.m_soubor.Text = "Soubor";
            // 
            // m_saveAs
            // 
            this.m_saveAs.Name = "m_saveAs";
            this.m_saveAs.Size = new System.Drawing.Size(152, 22);
            this.m_saveAs.Text = "Uložit jako...";
            // 
            // paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 319);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menuStrip1);
            this.Name = "paint";
            this.Text = "Editor jeskyň";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paint_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton rotateLeft;
        private System.Windows.Forms.ToolStripButton rotateRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton eraser;
        private System.Windows.Forms.ToolStripButton showGridB;
        private System.Windows.Forms.ToolStripButton insertImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_soubor;
        private System.Windows.Forms.ToolStripMenuItem m_saveAs;




    }
}