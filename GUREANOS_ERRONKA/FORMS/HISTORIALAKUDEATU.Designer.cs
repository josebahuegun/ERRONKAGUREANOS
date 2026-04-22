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
            ((System.ComponentModel.ISupportInitialize)datahistoriala).BeginInit();
            SuspendLayout();
            // 
            // btnirtenhistoriala
            // 
            btnirtenhistoriala.Location = new Point(571, 361);
            btnirtenhistoriala.Name = "btnirtenhistoriala";
            btnirtenhistoriala.Size = new Size(150, 44);
            btnirtenhistoriala.TabIndex = 5;
            btnirtenhistoriala.Text = "IRTEN";
            btnirtenhistoriala.UseVisualStyleBackColor = true;
            // 
            // btnatzerahistoriala
            // 
            btnatzerahistoriala.Location = new Point(80, 361);
            btnatzerahistoriala.Name = "btnatzerahistoriala";
            btnatzerahistoriala.Size = new Size(150, 44);
            btnatzerahistoriala.TabIndex = 4;
            btnatzerahistoriala.Text = "ATZERA";
            btnatzerahistoriala.UseVisualStyleBackColor = true;
            btnatzerahistoriala.Click += btnatzerahistoriala_Click;
            // 
            // datahistoriala
            // 
            datahistoriala.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datahistoriala.Location = new Point(80, 45);
            datahistoriala.Name = "datahistoriala";
            datahistoriala.RowHeadersWidth = 51;
            datahistoriala.Size = new Size(641, 292);
            datahistoriala.TabIndex = 3;
            // 
            // btnaldatuhistoriala
            // 
            btnaldatuhistoriala.Location = new Point(324, 361);
            btnaldatuhistoriala.Name = "btnaldatuhistoriala";
            btnaldatuhistoriala.Size = new Size(150, 44);
            btnaldatuhistoriala.TabIndex = 6;
            btnaldatuhistoriala.Text = "ALDATU";
            btnaldatuhistoriala.UseVisualStyleBackColor = true;
            // 
            // HISTORIALAKUDEATU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(btnaldatuhistoriala);
            Controls.Add(btnirtenhistoriala);
            Controls.Add(btnatzerahistoriala);
            Controls.Add(datahistoriala);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HISTORIALAKUDEATU";
            Text = "HISTORIALAIKUSI";
            ((System.ComponentModel.ISupportInitialize)datahistoriala).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnirtenhistoriala;
        private Button btnatzerahistoriala;
        private DataGridView datahistoriala;
        private Button btnaldatuhistoriala;
    }
}