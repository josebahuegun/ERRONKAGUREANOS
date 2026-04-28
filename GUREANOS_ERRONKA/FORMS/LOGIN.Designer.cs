namespace GUREANOS_ERRONKA.FORMS
{
    partial class LOGIN
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
            sartulogin = new Button();
            irtenlogin = new Button();
            label1 = new Label();
            label2 = new Label();
            txtizenalogin = new TextBox();
            txtpasahitzalogin = new TextBox();
            lblTitulo = new Label();
            SuspendLayout();
            /// 
            /// sartulogin
            /// 
            sartulogin.Location = new Point(205, 364);
            sartulogin.Name = "sartulogin";
            sartulogin.Size = new Size(94, 29);
            sartulogin.TabIndex = 0;
            sartulogin.Text = "SARTU";
            sartulogin.UseVisualStyleBackColor = true;
            sartulogin.Click += sartulogin_Click;
            /// 
            /// irtenlogin
            /// 
            irtenlogin.Location = new Point(450, 364);
            irtenlogin.Name = "irtenlogin";
            irtenlogin.Size = new Size(94, 29);
            irtenlogin.TabIndex = 1;
            irtenlogin.Text = "IRTEN";
            irtenlogin.UseVisualStyleBackColor = true;
            irtenlogin.Click += irtenlogin_Click;
            /// 
            /// label1
            /// 
            label1.AutoSize = true;
            label1.Location = new Point(217, 140);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 2;
            label1.Text = "ERABILTZAILEA";
            /// 
            /// label2
            /// 
            label2.AutoSize = true;
            label2.Location = new Point(242, 217);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 3;
            label2.Text = "PASAHITZA";
            /// 
            /// txtizenalogin
            /// 
            txtizenalogin.Location = new Point(419, 140);
            txtizenalogin.Name = "txtizenalogin";
            txtizenalogin.Size = new Size(125, 27);
            txtizenalogin.TabIndex = 4;
            /// 
            /// txtpasahitzalogin
            /// 
            txtpasahitzalogin.Location = new Point(419, 214);
            txtpasahitzalogin.Name = "txtpasahitzalogin";
            txtpasahitzalogin.Size = new Size(125, 27);
            txtpasahitzalogin.TabIndex = 5;
            /// 
            /// lblTitulo
            /// 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(360, 57);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(86, 20);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "GUREANOS";
            /// 
            /// LOGIN
            /// 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(txtpasahitzalogin);
            Controls.Add(txtizenalogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(irtenlogin);
            Controls.Add(sartulogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LOGIN";
            Text = "LOGIN";
            Load += LOGIN_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sartulogin;
        private Button irtenlogin;
        private Label label1;
        private Label label2;
        private TextBox txtizenalogin;
        private TextBox txtpasahitzalogin;
        private Label lblTitulo;
    }
}