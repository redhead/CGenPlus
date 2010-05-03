namespace WindowsFormsApplication1
{
    partial class ultraHod
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
            this.components = new System.ComponentModel.Container();
            this.posList = new System.Windows.Forms.TreeView();
            this.exprT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoditB = new System.Windows.Forms.Button();
            this.resultT = new System.Windows.Forms.TextBox();
            this.okB = new System.Windows.Forms.Button();
            this.optionB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nazevT = new System.Windows.Forms.TextBox();
            this.pasteB = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // posList
            // 
            this.posList.CheckBoxes = true;
            this.posList.Indent = 15;
            this.posList.ItemHeight = 20;
            this.posList.Location = new System.Drawing.Point(12, 27);
            this.posList.Name = "posList";
            this.posList.ShowLines = false;
            this.posList.Size = new System.Drawing.Size(138, 174);
            this.posList.TabIndex = 1;
            this.toolTip.SetToolTip(this.posList, "Vybete postavy, které chcete zahrnout do hodu");
            // 
            // exprT
            // 
            this.exprT.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exprT.Location = new System.Drawing.Point(207, 53);
            this.exprT.Name = "exprT";
            this.exprT.Size = new System.Drawing.Size(204, 20);
            this.exprT.TabIndex = 3;
            this.exprT.Text = "Sil+2k6*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zahrnout postavu/y:";
            // 
            // hoditB
            // 
            this.hoditB.Location = new System.Drawing.Point(261, 79);
            this.hoditB.Name = "hoditB";
            this.hoditB.Size = new System.Drawing.Size(75, 23);
            this.hoditB.TabIndex = 6;
            this.hoditB.Text = "Hodit";
            this.hoditB.UseVisualStyleBackColor = true;
            this.hoditB.Click += new System.EventHandler(this.hoditB_Click);
            // 
            // resultT
            // 
            this.resultT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultT.Location = new System.Drawing.Point(159, 110);
            this.resultT.Multiline = true;
            this.resultT.Name = "resultT";
            this.resultT.ReadOnly = true;
            this.resultT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultT.Size = new System.Drawing.Size(282, 91);
            this.resultT.TabIndex = 7;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.Location = new System.Drawing.Point(369, 215);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 8;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // optionB
            // 
            this.optionB.Location = new System.Drawing.Point(417, 25);
            this.optionB.Name = "optionB";
            this.optionB.Size = new System.Drawing.Size(24, 23);
            this.optionB.TabIndex = 4;
            this.optionB.Text = "...";
            this.toolTip.SetToolTip(this.optionB, "Načíst / Uložit hod");
            this.optionB.UseVisualStyleBackColor = true;
            this.optionB.Click += new System.EventHandler(this.optionB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Činnost:";
            // 
            // nazevT
            // 
            this.nazevT.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazevT.Location = new System.Drawing.Point(207, 27);
            this.nazevT.Name = "nazevT";
            this.nazevT.Size = new System.Drawing.Size(204, 20);
            this.nazevT.TabIndex = 2;
            this.nazevT.Text = "Bez názvu";
            // 
            // pasteB
            // 
            this.pasteB.Location = new System.Drawing.Point(417, 51);
            this.pasteB.Name = "pasteB";
            this.pasteB.Size = new System.Drawing.Size(24, 23);
            this.pasteB.TabIndex = 5;
            this.pasteB.Text = "<";
            this.toolTip.SetToolTip(this.pasteB, "Vložit výraz");
            this.pasteB.UseVisualStyleBackColor = true;
            this.pasteB.Click += new System.EventHandler(this.pasteB_Click);
            // 
            // ultraHod
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 250);
            this.Controls.Add(this.pasteB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazevT);
            this.Controls.Add(this.optionB);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.resultT);
            this.Controls.Add(this.hoditB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exprT);
            this.Controls.Add(this.posList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ultraHod";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hod na činnosti";
            this.Load += new System.EventHandler(this.ultraHod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView posList;
        private System.Windows.Forms.TextBox exprT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hoditB;
        private System.Windows.Forms.TextBox resultT;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Button optionB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nazevT;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button pasteB;
    }
}