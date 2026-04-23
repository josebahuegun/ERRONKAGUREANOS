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
    public partial class MINTEGIAEZABATUIKUSI : Form
    {
        public MINTEGIAEZABATUIKUSI()
        {
            InitializeComponent();
        }

        private void btnezabatu_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            string izena = dataGridView1.CurrentRow.Cells["izena"].Value.ToString();

            // ALMAZENA EZABATZEKO AUKERA EZ EMAN
            if (izena == "Almazena" || izena == "Matxuratuak")
            {
                MessageBox.Show("Ezin da Mintegi hori ezabatu!");
                return;
            }
            // MINTEGIAK IRASAKLEAK DITUEN EGIAZTATU
            else if (DBKONEXIOA.MintegiakIrakasleakDitu(id) == true)
            {
                MessageBox.Show("Ezin da mintegia ezabatu, oraindik irakasleak baititu esleituta. Mesedez, kendu irakasleak ezabatu aurretik.", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBKONEXIOA.EzabatuMintegia(id);

            MessageBox.Show("Mintegia ezabatuta!");

            dataGridView1.DataSource = DBKONEXIOA.LortuMintegiak();
        }

        private void MINTEGIAEZABATUIKUSI_Load(object sender, EventArgs e)
        {
            // datuak kargatu
            dataGridView1.DataSource = DBKONEXIOA.LortuMintegiak();
            dataGridView1.Columns["id"].Visible = false;

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // datagrid estiloa
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoiak estiloa
            btnatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnatzera.ForeColor = Color.White;
            btnatzera.FlatStyle = FlatStyle.Flat;

            btnezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnezabatu.ForeColor = Color.White;
            btnezabatu.FlatStyle = FlatStyle.Flat;

            irten.BackColor = Color.FromArgb(120, 120, 120);
            irten.ForeColor = Color.White;
            irten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int altoTotal = 350;
            int startY = centroY - altoTotal / 2;

            // datagrid erdian
            dataGridView1.Width = 700;
            dataGridView1.Height = 250;
            dataGridView1.Left = centroX - dataGridView1.Width / 2;
            dataGridView1.Top = startY;

            // botoiak azpian
            int botonesY = dataGridView1.Bottom + 30;

            btnezabatu.Top = botonesY;
            btnezabatu.Left = centroX - btnezabatu.Width / 2;

            btnatzera.Top = botonesY;
            btnatzera.Left = btnezabatu.Left - 180;

            irten.Top = botonesY;
            irten.Left = btnezabatu.Left + 180;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void irten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
