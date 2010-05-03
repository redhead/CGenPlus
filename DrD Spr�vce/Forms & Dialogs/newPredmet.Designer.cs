namespace WindowsFormsApplication1
{
    partial class newPredmet
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
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.owNameT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cenaks = new System.Windows.Forms.NumericUpDown();
            this.zaplatitCh = new System.Windows.Forms.CheckBox();
            this.celkemL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ksN = new System.Windows.Forms.NumericUpDown();
            this.cenaL = new System.Windows.Forms.Label();
            this.vahaL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jmenoL = new System.Windows.Forms.Label();
            this.newB = new System.Windows.Forms.Button();
            this.specB = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cenaks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksN)).BeginInit();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(202, 307);
            this.tree.TabIndex = 1;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(311, 325);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 4;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(230, 325);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 3;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.specB);
            this.panel1.Controls.Add(this.owNameT);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cenaks);
            this.panel1.Controls.Add(this.zaplatitCh);
            this.panel1.Controls.Add(this.celkemL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ksN);
            this.panel1.Controls.Add(this.cenaL);
            this.panel1.Controls.Add(this.vahaL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.jmenoL);
            this.panel1.Location = new System.Drawing.Point(220, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 307);
            this.panel1.TabIndex = 3;
            // 
            // owNameT
            // 
            this.owNameT.Location = new System.Drawing.Point(10, 248);
            this.owNameT.Name = "owNameT";
            this.owNameT.Size = new System.Drawing.Size(147, 20);
            this.owNameT.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Vlastní název:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cena / ks:";
            // 
            // cenaks
            // 
            this.cenaks.DecimalPlaces = 2;
            this.cenaks.Location = new System.Drawing.Point(75, 146);
            this.cenaks.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cenaks.Name = "cenaks";
            this.cenaks.Size = new System.Drawing.Size(82, 20);
            this.cenaks.TabIndex = 9;
            this.cenaks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cenaks.ValueChanged += new System.EventHandler(this.ksN_ValueChanged);
            // 
            // zaplatitCh
            // 
            this.zaplatitCh.AutoSize = true;
            this.zaplatitCh.Location = new System.Drawing.Point(10, 123);
            this.zaplatitCh.Name = "zaplatitCh";
            this.zaplatitCh.Size = new System.Drawing.Size(117, 17);
            this.zaplatitCh.TabIndex = 8;
            this.zaplatitCh.Text = "Zaplatit za předmět";
            this.zaplatitCh.UseVisualStyleBackColor = true;
            this.zaplatitCh.CheckedChanged += new System.EventHandler(this.zaplatitCh_CheckedChanged);
            // 
            // celkemL
            // 
            this.celkemL.AutoSize = true;
            this.celkemL.Location = new System.Drawing.Point(72, 171);
            this.celkemL.Name = "celkemL";
            this.celkemL.Size = new System.Drawing.Size(29, 13);
            this.celkemL.TabIndex = 7;
            this.celkemL.Text = "10 zl";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Celkem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kusů:";
            // 
            // ksN
            // 
            this.ksN.Location = new System.Drawing.Point(75, 77);
            this.ksN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ksN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ksN.Name = "ksN";
            this.ksN.Size = new System.Drawing.Size(82, 20);
            this.ksN.TabIndex = 2;
            this.ksN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ksN.ValueChanged += new System.EventHandler(this.ksN_ValueChanged);
            // 
            // cenaL
            // 
            this.cenaL.Location = new System.Drawing.Point(101, 45);
            this.cenaL.Name = "cenaL";
            this.cenaL.Size = new System.Drawing.Size(40, 13);
            this.cenaL.TabIndex = 4;
            this.cenaL.Text = "4";
            this.cenaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // vahaL
            // 
            this.vahaL.Location = new System.Drawing.Point(29, 45);
            this.vahaL.Name = "vahaL";
            this.vahaL.Size = new System.Drawing.Size(40, 13);
            this.vahaL.TabIndex = 3;
            this.vahaL.Text = "10";
            this.vahaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Váha";
            // 
            // jmenoL
            // 
            this.jmenoL.AutoSize = true;
            this.jmenoL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jmenoL.Location = new System.Drawing.Point(3, 0);
            this.jmenoL.Name = "jmenoL";
            this.jmenoL.Size = new System.Drawing.Size(41, 13);
            this.jmenoL.TabIndex = 0;
            this.jmenoL.Text = "label1";
            // 
            // newB
            // 
            this.newB.Location = new System.Drawing.Point(114, 325);
            this.newB.Name = "newB";
            this.newB.Size = new System.Drawing.Size(100, 23);
            this.newB.TabIndex = 5;
            this.newB.Text = "Vytvořit nový";
            this.newB.UseVisualStyleBackColor = true;
            this.newB.Click += new System.EventHandler(this.newB_Click);
            // 
            // specB
            // 
            this.specB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.specB.Location = new System.Drawing.Point(10, 274);
            this.specB.Name = "specB";
            this.specB.Size = new System.Drawing.Size(147, 23);
            this.specB.TabIndex = 6;
            this.specB.Text = "Speciální vlastnosti";
            this.specB.UseVisualStyleBackColor = true;
            this.specB.Click += new System.EventHandler(this.specB_Click);
            // 
            // newPredmet
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(398, 360);
            this.Controls.Add(this.newB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "newPredmet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Předměty";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cenaks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cenaL;
        private System.Windows.Forms.Label vahaL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label jmenoL;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown ksN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newB;
        private System.Windows.Forms.Label celkemL;
        private System.Windows.Forms.CheckBox zaplatitCh;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown cenaks;
        private System.Windows.Forms.TextBox owNameT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button specB;
    }
}