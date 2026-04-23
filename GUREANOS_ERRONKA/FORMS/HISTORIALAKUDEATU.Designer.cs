namespace GUREANOS_ERRONKA.FORMS
{
    partial class HISTORIALAKUDEATU
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
            btnirtenhistoriala = new Button();
            btnatzerahistoriala = new Button();
            datahistoriala = new DataGridView();
            btnaldatuhistoriala = new Button();
            btnezabatu = new Button();
            btnsortu = new Button();
            combogailua = new ComboBox();
            combomota = new ComboBox();
            txtdeskribapena = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)datahistoriala).BeginInit();
            SuspendLayout();
            // 
            // btnirtenhistoriala
            // 
            btnirtenhistoriala.Location = new Point(608, 361);
            btnirtenhistoriala.Name = "btnirtenhistoriala";
            btnirtenhistoriala.Size = new Size(113, 44);
            btnirtenhistoriala.TabIndex = 5;
            btnirtenhistoriala.Text = "IRTEN";
            btnirtenhistoriala.UseVisualStyleBackColor = true;
            btnirtenhistoriala.Click += btnirtenhistoriala_Click;
            // 
            // btnatzerahistoriala
            // 
            btnatzerahistoriala.Location = new Point(80, 361);
            btnatzerahistoriala.Name = "btnatzerahistoriala";
            btnatzerahistoriala.Size = new Size(104, 44);
            btnatzerahistoriala.TabIndex = 4;
            btnatzerahistoriala.Text = "ATZERA";
            btnatzerahistoriala.UseVisualStyleBackColor = true;
            btnatzerahistoriala.Click += btnatzerahistoriala_Click;
            // 
            // datahistoriala
            // 
            datahistoriala.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datahistoriala.Location = new Point(80, 176);
            datahistoriala.Name = "datahistoriala";
            datahistoriala.RowHeadersWidth = 51;
            datahistoriala.Size = new Size(641, 161);
            datahistoriala.TabIndex = 3;
            datahistoriala.CellContentClick += datahistoriala_CellContentClick;
            // 
            // btnaldatuhistoriala
            // 
            btnaldatuhistoriala.Location = new Point(255, 361);
            btnaldatuhistoriala.Name = "btnaldatuhistoriala";
            btnaldatuhistoriala.Size = new Size(109, 44);
            btnaldatuhistoriala.TabIndex = 6;
            btnaldatuhistoriala.Text = "ALDATU";
            btnaldatuhistoriala.UseVisualStyleBackColor = true;
            btnaldatuhistoriala.Click += btnaldatuhistoriala_Click;
            // 
            // btnezabatu
            // 
            btnezabatu.Location = new Point(442, 361);
            btnezabatu.Name = "btnezabatu";
            btnezabatu.Size = new Size(109, 44);
            btnezabatu.TabIndex = 7;
            btnezabatu.Text = "EZABATU";
            btnezabatu.UseVisualStyleBackColor = true;
            btnezabatu.Click += btnezabatu_Click;
            // 
            // btnsortu
            // 
            btnsortu.Location = new Point(345, 126);
            btnsortu.Name = "btnsortu";
            btnsortu.Size = new Size(109, 44);
            btnsortu.TabIndex = 8;
            btnsortu.Text = "SORTU";
            btnsortu.UseVisualStyleBackColor = true;
            btnsortu.Click += btnsortu_Click;
            // 
            // combogailua
            // 
            combogailua.FormattingEnabled = true;
            combogailua.Location = new Point(90, 63);
            combogailua.Name = "combogailua";
            combogailua.Size = new Size(151, 28);
            combogailua.TabIndex = 9;
            // 
            // combomota
            // 
            combomota.FormattingEnabled = true;
            combomota.Location = new Point(324, 62);
            combomota.Name = "combomota";
            combomota.Size = new Size(151, 28);
            combomota.TabIndex = 10;
            // 
            // txtdeskribapena
            // 
            txtdeskribapena.Location = new Point(550, 63);
            txtdeskribapena.Name = "txtdeskribapena";
            txtdeskribapena.Size = new Size(149, 27);
            txtdeskribapena.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 25);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 12;
            label1.Text = "GAILUA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 25);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 13;
            label2.Text = "MOTA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(571, 25);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 14;
            label3.Text = "DESKRIBAPENA";
            // 
            // HISTORIALAKUDEATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtdeskribapena);
            Controls.Add(combomota);
            Controls.Add(combogailua);
            Controls.Add(btnsortu);
            Controls.Add(btnezabatu);
            Controls.Add(btnaldatuhistoriala);
            Controls.Add(btnirtenhistoriala);
            Controls.Add(btnatzerahistoriala);
            Controls.Add(datahistoriala);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HISTORIALAKUDEATU";
            Text = "HISTORIALAIKUSI";
            Load += HISTORIALAKUDEATU_Load;
            ((System.ComponentModel.ISupportInitialize)datahistoriala).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnirtenhistoriala;
        private Button btnatzerahistoriala;
        private DataGridView datahistoriala;
        private Button btnaldatuhistoriala;
        private Button btnezabatu;
        private Button btnsortu;
        private ComboBox combogailua;
        private ComboBox combomota;
        private TextBox txtdeskribapena;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}