namespace GUREANOS_ERRONKA.FORMS
{
    partial class ALDATU
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
            btnaldatu = new Button();
            btnaldatuirten = new Button();
            btnaldatuatzera = new Button();
            dataaldatu = new DataGridView();
            panel1 = new Panel();
            txtkokalekua = new ComboBox();
            data = new DateTimePicker();
            txtMarka = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelor = new Panel();
            txtCPU = new TextBox();
            txtROM = new TextBox();
            txtRAM = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            panelin = new Panel();
            txtteknologia = new TextBox();
            chkkolore = new CheckBox();
            label5 = new Label();
            radioinprimagailua = new RadioButton();
            radioordenagailua = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataaldatu).BeginInit();
            panel1.SuspendLayout();
            panelor.SuspendLayout();
            panelin.SuspendLayout();
            SuspendLayout();
            // 
            // btnaldatu
            // 
            btnaldatu.Location = new Point(325, 361);
            btnaldatu.Name = "btnaldatu";
            btnaldatu.Size = new Size(150, 44);
            btnaldatu.TabIndex = 10;
            btnaldatu.Text = "ALDATU";
            btnaldatu.UseVisualStyleBackColor = true;
            btnaldatu.Click += btnaldatu_Click;
            // 
            // btnaldatuirten
            // 
            btnaldatuirten.Location = new Point(571, 361);
            btnaldatuirten.Name = "btnaldatuirten";
            btnaldatuirten.Size = new Size(150, 44);
            btnaldatuirten.TabIndex = 9;
            btnaldatuirten.Text = "IRTEN";
            btnaldatuirten.UseVisualStyleBackColor = true;
            btnaldatuirten.Click += btnaldatuirten_Click;
            // 
            // btnaldatuatzera
            // 
            btnaldatuatzera.Location = new Point(80, 361);
            btnaldatuatzera.Name = "btnaldatuatzera";
            btnaldatuatzera.Size = new Size(150, 44);
            btnaldatuatzera.TabIndex = 8;
            btnaldatuatzera.Text = "ATZERA";
            btnaldatuatzera.UseVisualStyleBackColor = true;
            btnaldatuatzera.Click += btnaldatuatzera_Click;
            // 
            // dataaldatu
            // 
            dataaldatu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataaldatu.Location = new Point(80, 29);
            dataaldatu.Name = "dataaldatu";
            dataaldatu.RowHeadersWidth = 51;
            dataaldatu.Size = new Size(363, 185);
            dataaldatu.TabIndex = 7;
            dataaldatu.CellContentClick += dataaldatu_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtkokalekua);
            panel1.Controls.Add(data);
            panel1.Controls.Add(txtMarka);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(80, 220);
            panel1.Name = "panel1";
            panel1.Size = new Size(363, 125);
            panel1.TabIndex = 11;
            // 
            // txtkokalekua
            // 
            txtkokalekua.FormattingEnabled = true;
            txtkokalekua.Location = new Point(113, 53);
            txtkokalekua.Name = "txtkokalekua";
            txtkokalekua.Size = new Size(151, 28);
            txtkokalekua.TabIndex = 6;
            txtkokalekua.SelectedIndexChanged += txtkokalekua_SelectedIndexChanged;
            // 
            // data
            // 
            data.Location = new Point(113, 93);
            data.Name = "data";
            data.Size = new Size(250, 27);
            data.TabIndex = 5;
            // 
            // txtMarka
            // 
            txtMarka.Location = new Point(113, 11);
            txtMarka.Name = "txtMarka";
            txtMarka.Size = new Size(125, 27);
            txtMarka.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 93);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 2;
            label3.Text = "Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 53);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Kokalekua";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 11);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Marka";
            // 
            // panelor
            // 
            panelor.Controls.Add(txtCPU);
            panelor.Controls.Add(txtROM);
            panelor.Controls.Add(txtRAM);
            panelor.Controls.Add(label8);
            panelor.Controls.Add(label7);
            panelor.Controls.Add(label6);
            panelor.Location = new Point(461, 215);
            panelor.Name = "panelor";
            panelor.Size = new Size(257, 130);
            panelor.TabIndex = 12;
            panelor.Paint += panel2_Paint;
            // 
            // txtCPU
            // 
            txtCPU.Location = new Point(122, 95);
            txtCPU.Name = "txtCPU";
            txtCPU.Size = new Size(125, 27);
            txtCPU.TabIndex = 8;
            // 
            // txtROM
            // 
            txtROM.Location = new Point(122, 55);
            txtROM.Name = "txtROM";
            txtROM.Size = new Size(125, 27);
            txtROM.TabIndex = 7;
            // 
            // txtRAM
            // 
            txtRAM.Location = new Point(122, 10);
            txtRAM.Name = "txtRAM";
            txtRAM.Size = new Size(125, 27);
            txtRAM.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 102);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 5;
            label8.Text = "CPU";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 55);
            label7.Name = "label7";
            label7.Size = new Size(42, 20);
            label7.TabIndex = 4;
            label7.Text = "ROM";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 10);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 3;
            label6.Text = "RAM";
            // 
            // panelin
            // 
            panelin.Controls.Add(txtteknologia);
            panelin.Controls.Add(chkkolore);
            panelin.Controls.Add(label5);
            panelin.Location = new Point(471, 215);
            panelin.Name = "panelin";
            panelin.Size = new Size(250, 125);
            panelin.TabIndex = 13;
            // 
            // txtteknologia
            // 
            txtteknologia.Location = new Point(115, 93);
            txtteknologia.Name = "txtteknologia";
            txtteknologia.Size = new Size(125, 27);
            txtteknologia.TabIndex = 6;
            // 
            // chkkolore
            // 
            chkkolore.AutoSize = true;
            chkkolore.Location = new Point(24, 31);
            chkkolore.Name = "chkkolore";
            chkkolore.RightToLeft = RightToLeft.Yes;
            chkkolore.Size = new Size(112, 24);
            chkkolore.TabIndex = 5;
            chkkolore.Text = "Koloretakoa";
            chkkolore.UseVisualStyleBackColor = true;
            chkkolore.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 96);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 4;
            label5.Text = "Teknologia:";
            // 
            // radioinprimagailua
            // 
            radioinprimagailua.AutoSize = true;
            radioinprimagailua.Location = new Point(472, 123);
            radioinprimagailua.Name = "radioinprimagailua";
            radioinprimagailua.Size = new Size(122, 24);
            radioinprimagailua.TabIndex = 15;
            radioinprimagailua.TabStop = true;
            radioinprimagailua.Text = "Inprimagailua";
            radioinprimagailua.UseVisualStyleBackColor = true;
            radioinprimagailua.CheckedChanged += radioinprimagailua_CheckedChanged;
            // 
            // radioordenagailua
            // 
            radioordenagailua.AutoSize = true;
            radioordenagailua.Location = new Point(471, 46);
            radioordenagailua.Name = "radioordenagailua";
            radioordenagailua.Size = new Size(120, 24);
            radioordenagailua.TabIndex = 14;
            radioordenagailua.TabStop = true;
            radioordenagailua.Text = "Ordenagailua";
            radioordenagailua.UseVisualStyleBackColor = true;
            radioordenagailua.CheckedChanged += radioordenagailua_CheckedChanged;
            // 
            // ALDATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(radioinprimagailua);
            Controls.Add(panelor);
            Controls.Add(radioordenagailua);
            Controls.Add(panelin);
            Controls.Add(panel1);
            Controls.Add(btnaldatu);
            Controls.Add(btnaldatuirten);
            Controls.Add(btnaldatuatzera);
            Controls.Add(dataaldatu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ALDATU";
            Load += ALDATU_Load;
            ((System.ComponentModel.ISupportInitialize)dataaldatu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelor.ResumeLayout(false);
            panelor.PerformLayout();
            panelin.ResumeLayout(false);
            panelin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnaldatu;
        private Button btnaldatuirten;
        private Button btnaldatuatzera;
        private DataGridView dataaldatu;
        private Panel panel1;
        private TextBox textBox3;
        private TextBox txtMarka;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelor;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private Panel panelin;
        private TextBox txttekno;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private CheckBox chkkolore;
        private DateTimePicker data;
        private TextBox txtCPU;
        private TextBox txtROM;
        private TextBox txtRAM;
        private TextBox txtteknologia;
        private RadioButton radioinprimagailua;
        private RadioButton radioordenagailua;
        private ComboBox txtkokalekua;
    }
}