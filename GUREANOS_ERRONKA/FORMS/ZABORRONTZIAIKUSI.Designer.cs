namespace GUREANOS_ERRONKA.FORMS
{
    partial class ZABORRONTZIAIKUSI
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
            btnzaborirten = new Button();
            btnzaboratzera = new Button();
            datazabor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)datazabor).BeginInit();
            SuspendLayout();
            // 
            // btnzaborirten
            // 
            btnzaborirten.Location = new Point(524, 361);
            btnzaborirten.Name = "btnzaborirten";
            btnzaborirten.Size = new Size(150, 44);
            btnzaborirten.TabIndex = 5;
            btnzaborirten.Text = "IRTEN";
            btnzaborirten.UseVisualStyleBackColor = true;
            // 
            // btnzaboratzera
            // 
            btnzaboratzera.Location = new Point(126, 361);
            btnzaboratzera.Name = "btnzaboratzera";
            btnzaboratzera.Size = new Size(150, 44);
            btnzaboratzera.TabIndex = 4;
            btnzaboratzera.Text = "ATZERA";
            btnzaboratzera.UseVisualStyleBackColor = true;
            // 
            // datazabor
            // 
            datazabor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datazabor.Location = new Point(80, 45);
            datazabor.Name = "datazabor";
            datazabor.RowHeadersWidth = 51;
            datazabor.Size = new Size(641, 292);
            datazabor.TabIndex = 3;
            datazabor.CellContentClick += datazabor_CellContentClick;
            // 
            // ZABORRONTZIAIKUSI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnzaborirten);
            Controls.Add(btnzaboratzera);
            Controls.Add(datazabor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ZABORRONTZIAIKUSI";
            Text = "ZABORRONTZIAIKUSI";
            Load += ZABORRONTZIAIKUSI_Load;
            ((System.ComponentModel.ISupportInitialize)datazabor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnzaborirten;
        private Button btnzaboratzera;
        private DataGridView datazabor;
    }
}