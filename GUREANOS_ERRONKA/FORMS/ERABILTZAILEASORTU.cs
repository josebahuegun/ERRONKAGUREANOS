using GUREANOS_ERRONKA.CODIGO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA.FORMS
{
    public partial class ERABILTZAILEASORTU : Form
    {
        public ERABILTZAILEASORTU()
        {
            InitializeComponent();
        }

        private void ERABILTZAILEASORTU_Load(object sender, EventArgs e)
        {
            // rolak gehitu
            comborola.Items.Clear();
            comborola.Items.Add("IKT arduraduna");
            comborola.Items.Add("Mintegiburua");
            comborola.Items.Add("Irakaslea");
            comborola.SelectedIndex = 0;

            // mintegiak kargatu
            combomintegia.DataSource = DBKONEXIOA.LortuMintegiak();
            combomintegia.DisplayMember = "izena";
            combomintegia.ValueMember = "id";

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // label estiloa
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;

            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // textbox estiloa
            txtizenaerabil.BackColor = Color.White;
            txtizenaerabil.BorderStyle = BorderStyle.FixedSingle;

            txtpasahitzaerabil.BackColor = Color.White;
            txtpasahitzaerabil.BorderStyle = BorderStyle.FixedSingle;

            // combobox estiloa
            comborola.BackColor = Color.White;
            combomintegia.BackColor = Color.White;

            // botoiak estiloa
            btngehituerabilatzera.BackColor = Color.FromArgb(100, 100, 100);
            btngehituerabilatzera.ForeColor = Color.White;
            btngehituerabilatzera.FlatStyle = FlatStyle.Flat;

            btnsortuerabil.BackColor = Color.FromArgb(0, 120, 215);
            btnsortuerabil.ForeColor = Color.White;
            btnsortuerabil.FlatStyle = FlatStyle.Flat;

            irten.BackColor = Color.FromArgb(200, 50, 50);
            irten.ForeColor = Color.White;
            irten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            // pantailaren erdigunea
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 120;

            // izena
            label1.Left = centroX - 250;
            label1.Top = startY;

            txtizenaerabil.Left = centroX - 100;
            txtizenaerabil.Top = startY;

            // rola
            label3.Left = centroX + 50;
            label3.Top = startY;

            comborola.Left = centroX + 150;
            comborola.Top = startY;

            // pasahitza
            label2.Left = centroX - 250;
            label2.Top = startY + 70;

            txtpasahitzaerabil.Left = centroX - 100;
            txtpasahitzaerabil.Top = startY + 70;

            // mintegia
            label4.Left = centroX + 50;
            label4.Top = startY + 70;

            combomintegia.Left = centroX + 150;
            combomintegia.Top = startY + 70;

            // botoiak
            int botonesY = startY + 160;

            btnsortuerabil.Top = botonesY;
            btnsortuerabil.Left = centroX - btnsortuerabil.Width / 2;

            btngehituerabilatzera.Top = botonesY;
            btngehituerabilatzera.Left = btnsortuerabil.Left - 180;

            irten.Top = botonesY;
            irten.Left = btnsortuerabil.Left + 180;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
        private void radioirakasle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsortuerabil_Click(object sender, EventArgs e)
        {
            // datuak bete diren egiaztatu
            if (txtizenaerabil.Text == "" || txtpasahitzaerabil.Text == "")
            {
                MessageBox.Show("Bete datu guztiak!");
                return;
            }

            // mintegia hartu
            int mintegiaId = Convert.ToInt32(combomintegia.SelectedValue);

            // mintegiburua bada → kontrolatu
            if (comborola.Text == "Mintegiburua")
            {
                if (DBKONEXIOA.mintegiburuaexistitu(mintegiaId, 0))
                {
                    MessageBox.Show("Mintegi honek dagoeneko Mintegiburua dauka!");
                    return;
                }
            }

            // sortu erabiltzailea
            bool sortuta = DBKONEXIOA.SortuErabiltzailea(
                txtizenaerabil.Text,
                txtpasahitzaerabil.Text,
                comborola.Text,
                mintegiaId
            );

            if (sortuta)
            {
                MessageBox.Show("Erabiltzailea sortuta!");

                // garbitu formularioa
                txtizenaerabil.Clear();
                txtpasahitzaerabil.Clear();
                comborola.SelectedIndex = 0;
                combomintegia.SelectedIndex = 0;
            }
        }

        private void btngehituerabilatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        private void irten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
