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
    public partial class ERABILTZAILEAKIKUSI : Form
    {
        public ERABILTZAILEAKIKUSI()
        {
            InitializeComponent();
        }

        private void ERABILTZAILEAKIKUSI_Load(object sender, EventArgs e)
        {
            // datuak kargatu
            dataikusierabil.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            dataikusierabil.Columns["id"].Visible = false;

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // datagrid estiloa
            dataikusierabil.BackgroundColor = Color.White;
            dataikusierabil.GridColor = Color.LightGray;
            dataikusierabil.EnableHeadersVisualStyles = false;
            dataikusierabil.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataikusierabil.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoiak estiloa
            btnikusierabilatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnikusierabilatzera.ForeColor = Color.White;
            btnikusierabilatzera.FlatStyle = FlatStyle.Flat;

            btnikusierabilirten.BackColor = Color.FromArgb(200, 50, 50);
            btnikusierabilirten.ForeColor = Color.White;
            btnikusierabilirten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatuikusi();
        }
        private void rekolokatuikusi()
        {
            // pantailaren erdigunea kalkulatu
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // bloke altuera
            int altoTotal = 350;
            int startY = centroY - altoTotal / 2;

            // datagrid erdian
            dataikusierabil.Width = 700;
            dataikusierabil.Height = 250;
            dataikusierabil.Left = centroX - dataikusierabil.Width / 2;
            dataikusierabil.Top = startY;

            // botoiak azpian
            int botonesY = dataikusierabil.Bottom + 30;

            btnikusierabilatzera.Top = botonesY;
            btnikusierabilatzera.Left = centroX - 200;

            btnikusierabilirten.Top = botonesY;
            btnikusierabilirten.Left = centroX + 80;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatuikusi();
        }

        private void btnikusierabilatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnikusierabilirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataikusierabil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

