namespace GUREANOS_ERRONKA.FORMS
{
    partial class ERABILTZAILEAKIKUSI
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
            btnikusierabilirten = new Button();
            btnikusierabilatzera = new Button();
            dataikusierabil = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataikusierabil).BeginInit();
            SuspendLayout();
            /// 
            /// btnikusierabilirten
            /// 
            btnikusierabilirten.Location = new Point(524, 361);
            btnikusierabilirten.Name = "btnikusierabilirten";
            btnikusierabilirten.Size = new Size(150, 44);
            btnikusierabilirten.TabIndex = 5;
            btnikusierabilirten.Text = "IRTEN";
            btnikusierabilirten.UseVisualStyleBackColor = true;
            btnikusierabilirten.Click += btnikusierabilirten_Click;
            /// 
            /// btnikusierabilatzera
            /// 
            btnikusierabilatzera.Location = new Point(126, 361);
            btnikusierabilatzera.Name = "btnikusierabilatzera";
            btnikusierabilatzera.Size = new Size(150, 44);
            btnikusierabilatzera.TabIndex = 4;
            btnikusierabilatzera.Text = "ATZERA";
            btnikusierabilatzera.UseVisualStyleBackColor = true;
            btnikusierabilatzera.Click += btnikusierabilatzera_Click;
            /// 
            /// dataikusierabil
            /// 
            dataikusierabil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataikusierabil.Location = new Point(80, 45);
            dataikusierabil.Name = "dataikusierabil";
            dataikusierabil.ReadOnly = true;
            dataikusierabil.RowHeadersWidth = 51;
            dataikusierabil.Size = new Size(641, 292);
            dataikusierabil.TabIndex = 3;
            dataikusierabil.CellContentClick += dataikusierabil_CellContentClick;
            /// 
            /// ERABILTZAILEAKIKUSI
            /// 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnikusierabilirten);
            Controls.Add(btnikusierabilatzera);
            Controls.Add(dataikusierabil);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ERABILTZAILEAKIKUSI";
            Text = "ERABILTZAILEAKIKUSI";
            Load += ERABILTZAILEAKIKUSI_Load;
            ((System.ComponentModel.ISupportInitialize)dataikusierabil).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnikusierabilirten;
        private Button btnikusierabilatzera;
        private DataGridView dataikusierabil;
    }
}