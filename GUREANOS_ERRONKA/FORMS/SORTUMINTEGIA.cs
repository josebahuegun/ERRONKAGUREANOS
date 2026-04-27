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
    public partial class SORTUMINTEGIA : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SORTUMINTEGIA"/> class.
        /// </summary>
        public SORTUMINTEGIA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the SORTU control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SORTU_Click(object sender, EventArgs e)
        {
            if (txtizena.Text == "")
            {
                MessageBox.Show("Sartu izena!");
                return;
            }

            // ez utzi Almazena izena erabiltzen
            if (txtizena.Text == "Almazena")
            {
                MessageBox.Show("Izena erabilia!");
                return;
            }

            bool sortuta = DBKONEXIOA.SortuMintegia(txtizena.Text);

            if (sortuta)
            {
                MessageBox.Show("Mintegia sortuta!");

                txtizena.Clear();
            }
        }

        /// <summary>
        /// Handles the Click event of the atzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void atzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Load event of the SORTUMINTEGIA control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SORTUMINTEGIA_Load(object sender, EventArgs e)
        {
            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // label estiloa
            label1.ForeColor = Color.Black;
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // textbox estiloa
            txtizena.BackColor = Color.White;
            txtizena.ForeColor = Color.Black;
            txtizena.BorderStyle = BorderStyle.FixedSingle;

            // botoiak estiloa
            atzera.BackColor = Color.FromArgb(100, 100, 100);
            atzera.ForeColor = Color.White;
            atzera.FlatStyle = FlatStyle.Flat;

            SORTU.BackColor = Color.FromArgb(0, 120, 215);
            SORTU.ForeColor = Color.White;
            SORTU.FlatStyle = FlatStyle.Flat;

            irten.BackColor = Color.FromArgb(200, 50, 50);
            irten.ForeColor = Color.White;
            irten.FlatStyle = FlatStyle.Flat;

            // elementuak erdian jarri
            rekolokatu();
        }
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 80;

            // label kokatu
            label1.Left = centroX - 150;
            label1.Top = startY;

            // textbox kokatu
            txtizena.Left = centroX + 20;
            txtizena.Top = startY;

            // botoiak kokatu
            int botonesY = startY + 120;

            SORTU.Top = botonesY;
            SORTU.Left = centroX - SORTU.Width / 2;

            atzera.Top = botonesY;
            atzera.Left = SORTU.Left - 180;

            irten.Top = botonesY;
            irten.Left = SORTU.Left + 180;
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
    }
}
