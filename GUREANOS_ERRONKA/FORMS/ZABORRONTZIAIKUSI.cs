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
    public partial class ZABORRONTZIAIKUSI : Form
    {
        public ZABORRONTZIAIKUSI()
        {
            InitializeComponent();
        }

        private void datazabor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ZABORRONTZIAIKUSI_Load(object sender, EventArgs e)
        {
            // datuak kargatu
            datazabor.DataSource = DBKONEXIOA.IkusiZaborrontzia();
            datazabor.Columns["id_zaborrontzia"].Visible = false;

            // pantaila osoa
            this.WindowState = FormWindowState.Maximized;

            // fondo garbia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // datagrid estiloa
            datazabor.BackgroundColor = Color.White;
            datazabor.GridColor = Color.LightGray;
            datazabor.EnableHeadersVisualStyles = false;
            datazabor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            datazabor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoiak estiloa
            btnzaboratzera.BackColor = Color.FromArgb(100, 100, 100);
            btnzaboratzera.ForeColor = Color.White;
            btnzaboratzera.FlatStyle = FlatStyle.Flat;

            btnzaborirten.BackColor = Color.FromArgb(200, 50, 50);
            btnzaborirten.ForeColor = Color.White;
            btnzaborirten.FlatStyle = FlatStyle.Flat;

            // kokatu elementuak
            rekolokatu();
        }
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 180;

            // datagrid erdian
            datazabor.Width = 800;
            datazabor.Height = 300;
            datazabor.Left = centroX - datazabor.Width / 2;
            datazabor.Top = startY;

            // botoiak azpian
            int botonesY = datazabor.Bottom + 30;

            btnzaboratzera.Top = botonesY;
            btnzaboratzera.Left = centroX - 200;

            btnzaborirten.Top = botonesY;
            btnzaborirten.Left = centroX + 80;
        }

        private void btnzaboratzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnzaborirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
