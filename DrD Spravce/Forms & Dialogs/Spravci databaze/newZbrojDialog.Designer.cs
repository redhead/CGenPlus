namespace WindowsFormsApplication1
{
    partial class newZbrojDialog
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
            this.cancelB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.ochranaN = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.omezeniN = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pSilaN = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jmenoL = new System.Windows.Forms.TextBox();
            this.vahaN = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ochranaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.omezeniN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSilaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vahaN)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(170, 150);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 7;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // saveB
            // 
            this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveB.Location = new System.Drawing.Point(32, 150);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(132, 23);
            this.saveB.TabIndex = 6;
            this.saveB.Text = "Uložit do databáze";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // ochranaN
            // 
            this.ochranaN.Location = new System.Drawing.Point(108, 92);
            this.ochranaN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ochranaN.Name = "ochranaN";
            this.ochranaN.Size = new System.Drawing.Size(58, 20);
            this.ochranaN.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ochrana:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Omezení:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Potřebná síla:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Název:";
            // 
            // jmenoL
            // 
            this.jmenoL.Location = new System.Drawing.Point(108, 12);
            this.jmenoL.Name = "jmenoL";
            this.jmenoL.Size = new System.Drawing.Size(137, 20);
            this.jmenoL.TabIndex = 1;
            // 
            // vahaN
            // 
            this.vahaN.DecimalPlaces = 2;
            this.vahaN.Location = new System.Drawing.Point(108, 118);
            this.vahaN.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.vahaN.Name = "vahaN";
            this.vahaN.Size = new System.Drawing.Size(58, 20);
            this.vahaN.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Váha:";
            // 
            // newZbrojDialog
            // 
            this.AcceptButton = this.saveB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(257, 185);
            this.Controls.Add(this.vahaN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.ochranaN);
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
            this.Name = "newZbrojDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nová zbroj";
            ((System.ComponentModel.ISupportInitialize)(this.ochranaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.omezeniN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSilaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vahaN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.NumericUpDown ochranaN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown omezeniN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown pSilaN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jmenoL;
        private System.Windows.Forms.NumericUpDown vahaN;
        private System.Windows.Forms.Label label5;
    }
}