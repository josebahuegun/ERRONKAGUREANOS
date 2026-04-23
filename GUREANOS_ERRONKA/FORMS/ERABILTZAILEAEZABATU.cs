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
    public partial class ERABILTZAILEAEZABATU : Form
    {
        public ERABILTZAILEAEZABATU()
        {
            InitializeComponent();
        }

        private void dataerabilezabatu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ERABILTZAILEAEZABATU_Load(object sender, EventArgs e)
        {
            // erabiltzailearen rola lortu
            string rola = sesioa.Rola.ToLower();

            // irakaslea bada ezin sartu
            if (rola == "irakaslea")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                this.Close();
                return;
            }

            // ikt ez bada botoiak ezkutatu
            if (rola != "iktarduraduna")
            {
                btnaldatu.Visible = false;
                btnerabilezabatu.Visible = false;
            }

            // datuak kargatu
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            dataerabilezabatu.Columns["id"].Visible = false;

            // leihoa maximizatu
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);
            
            // datagrid estiloa
            dataerabilezabatu.BackgroundColor = Color.White;
            dataerabilezabatu.GridColor = Color.LightGray;
            dataerabilezabatu.EnableHeadersVisualStyles = false;
            dataerabilezabatu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataerabilezabatu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoien estiloa
            btnerabilezabatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnerabilezabatuatzera.ForeColor = Color.White;
            btnerabilezabatuatzera.FlatStyle = FlatStyle.Flat;

            btnaldatu.BackColor = Color.FromArgb(0, 120, 215);
            btnaldatu.ForeColor = Color.White;
            btnaldatu.FlatStyle = FlatStyle.Flat;

            btnerabilezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnerabilezabatu.ForeColor = Color.White;
            btnerabilezabatu.FlatStyle = FlatStyle.Flat;

            btnerabilezabatuirten.BackColor = Color.FromArgb(120, 120, 120);
            btnerabilezabatuirten.ForeColor = Color.White;
            btnerabilezabatuirten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            // 🔹 centro pantalla
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // 🔹 tamaño del bloque
            int anchoTotal = 900;
            int altoTotal = 400;

            int startY = centroY - altoTotal / 2;


            dataerabilezabatu.Width = 700;
            dataerabilezabatu.Height = 250;
            dataerabilezabatu.Left = centroX - dataerabilezabatu.Width / 2;
            dataerabilezabatu.Top = startY;


            int botonesY = dataerabilezabatu.Bottom + 30;
            int espacio = 20;

            btnaldatu.Width = 120;
            btnerabilezabatu.Width = 120;
            btnerabilezabatuatzera.Width = 120;
            btnerabilezabatuirten.Width = 120;

            int anchoTotalBotones =
                btnerabilezabatuatzera.Width +
                btnaldatu.Width +
                btnerabilezabatu.Width +
                btnerabilezabatuirten.Width +
                (espacio * 3);

            int startBotonesX = centroX - (anchoTotalBotones / 2);

            btnerabilezabatuatzera.Top = botonesY;
            btnerabilezabatuatzera.Left = startBotonesX;

            btnaldatu.Top = botonesY;
            btnaldatu.Left = btnerabilezabatuatzera.Right + espacio;

            btnerabilezabatu.Top = botonesY;
            btnerabilezabatu.Left = btnaldatu.Right + espacio;

            btnerabilezabatuirten.Top = botonesY;
            btnerabilezabatuirten.Left = btnerabilezabatu.Right + espacio;
        }

        private void btnerabilezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);

            if (id == sesioa.ErabiltzaileId)
            {
                MessageBox.Show("Ezin duzu zeure burua ezabatu!");
                return;
            }

            DialogResult r = MessageBox.Show("Ziur zaude?", "EZABATU", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                DBKONEXIOA.EzabatuErabiltzailea(id);

                dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            }
        }

        private void btnerabilezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnerabilezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnaldatu_Click(object sender, EventArgs e)
        {
            // 🔒 solo IKT
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            // 🔹 comprobar selección
            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            // 🔹 coger datos
            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);
            string izena = dataerabilezabatu.CurrentRow.Cells["izena"].Value.ToString();
            string rolaActual = dataerabilezabatu.CurrentRow.Cells["rola"].Value.ToString();

            // 🔹 pedir datos nuevos
            string nuevaIzena = Microsoft.VisualBasic.Interaction.InputBox("Izena berria:", "Editatu", izena);
            string nuevaPass = Microsoft.VisualBasic.Interaction.InputBox("Pasahitza berria:", "Editatu", "");
            string nuevaRola = Microsoft.VisualBasic.Interaction.InputBox("Rola berria (Irakaslea / Mintegiburua / IKTarduraduna):", "Editatu", rolaActual);

            // 🔒 validar vacío
            if (string.IsNullOrWhiteSpace(nuevaIzena) || string.IsNullOrWhiteSpace(nuevaPass))
            {
                MessageBox.Show("Datuak falta dira!");
                return;
            }

            // 🔒 normalizar rola
            string r = nuevaRola.ToLower();

            if (r != "irakaslea" && r != "mintegiburua" && r != "iktarduraduna")
            {
                MessageBox.Show("Rola okerra!");
                return;
            }

            // 👉 guardar bonito
            if (r == "irakaslea") nuevaRola = "Irakaslea";
            if (r == "mintegiburua") nuevaRola = "Mintegiburua";
            if (r == "iktarduraduna") nuevaRola = "IKTarduraduna";

            // 🔥 contar IKT
            int kopurua = DBKONEXIOA.KontatuIKT();

            // ❌ no quitar último IKT
            if (rolaActual == "IKTarduraduna" && kopurua <= 1 && nuevaRola != "IKTarduraduna")
            {
                MessageBox.Show("Ezin da azken IKT aldatu!");
                return;
            }

            // ❌ no quitarte tu propio rol
            if (id == sesioa.ErabiltzaileId && rolaActual == "IKTarduraduna" && nuevaRola != "IKTarduraduna")
            {
                MessageBox.Show("Ezin duzu zeure rola kendu!");
                return;
            }

            // 🔹 actualizar
            DBKONEXIOA.AldatuErabiltzailea(id, nuevaIzena, nuevaPass, nuevaRola);

            MessageBox.Show("Erabiltzailea aldatuta!");

            // 🔄 refrescar
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
        }
    }
}
