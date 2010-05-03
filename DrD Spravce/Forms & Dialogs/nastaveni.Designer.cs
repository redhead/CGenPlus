namespace WindowsFormsApplication1
{
    partial class nastaveni
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
            this.startUpLoad = new System.Windows.Forms.CheckBox();
            this.includeSize = new System.Windows.Forms.CheckBox();
            this.okB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startUpLoad
            // 
            this.startUpLoad.AutoSize = true;
            this.startUpLoad.Location = new System.Drawing.Point(12, 12);
            this.startUpLoad.Name = "startUpLoad";
            this.startUpLoad.Size = new System.Drawing.Size(253, 17);
            this.startUpLoad.TabIndex = 0;
            this.startUpLoad.Text = "Při spuštění nahrát naposledy otevřené soubory";
            this.startUpLoad.UseVisualStyleBackColor = true;
            // 
            // includeSize
            // 
            this.includeSize.AutoSize = true;
            this.includeSize.Location = new System.Drawing.Point(12, 35);
            this.includeSize.Name = "includeSize";
            this.includeSize.Size = new System.Drawing.Size(248, 17);
            this.includeSize.TabIndex = 1;
            this.includeSize.Text = "Započítávat velikost postavy (u zbroje a přileb)";
            this.includeSize.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(116, 133);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 2;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(197, 133);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 3;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Asociovat soubory k programu CGen+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nastaveni
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.includeSize);
            this.Controls.Add(this.startUpLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "nastaveni";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nastavení";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox startUpLoad;
        private System.Windows.Forms.CheckBox includeSize;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button button1;
    }
}