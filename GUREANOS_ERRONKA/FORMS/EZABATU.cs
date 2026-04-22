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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GUREANOS_ERRONKA.FORMS
{
    public partial class EZABATU : Form
    {
        public EZABATU()
        {
            InitializeComponent();
        }

        private void btnezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(ezabatudata.CurrentRow.Cells["mintegia_id"].Value);

                if (mintegiIdGailua != sesioa.MintegiaId)
                {
                    MessageBox.Show("Ezin duzu beste mintegi bateko gailua ezabatu!");
                    return;
                }
            }
            if (ezabatudata.CurrentRow != null)
            {
                int id = Convert.ToInt32(ezabatudata.CurrentRow.Cells["id"].Value);

                DBKONEXIOA.EzabatuGailua(id);

                MessageBox.Show("Ezabatuta!");

                ezabatudata.DataSource = DBKONEXIOA.ikusiGailuak();
            }
        }

        private void ezabatudata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EZABATU_Load(object sender, EventArgs e)
        {
            // datuak kargatu
            ezabatudata.DataSource = DBKONEXIOA.ikusiGailuak();
            ezabatudata.Columns["id"].Visible = false;

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // datagrid estiloa
            ezabatudata.BackgroundColor = Color.White;
            ezabatudata.GridColor = Color.LightGray;
            ezabatudata.EnableHeadersVisualStyles = false;
            ezabatudata.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            ezabatudata.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoiak estiloa
            btnezabatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnezabatuatzera.ForeColor = Color.White;
            btnezabatuatzera.FlatStyle = FlatStyle.Flat;

            btnezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnezabatu.ForeColor = Color.White;
            btnezabatu.FlatStyle = FlatStyle.Flat;

            btnezabatuirten.BackColor = Color.FromArgb(120, 120, 120);
            btnezabatuirten.ForeColor = Color.White;
            btnezabatuirten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            // pantailaren erdigunea
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int altoTotal = 350;
            int startY = centroY - altoTotal / 2;

            // datagrid erdian
            ezabatudata.Width = 700;
            ezabatudata.Height = 250;
            ezabatudata.Left = centroX - ezabatudata.Width / 2;
            ezabatudata.Top = startY;

            // botoiak azpian
            int botonesY = ezabatudata.Bottom + 30;

            btnezabatu.Top = botonesY;
            btnezabatu.Left = centroX - btnezabatu.Width / 2;

            btnezabatuatzera.Top = botonesY;
            btnezabatuatzera.Left = btnezabatu.Left - 180;

            btnezabatuirten.Top = botonesY;
            btnezabatuirten.Left = btnezabatu.Left + 180;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
        private void btnezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
