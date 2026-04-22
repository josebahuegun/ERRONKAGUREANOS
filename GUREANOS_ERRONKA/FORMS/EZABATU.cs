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
    public partial class EZABATU : Form
    {
        public EZABATU()
        {
            InitializeComponent();
        }

        private void btnezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(ezabatudata.CurrentRow.Cells["mintegia_id"].Value);

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

        private void ezabatudata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EZABATU_Load(object sender, EventArgs e)
        {
            ezabatudata.DataSource = DBKONEXIOA.ikusiGailuak();
            ezabatudata.Columns["id"].Visible = false;
        }

        private void btnezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
