namespace GUREANOS_ERRONKA.FORMS
{
    partial class GEHITU
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
            erostedata = new DateTimePicker();
            txtmarka = new TextBox();
            radioordenagailua = new RadioButton();
            txtkokalekua = new TextBox();
            radioinprimagailua = new RadioButton();
            panelInprimagailua = new Panel();
            label8 = new Label();
            txtTeknologia = new TextBox();
            chkKolore = new CheckBox();
            panelOrdenagailua = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtcpu = new TextBox();
            txtrom = new TextBox();
            txtram = new TextBox();
            btnGehitu = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btngehituatzera = new Button();
            panelInprimagailua.SuspendLayout();
            panelOrdenagailua.SuspendLayout();
            SuspendLayout();
            // 
            // erostedata
            // 
            erostedata.Location = new Point(141, 222);
            erostedata.Name = "erostedata";
            erostedata.Size = new Size(250, 27);
            erostedata.TabIndex = 0;
            erostedata.ValueChanged += erostedata_ValueChanged;
            // 
            // txtmarka
            // 
            txtmarka.Location = new Point(151, 44);
            txtmarka.Name = "txtmarka";
            txtmarka.Size = new Size(125, 27);
            txtmarka.TabIndex = 1;
            // 
            // radioordenagailua
            // 
            radioordenagailua.AutoSize = true;
            radioordenagailua.Location = new Point(463, 51);
            radioordenagailua.Name = "radioordenagailua";
            radioordenagailua.Size = new Size(120, 24);
            radioordenagailua.TabIndex = 3;
            radioordenagailua.TabStop = true;
            radioordenagailua.Text = "Ordenagailua";
            radioordenagailua.UseVisualStyleBackColor = true;
            radioordenagailua.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // txtkokalekua
            // 
            txtkokalekua.Location = new Point(151, 128);
            txtkokalekua.Name = "txtkokalekua";
            txtkokalekua.Size = new Size(125, 27);
            txtkokalekua.TabIndex = 4;
            // 
            // radioinprimagailua
            // 
            radioinprimagailua.AutoSize = true;
            radioinprimagailua.Location = new Point(464, 128);
            radioinprimagailua.Name = "radioinprimagailua";
            radioinprimagailua.Size = new Size(122, 24);
            radioinprimagailua.TabIndex = 5;
            radioinprimagailua.TabStop = true;
            radioinprimagailua.Text = "Inprimagailua";
            radioinprimagailua.UseVisualStyleBackColor = true;
            radioinprimagailua.CheckedChanged += radioinprimagailua_CheckedChanged;
            // 
            // panelInprimagailua
            // 
            panelInprimagailua.Controls.Add(label8);
            panelInprimagailua.Controls.Add(txtTeknologia);
            panelInprimagailua.Controls.Add(chkKolore);
            panelInprimagailua.Location = new Point(463, 202);
            panelInprimagailua.Name = "panelInprimagailua";
            panelInprimagailua.Size = new Size(250, 125);
            panelInprimagailua.TabIndex = 7;
            panelInprimagailua.Paint += panelInprimagailua_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 23);
            label8.Name = "label8";
            label8.Size = new Size(97, 20);
            label8.TabIndex = 16;
            label8.Text = "TEKNOLOGIA";
            // 
            // txtTeknologia
            // 
            txtTeknologia.Location = new Point(106, 20);
            txtTeknologia.Name = "txtTeknologia";
            txtTeknologia.Size = new Size(125, 27);
            txtTeknologia.TabIndex = 1;
            // 
            // chkKolore
            // 
            chkKolore.AutoSize = true;
            chkKolore.Location = new Point(91, 81);
            chkKolore.Name = "chkKolore";
            chkKolore.Size = new Size(140, 24);
            chkKolore.TabIndex = 0;
            chkKolore.Text = "Koloretakoa da?";
            chkKolore.UseVisualStyleBackColor = true;
            // 
            // panelOrdenagailua
            // 
            panelOrdenagailua.Controls.Add(label7);
            panelOrdenagailua.Controls.Add(label6);
            panelOrdenagailua.Controls.Add(label5);
            panelOrdenagailua.Controls.Add(txtcpu);
            panelOrdenagailua.Controls.Add(txtrom);
            panelOrdenagailua.Controls.Add(txtram);
            panelOrdenagailua.Location = new Point(466, 202);
            panelOrdenagailua.Name = "panelOrdenagailua";
            panelOrdenagailua.Size = new Size(250, 125);
            panelOrdenagailua.TabIndex = 8;
            panelOrdenagailua.Paint += panel2_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 98);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 16;
            label7.Text = "CPU";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 53);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 15;
            label6.Text = "ROM";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 6);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 14;
            label5.Text = "RAM";
            // 
            // txtcpu
            // 
            txtcpu.Location = new Point(103, 95);
            txtcpu.Name = "txtcpu";
            txtcpu.Size = new Size(125, 27);
            txtcpu.TabIndex = 2;
            // 
            // txtrom
            // 
            txtrom.Location = new Point(103, 50);
            txtrom.Name = "txtrom";
            txtrom.Size = new Size(125, 27);
            txtrom.TabIndex = 1;
            // 
            // txtram
            // 
            txtram.Location = new Point(103, 3);
            txtram.Name = "txtram";
            txtram.Size = new Size(125, 27);
            txtram.TabIndex = 0;
            txtram.TextChanged += textBox1_TextChanged;
            // 
            // btnGehitu
            // 
            btnGehitu.Location = new Point(466, 371);
            btnGehitu.Name = "btnGehitu";
            btnGehitu.Size = new Size(133, 46);
            btnGehitu.TabIndex = 9;
            btnGehitu.Text = "GEHITU";
            btnGehitu.UseVisualStyleBackColor = true;
            btnGehitu.Click += btnGehitu_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 51);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 11;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 135);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 12;
            label3.Text = "Kokalekua";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 229);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 13;
            label4.Text = "Eroste Data";
            // 
            // btngehituatzera
            // 
            btngehituatzera.Location = new Point(196, 371);
            btngehituatzera.Name = "btngehituatzera";
            btngehituatzera.Size = new Size(133, 46);
            btngehituatzera.TabIndex = 14;
            btngehituatzera.Text = "AZTERA";
            btngehituatzera.UseVisualStyleBackColor = true;
            // 
            // GEHITU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btngehituatzera);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panelOrdenagailua);
            Controls.Add(btnGehitu);
            Controls.Add(panelInprimagailua);
            Controls.Add(radioinprimagailua);
            Controls.Add(txtkokalekua);
            Controls.Add(radioordenagailua);
            Controls.Add(txtmarka);
            Controls.Add(erostedata);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GEHITU";
            Text = "GEHITU";
            Load += GEHITU_Load;
            panelInprimagailua.ResumeLayout(false);
            panelInprimagailua.PerformLayout();
            panelOrdenagailua.ResumeLayout(false);
            panelOrdenagailua.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker erostedata;
        private TextBox txtmarka;
        private RadioButton radioordenagailua;
        private TextBox txtkokalekua;
        private RadioButton radioinprimagailua;
        private Panel panelInprimagailua;
        private Panel panelOrdenagailua;
        private TextBox txtcpu;
        private TextBox txtrom;
        private TextBox txtram;
        private TextBox txtTeknologia;
        private CheckBox chkKolore;
        private Button btnGehitu;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btngehituatzera;
    }
}