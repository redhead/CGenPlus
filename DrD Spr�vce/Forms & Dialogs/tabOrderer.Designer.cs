namespace WindowsFormsApplication1
{
    partial class tabOrderer
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
            this.upB = new System.Windows.Forms.Button();
            this.downB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(12, 12);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(120, 82);
            this.list.TabIndex = 0;
            // 
            // upB
            // 
            this.upB.Location = new System.Drawing.Point(138, 12);
            this.upB.Name = "upB";
            this.upB.Size = new System.Drawing.Size(73, 23);
            this.upB.TabIndex = 1;
            this.upB.Text = "Nahoru";
            this.upB.UseVisualStyleBackColor = true;
            this.upB.Click += new System.EventHandler(this.upB_Click);
            // 
            // downB
            // 
            this.downB.Location = new System.Drawing.Point(138, 41);
            this.downB.Name = "downB";
            this.downB.Size = new System.Drawing.Size(73, 23);
            this.downB.TabIndex = 2;
            this.downB.Text = "Dolu";
            this.downB.UseVisualStyleBackColor = true;
            this.downB.Click += new System.EventHandler(this.downB_Click);
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(136, 107);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 3;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Location = new System.Drawing.Point(55, 107);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 4;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // tabOrderer
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(223, 142);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.downB);
            this.Controls.Add(this.upB);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "tabOrderer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pořadí záložek";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Button upB;
        private System.Windows.Forms.Button downB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button okB;
    }
}