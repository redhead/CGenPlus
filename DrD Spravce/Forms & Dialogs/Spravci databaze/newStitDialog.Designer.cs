namespace WindowsFormsApplication1
{
    partial class newStitDialog
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
            this.jmenoL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pSilaN = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.omezeniN = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.utocnostN = new System.Windows.Forms.NumericUpDown();
            this.zraneniN = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.typList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.krytN = new System.Windows.Forms.NumericUpDown();
            this.saveB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.vahaN = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pSilaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.omezeniN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utocnostN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zraneniN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krytN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vahaN)).BeginInit();
            this.SuspendLayout();
            // 
            // jmenoL
            // 
            this.jmenoL.Location = new System.Drawing.Point(108, 12);
            this.jmenoL.Name = "jmenoL";
            this.jmenoL.Size = new System.Drawing.Size(137, 20);
            this.jmenoL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Název štítu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Potřebná síla:";
            // 
            // pSilaN
            // 
            this.pSilaN.Location = new System.Drawing.Point(108, 40);
            this.pSilaN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.pSilaN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.pSilaN.Name = "pSilaN";
            this.pSilaN.Size = new System.Drawing.Size(58, 20);
            this.pSilaN.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(179, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "žádná";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Omezení:";
            // 
            // omezeniN
            // 
            this.omezeniN.Location = new System.Drawing.Point(108, 66);
            this.omezeniN.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.omezeniN.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.omezeniN.Name = "omezeniN";
            this.omezeniN.Size = new System.Drawing.Size(58, 20);
            this.omezeniN.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Útočnost:";
            // 
            // utocnostN
            // 
            this.utocnostN.Location = new System.Drawing.Point(108, 92);
            this.utocnostN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.utocnostN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.utocnostN.Name = "utocnostN";
            this.utocnostN.Size = new System.Drawing.Size(58, 20);
            this.utocnostN.TabIndex = 5;
            // 
            // zraneniN
            // 
            this.zraneniN.Location = new System.Drawing.Point(108, 118);
            this.zraneniN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.zraneniN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.zraneniN.Name = "zraneniN";
            this.zraneniN.Size = new System.Drawing.Size(58, 20);
            this.zraneniN.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Zranění:";
            // 
            // typList
            // 
            this.typList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typList.FormattingEnabled = true;
            this.typList.Items.AddRange(new object[] {
            "B",
            "S",
            "D"});
            this.typList.Location = new System.Drawing.Point(108, 144);
            this.typList.Name = "typList";
            this.typList.Size = new System.Drawing.Size(58, 21);
            this.typList.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Typ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kryt:";
            // 
            // krytN
            // 
            this.krytN.Location = new System.Drawing.Point(108, 171);
            this.krytN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.krytN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.krytN.Name = "krytN";
            this.krytN.Size = new System.Drawing.Size(58, 20);
            this.krytN.TabIndex = 8;
            // 
            // saveB
            // 
            this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveB.Location = new System.Drawing.Point(32, 237);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(132, 23);
            this.saveB.TabIndex = 9;
            this.saveB.Text = "Uložit do databáze";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(170, 237);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 10;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // vahaN
            // 
            this.vahaN.DecimalPlaces = 2;
            this.vahaN.Location = new System.Drawing.Point(108, 197);
            this.vahaN.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.vahaN.Name = "vahaN";
            this.vahaN.Size = new System.Drawing.Size(58, 20);
            this.vahaN.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Váha:";
            // 
            // newStitDialog
            // 
            this.AcceptButton = this.saveB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(257, 272);
            this.Controls.Add(this.vahaN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.krytN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.typList);
            this.Controls.Add(this.zraneniN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.utocnostN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.omezeniN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pSilaN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jmenoL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newStitDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nový štít";
            ((System.ComponentModel.ISupportInitialize)(this.pSilaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.omezeniN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utocnostN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zraneniN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krytN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vahaN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox jmenoL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pSilaN;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown omezeniN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown utocnostN;
        private System.Windows.Forms.NumericUpDown zraneniN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox typList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown krytN;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.NumericUpDown vahaN;
        private System.Windows.Forms.Label label8;
    }
}