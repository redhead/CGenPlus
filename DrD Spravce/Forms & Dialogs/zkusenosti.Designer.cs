namespace WindowsFormsApplication1
{
    partial class zkusenosti
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.n2 = new System.Windows.Forms.NumericUpDown();
            this.n1 = new System.Windows.Forms.NumericUpDown();
            this.n3 = new System.Windows.Forms.NumericUpDown();
            this.n4 = new System.Windows.Forms.NumericUpDown();
            this.n5 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.n2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hraní postavy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Řešení překážek:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Použití schopností:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pomoc družině:";
            // 
            // n2
            // 
            this.n2.Location = new System.Drawing.Point(152, 38);
            this.n2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(39, 20);
            this.n2.TabIndex = 2;
            // 
            // n1
            // 
            this.n1.Location = new System.Drawing.Point(152, 12);
            this.n1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(39, 20);
            this.n1.TabIndex = 1;
            // 
            // n3
            // 
            this.n3.Location = new System.Drawing.Point(152, 64);
            this.n3.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.n3.Name = "n3";
            this.n3.Size = new System.Drawing.Size(39, 20);
            this.n3.TabIndex = 3;
            // 
            // n4
            // 
            this.n4.Location = new System.Drawing.Point(152, 90);
            this.n4.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.n4.Name = "n4";
            this.n4.Size = new System.Drawing.Size(39, 20);
            this.n4.TabIndex = 4;
            // 
            // n5
            // 
            this.n5.Location = new System.Drawing.Point(152, 116);
            this.n5.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.n5.Name = "n5";
            this.n5.Size = new System.Drawing.Size(39, 20);
            this.n5.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Přispění ke hře:";
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(104, 157);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 7;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Location = new System.Drawing.Point(24, 157);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 6;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // zkusenosti
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(203, 192);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.n5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.n4);
            this.Controls.Add(this.n3);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "zkusenosti";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Přidání bodů zkušenosti";
            ((System.ComponentModel.ISupportInitialize)(this.n2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown n2;
        public System.Windows.Forms.NumericUpDown n1;
        public System.Windows.Forms.NumericUpDown n3;
        public System.Windows.Forms.NumericUpDown n4;
        public System.Windows.Forms.NumericUpDown n5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button okB;
    }
}