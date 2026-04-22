using GUREANOS_ERRONKA.CODIGO;
using GUREANOS_ERRONKA.FORMS;
using System;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA
{
    public partial class PANELA : Form
    {
        public PANELA()
        {
            InitializeComponent();
        }

        private void PANELA_Load(object sender, EventArgs e)
        {
            if (sesioa.Rola == "Irakaslea")
            {
                // GAILUAK
                gEHITUToolStripMenuItem.Visible = false;
                aLDATUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem.Visible = false;

                // ERABILTZAILEAK
                sORTUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem1.Visible = false;

                // MINTEGIAK
                sORTUToolStripMenuItem1.Visible = false;
                iKUSIEZABATUToolStripMenuItem.Visible = false;
            }

            else if (sesioa.Rola == "Mintegiburua")
            {
                // usuarios fuera
                sORTUToolStripMenuItem.Visible = false;
                eZABATUToolStripMenuItem1.Visible = false;

                // mintegiak fuera
                sORTUToolStripMenuItem1.Visible = false;
                iKUSIEZABATUToolStripMenuItem.Visible = false;
            }

            else if (sesioa.Rola == "IKTarduraduna")
            {
                // todo permitido
            }
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