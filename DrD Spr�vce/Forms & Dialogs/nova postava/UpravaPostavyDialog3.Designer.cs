namespace WindowsFormsApplication1
{
    partial class UpravaPostavyDialog3
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
            this.tree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.kombL = new System.Windows.Forms.Label();
            this.psyL = new System.Windows.Forms.Label();
            this.fyzL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.details = new System.Windows.Forms.Label();
            this.stupenL = new System.Windows.Forms.Label();
            this.cancelB = new System.Windows.Forms.Button();
            this.backB = new System.Windows.Forms.Button();
            this.createB = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(190, 301);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kombL
            // 
            this.kombL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kombL.Location = new System.Drawing.Point(316, 55);
            this.kombL.Name = "kombL";
            this.kombL.Size = new System.Drawing.Size(71, 13);
            this.kombL.TabIndex = 21;
            this.kombL.Text = "1";
            this.kombL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // psyL
            // 
            this.psyL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.psyL.Location = new System.Drawing.Point(258, 55);
            this.psyL.Name = "psyL";
            this.psyL.Size = new System.Drawing.Size(52, 13);
            this.psyL.TabIndex = 20;
            this.psyL.Text = "0";
            this.psyL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fyzL
            // 
            this.fyzL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fyzL.Location = new System.Drawing.Point(211, 55);
            this.fyzL.Name = "fyzL";
            this.fyzL.Size = new System.Drawing.Size(37, 13);
            this.fyzL.TabIndex = 19;
            this.fyzL.Text = "2";
            this.fyzL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "kombinované";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "psychické";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "fyzické";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zbývá:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.details);
            this.panel.Controls.Add(this.stupenL);
            this.panel.Controls.Add(this.button1);
            this.panel.Controls.Add(this.button2);
            this.panel.Location = new System.Drawing.Point(211, 85);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(176, 228);
            this.panel.TabIndex = 24;
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(6, 32);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(165, 183);
            this.details.TabIndex = 25;
            // 
            // stupenL
            // 
            this.stupenL.AutoSize = true;
            this.stupenL.Location = new System.Drawing.Point(48, 7);
            this.stupenL.Name = "stupenL";
            this.stupenL.Size = new System.Drawing.Size(70, 13);
            this.stupenL.TabIndex = 24;
            this.stupenL.Text = "žádný stupeň";
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(307, 327);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 5;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // backB
            // 
            this.backB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backB.Location = new System.Drawing.Point(89, 327);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(75, 23);
            this.backB.TabIndex = 3;
            this.backB.Text = "Zpět";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // createB
            // 
            this.createB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createB.Location = new System.Drawing.Point(179, 327);
            this.createB.Name = "createB";
            this.createB.Size = new System.Drawing.Size(122, 23);
            this.createB.TabIndex = 4;
            this.createB.Text = "Vytvořit postavu";
            this.createB.UseVisualStyleBackColor = true;
            this.createB.Click += new System.EventHandler(this.createB_Click);
            // 
            // UpravaPostavyDialog3
            // 
            this.AcceptButton = this.createB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(394, 362);
            this.Controls.Add(this.createB);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kombL);
            this.Controls.Add(this.psyL);
            this.Controls.Add(this.fyzL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpravaPostavyDialog3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "3) Výběr dovedností";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label kombL;
        private System.Windows.Forms.Label psyL;
        private System.Windows.Forms.Label fyzL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label stupenL;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.Button createB;
        private System.Windows.Forms.Label details;
    }
}