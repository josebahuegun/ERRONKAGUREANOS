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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ZABORRONTZIAIKUSI : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZABORRONTZIAIKUSI"/> class.
        /// </summary>
        public ZABORRONTZIAIKUSI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CellContentClick event of the datazabor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void datazabor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the ZABORRONTZIAIKUSI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZABORRONTZIAIKUSI_Load(object sender, EventArgs e)
        {
            // datuak kargatu
            datazabor.DataSource = DBKONEXIOA.IkusiZaborrontzia();
            datazabor.Columns["Etiketa"].DisplayIndex = 0;



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
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the btnzaboratzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnzaboratzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnzaborirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnzaborirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
