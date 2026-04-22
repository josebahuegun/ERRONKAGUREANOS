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
    public partial class ERABILTZAILEAEZABATU : Form
    {
        public ERABILTZAILEAEZABATU()
        {
            InitializeComponent();
        }

        private void dataerabilezabatu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ERABILTZAILEAEZABATU_Load(object sender, EventArgs e)
        {
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();

            dataerabilezabatu.Columns["id"].Visible = false;
        }

        private void btnerabilezabatu_Click(object sender, EventArgs e)
        {
            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);

            DBKONEXIOA.EzabatuErabiltzailea(id);

            MessageBox.Show("Ezabatuta!");

            // refrescar tabla
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
        }

        private void btnerabilezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnerabilezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
