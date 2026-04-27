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
    public partial class IKUSI : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IKUSI"/> class.
        /// </summary>
        public IKUSI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the Load event of the IKUSI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void IKUSI_Load(object sender, EventArgs e)
        {
            // datu-basetik gailuen zerrenda ekarri
            List<Gailua> gailuZerrenda = DBKONEXIOA.ikusiGailuak();

            // zerrenda eraldatu datuak erakusteko
            var erakustekoTaula = gailuZerrenda.Select(g => new
            {
                Id = g.Id,
                Mota = g.Mota,
                Marka = g.Marka,
                Kokalekua = g.Kokalekua,
                ErosteData = g.ErosteData.ToShortDateString(),
                Egoera = g.Egoera,
                Mintegia = g.Mintegia,

                RAM = (g is Ordenagailua) ? ((Ordenagailua)g).RAM1 : "",
                ROM = (g is Ordenagailua) ? ((Ordenagailua)g).ROM1 : "",
                CPU = (g is Ordenagailua) ? ((Ordenagailua)g).CPU1 : "",

                Koloretakoa = (g is Inprimagailua) ? ((Inprimagailua)g).Koloretakoa.ToString() : "",
                Teknologia = (g is Inprimagailua) ? ((Inprimagailua)g).Teknologia : ""
            }).ToList();

            // datagrid-ean erakutsi
            dataGridView1.DataSource = erakustekoTaula;

            // id-a lelna eta ikusgai, etiketa izenarekin
            dataGridView1.Columns["Id"].Visible = true;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].HeaderText = "Etiketa";
            // ezkutatu
            dataGridView1.Columns["Egoera"].Visible = false;

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
            btnikusiatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnikusiatzera.ForeColor = Color.White;
            btnikusiatzera.FlatStyle = FlatStyle.Flat;

            btnikusiirten.BackColor = Color.FromArgb(200, 50, 50);
            btnikusiirten.ForeColor = Color.White;
            btnikusiirten.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            // pantailaren erdigunea kalkulatu
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int altoTotal = 400;
            int startY = centroY - altoTotal / 2;

            // datagrid erdian
            dataGridView1.Width = 900;
            dataGridView1.Height = 300;
            dataGridView1.Left = centroX - dataGridView1.Width / 2;
            dataGridView1.Top = startY;

            // botoiak azpian
            int botonesY = dataGridView1.Bottom + 30;

            btnikusiatzera.Top = botonesY;
            btnikusiatzera.Left = centroX - 200;
                
            btnikusiirten.Top = botonesY;
            btnikusiirten.Left = centroX + 80;
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
        /// Handles the CellContentClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnikusiirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnikusiirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
