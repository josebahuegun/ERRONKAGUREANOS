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
    }
}