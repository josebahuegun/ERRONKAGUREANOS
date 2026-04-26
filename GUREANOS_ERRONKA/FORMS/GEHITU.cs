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
    public partial class GEHITU : Form
    {
        public GEHITU()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioordenagailua.Checked)
            {
                panelOrdenagailua.Visible = true;
                panelInprimagailua.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GEHITU_Load(object sender, EventArgs e)
        {
            // panelak hasieran ezkutatu
            panelOrdenagailua.Visible = false;
            panelInprimagailua.Visible = false;

            // mintegiak kargatu
            combomintegia.DataSource = DBKONEXIOA.LortuMintegiak();
            combomintegia.DisplayMember = "izena";
            combomintegia.ValueMember = "id";

            // mintegiburua bada bere mintegia bakarrik
            if (sesioa.Rola == "Mintegiburua")
            {
                combomintegia.SelectedValue = sesioa.MintegiaId;
                combomintegia.Enabled = false;
            }

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // label estiloa
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;

            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // textbox estiloa
            txtmarka.BackColor = Color.White;
            txtmarka.BorderStyle = BorderStyle.FixedSingle;

            // combobox estiloa
            combomintegia.BackColor = Color.White;

            // datetime estiloa
            erostedata.CalendarMonthBackground = Color.White;

            // panel estiloa
            panelOrdenagailua.BackColor = Color.White;
            panelInprimagailua.BackColor = Color.White;

            panelOrdenagailua.BorderStyle = BorderStyle.FixedSingle;
            panelInprimagailua.BorderStyle = BorderStyle.FixedSingle;

            // botoiak estiloa
            btngehituatzera.BackColor = Color.FromArgb(100, 100, 100);
            btngehituatzera.ForeColor = Color.White;
            btngehituatzera.FlatStyle = FlatStyle.Flat;

            btnGehitu.BackColor = Color.FromArgb(0, 120, 215);
            btnGehitu.ForeColor = Color.White;
            btnGehitu.FlatStyle = FlatStyle.Flat;

            irten.BackColor = Color.FromArgb(200, 50, 50);
            irten.ForeColor = Color.White;
            irten.FlatStyle = FlatStyle.Flat;
            // radio estiloa
            radioordenagailua.ForeColor = Color.Black;
            radioinprimagailua.ForeColor = Color.Black;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            // pantailaren erdigunea
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 150;

            // ezkerreko zona (datu nagusiak)
            label2.Left = centroX - 300;
            label2.Top = startY;

            txtmarka.Left = centroX - 150;
            txtmarka.Top = startY;

            label3.Left = centroX - 300;
            label3.Top = startY + 70;

            combomintegia.Left = centroX - 150;
            combomintegia.Top = startY + 70;

            label4.Left = centroX - 300;
            label4.Top = startY + 140;

            erostedata.Left = centroX - 150;
            erostedata.Top = startY + 140;

            // eskuineko zona (radio + panelak)
            radioordenagailua.Left = centroX + 50;
            radioordenagailua.Top = startY;

            radioinprimagailua.Left = centroX + 50;
            radioinprimagailua.Top = startY + 50;

            panelOrdenagailua.Left = centroX + 50;
            panelOrdenagailua.Top = startY + 90;

            panelInprimagailua.Left = centroX + 50;
            panelInprimagailua.Top = startY + 90;

            // botoiak
            int botonesY = startY + 250;

            btnGehitu.Top = botonesY;
            btnGehitu.Left = centroX - btnGehitu.Width / 2;

            btngehituatzera.Top = botonesY;
            btngehituatzera.Left = btnGehitu.Left - 180;

            irten.Top = botonesY;
            irten.Left = btnGehitu.Left + 180;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }

        private void panelInprimagailua_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioinprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioinprimagailua.Checked)
            {
                panelOrdenagailua.Visible = false;
                panelInprimagailua.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void erostedata_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGehitu_Click(object sender, EventArgs e)
        {
            // balidazioa
            if (txtmarka.Text == "" || combomintegia.Text == "")
            {
                MessageBox.Show("Bete datu guztiak");
                return;
            }

            // ordenagailua
            if (radioordenagailua.Checked)
            {
                if (txtram.Text == "" || txtrom.Text == "" || txtcpu.Text == "")
                {
                    MessageBox.Show("Bete ordenagailuaren datuak");
                    return;
                }

                Ordenagailua o = new Ordenagailua(
                    txtmarka.Text,
                    combomintegia.Text,
                    erostedata.Value,
                    "aktibo",
                    "Informatika",
                    txtram.Text,
                    txtrom.Text,
                    txtcpu.Text
                );

                int id = DBKONEXIOA.gailuaGehitu(o);

                if (id > 0)
                {
                    DBKONEXIOA.TxertatuOrdenagailua(id, o.RAM1, o.ROM1, o.CPU1);

                    MessageBox.Show("Ordenagailua gehituta");

                    // formularioa garbitu
                    GarbituFormularioa();
                }
            }

            //  inprimagailua
            else if (radioinprimagailua.Checked)
            {
                Inprimagailua i = new Inprimagailua(
                    txtmarka.Text,
                    combomintegia.Text,
                    erostedata.Value,
                    "aktibo",
                    "Informatika",
                    chkKolore.Checked,
                    txtTeknologia.Text
                );

                int id = DBKONEXIOA.gailuaGehitu(i);

                if (id > 0)
                {
                    DBKONEXIOA.TxertatuInprimagailua(id, i.Koloretakoa, i.Teknologia);

                    MessageBox.Show("Inprimagailua gehituta");

                    // formularioa garbitu
                    GarbituFormularioa();
                }
            }
            else
            {
                MessageBox.Show("Aukeratu mota");
            }
        }

        private void combomintegia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btngehituatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }
        private void GarbituFormularioa()
        {
            // testuak garbitu
            txtmarka.Text = "";

            txtram.Text = "";
            txtrom.Text = "";
            txtcpu.Text = "";
            txtTeknologia.Text = "";

            // combobox reset (mintegiburua bada ez ukitu)
            if (sesioa.Rola != "Mintegiburua")
            {
                combomintegia.SelectedIndex = -1;
            }

            // data gaurko jarri
            erostedata.Value = DateTime.Now;

            // checkbox garbitu
            chkKolore.Checked = false;

            // radioak kendu
            radioordenagailua.Checked = false;
            radioinprimagailua.Checked = false;

            // panelak ezkutatu
            panelOrdenagailua.Visible = false;
            panelInprimagailua.Visible = false;
        }
    }
}
