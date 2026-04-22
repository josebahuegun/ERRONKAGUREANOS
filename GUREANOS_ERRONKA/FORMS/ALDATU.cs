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
            // 🔹 cargar mintegiak en el combo
            txtkokalekua.DataSource = DBKONEXIOA.LortuMintegiak();
            txtkokalekua.DisplayMember = "izena";
            txtkokalekua.ValueMember = "id";
            txtkokalekua.SelectedIndex = -1; // 🔥 evita selección automática

            // 🔹 cargar tabla
            dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            dataaldatu.Columns["id"].Visible = false;

            panelor.Visible = false;
            panelin.Visible = false;

            // itxura aldatu
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(240, 244, 248);

            RecolocarTodo();

            panel1.BackColor = Color.White;
            panelor.BackColor = Color.White;
            panelin.BackColor = Color.White;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panelor.BorderStyle = BorderStyle.FixedSingle;
            panelin.BorderStyle = BorderStyle.FixedSingle;
        }
        private void RecolocarTodo()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // 📏 bloque total (ajústalo si quieres más grande)
            int anchoTotal = 900;
            int altoTotal = 500;

            int startX = centroX - anchoTotal / 2;
            int startY = centroY - altoTotal / 2;

            // 📊 DATAGRID (arriba del bloque)
            dataaldatu.Width = 500;
            dataaldatu.Height = 180;
            dataaldatu.Left = startX;
            dataaldatu.Top = startY;

            // 📦 PANEL DATOS
            panel1.Width = 500;
            panel1.Height = 130;
            panel1.Left = startX;
            panel1.Top = dataaldatu.Bottom + 15;

            // 👉 DERECHA (zona secundaria)
            int derechaX = panel1.Right + 40;

            // 🔘 RADIOS
            radioordenagailua.Left = derechaX;
            radioordenagailua.Top = startY + 20;

            radioinprimagailua.Left = derechaX;
            radioinprimagailua.Top = radioordenagailua.Bottom + 20;

            // 💻 PANEL ORDENAGAILUA
            panelor.Left = derechaX;
            panelor.Top = panel1.Top;

            // 🖨️ PANEL INPRIMAGAILUA
            panelin.Left = derechaX;
            panelin.Top = panel1.Top;

            // 🔘 BOTONES CENTRADOS ABAJO
            int botonesY = panel1.Bottom + 30;

            btnaldatu.Top = botonesY;
            btnaldatu.Left = centroX - btnaldatu.Width / 2;

            btnaldatuatzera.Top = botonesY;
            btnaldatuatzera.Left = btnaldatu.Left - 180;

            btnaldatuirten.Top = botonesY;
            btnaldatuirten.Left = btnaldatu.Left + 180;
        }
        private void btnaldatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(dataaldatu.CurrentRow.Cells["mintegia_id"].Value);

                if (mintegiIdGailua != sesioa.MintegiaId)
                {
                    MessageBox.Show("Ezin duzu beste mintegi bateko gailua aldatu!");
                    return;
                }
            }
            if (dataaldatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu gailu bat!");
                return;
            }

            // 🔥 VALIDACIÓN COMBO
            if (txtkokalekua.SelectedIndex == -1)
            {
                MessageBox.Show("Aukeratu mintegia!");
                return;
            }

            int id = Convert.ToInt32(dataaldatu.CurrentRow.Cells["id"].Value);
            string mota = dataaldatu.CurrentRow.Cells["mota"].Value.ToString();

            try
            {
                // 🔹 actualizar gailua (usando ComboBox)
                Gailua g = new Gailua(
                    id,
                    data.Value,
                    txtkokalekua.Text, // 🔥 ComboBox
                    txtMarka.Text,
                    "aktibo",
                    txtkokalekua.Text // 🔥 ComboBox
                );

                DBKONEXIOA.AldatuGailua(g);

                // 🔹 ORDENAGAILUA
                if (mota == "Ordenagailua")
                {
                    DBKONEXIOA.AldatuOrdenagailua(
                        id,
                        txtRAM.Text,
                        txtROM.Text,
                        txtCPU.Text
                    );
                }

                // 🔹 INPRIMAGAILUA
                else if (mota == "Inprimagailua")
                {
                    DBKONEXIOA.AldatuInprimagailua(
                        id,
                        chkkolore.Checked,
                        txttekno.Text
                    );
                }

                MessageBox.Show("Aldatuta!");

                // 🔄 refrescar tabla
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
            RecolocarTodo();
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
    }
}
