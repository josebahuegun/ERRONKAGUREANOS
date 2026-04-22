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
    public partial class MINTEGIAEZABATUIKUSI : Form
    {
        public MINTEGIAEZABATUIKUSI()
        {
            InitializeComponent();
        }

        private void btnezabatu_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            string izena = dataGridView1.CurrentRow.Cells["izena"].Value.ToString();

            // ALMAZENA EZABATZEKO AUKERA EZ EMAN
            if (izena == "Almazena" || izena == "Matxuratuak")
            {
                MessageBox.Show("Ezin da Mintegi hori ezabatu!");
                return;
            }
            // MINTEGIAK IRASAKLEAK DITUEN EGIAZTATU
            else if (DBKONEXIOA.MintegiakIrakasleakDitu(id) == true)
            {
                MessageBox.Show("Ezin da mintegia ezabatu, oraindik irakasleak baititu esleituta. Mesedez, kendu irakasleak ezabatu aurretik.", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBKONEXIOA.EzabatuMintegia(id);

            MessageBox.Show("Mintegia ezabatuta!");

            dataGridView1.DataSource = DBKONEXIOA.LortuMintegiak();
        }

        private void MINTEGIAEZABATUIKUSI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBKONEXIOA.LortuMintegiak();
            dataGridView1.Columns["id"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
