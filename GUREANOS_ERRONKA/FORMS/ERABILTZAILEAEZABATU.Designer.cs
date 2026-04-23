namespace GUREANOS_ERRONKA.FORMS
{
    partial class ERABILTZAILEAEZABATU
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
            btnerabilezabatu = new Button();
            btnerabilezabatuirten = new Button();
            btnerabilezabatuatzera = new Button();
            dataerabilezabatu = new DataGridView();
            btnaldatu = new Button();
            ((System.ComponentModel.ISupportInitialize)dataerabilezabatu).BeginInit();
            SuspendLayout();
            // 
            // btnerabilezabatu
            // 
            btnerabilezabatu.Location = new Point(406, 361);
            btnerabilezabatu.Name = "btnerabilezabatu";
            btnerabilezabatu.Size = new Size(150, 44);
            btnerabilezabatu.TabIndex = 10;
            btnerabilezabatu.Text = "EZABATU";
            btnerabilezabatu.UseVisualStyleBackColor = true;
            btnerabilezabatu.Click += btnerabilezabatu_Click;
            // 
            // btnerabilezabatuirten
            // 
            btnerabilezabatuirten.Location = new Point(571, 361);
            btnerabilezabatuirten.Name = "btnerabilezabatuirten";
            btnerabilezabatuirten.Size = new Size(150, 44);
            btnerabilezabatuirten.TabIndex = 9;
            btnerabilezabatuirten.Text = "IRTEN";
            btnerabilezabatuirten.UseVisualStyleBackColor = true;
            btnerabilezabatuirten.Click += btnerabilezabatuirten_Click;
            // 
            // btnerabilezabatuatzera
            // 
            btnerabilezabatuatzera.Location = new Point(80, 361);
            btnerabilezabatuatzera.Name = "btnerabilezabatuatzera";
            btnerabilezabatuatzera.Size = new Size(150, 44);
            btnerabilezabatuatzera.TabIndex = 8;
            btnerabilezabatuatzera.Text = "ATZERA";
            btnerabilezabatuatzera.UseVisualStyleBackColor = true;
            btnerabilezabatuatzera.Click += btnerabilezabatuatzera_Click;
            // 
            // dataerabilezabatu
            // 
            dataerabilezabatu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataerabilezabatu.Location = new Point(80, 45);
            dataerabilezabatu.Name = "dataerabilezabatu";
            dataerabilezabatu.ReadOnly = true;
            dataerabilezabatu.RowHeadersWidth = 51;
            dataerabilezabatu.Size = new Size(641, 292);
            dataerabilezabatu.TabIndex = 7;
            dataerabilezabatu.CellContentClick += dataerabilezabatu_CellContentClick;
            // 
            // btnaldatu
            // 
            btnaldatu.Location = new Point(238, 361);
            btnaldatu.Name = "btnaldatu";
            btnaldatu.Size = new Size(150, 44);
            btnaldatu.TabIndex = 11;
            btnaldatu.Text = "ALDATU";
            btnaldatu.UseVisualStyleBackColor = true;
            btnaldatu.Click += btnaldatu_Click;
            // 
            // ERABILTZAILEAEZABATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnaldatu);
            Controls.Add(btnerabilezabatu);
            Controls.Add(btnerabilezabatuirten);
            Controls.Add(btnerabilezabatuatzera);
            Controls.Add(dataerabilezabatu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ERABILTZAILEAEZABATU";
            Text = "ERABILTZAILEAEZABATU";
            Load += ERABILTZAILEAEZABATU_Load;
            ((System.ComponentModel.ISupportInitialize)dataerabilezabatu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnerabilezabatu;
        private Button btnerabilezabatuirten;
        private Button btnerabilezabatuatzera;
        private DataGridView dataerabilezabatu;
        private Button btnaldatu;
    }
}