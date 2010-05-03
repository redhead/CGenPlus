namespace WindowsFormsApplication1
{
    partial class zbrojeDataDialog
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
            this.okB = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.newB = new System.Windows.Forms.Button();
            this.list1 = new System.Windows.Forms.ListBox();
            this.editB = new System.Windows.Forms.Button();
            this.list2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(263, 295);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(97, 23);
            this.okB.TabIndex = 9;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // deleteB
            // 
            this.deleteB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteB.Location = new System.Drawing.Point(263, 70);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(97, 23);
            this.deleteB.TabIndex = 4;
            this.deleteB.Text = "Smazat";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // newB
            // 
            this.newB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newB.Location = new System.Drawing.Point(263, 12);
            this.newB.Name = "newB";
            this.newB.Size = new System.Drawing.Size(97, 23);
            this.newB.TabIndex = 2;
            this.newB.Text = "Nová zbroj";
            this.newB.UseVisualStyleBackColor = true;
            this.newB.Click += new System.EventHandler(this.newB_Click);
            // 
            // list1
            // 
            this.list1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list1.FormattingEnabled = true;
            this.list1.IntegralHeight = false;
            this.list1.Location = new System.Drawing.Point(12, 12);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(245, 150);
            this.list1.TabIndex = 1;
            // 
            // editB
            // 
            this.editB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editB.Location = new System.Drawing.Point(263, 41);
            this.editB.Name = "editB";
            this.editB.Size = new System.Drawing.Size(97, 23);
            this.editB.TabIndex = 3;
            this.editB.Text = "Upravit";
            this.editB.UseVisualStyleBackColor = true;
            this.editB.Click += new System.EventHandler(this.editB_Click);
            // 
            // list2
            // 
            this.list2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list2.FormattingEnabled = true;
            this.list2.IntegralHeight = false;
            this.list2.Location = new System.Drawing.Point(12, 168);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(245, 150);
            this.list2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(263, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Smazat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteB2_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(263, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Nová přilba";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.newB2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(263, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Upravit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.editB2_Click);
            // 
            // zbrojeDataDialog
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.list2);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.deleteB);
            this.Controls.Add(this.newB);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.editB);
            this.MinimumSize = new System.Drawing.Size(180, 326);
            this.Name = "zbrojeDataDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Databáze zbrojí a přileb";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button newB;
        private System.Windows.Forms.ListBox list1;
        private System.Windows.Forms.Button editB;
        private System.Windows.Forms.ListBox list2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}