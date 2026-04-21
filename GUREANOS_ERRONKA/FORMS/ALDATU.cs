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
    public partial class ALDATU : Form
    {
        public ALDATU()
        {
            InitializeComponent();
        }

        private void dataaldatu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ALDATU_Load(object sender, EventArgs e)
        {
            dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            dataaldatu.Columns["id"].Visible = false;
            panelor.Visible = false;
            panelin.Visible = false;
        }

        private void btnaldatu_Click(object sender, EventArgs e)
        {
            if (dataaldatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu gailu bat!");
                return;
            }

            int id = Convert.ToInt32(dataaldatu.CurrentRow.Cells["id"].Value);
            string mota = dataaldatu.CurrentRow.Cells["mota"].Value.ToString();

            try
            {
                // 🔹 actualizar gailua
                Gailua g = new Gailua(
                    id,
                    data.Value,
                    txtkokalekua.Text,
                    txtMarka.Text,
                    true,
                    "Informatika Mintegia"
                );

                DBKONEXIOA.AldatuGailua(g);

                // 🔹 ORDENAGAILUA
                if (mota == "Ordenagailua")
                {
                    DBKONEXIOA.AldatuOrdenagailua(
                        id,
                        txtRAM.Text,
                        txtROM.Text,
                        txtCPU.Text
                    );
                }

                // 🔹 INPRIMAGAILUA
                else if (mota == "Inprimagailua")
                {
                    DBKONEXIOA.AldatuInprimagailua(
                        id,
                        chkkolore.Checked,
                        txttekno.Text
                    );
                }

                MessageBox.Show("Aldatuta!");

                // 🔄 refrescar tabla
                dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioordenagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioordenagailua.Checked)
            {
                panelor.Visible = true;
                panelin.Visible = false;
            }
        }

        private void radioinprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioinprimagailua.Checked)
            {
                panelor.Visible = false;
                panelin.Visible = true;
            }
        }
    }
}
