namespace WindowsFormsApplication1
{
    partial class newPredmetDialog
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
            this.vahaL = new System.Windows.Forms.NumericUpDown();
            this.cenaL = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.kategorieList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.vahaL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cenaL)).BeginInit();
            this.SuspendLayout();
            // 
            // jmenoL
            // 
            this.jmenoL.Location = new System.Drawing.Point(110, 12);
            this.jmenoL.Name = "jmenoL";
            this.jmenoL.Size = new System.Drawing.Size(151, 20);
            this.jmenoL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Název předmětu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Váha:";
            // 
            // vahaL
            // 
            this.vahaL.DecimalPlaces = 2;
            this.vahaL.Location = new System.Drawing.Point(110, 65);
            this.vahaL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.vahaL.Name = "vahaL";
            this.vahaL.Size = new System.Drawing.Size(66, 20);
            this.vahaL.TabIndex = 3;
            // 
            // cenaL
            // 
            this.cenaL.DecimalPlaces = 2;
            this.cenaL.Location = new System.Drawing.Point(110, 91);
            this.cenaL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.cenaL.Name = "cenaL";
            this.cenaL.Size = new System.Drawing.Size(66, 20);
            this.cenaL.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cena:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "zl";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "kg";
            // 
            // saveB
            // 
            this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveB.Location = new System.Drawing.Point(50, 143);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(130, 23);
            this.saveB.TabIndex = 5;
            this.saveB.Text = "Uložit do databáze";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.okB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(186, 143);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 6;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kategorie";
            // 
            // kategorieList
            // 
            this.kategorieList.FormattingEnabled = true;
            this.kategorieList.Location = new System.Drawing.Point(110, 38);
            this.kategorieList.Name = "kategorieList";
            this.kategorieList.Size = new System.Drawing.Size(151, 21);
            this.kategorieList.TabIndex = 2;
            // 
            // newPredmetDialog
            // 
            this.AcceptButton = this.saveB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(273, 178);
            this.Controls.Add(this.kategorieList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cenaL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vahaL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jmenoL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newPredmetDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nový předmět";
            this.Load += new System.EventHandler(this.newPredmetDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vahaL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cenaL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox jmenoL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown vahaL;
        private System.Windows.Forms.NumericUpDown cenaL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox kategorieList;
    }
}