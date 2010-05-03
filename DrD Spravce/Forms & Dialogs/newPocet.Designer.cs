namespace WindowsFormsApplication1
{
    partial class newPocet
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
            this.r1 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.pocetN = new System.Windows.Forms.NumericUpDown();
            this.okB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pocetN)).BeginInit();
            this.SuspendLayout();
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Checked = true;
            this.r1.Location = new System.Drawing.Point(12, 12);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(80, 17);
            this.r1.TabIndex = 0;
            this.r1.TabStop = true;
            this.r1.Text = "Nový počet";
            this.r1.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(12, 35);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(53, 17);
            this.r2.TabIndex = 1;
            this.r2.Text = "Přidat";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // r3
            // 
            this.r3.AutoSize = true;
            this.r3.Location = new System.Drawing.Point(12, 58);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(63, 17);
            this.r3.TabIndex = 2;
            this.r3.Text = "Odebrat";
            this.r3.UseVisualStyleBackColor = true;
            // 
            // pocetN
            // 
            this.pocetN.Location = new System.Drawing.Point(54, 86);
            this.pocetN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pocetN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pocetN.Name = "pocetN";
            this.pocetN.Size = new System.Drawing.Size(77, 20);
            this.pocetN.TabIndex = 3;
            this.pocetN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okB
            // 
            this.okB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okB.Location = new System.Drawing.Point(14, 120);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 4;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(95, 120);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 5;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // newPocet
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(184, 155);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.pocetN);
            this.Controls.Add(this.r3);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.r1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newPocet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Změnit počet";
            ((System.ComponentModel.ISupportInitialize)(this.pocetN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton r1;
        private System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.RadioButton r3;
        private System.Windows.Forms.NumericUpDown pocetN;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Button cancelB;
    }
}