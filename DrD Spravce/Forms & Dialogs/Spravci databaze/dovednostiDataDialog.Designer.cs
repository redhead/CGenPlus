namespace WindowsFormsApplication1
{
    partial class dovednostiDataDialog
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
            this.tree = new System.Windows.Forms.TreeView();
            this.okB = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.newB = new System.Windows.Forms.Button();
            this.editB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(245, 306);
            this.tree.TabIndex = 1;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(263, 295);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(97, 23);
            this.okB.TabIndex = 5;
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
            this.newB.Text = "Nová dovednost";
            this.newB.UseVisualStyleBackColor = true;
            this.newB.Click += new System.EventHandler(this.newB_Click);
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
            // zbraneDataDialog
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 330);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.deleteB);
            this.Controls.Add(this.newB);
            this.Controls.Add(this.editB);
            this.MinimumSize = new System.Drawing.Size(220, 200);
            this.Name = "zbraneDataDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Databáze dovedností";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button newB;
        private System.Windows.Forms.Button editB;
    }
}