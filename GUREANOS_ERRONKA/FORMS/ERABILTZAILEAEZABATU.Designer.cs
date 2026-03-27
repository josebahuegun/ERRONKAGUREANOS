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
            ((System.ComponentModel.ISupportInitialize)dataerabilezabatu).BeginInit();
            SuspendLayout();
            // 
            // btnerabilezabatu
            // 
            btnerabilezabatu.Location = new Point(325, 361);
            btnerabilezabatu.Name = "btnerabilezabatu";
            btnerabilezabatu.Size = new Size(150, 44);
            btnerabilezabatu.TabIndex = 10;
            btnerabilezabatu.Text = "EZABATU";
            btnerabilezabatu.UseVisualStyleBackColor = true;
            // 
            // btnerabilezabatuirten
            // 
            btnerabilezabatuirten.Location = new Point(571, 361);
            btnerabilezabatuirten.Name = "btnerabilezabatuirten";
            btnerabilezabatuirten.Size = new Size(150, 44);
            btnerabilezabatuirten.TabIndex = 9;
            btnerabilezabatuirten.Text = "IRTEN";
            btnerabilezabatuirten.UseVisualStyleBackColor = true;
            // 
            // btnerabilezabatuatzera
            // 
            btnerabilezabatuatzera.Location = new Point(80, 361);
            btnerabilezabatuatzera.Name = "btnerabilezabatuatzera";
            btnerabilezabatuatzera.Size = new Size(150, 44);
            btnerabilezabatuatzera.TabIndex = 8;
            btnerabilezabatuatzera.Text = "ATZERA";
            btnerabilezabatuatzera.UseVisualStyleBackColor = true;
            // 
            // dataerabilezabatu
            // 
            dataerabilezabatu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataerabilezabatu.Location = new Point(80, 45);
            dataerabilezabatu.Name = "dataerabilezabatu";
            dataerabilezabatu.RowHeadersWidth = 51;
            dataerabilezabatu.Size = new Size(641, 292);
            dataerabilezabatu.TabIndex = 7;
            // 
            // ERABILTZAILEAEZABATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnerabilezabatu);
            Controls.Add(btnerabilezabatuirten);
            Controls.Add(btnerabilezabatuatzera);
            Controls.Add(dataerabilezabatu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ERABILTZAILEAEZABATU";
            Text = "ERABILTZAILEAEZABATU";
            ((System.ComponentModel.ISupportInitialize)dataerabilezabatu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnerabilezabatu;
        private Button btnerabilezabatuirten;
        private Button btnerabilezabatuatzera;
        private DataGridView dataerabilezabatu;
    }
}