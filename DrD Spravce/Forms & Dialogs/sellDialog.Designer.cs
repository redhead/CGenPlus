namespace WindowsFormsApplication1
{
    partial class sellDialog
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
            this.penezN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.sellB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ksN = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.penezN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksN)).BeginInit();
            this.SuspendLayout();
            // 
            // penezN
            // 
            this.penezN.DecimalPlaces = 2;
            this.penezN.Location = new System.Drawing.Point(87, 13);
            this.penezN.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.penezN.Name = "penezN";
            this.penezN.Size = new System.Drawing.Size(84, 20);
            this.penezN.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cena / ks:";
            // 
            // sellB
            // 
            this.sellB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sellB.Location = new System.Drawing.Point(18, 80);
            this.sellB.Name = "sellB";
            this.sellB.Size = new System.Drawing.Size(75, 23);
            this.sellB.TabIndex = 2;
            this.sellB.Text = "Prodat";
            this.sellB.UseVisualStyleBackColor = true;
            this.sellB.Click += new System.EventHandler(this.sellB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(96, 80);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 3;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kusů:";
            // 
            // ksN
            // 
            this.ksN.Location = new System.Drawing.Point(87, 39);
            this.ksN.Name = "ksN";
            this.ksN.Size = new System.Drawing.Size(84, 20);
            this.ksN.TabIndex = 4;
            // 
            // sellDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(183, 115);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ksN);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.sellB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.penezN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sellDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prodat";
            ((System.ComponentModel.ISupportInitialize)(this.penezN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown penezN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sellB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ksN;
    }
}