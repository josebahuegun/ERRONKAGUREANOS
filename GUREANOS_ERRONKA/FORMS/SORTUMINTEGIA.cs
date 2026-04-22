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
    public partial class SORTUMINTEGIA : Form
    {
        public SORTUMINTEGIA()
        {
            InitializeComponent();
        }

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

        private void atzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
