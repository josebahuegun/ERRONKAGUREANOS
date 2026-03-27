namespace GUREANOS_ERRONKA.FORMS
{
    partial class ERABILTZAILEASORTU
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
            btngehituerabilatzera = new Button();
            btnsortuerabil = new Button();
            txtizenaerabil = new TextBox();
            txtpasahitzaerabil = new TextBox();
            radioirakasle = new RadioButton();
            radiomintegiburu = new RadioButton();
            radioiktarduraduna = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btngehituerabilatzera
            // 
            btngehituerabilatzera.Location = new Point(188, 369);
            btngehituerabilatzera.Name = "btngehituerabilatzera";
            btngehituerabilatzera.Size = new Size(133, 46);
            btngehituerabilatzera.TabIndex = 16;
            btngehituerabilatzera.Text = "AZTERA";
            btngehituerabilatzera.UseVisualStyleBackColor = true;
            // 
            // btnsortuerabil
            // 
            btnsortuerabil.Location = new Point(501, 369);
            btnsortuerabil.Name = "btnsortuerabil";
            btnsortuerabil.Size = new Size(133, 46);
            btnsortuerabil.TabIndex = 15;
            btnsortuerabil.Text = "SORTU";
            btnsortuerabil.UseVisualStyleBackColor = true;
            // 
            // txtizenaerabil
            // 
            txtizenaerabil.Location = new Point(188, 144);
            txtizenaerabil.Name = "txtizenaerabil";
            txtizenaerabil.Size = new Size(125, 27);
            txtizenaerabil.TabIndex = 17;
            // 
            // txtpasahitzaerabil
            // 
            txtpasahitzaerabil.Location = new Point(188, 245);
            txtpasahitzaerabil.Name = "txtpasahitzaerabil";
            txtpasahitzaerabil.Size = new Size(125, 27);
            txtpasahitzaerabil.TabIndex = 18;
            // 
            // radioirakasle
            // 
            radioirakasle.AutoSize = true;
            radioirakasle.Location = new Point(492, 216);
            radioirakasle.Name = "radioirakasle";
            radioirakasle.Size = new Size(105, 24);
            radioirakasle.TabIndex = 19;
            radioirakasle.TabStop = true;
            radioirakasle.Text = "IRAKASLEA";
            radioirakasle.UseVisualStyleBackColor = true;
            // 
            // radiomintegiburu
            // 
            radiomintegiburu.AutoSize = true;
            radiomintegiburu.Location = new Point(492, 246);
            radiomintegiburu.Name = "radiomintegiburu";
            radiomintegiburu.Size = new Size(140, 24);
            radiomintegiburu.TabIndex = 20;
            radiomintegiburu.TabStop = true;
            radiomintegiburu.Text = "MINTEGI BURUA";
            radiomintegiburu.UseVisualStyleBackColor = true;
            // 
            // radioiktarduraduna
            // 
            radioiktarduraduna.AutoSize = true;
            radioiktarduraduna.Location = new Point(492, 276);
            radioiktarduraduna.Name = "radioiktarduraduna";
            radioiktarduraduna.Size = new Size(156, 24);
            radioiktarduraduna.TabIndex = 21;
            radioiktarduraduna.TabStop = true;
            radioiktarduraduna.Text = "IKT ARDURADUNA";
            radioiktarduraduna.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 151);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 22;
            label1.Text = "Izena:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 252);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 23;
            label2.Text = "Pasahitza:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 183);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 24;
            label3.Text = "Rol-a:";
            // 
            // ERABILTZAILEASORTU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(radioiktarduraduna);
            Controls.Add(radiomintegiburu);
            Controls.Add(radioirakasle);
            Controls.Add(txtpasahitzaerabil);
            Controls.Add(txtizenaerabil);
            Controls.Add(btngehituerabilatzera);
            Controls.Add(btnsortuerabil);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ERABILTZAILEASORTU";
            Text = "ERABILTZAILEASORTU";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btngehituerabilatzera;
        private Button btnsortuerabil;
        private TextBox txtizenaerabil;
        private TextBox txtpasahitzaerabil;
        private RadioButton radioirakasle;
        private RadioButton radiomintegiburu;
        private RadioButton radioiktarduraduna;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}