using GUREANOS_ERRONKA.CODIGO;
using GUREANOS_ERRONKA.FORMS;
using System;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PANELA : Form
    {
        /// <summary>
        /// The reloj
        /// </summary>
        System.Windows.Forms.Timer reloj = new System.Windows.Forms.Timer();

        /// <summary>
        /// Initializes a new instance of the <see cref="PANELA" /> class.
        /// </summary>
        public PANELA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the PANELA control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void PANELA_Load(object sender, EventArgs e)
        {
            /// fondo garbia
            this.BackColor = Color.FromArgb(240, 244, 248);

            /// pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            /// titulua
            lblTitulo.Text = "MENUA";
            lblTitulo.Font = new Font("Segoe UI", 30, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitulo.AutoSize = true;


            ///sesioa itxi eta irten botoiak
            btnIrten.BackColor = Color.FromArgb(120, 120, 120);
            btnIrten.ForeColor = Color.White;
            btnIrten.FlatStyle = FlatStyle.Flat;

            btnsesioaItxi.BackColor = Color.FromArgb(200, 50, 50);
            btnsesioaItxi.ForeColor = Color.White;
            btnsesioaItxi.FlatStyle = FlatStyle.Flat;

            /// erabiltzailea
            lblErabiltzailea.Text = "Erabiltzailea: " + sesioa.Izena;
            lblErabiltzailea.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblErabiltzailea.AutoSize = true;

            /// rola
            lblRola.Text = "Rola: " + sesioa.Rola;
            lblRola.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRola.AutoSize = true;

            /// data
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblFecha.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFecha.AutoSize = true;

            /// ordua
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblHora.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHora.AutoSize = true;

            /// timer martxan
            reloj.Interval = 1000;
            reloj.Tick += erlojua;
            reloj.Start();

            /// kokatu elementuak
            rekolokatu();

            /// baimenak rolaren arabera
            if (sesioa.Rola == "Irakaslea")
            {
                gEHITUToolStripMenuItem.Visible = false;
                aLDATUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem.Visible = false;

                sORTUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem1.Visible = false;

                sORTUToolStripMenuItem1.Visible = false;
                iKUSIEZABATUToolStripMenuItem.Visible = false;
            }
            else if (sesioa.Rola == "Mintegiburua")
            {
                sORTUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem1.Visible = false;

                sORTUToolStripMenuItem1.Visible = false;
                iKUSIEZABATUToolStripMenuItem.Visible = false;
            }
        }
        /// <summary>
        /// Erlojuas the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void erlojua(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            /// titulua
            lblTitulo.Left = centroX - lblTitulo.Width / 2;
            lblTitulo.Top = centroY - 140;

            /// erabiltzailea
            lblErabiltzailea.Left = centroX - lblErabiltzailea.Width / 2;
            lblErabiltzailea.Top = lblTitulo.Bottom + 30;

            /// rola
            lblRola.Left = centroX - lblRola.Width / 2;
            lblRola.Top = lblErabiltzailea.Bottom + 10;

            /// data
            lblFecha.Left = centroX - lblFecha.Width / 2;
            lblFecha.Top = lblRola.Bottom + 30;

            /// ordua
            lblHora.Left = centroX - lblHora.Width / 2;
            lblHora.Top = lblFecha.Bottom + 10;


            int centroXX = this.ClientSize.Width / 2;
            int abajoY = this.ClientSize.Height - 120;

            /// SESIOA ITXI 
            btnsesioaItxi.Top = abajoY;
            btnsesioaItxi.Left = centroXX - 150;

            /// IRTEN 
            btnIrten.Top = abajoY;
            btnIrten.Left = centroXX + 20;

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
        /// Handles the Click event of the iKUSIToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// IKUSI GAILUAK
        private void iKUSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IKUSI ikusi = new IKUSI();
            ikusi.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the gEHITUToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// GEHITU GAILUA
        private void gEHITUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEHITU gehitu = new GEHITU();
            gehitu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the aLDATUToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// ALDATU GAILUA
        private void aLDATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ALDATU a = new ALDATU();
            a.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the eZABATUToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// EZABATU GAILUA
        private void eZABATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EZABATU ee = new EZABATU();
            ee.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the zABORRONTZIANIKUSIToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// ZABORRONTZIA
        private void zABORRONTZIANIKUSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZABORRONTZIAIKUSI z = new ZABORRONTZIAIKUSI();
            z.Show();
            this.Hide();
        }


        /// <summary>
        /// Handles the Click event of the erabiltzaileakSortuToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// ERABILTZAILEA SORTU
        private void erabiltzaileakSortuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the erabiltzaileakEzabatuToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// ERABILTZAILEA EZABATU
        private void erabiltzaileakEzabatuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the irtenToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// IRTEN
        private void irtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the iKUSIToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void iKUSIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ERABILTZAILEAKIKUSI ikusi = new ERABILTZAILEAKIKUSI();
            ikusi.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the sORTUToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void sORTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERABILTZAILEASORTU sortu = new ERABILTZAILEASORTU();
            sortu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the aLDATUToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void aLDATUToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the eZABATUToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void eZABATUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ERABILTZAILEAEZABATU ezabatu = new ERABILTZAILEAEZABATU();
            ezabatu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the iKUSIEZABATUToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void iKUSIEZABATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MINTEGIAEZABATUIKUSI ikusi = new MINTEGIAEZABATUIKUSI();
            ikusi.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the sORTUToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void sORTUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SORTUMINTEGIA sortu = new SORTUMINTEGIA();
            sortu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the gAILUENHISTORIALAToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void gAILUENHISTORIALAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HISTORIALAKUDEATU sortu = new HISTORIALAKUDEATU();
            sortu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnsesioaItxi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnsesioaItxi_Click(object sender, EventArgs e)
        {
            /// garbitu sesioa
            sesioa.ErabiltzaileId = 0;
            sesioa.Izena = "";
            sesioa.Rola = "";
            sesioa.MintegiaId = 0;

            /// loginera itzuli
            LOGIN f = new LOGIN();
            f.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnIrten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnIrten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}