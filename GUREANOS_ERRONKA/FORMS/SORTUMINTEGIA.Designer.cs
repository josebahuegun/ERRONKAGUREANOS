namespace GUREANOS_ERRONKA.FORMS
{
    partial class SORTUMINTEGIA
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
            atzera = new Button();
            SORTU = new Button();
            txtizena = new TextBox();
            label1 = new Label();
            irten = new Button();
            SuspendLayout();
            /// 
            /// atzera
            /// 
            atzera.Location = new Point(173, 340);
            atzera.Name = "atzera";
            atzera.Size = new Size(116, 33);
            atzera.TabIndex = 0;
            atzera.Text = "ATZERA";
            atzera.UseVisualStyleBackColor = true;
            atzera.Click += atzera_Click;
            /// 
            /// SORTU
            /// 
            SORTU.Location = new Point(362, 340);
            SORTU.Name = "SORTU";
            SORTU.Size = new Size(110, 37);
            SORTU.TabIndex = 1;
            SORTU.Text = "SORTU";
            SORTU.UseVisualStyleBackColor = true;
            SORTU.Click += SORTU_Click;
            /// 
            /// txtizena
            /// 
            txtizena.Location = new Point(432, 167);
            txtizena.Name = "txtizena";
            txtizena.Size = new Size(125, 27);
            txtizena.TabIndex = 2;
            /// 
            /// label1
            /// 
            label1.AutoSize = true;
            label1.Location = new Point(245, 167);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 3;
            label1.Text = "Izena";
            /// 
            /// irten
            /// 
            irten.Location = new Point(537, 340);
            irten.Name = "irten";
            irten.Size = new Size(116, 33);
            irten.TabIndex = 4;
            irten.Text = "IRTEN";
            irten.UseVisualStyleBackColor = true;
            irten.Click += button1_Click;
            /// 
            /// SORTUMINTEGIA
            /// 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(irten);
            Controls.Add(label1);
            Controls.Add(txtizena);
            Controls.Add(SORTU);
            Controls.Add(atzera);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SORTUMINTEGIA";
            Text = "SORTUMINTEGIA";
            Load += SORTUMINTEGIA_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button atzera;
        private Button SORTU;
        private TextBox txtizena;
        private Label label1;
        private Button irten;
    }
}