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
            ((System.ComponentModel.ISupportInitialize)dataaldatu).BeginInit();
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
            // 
            // btnaldatuirten
            // 
            btnaldatuirten.Location = new Point(571, 361);
            btnaldatuirten.Name = "btnaldatuirten";
            btnaldatuirten.Size = new Size(150, 44);
            btnaldatuirten.TabIndex = 9;
            btnaldatuirten.Text = "IRTEN";
            btnaldatuirten.UseVisualStyleBackColor = true;
            // 
            // btnaldatuatzera
            // 
            btnaldatuatzera.Location = new Point(80, 361);
            btnaldatuatzera.Name = "btnaldatuatzera";
            btnaldatuatzera.Size = new Size(150, 44);
            btnaldatuatzera.TabIndex = 8;
            btnaldatuatzera.Text = "ATZERA";
            btnaldatuatzera.UseVisualStyleBackColor = true;
            // 
            // dataaldatu
            // 
            dataaldatu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataaldatu.Location = new Point(80, 45);
            dataaldatu.Name = "dataaldatu";
            dataaldatu.RowHeadersWidth = 51;
            dataaldatu.Size = new Size(641, 292);
            dataaldatu.TabIndex = 7;
            // 
            // ALDATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnaldatu);
            Controls.Add(btnaldatuirten);
            Controls.Add(btnaldatuatzera);
            Controls.Add(dataaldatu);
            Name = "ALDATU";
            Text = "ALDATU";
            ((System.ComponentModel.ISupportInitialize)dataaldatu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnaldatu;
        private Button btnaldatuirten;
        private Button btnaldatuatzera;
        private DataGridView dataaldatu;
    }
}