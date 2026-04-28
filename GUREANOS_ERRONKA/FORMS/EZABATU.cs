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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class EZABATU : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EZABATU" /> class.
        /// </summary>
        public EZABATU()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnezabatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(ezabatudata.CurrentRow.Cells["MintegiaId"].Value);

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

        /// <summary>
        /// Handles the CellContentClick event of the ezabatudata control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void ezabatudata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the EZABATU control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EZABATU_Load(object sender, EventArgs e)
        {
            /// datuak kargatu
            ezabatudata.DataSource = DBKONEXIOA.ikusiGailuak();
            ezabatudata.Columns["id"].Visible = true;
            ezabatudata.Columns["id"].DisplayIndex = 0;
            ezabatudata.Columns["id"].HeaderText = "Etiketa";

            /// leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            /// fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            /// datagrid estiloa
            ezabatudata.BackgroundColor = Color.White;
            ezabatudata.GridColor = Color.LightGray;
            ezabatudata.EnableHeadersVisualStyles = false;
            ezabatudata.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            ezabatudata.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            /// botoiak estiloa
            btnezabatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnezabatuatzera.ForeColor = Color.White;
            btnezabatuatzera.FlatStyle = FlatStyle.Flat;

            btnezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnezabatu.ForeColor = Color.White;
            btnezabatu.FlatStyle = FlatStyle.Flat;

            btnezabatuirten.BackColor = Color.FromArgb(120, 120, 120);
            btnezabatuirten.ForeColor = Color.White;
            btnezabatuirten.FlatStyle = FlatStyle.Flat;

            /// elementuak kokatu
            rekolokatu();
        }
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            /// pantailaren erdigunea
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int altoTotal = 350;
            int startY = centroY - altoTotal / 2;

            /// datagrid erdian
            ezabatudata.Width = 700;
            ezabatudata.Height = 250;
            ezabatudata.Left = centroX - ezabatudata.Width / 2;
            ezabatudata.Top = startY;

            /// botoiak azpian
            int botonesY = ezabatudata.Bottom + 30;

            btnezabatu.Top = botonesY;
            btnezabatu.Left = centroX - btnezabatu.Width / 2;

            btnezabatuatzera.Top = botonesY;
            btnezabatuatzera.Left = btnezabatu.Left - 180;

            btnezabatuirten.Top = botonesY;
            btnezabatuirten.Left = btnezabatu.Left + 180;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
        /// <summary>
        /// Handles the Click event of the btnezabatuatzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the Click event of the btnezabatuirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
