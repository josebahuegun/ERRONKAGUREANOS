using GUREANOS_ERRONKA.CODIGO;
using GUREANOS_ERRONKA.FORMS;
using System;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA
{
    public partial class PANELA : Form
    {
        System.Windows.Forms.Timer reloj = new System.Windows.Forms.Timer();

        public PANELA()
        {
            InitializeComponent();
        }

        private void PANELA_Load(object sender, EventArgs e)
        {
            // fondo garbia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // titulua
            lblTitulo.Text = "MENUA";
            lblTitulo.Font = new Font("Segoe UI", 30, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitulo.AutoSize = true;

            // erabiltzailea
            lblErabiltzailea.Text = "Erabiltzailea: " + sesioa.Izena;
            lblErabiltzailea.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblErabiltzailea.AutoSize = true;

            // rola
            lblRola.Text = "Rola: " + sesioa.Rola;
            lblRola.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRola.AutoSize = true;

            // data
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblFecha.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFecha.AutoSize = true;

            // ordua
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblHora.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHora.AutoSize = true;

            // timer martxan
            reloj.Interval = 1000;
            reloj.Tick += erlojua;
            reloj.Start();

            // kokatu elementuak
            rekolokatu();

            // 🔐 permisos
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
        private void erlojua(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            // titulua
            lblTitulo.Left = centroX - lblTitulo.Width / 2;
            lblTitulo.Top = centroY - 140;

            // erabiltzailea
            lblErabiltzailea.Left = centroX - lblErabiltzailea.Width / 2;
            lblErabiltzailea.Top = lblTitulo.Bottom + 30;

            // rola
            lblRola.Left = centroX - lblRola.Width / 2;
            lblRola.Top = lblErabiltzailea.Bottom + 10;

            // data
            lblFecha.Left = centroX - lblFecha.Width / 2;
            lblFecha.Top = lblRola.Bottom + 30;

            // ordua
            lblHora.Left = centroX - lblHora.Width / 2;
            lblHora.Top = lblFecha.Bottom + 10;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }

        // 🔍 IKUSI GAILUAK
        private void iKUSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IKUSI ikusi = new IKUSI();
            ikusi.Show();
            this.Hide();
        }

        // ➕ GEHITU GAILUA
        private void gEHITUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEHITU gehitu = new GEHITU();
            gehitu.Show();
            this.Hide();
        }

        // ✏️ ALDATU GAILUA
        private void aLDATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ALDATU a = new ALDATU();
            a.Show();
            this.Hide();
        }

        // ❌ EZABATU GAILUA
        private void eZABATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EZABATU ee = new EZABATU();
            ee.Show();
            this.Hide();
        }

        // 🗑️ ZABORRONTZIA
        private void zABORRONTZIANIKUSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZABORRONTZIAIKUSI z = new ZABORRONTZIAIKUSI();
            z.Show();
            this.Hide();
        }


        // ➕ ERABILTZAILEA SORTU
        private void erabiltzaileakSortuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // ❌ ERABILTZAILEA EZABATU
        private void erabiltzaileakEzabatuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // 🚪 IRTEN
        private void irtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iKUSIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ERABILTZAILEAKIKUSI ikusi = new ERABILTZAILEAKIKUSI();
            ikusi.Show();
            this.Hide();
        }

        private void sORTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERABILTZAILEASORTU sortu = new ERABILTZAILEASORTU();
            sortu.Show();
            this.Hide();
        }

        private void aLDATUToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eZABATUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ERABILTZAILEAEZABATU ezabatu = new ERABILTZAILEAEZABATU();
            ezabatu.Show();
            this.Hide();
        }

        private void iKUSIEZABATUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MINTEGIAEZABATUIKUSI ikusi = new MINTEGIAEZABATUIKUSI();
            ikusi.Show();
            this.Hide();
        }

        private void sORTUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SORTUMINTEGIA sortu = new SORTUMINTEGIA();
            sortu.Show();
            this.Hide();
        }

        private void gAILUENHISTORIALAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HISTORIALAKUDEATU sortu = new HISTORIALAKUDEATU();
            sortu.Show();
            this.Hide();
        }
    }
}