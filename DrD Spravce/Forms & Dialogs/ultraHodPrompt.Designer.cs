namespace WindowsFormsApplication1
{
    partial class ultraHodPrompt
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
            this.list = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okB = new System.Windows.Forms.Button();
            this.dontNext = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.HorizontalScrollbar = true;
            this.list.Location = new System.Drawing.Point(12, 47);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(215, 56);
            this.list.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dovednost poskytuje více než jeden bonus.\r\nVyberte požadovaný bonus ze seznamu:";
            // 
            // okB
            // 
            this.okB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okB.Location = new System.Drawing.Point(82, 137);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 2;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // dontNext
            // 
            this.dontNext.AutoSize = true;
            this.dontNext.Checked = true;
            this.dontNext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dontNext.Location = new System.Drawing.Point(15, 109);
            this.dontNext.Name = "dontNext";
            this.dontNext.Size = new System.Drawing.Size(157, 17);
            this.dontNext.TabIndex = 3;
            this.dontNext.Text = "Neptat se pro další postavu";
            this.dontNext.UseVisualStyleBackColor = true;
            // 
            // ultraHodPrompt
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okB;
            this.ClientSize = new System.Drawing.Size(239, 172);
            this.Controls.Add(this.dontNext);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ultraHodPrompt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Výběr bonusu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okB;
        public System.Windows.Forms.CheckBox dontNext;
    }
}