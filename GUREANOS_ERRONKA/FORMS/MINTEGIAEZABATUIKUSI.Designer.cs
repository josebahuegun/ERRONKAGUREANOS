namespace GUREANOS_ERRONKA.FORMS
{
    partial class MINTEGIAEZABATUIKUSI
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
            dataGridView1 = new DataGridView();
            btnezabatu = new Button();
            btnatzera = new Button();
            irten = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(73, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(632, 331);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnezabatu
            // 
            btnezabatu.Location = new Point(329, 378);
            btnezabatu.Name = "btnezabatu";
            btnezabatu.Size = new Size(139, 43);
            btnezabatu.TabIndex = 1;
            btnezabatu.Text = "EZABATU";
            btnezabatu.UseVisualStyleBackColor = true;
            btnezabatu.Click += btnezabatu_Click;
            // 
            // btnatzera
            // 
            btnatzera.Location = new Point(107, 378);
            btnatzera.Name = "btnatzera";
            btnatzera.Size = new Size(139, 43);
            btnatzera.TabIndex = 2;
            btnatzera.Text = "ATZERA";
            btnatzera.UseVisualStyleBackColor = true;
            btnatzera.Click += btnatzera_Click;
            // 
            // irten
            // 
            irten.Location = new Point(557, 378);
            irten.Name = "irten";
            irten.Size = new Size(139, 43);
            irten.TabIndex = 3;
            irten.Text = "IRTEN";
            irten.UseVisualStyleBackColor = true;
            irten.Click += irten_Click;
            // 
            // MINTEGIAEZABATUIKUSI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(irten);
            Controls.Add(btnatzera);
            Controls.Add(btnezabatu);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MINTEGIAEZABATUIKUSI";
            Text = "MINTEGIAEZABATUIKUSI";
            Load += MINTEGIAEZABATUIKUSI_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnezabatu;
        private Button btnatzera;
        private Button irten;
    }
}