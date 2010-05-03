namespace WindowsFormsApplication1
{
    partial class newDovednostDialog
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
            this.saveB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.typList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.popisT = new System.Windows.Forms.TextBox();
            this.popis1T = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.popis2T = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.popis3T = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jmenoL
            // 
            this.jmenoL.Location = new System.Drawing.Point(117, 12);
            this.jmenoL.Name = "jmenoL";
            this.jmenoL.Size = new System.Drawing.Size(144, 20);
            this.jmenoL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Název dovednosti:";
            // 
            // saveB
            // 
            this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveB.Location = new System.Drawing.Point(303, 175);
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
            this.cancelB.Location = new System.Drawing.Point(439, 175);
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
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Typ:";
            // 
            // typList
            // 
            this.typList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typList.FormattingEnabled = true;
            this.typList.Location = new System.Drawing.Point(117, 38);
            this.typList.Name = "typList";
            this.typList.Size = new System.Drawing.Size(144, 21);
            this.typList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Popis obecně:";
            // 
            // popisT
            // 
            this.popisT.Location = new System.Drawing.Point(96, 65);
            this.popisT.Multiline = true;
            this.popisT.Name = "popisT";
            this.popisT.Size = new System.Drawing.Size(165, 94);
            this.popisT.TabIndex = 13;
            // 
            // popis1T
            // 
            this.popis1T.Location = new System.Drawing.Point(351, 15);
            this.popis1T.Multiline = true;
            this.popis1T.Name = "popis1T";
            this.popis1T.Size = new System.Drawing.Size(165, 44);
            this.popis1T.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Popis 1. stupně:";
            // 
            // popis2T
            // 
            this.popis2T.Location = new System.Drawing.Point(351, 65);
            this.popis2T.Multiline = true;
            this.popis2T.Name = "popis2T";
            this.popis2T.Size = new System.Drawing.Size(165, 44);
            this.popis2T.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Popis 2. stupně:";
            // 
            // popis3T
            // 
            this.popis3T.Location = new System.Drawing.Point(351, 115);
            this.popis3T.Multiline = true;
            this.popis3T.Name = "popis3T";
            this.popis3T.Size = new System.Drawing.Size(165, 44);
            this.popis3T.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Popis 3. stupně:";
            // 
            // newDovednostDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(526, 210);
            this.Controls.Add(this.popis3T);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.popis2T);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.popis1T);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.popisT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jmenoL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newDovednostDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nový předmět";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox jmenoL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox typList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox popisT;
        private System.Windows.Forms.TextBox popis1T;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox popis2T;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox popis3T;
        private System.Windows.Forms.Label label5;
    }
}