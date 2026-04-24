namespace GUREANOS_ERRONKA.FORMS
{
    partial class EZABATU
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
            btnezabatuirten = new Button();
            btnezabatuatzera = new Button();
            ezabatudata = new DataGridView();
            btnezabatu = new Button();
            ((System.ComponentModel.ISupportInitialize)ezabatudata).BeginInit();
            SuspendLayout();
            // 
            // btnezabatuirten
            // 
            btnezabatuirten.Location = new Point(571, 361);
            btnezabatuirten.Name = "btnezabatuirten";
            btnezabatuirten.Size = new Size(150, 44);
            btnezabatuirten.TabIndex = 5;
            btnezabatuirten.Text = "IRTEN";
            btnezabatuirten.UseVisualStyleBackColor = true;
            btnezabatuirten.Click += btnezabatuirten_Click;
            // 
            // btnezabatuatzera
            // 
            btnezabatuatzera.Location = new Point(80, 361);
            btnezabatuatzera.Name = "btnezabatuatzera";
            btnezabatuatzera.Size = new Size(150, 44);
            btnezabatuatzera.TabIndex = 4;
            btnezabatuatzera.Text = "ATZERA";
            btnezabatuatzera.UseVisualStyleBackColor = true;
            btnezabatuatzera.Click += btnezabatuatzera_Click;
            // 
            // ezabatudata
            // 
            ezabatudata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ezabatudata.Location = new Point(80, 45);
            ezabatudata.Name = "ezabatudata";
            ezabatudata.ReadOnly = true;
            ezabatudata.RowHeadersWidth = 51;
            ezabatudata.Size = new Size(641, 292);
            ezabatudata.TabIndex = 3;
            ezabatudata.CellContentClick += ezabatudata_CellContentClick;
            // 
            // btnezabatu
            // 
            btnezabatu.Location = new Point(329, 361);
            btnezabatu.Name = "btnezabatu";
            btnezabatu.Size = new Size(150, 44);
            btnezabatu.TabIndex = 6;
            btnezabatu.Text = "EZABATU";
            btnezabatu.UseVisualStyleBackColor = true;
            btnezabatu.Click += btnezabatu_Click;
            // 
            // EZABATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnezabatu);
            Controls.Add(btnezabatuirten);
            Controls.Add(btnezabatuatzera);
            Controls.Add(ezabatudata);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EZABATU";
            Text = "EZABATU";
            Load += EZABATU_Load;
            ((System.ComponentModel.ISupportInitialize)ezabatudata).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnezabatuirten;
        private Button btnezabatuatzera;
        private DataGridView ezabatudata;
        private Button btnezabatu;
    }
}