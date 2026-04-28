namespace GUREANOS_ERRONKA.FORMS
{
    partial class ERABILTZAILEASORTU
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
            btngehituerabilatzera = new Button();
            btnsortuerabil = new Button();
            txtizenaerabil = new TextBox();
            txtpasahitzaerabil = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            combomintegia = new ComboBox();
            label4 = new Label();
            comborola = new ComboBox();
            irten = new Button();
            SuspendLayout();
            /// 
            /// btngehituerabilatzera
            /// 
            btngehituerabilatzera.Location = new Point(118, 369);
            btngehituerabilatzera.Name = "btngehituerabilatzera";
            btngehituerabilatzera.Size = new Size(133, 46);
            btngehituerabilatzera.TabIndex = 16;
            btngehituerabilatzera.Text = "ATZERA";
            btngehituerabilatzera.UseVisualStyleBackColor = true;
            btngehituerabilatzera.Click += btngehituerabilatzera_Click;
            /// 
            /// btnsortuerabil
            /// 
            btnsortuerabil.Location = new Point(342, 369);
            btnsortuerabil.Name = "btnsortuerabil";
            btnsortuerabil.Size = new Size(133, 46);
            btnsortuerabil.TabIndex = 15;
            btnsortuerabil.Text = "SORTU";
            btnsortuerabil.UseVisualStyleBackColor = true;
            btnsortuerabil.Click += btnsortuerabil_Click;
            /// 
            /// txtizenaerabil
            /// 
            txtizenaerabil.Location = new Point(188, 144);
            txtizenaerabil.Name = "txtizenaerabil";
            txtizenaerabil.Size = new Size(125, 27);
            txtizenaerabil.TabIndex = 17;
            /// 
            /// txtpasahitzaerabil
            /// 
            txtpasahitzaerabil.Location = new Point(188, 245);
            txtpasahitzaerabil.Name = "txtpasahitzaerabil";
            txtpasahitzaerabil.Size = new Size(125, 27);
            txtpasahitzaerabil.TabIndex = 18;
            /// 
            /// label1
            /// 
            label1.AutoSize = true;
            label1.Location = new Point(90, 151);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 22;
            label1.Text = "Izena:";
            /// 
            /// label2
            /// 
            label2.AutoSize = true;
            label2.Location = new Point(90, 252);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 23;
            label2.Text = "Pasahitza:";
            /// 
            /// label3
            /// 
            label3.AutoSize = true;
            label3.Location = new Point(418, 144);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 24;
            label3.Text = "Rol-a:";
            /// 
            /// combomintegia
            /// 
            combomintegia.FormattingEnabled = true;
            combomintegia.Items.AddRange(new object[] { "Informatika", "Osasungintza" });
            combomintegia.Location = new Point(501, 245);
            combomintegia.Name = "combomintegia";
            combomintegia.Size = new Size(151, 28);
            combomintegia.TabIndex = 25;
            combomintegia.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            /// 
            /// label4
            /// 
            label4.AutoSize = true;
            label4.Location = new Point(418, 252);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 26;
            label4.Text = "Mintegia";
            /// 
            /// comborola
            /// 
            comborola.FormattingEnabled = true;
            comborola.Location = new Point(501, 141);
            comborola.Name = "comborola";
            comborola.Size = new Size(151, 28);
            comborola.TabIndex = 27;
            /// 
            /// irten
            /// 
            irten.Location = new Point(565, 369);
            irten.Name = "irten";
            irten.Size = new Size(133, 46);
            irten.TabIndex = 28;
            irten.Text = "IRTEN";
            irten.UseVisualStyleBackColor = true;
            irten.Click += irten_Click;
            /// 
            /// ERABILTZAILEASORTU
            /// 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(irten);
            Controls.Add(comborola);
            Controls.Add(label4);
            Controls.Add(combomintegia);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtpasahitzaerabil);
            Controls.Add(txtizenaerabil);
            Controls.Add(btngehituerabilatzera);
            Controls.Add(btnsortuerabil);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ERABILTZAILEASORTU";
            Text = "ERABILTZAILEASORTU";
            Load += ERABILTZAILEASORTU_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btngehituerabilatzera;
        private Button btnsortuerabil;
        private TextBox txtizenaerabil;
        private TextBox txtpasahitzaerabil;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox combomintegia;
        private Label label4;
        private ComboBox comborola;
        private Button irten;
    }
}