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
    public partial class ERABILTZAILEAKIKUSI : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ERABILTZAILEAKIKUSI" /> class.
        /// </summary>
        public ERABILTZAILEAKIKUSI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ERABILTZAILEAKIKUSI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ERABILTZAILEAKIKUSI_Load(object sender, EventArgs e)
        {
            /// datuak kargatu
            dataikusierabil.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            dataikusierabil.Columns["id"].Visible = false;


            /// leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            /// fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            /// datagrid estiloa
            dataikusierabil.BackgroundColor = Color.White;
            dataikusierabil.GridColor = Color.LightGray;
            dataikusierabil.EnableHeadersVisualStyles = false;
            dataikusierabil.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataikusierabil.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            /// botoiak estiloa
            btnikusierabilatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnikusierabilatzera.ForeColor = Color.White;
            btnikusierabilatzera.FlatStyle = FlatStyle.Flat;

            btnikusierabilirten.BackColor = Color.FromArgb(200, 50, 50);
            btnikusierabilirten.ForeColor = Color.White;
            btnikusierabilirten.FlatStyle = FlatStyle.Flat;

            /// elementuak kokatu
            rekolokatuikusi();
        }
        /// <summary>
        /// Rekolokatuikusis this instance.
        /// </summary>
        private void rekolokatuikusi()
        {
            /// pantailaren erdigunea kalkulatu
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            /// bloke altuera
            int altoTotal = 350;
            int startY = centroY - altoTotal / 2;

            /// datagrid erdian
            dataikusierabil.Width = 700;
            dataikusierabil.Height = 250;
            dataikusierabil.Left = centroX - dataikusierabil.Width / 2;
            dataikusierabil.Top = startY;

            /// botoiak azpian
            int botonesY = dataikusierabil.Bottom + 30;

            btnikusierabilatzera.Top = botonesY;
            btnikusierabilatzera.Left = centroX - 200;

            btnikusierabilirten.Top = botonesY;
            btnikusierabilirten.Left = centroX + 80;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatuikusi();
        }

        /// <summary>
        /// Handles the Click event of the btnikusierabilatzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnikusierabilatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the Click event of the btnikusierabilirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnikusierabilirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the CellContentClick event of the dataikusierabil control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dataikusierabil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

