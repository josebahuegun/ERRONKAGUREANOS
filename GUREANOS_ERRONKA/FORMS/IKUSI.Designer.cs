namespace GUREANOS_ERRONKA.FORMS
{
    partial class IKUSI
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
            btnikusiatzera = new Button();
            btnikusiirten = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(77, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(641, 292);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnikusiatzera
            // 
            btnikusiatzera.Location = new Point(123, 394);
            btnikusiatzera.Name = "btnikusiatzera";
            btnikusiatzera.Size = new Size(150, 44);
            btnikusiatzera.TabIndex = 1;
            btnikusiatzera.Text = "ATZERA";
            btnikusiatzera.UseVisualStyleBackColor = true;
            btnikusiatzera.Click += button1_Click;
            // 
            // btnikusiirten
            // 
            btnikusiirten.Location = new Point(521, 394);
            btnikusiirten.Name = "btnikusiirten";
            btnikusiirten.Size = new Size(150, 44);
            btnikusiirten.TabIndex = 2;
            btnikusiirten.Text = "IRTEN";
            btnikusiirten.UseVisualStyleBackColor = true;
            // 
            // IKUSI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnikusiirten);
            Controls.Add(btnikusiatzera);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IKUSI";
            Text = "IKUSI";
            Load += IKUSI_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnikusiatzera;
        private Button btnikusiirten;
    }
}