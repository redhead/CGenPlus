namespace WindowsFormsApplication1
{
    partial class newZbranDialog
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
            this.zJmenoL = new System.Windows.Forms.TextBox();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.zKrytN = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.zTypList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.zUtocnostN = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.zDelkaN = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.zpSilaN = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.zKategorieList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sKategorieList = new System.Windows.Forms.ComboBox();
            this.sDostrelN = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sTypList = new System.Windows.Forms.ComboBox();
            this.sZraneniN = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.sUtocnostN = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.sMaxSilaN = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.spSilaN = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.sJmenoL = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.saveB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.zZraneniN = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.zVaha = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.sVaha = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.zKrytN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zUtocnostN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zDelkaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zpSilaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDostrelN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sZraneniN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUtocnostN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMaxSilaN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSilaN)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zZraneniN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zVaha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVaha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název zbraně:";
            // 
            // zJmenoL
            // 
            this.zJmenoL.Location = new System.Drawing.Point(116, 4);
            this.zJmenoL.Name = "zJmenoL";
            this.zJmenoL.Size = new System.Drawing.Size(149, 20);
            this.zJmenoL.TabIndex = 3;
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(12, 12);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(84, 17);
            this.r1.TabIndex = 1;
            this.r1.Text = "Ruční zbraň";
            this.r1.UseVisualStyleBackColor = true;
            this.r1.CheckedChanged += new System.EventHandler(this.r1_CheckedChanged);
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(299, 12);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(130, 17);
            this.r2.TabIndex = 2;
            this.r2.Text = "Střelná / vrhací zbraň";
            this.r2.UseVisualStyleBackColor = true;
            this.r2.CheckedChanged += new System.EventHandler(this.r1_CheckedChanged);
            // 
            // zKrytN
            // 
            this.zKrytN.Location = new System.Drawing.Point(116, 188);
            this.zKrytN.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.zKrytN.Name = "zKrytN";
            this.zKrytN.Size = new System.Drawing.Size(58, 20);
            this.zKrytN.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Kryt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Typ:";
            // 
            // zTypList
            // 
            this.zTypList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zTypList.FormattingEnabled = true;
            this.zTypList.Items.AddRange(new object[] {
            "B",
            "S",
            "D"});
            this.zTypList.Location = new System.Drawing.Point(116, 161);
            this.zTypList.Name = "zTypList";
            this.zTypList.Size = new System.Drawing.Size(58, 21);
            this.zTypList.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Zranění:";
            // 
            // zUtocnostN
            // 
            this.zUtocnostN.Location = new System.Drawing.Point(116, 109);
            this.zUtocnostN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.zUtocnostN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.zUtocnostN.Name = "zUtocnostN";
            this.zUtocnostN.Size = new System.Drawing.Size(58, 20);
            this.zUtocnostN.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Útočnost:";
            // 
            // zDelkaN
            // 
            this.zDelkaN.Location = new System.Drawing.Point(116, 83);
            this.zDelkaN.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zDelkaN.Name = "zDelkaN";
            this.zDelkaN.Size = new System.Drawing.Size(58, 20);
            this.zDelkaN.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Délka:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(187, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "žádná";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // zpSilaN
            // 
            this.zpSilaN.Location = new System.Drawing.Point(116, 57);
            this.zpSilaN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.zpSilaN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.zpSilaN.Name = "zpSilaN";
            this.zpSilaN.Size = new System.Drawing.Size(58, 20);
            this.zpSilaN.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Potřebná síla:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 239);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(106, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Obouruční zbraň";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // zKategorieList
            // 
            this.zKategorieList.FormattingEnabled = true;
            this.zKategorieList.Location = new System.Drawing.Point(116, 30);
            this.zKategorieList.Name = "zKategorieList";
            this.zKategorieList.Size = new System.Drawing.Size(149, 21);
            this.zKategorieList.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Druh zbraně:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Druh zbraně:";
            // 
            // sKategorieList
            // 
            this.sKategorieList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sKategorieList.FormattingEnabled = true;
            this.sKategorieList.Location = new System.Drawing.Point(116, 30);
            this.sKategorieList.Name = "sKategorieList";
            this.sKategorieList.Size = new System.Drawing.Size(153, 21);
            this.sKategorieList.TabIndex = 14;
            // 
            // sDostrelN
            // 
            this.sDostrelN.Location = new System.Drawing.Point(116, 188);
            this.sDostrelN.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.sDostrelN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sDostrelN.Name = "sDostrelN";
            this.sDostrelN.Size = new System.Drawing.Size(58, 20);
            this.sDostrelN.TabIndex = 20;
            this.sDostrelN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Dostřel:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Typ:";
            // 
            // sTypList
            // 
            this.sTypList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sTypList.FormattingEnabled = true;
            this.sTypList.Items.AddRange(new object[] {
            "B",
            "S",
            "D"});
            this.sTypList.Location = new System.Drawing.Point(116, 161);
            this.sTypList.Name = "sTypList";
            this.sTypList.Size = new System.Drawing.Size(58, 21);
            this.sTypList.TabIndex = 19;
            // 
            // sZraneniN
            // 
            this.sZraneniN.Location = new System.Drawing.Point(116, 135);
            this.sZraneniN.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sZraneniN.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.sZraneniN.Name = "sZraneniN";
            this.sZraneniN.Size = new System.Drawing.Size(58, 20);
            this.sZraneniN.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Zranění:";
            // 
            // sUtocnostN
            // 
            this.sUtocnostN.Location = new System.Drawing.Point(116, 109);
            this.sUtocnostN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.sUtocnostN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.sUtocnostN.Name = "sUtocnostN";
            this.sUtocnostN.Size = new System.Drawing.Size(58, 20);
            this.sUtocnostN.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Útočnost:";
            // 
            // sMaxSilaN
            // 
            this.sMaxSilaN.Location = new System.Drawing.Point(116, 83);
            this.sMaxSilaN.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sMaxSilaN.Name = "sMaxSilaN";
            this.sMaxSilaN.Size = new System.Drawing.Size(58, 20);
            this.sMaxSilaN.TabIndex = 16;
            this.sMaxSilaN.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Maximální síla:";
            // 
            // spSilaN
            // 
            this.spSilaN.Location = new System.Drawing.Point(116, 57);
            this.spSilaN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.spSilaN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.spSilaN.Name = "spSilaN";
            this.spSilaN.Size = new System.Drawing.Size(58, 20);
            this.spSilaN.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Potřebná síla:";
            // 
            // sJmenoL
            // 
            this.sJmenoL.Location = new System.Drawing.Point(116, 4);
            this.sJmenoL.Name = "sJmenoL";
            this.sJmenoL.Size = new System.Drawing.Size(153, 20);
            this.sJmenoL.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Název zbraně:";
            // 
            // saveB
            // 
            this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveB.Location = new System.Drawing.Point(357, 288);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(130, 23);
            this.saveB.TabIndex = 21;
            this.saveB.Text = "Uložit do databáze";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(493, 288);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(75, 23);
            this.cancelB.TabIndex = 22;
            this.cancelB.Text = "Storno";
            this.cancelB.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.zVaha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zJmenoL);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.zpSilaN);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.zDelkaN);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.zUtocnostN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.zZraneniN);
            this.panel1.Controls.Add(this.zTypList);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.zKrytN);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.zKategorieList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 265);
            this.panel1.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.sJmenoL);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.sVaha);
            this.panel2.Controls.Add(this.spSilaN);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.sKategorieList);
            this.panel2.Controls.Add(this.sMaxSilaN);
            this.panel2.Controls.Add(this.sDostrelN);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.sUtocnostN);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.sTypList);
            this.panel2.Controls.Add(this.sZraneniN);
            this.panel2.Location = new System.Drawing.Point(299, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 244);
            this.panel2.TabIndex = 51;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(180, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "(u luků)";
            // 
            // zZraneniN
            // 
            this.zZraneniN.Location = new System.Drawing.Point(116, 135);
            this.zZraneniN.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.zZraneniN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.zZraneniN.Name = "zZraneniN";
            this.zZraneniN.Size = new System.Drawing.Size(58, 20);
            this.zZraneniN.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 216);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Váha:";
            // 
            // zVaha
            // 
            this.zVaha.DecimalPlaces = 2;
            this.zVaha.Location = new System.Drawing.Point(116, 214);
            this.zVaha.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.zVaha.Name = "zVaha";
            this.zVaha.Size = new System.Drawing.Size(58, 20);
            this.zVaha.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(180, 218);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "kg";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(180, 218);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "kg";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Váha:";
            // 
            // sVaha
            // 
            this.sVaha.DecimalPlaces = 2;
            this.sVaha.Location = new System.Drawing.Point(116, 214);
            this.sVaha.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sVaha.Name = "sVaha";
            this.sVaha.Size = new System.Drawing.Size(58, 20);
            this.sVaha.TabIndex = 34;
            // 
            // newZbranDialog
            // 
            this.AcceptButton = this.saveB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(584, 323);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.r2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newZbranDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nová zbraň";
            ((System.ComponentModel.ISupportInitialize)(this.zKrytN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zUtocnostN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zDelkaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zpSilaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDostrelN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sZraneniN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUtocnostN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMaxSilaN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSilaN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zZraneniN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zVaha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVaha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zJmenoL;
        public System.Windows.Forms.RadioButton r1;
        public System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.NumericUpDown zKrytN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox zTypList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown zUtocnostN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown zDelkaN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown zpSilaN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox zKategorieList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox sKategorieList;
        private System.Windows.Forms.NumericUpDown sDostrelN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox sTypList;
        private System.Windows.Forms.NumericUpDown sZraneniN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown sUtocnostN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown sMaxSilaN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown spSilaN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox sJmenoL;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown zZraneniN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown zVaha;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown sVaha;
    }
}