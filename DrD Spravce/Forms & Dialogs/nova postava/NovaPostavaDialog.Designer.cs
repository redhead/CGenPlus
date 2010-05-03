namespace WindowsFormsApplication1
{
    partial class NovaPostavaDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pohlavi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.povolani = new System.Windows.Forms.ComboBox();
            this.rasa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jmenoPostavy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jméno postavy:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pohlavi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cancelB);
            this.groupBox1.Controls.Add(this.okB);
            this.groupBox1.Controls.Add(this.povolani);
            this.groupBox1.Controls.Add(this.rasa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.jmenoPostavy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 183);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rysy postavy";
            // 
            // pohlavi
            // 
            this.pohlavi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pohlavi.FormattingEnabled = true;
            this.pohlavi.Items.AddRange(new object[] {
            "Muž",
            "Žena"});
            this.pohlavi.Location = new System.Drawing.Point(101, 76);
            this.pohlavi.Name = "pohlavi";
            this.pohlavi.Size = new System.Drawing.Size(148, 21);
            this.pohlavi.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pohlaví:";
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(174, 144);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 6;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(93, 144);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 5;
            this.okB.Text = "Dále";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.button1_Click);
            // 
            // povolani
            // 
            this.povolani.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.povolani.FormattingEnabled = true;
            this.povolani.Location = new System.Drawing.Point(101, 103);
            this.povolani.Name = "povolani";
            this.povolani.Size = new System.Drawing.Size(148, 21);
            this.povolani.TabIndex = 4;
            // 
            // rasa
            // 
            this.rasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rasa.FormattingEnabled = true;
            this.rasa.Location = new System.Drawing.Point(101, 49);
            this.rasa.Name = "rasa";
            this.rasa.Size = new System.Drawing.Size(148, 21);
            this.rasa.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Povolání:";
            // 
            // jmenoPostavy
            // 
            this.jmenoPostavy.Location = new System.Drawing.Point(101, 23);
            this.jmenoPostavy.Name = "jmenoPostavy";
            this.jmenoPostavy.Size = new System.Drawing.Size(148, 20);
            this.jmenoPostavy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rasa:";
            // 
            // NovaPostavaDialog
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(290, 207);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NovaPostavaDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nová postava";
            this.Load += new System.EventHandler(this.NovaPostava_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.ComboBox povolani;
        private System.Windows.Forms.ComboBox rasa;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.TextBox jmenoPostavy;
        private System.Windows.Forms.ComboBox pohlavi;
        private System.Windows.Forms.Label label4;
    }
}