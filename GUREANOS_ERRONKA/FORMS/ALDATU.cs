using GUREANOS_ERRONKA.CODIGO;
using MySql.Data.MySqlClient;
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
    public partial class ALDATU : Form
    {
        public ALDATU()
        {
            InitializeComponent();
        }

        private void dataaldatu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ALDATU_Load(object sender, EventArgs e)
        {
            // mintegiak kargatu combobox-ean
            txtkokalekua.DataSource = DBKONEXIOA.LortuMintegiak();
            txtkokalekua.DisplayMember = "izena";
            txtkokalekua.ValueMember = "id";
            txtkokalekua.SelectedIndex = -1; // lehenetsitako aukerarik ez

            // datagrid-a bete gailuekin
            dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            dataaldatu.Columns["id"].Visible = true;
            dataaldatu.Columns["id"].DisplayIndex = 0;
            dataaldatu.Columns["id"].HeaderText = "Etiketa";
            dataaldatu.Columns["MintegiaId"].Visible = false;

            // panelak hasieran ezkutatuta
            panelor.Visible = false;
            panelin.Visible = false;

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // panelen itxura txukuna
            panel1.BackColor = Color.White;
            panelor.BackColor = Color.White;
            panelin.BackColor = Color.White;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panelor.BorderStyle = BorderStyle.FixedSingle;
            panelin.BorderStyle = BorderStyle.FixedSingle;

            // datagrid estiloa
            dataaldatu.BackgroundColor = Color.White;
            dataaldatu.GridColor = Color.LightGray;
            dataaldatu.EnableHeadersVisualStyles = false;
            dataaldatu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataaldatu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            // atzera 
            btnaldatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnaldatuatzera.ForeColor = Color.White;
            btnaldatuatzera.FlatStyle = FlatStyle.Flat;

            // aldatu 
            btnaldatu.BackColor = Color.FromArgb(0, 120, 215);
            btnaldatu.ForeColor = Color.White;
            btnaldatu.FlatStyle = FlatStyle.Flat;

            // irten 
            btnaldatuirten.BackColor = Color.FromArgb(200, 50, 50);
            btnaldatuirten.ForeColor = Color.White;
            btnaldatuirten.FlatStyle = FlatStyle.Flat;
            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            // 🔹 pantailaren erdigunea kalkulatu
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // 🔹 bloke osoaren tamaina
            int anchoTotal = 950;
            int altoTotal = 520;

            // 🔹 hasierako posizioa (erdian jartzeko)
            int startX = centroX - anchoTotal / 2;
            int startY = centroY - altoTotal / 2;

            // 🔹 datagrid goian
            dataaldatu.Width = 550;
            dataaldatu.Height = 200;
            dataaldatu.Left = startX;
            dataaldatu.Top = startY;

            // 🔹 datuen panela azpian
            panel1.Width = 550;
            panel1.Height = 140;
            panel1.Left = startX;
            panel1.Top = dataaldatu.Bottom + 15;

            // 🔹 eskuineko zona kalkulatu
            int derechaX = panel1.Right + 40;

            // 🔹 radio botoiak
            radioordenagailua.Left = derechaX;
            radioordenagailua.Top = startY + 20;

            radioinprimagailua.Left = derechaX;
            radioinprimagailua.Top = radioordenagailua.Bottom + 20;

            // 🔹 ordenagailu panela
            panelor.Left = derechaX;
            panelor.Top = panel1.Top;

            // 🔹 inprimagailu panela
            panelin.Left = derechaX;
            panelin.Top = panel1.Top;

            // 🔹 botoiak behean eta zentratuta
            int botonesY = panel1.Bottom + 40;

            btnaldatu.Top = botonesY;
            btnaldatu.Left = centroX - btnaldatu.Width / 2;

            btnaldatuatzera.Top = botonesY;
            btnaldatuatzera.Left = btnaldatu.Left - 180;

            btnaldatuirten.Top = botonesY;
            btnaldatuirten.Left = btnaldatu.Left + 180;
        }

        private void btnaldatu_Click(object sender, EventArgs e)
        {
            if (dataaldatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu gailu bat!");
                return;
            }

            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(dataaldatu.CurrentRow.Cells["MintegiaId"].Value);

                if (mintegiIdGailua != sesioa.MintegiaId)
                {
                    MessageBox.Show("Ezin duzu beste mintegi bateko gailua aldatu!");
                    return;
                }
            }

            if (txtkokalekua.SelectedIndex == -1)
            {
                MessageBox.Show("Aukeratu mintegia!");
                return;
            }

            int id = Convert.ToInt32(dataaldatu.CurrentRow.Cells["id"].Value);

            string motaActual = dataaldatu.CurrentRow.Cells["Mota"].Value.ToString();

            string motaBerria = "";

            if (radioordenagailua.Checked)
                motaBerria = "Ordenagailua";
            else if (radioinprimagailua.Checked)
                motaBerria = "Inprimagailua";

            if (motaBerria == "")
            {
                MessageBox.Show("Aukeratu mota!");
                return;
            }

            try
            {
                string ram = txtRAM?.Text ?? "";
                string rom = txtROM?.Text ?? "";
                string cpu = txtCPU?.Text ?? "";
                string tekno = txttekno?.Text ?? "";

                Gailua g = new Gailua(
                    id,
                    data.Value,
                    txtkokalekua.Text,
                    txtMarka.Text,
                    "aktibo",
                    txtkokalekua.Text
                );

                DBKONEXIOA.AldatuGailua(g);

                if (motaActual != motaBerria)
                {
                    if (motaActual == "Ordenagailua" && motaBerria == "Inprimagailua")
                    {
                        DBKONEXIOA.EzabatuOrdenagailua(id);
                        DBKONEXIOA.TxertatuInprimagailua(id, chkkolore.Checked, tekno);
                    }
                    else if (motaActual == "Inprimagailua" && motaBerria == "Ordenagailua")
                    {
                        DBKONEXIOA.EzabatuInprimagailua(id);
                        DBKONEXIOA.TxertatuOrdenagailua(id, ram, rom, cpu);
                    }

                    // historiala (sin tocar conexión)
                    DBKONEXIOA.TxertatuHistorikoa(
                        "ALDATU",
                        "mota aldatu da: " + motaActual + " -> " + motaBerria,
                        id
                    );
                }
                else
                {
                    if (motaActual == "Ordenagailua")
                    {
                        DBKONEXIOA.AldatuOrdenagailua(id, ram, rom, cpu);
                    }
                    else if (motaActual == "Inprimagailua")
                    {
                        DBKONEXIOA.AldatuInprimagailua(id, chkkolore.Checked, tekno);
                    }

                    // historiala (sin tocar conexión)
                    DBKONEXIOA.TxertatuHistorikoa(
                        "ALDATU",
                        "gailua eguneratu da: " + txtMarka.Text,
                        id
                    );
                }

                MessageBox.Show("Aldatuta!");

                GarbituFormularioa();

                dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
        private void GarbituFormularioa()
        {
            txtMarka.Text = "";
            txtRAM.Text = "";
            txtROM.Text = "";
            txtCPU.Text = "";
            txttekno.Text = "";

            // combobox segurua
            if (txtkokalekua.Items.Count > 0)
                txtkokalekua.SelectedIndex = 0;

            data.Value = DateTime.Now;

            chkkolore.Checked = false;

            // radio segurua (uno siempre activo)
            radioordenagailua.Checked = true;

            panelor.Visible = false;
            panelin.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioordenagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioordenagailua.Checked)
            {
                panelor.Visible = true;
                panelin.Visible = false;
            }
        }

        private void radioinprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioinprimagailua.Checked)
            {
                panelor.Visible = false;
                panelin.Visible = true;
            }
        }

        private void txtkokalekua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnaldatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnaldatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
