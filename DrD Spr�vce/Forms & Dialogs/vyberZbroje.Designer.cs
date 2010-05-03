namespace WindowsFormsApplication1
{
    partial class vyberZbroje
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
            this.zbrojeList = new System.Windows.Forms.ListBox();
            this.zJmenoL = new System.Windows.Forms.Label();
            this.pJmenoL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zOchranaL = new System.Windows.Forms.Label();
            this.zOmezeniL = new System.Windows.Forms.Label();
            this.zpSilaL = new System.Windows.Forms.Label();
            this.pOchranaL = new System.Windows.Forms.Label();
            this.pOmezeniL = new System.Windows.Forms.Label();
            this.ppSilaL = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prilbyList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.dovednostL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zVahaL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pVahaL = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zbrojeList
            // 
            this.zbrojeList.FormattingEnabled = true;
            this.zbrojeList.Location = new System.Drawing.Point(17, 25);
            this.zbrojeList.Name = "zbrojeList";
            this.zbrojeList.Size = new System.Drawing.Size(181, 121);
            this.zbrojeList.TabIndex = 0;
            this.zbrojeList.SelectedIndexChanged += new System.EventHandler(this.zbrojeList_SelectedIndexChanged);
            // 
            // zJmenoL
            // 
            this.zJmenoL.AutoSize = true;
            this.zJmenoL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zJmenoL.Location = new System.Drawing.Point(213, 25);
            this.zJmenoL.Name = "zJmenoL";
            this.zJmenoL.Size = new System.Drawing.Size(41, 13);
            this.zJmenoL.TabIndex = 4;
            this.zJmenoL.Text = "label3";
            // 
            // pJmenoL
            // 
            this.pJmenoL.AutoSize = true;
            this.pJmenoL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pJmenoL.Location = new System.Drawing.Point(213, 25);
            this.pJmenoL.Name = "pJmenoL";
            this.pJmenoL.Size = new System.Drawing.Size(41, 13);
            this.pJmenoL.TabIndex = 5;
            this.pJmenoL.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Potřebná\r\nsíla";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Omezení";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ochrana";
            // 
            // zOchranaL
            // 
            this.zOchranaL.Location = new System.Drawing.Point(336, 78);
            this.zOchranaL.Name = "zOchranaL";
            this.zOchranaL.Size = new System.Drawing.Size(48, 13);
            this.zOchranaL.TabIndex = 11;
            this.zOchranaL.Text = "2";
            this.zOchranaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // zOmezeniL
            // 
            this.zOmezeniL.Location = new System.Drawing.Point(275, 78);
            this.zOmezeniL.Name = "zOmezeniL";
            this.zOmezeniL.Size = new System.Drawing.Size(50, 13);
            this.zOmezeniL.TabIndex = 10;
            this.zOmezeniL.Text = "2";
            this.zOmezeniL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // zpSilaL
            // 
            this.zpSilaL.Location = new System.Drawing.Point(213, 78);
            this.zpSilaL.Name = "zpSilaL";
            this.zpSilaL.Size = new System.Drawing.Size(51, 13);
            this.zpSilaL.TabIndex = 9;
            this.zpSilaL.Text = "2";
            this.zpSilaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pOchranaL
            // 
            this.pOchranaL.Location = new System.Drawing.Point(336, 78);
            this.pOchranaL.Name = "pOchranaL";
            this.pOchranaL.Size = new System.Drawing.Size(48, 13);
            this.pOchranaL.TabIndex = 17;
            this.pOchranaL.Text = "2";
            this.pOchranaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pOmezeniL
            // 
            this.pOmezeniL.Location = new System.Drawing.Point(275, 78);
            this.pOmezeniL.Name = "pOmezeniL";
            this.pOmezeniL.Size = new System.Drawing.Size(50, 13);
            this.pOmezeniL.TabIndex = 16;
            this.pOmezeniL.Text = "2";
            this.pOmezeniL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ppSilaL
            // 
            this.ppSilaL.Location = new System.Drawing.Point(213, 78);
            this.ppSilaL.Name = "ppSilaL";
            this.ppSilaL.Size = new System.Drawing.Size(51, 13);
            this.ppSilaL.TabIndex = 15;
            this.ppSilaL.Text = "2";
            this.ppSilaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Ochrana";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(275, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Omezení";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 26);
            this.label14.TabIndex = 12;
            this.label14.Text = "Potřebná\r\nsíla";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.zVahaL);
            this.groupBox1.Controls.Add(this.zbrojeList);
            this.groupBox1.Controls.Add(this.zJmenoL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.zpSilaL);
            this.groupBox1.Controls.Add(this.zOmezeniL);
            this.groupBox1.Controls.Add(this.zOchranaL);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 157);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zbroje";
            // 
            // prilbyList
            // 
            this.prilbyList.FormattingEnabled = true;
            this.prilbyList.Location = new System.Drawing.Point(17, 25);
            this.prilbyList.Name = "prilbyList";
            this.prilbyList.Size = new System.Drawing.Size(181, 121);
            this.prilbyList.TabIndex = 1;
            this.prilbyList.SelectedIndexChanged += new System.EventHandler(this.prilbyList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pVahaL);
            this.groupBox2.Controls.Add(this.prilbyList);
            this.groupBox2.Controls.Add(this.pJmenoL);
            this.groupBox2.Controls.Add(this.pOchranaL);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.pOmezeniL);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.ppSilaL);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 157);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Přilby";
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(379, 376);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 4;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(298, 375);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 3;
            this.okB.Text = "Vybrat";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // dovednostL
            // 
            this.dovednostL.Location = new System.Drawing.Point(152, 341);
            this.dovednostL.Name = "dovednostL";
            this.dovednostL.Size = new System.Drawing.Size(302, 13);
            this.dovednostL.TabIndex = 19;
            this.dovednostL.Text = "Dovednost nošení zbroje:";
            this.dovednostL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Váha";
            // 
            // zVahaL
            // 
            this.zVahaL.Location = new System.Drawing.Point(388, 78);
            this.zVahaL.Name = "zVahaL";
            this.zVahaL.Size = new System.Drawing.Size(48, 13);
            this.zVahaL.TabIndex = 13;
            this.zVahaL.Text = "2";
            this.zVahaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Váha";
            // 
            // pVahaL
            // 
            this.pVahaL.Location = new System.Drawing.Point(388, 78);
            this.pVahaL.Name = "pVahaL";
            this.pVahaL.Size = new System.Drawing.Size(48, 13);
            this.pVahaL.TabIndex = 19;
            this.pVahaL.Text = "2";
            this.pVahaL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // vyberZbroje
            // 
            this.AcceptButton = this.okB;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(466, 410);
            this.Controls.Add(this.dovednostL);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "vyberZbroje";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Výběr zbroje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox zbrojeList;
        public System.Windows.Forms.Label zJmenoL;
        public System.Windows.Forms.Label pJmenoL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label zOchranaL;
        public System.Windows.Forms.Label zOmezeniL;
        public System.Windows.Forms.Label zpSilaL;
        public System.Windows.Forms.Label pOchranaL;
        public System.Windows.Forms.Label pOmezeniL;
        public System.Windows.Forms.Label ppSilaL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox prilbyList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Label dovednostL;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label zVahaL;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label pVahaL;
    }
}