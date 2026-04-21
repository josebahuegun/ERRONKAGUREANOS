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
    public partial class GEHITU : Form
    {
        public GEHITU()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioordenagailua.Checked)
            {
                panelOrdenagailua.Visible = true;
                panelInprimagailua.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GEHITU_Load(object sender, EventArgs e)
        {
            panelOrdenagailua.Visible = false;
            panelInprimagailua.Visible = false;

        }

        private void panelInprimagailua_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioinprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            if (radioinprimagailua.Checked)
            {
                panelOrdenagailua.Visible = false;
                panelInprimagailua.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*private void btnGehitu_Click(object sender, EventArgs e)
        {
            if (txtmarka.Text == "" || txtkokalekua.Text == "")
            {
                MessageBox.Show("Bete datu guztiak");
                return;
            }

            if (!radioordenagailua.Checked && !radioinprimagailua.Checked)
            {
                MessageBox.Show("Aukeratu mota bat");
                return;
            }

            if (radioordenagailua.Checked)
            {
                if (txtram.Text == "" || txtcpu.Text == "" || txtrom.Text == "")
                {
                    MessageBox.Show("Bete ordenagailuaren datuak");
                    return;
                }
            }
            Gailua g = new Gailua(
                erostedata.Value,
                txtkokalekua.Text,
                txtmarka.Text,
                true
            );

            int id = DBKONEXIOA.gailuaGehitu(g);

            if (id == -1)
            {
                MessageBox.Show("Errorea gailua gehitzean");
                return;
            }

            if (radioordenagailua.Checked)
            {
                DBKONEXIOA.TxertatuOrdenagailua(id, txtram.Text, txtrom.Text, txtcpu.Text);
            }
            else if (radioinprimagailua.Checked)
            {
                DBKONEXIOA.TxertatuInprimagailua(id, chkKolore.Checked, txtTeknologia.Text);
            }

            MessageBox.Show("Gailua gehituta!");

            txtmarka.Clear();
            txtkokalekua.Clear();
            txtram.Clear();
            txtcpu.Clear();
            txtrom.Clear();
            txtTeknologia.Clear();
        }*/

        private void erostedata_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGehitu_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN
            if (txtmarka.Text == "" || txtkokalekua.Text == "")
            {
                MessageBox.Show("Bete datu guztiak");
                return;
            }

            // 💻 ORDENAGAILUA
            if (radioordenagailua.Checked)
            {
                if (txtram.Text == "" || txtrom.Text == "" || txtcpu.Text == "")
                {
                    MessageBox.Show("Bete ordenagailuaren datuak");
                    return;
                }

                Ordenagailua o = new Ordenagailua(
                    txtmarka.Text,
                    txtkokalekua.Text,
                    erostedata.Value,
                    true,
                    "Informatika", // ajusta a tu mintegia
                    txtram.Text,
                    txtrom.Text,
                    txtcpu.Text
                );

                int id = DBKONEXIOA.gailuaGehitu(o);

                if (id > 0)
                {
                    DBKONEXIOA.TxertatuOrdenagailua(id, o.RAM1, o.ROM1, o.CPU1);
                    MessageBox.Show("Ordenagailua gehituta");
                }
            }

            // INPRIMAGAILUA
            else if (radioinprimagailua.Checked)
            {
                Inprimagailua i = new Inprimagailua(
                    txtmarka.Text,
                    txtkokalekua.Text,
                    erostedata.Value,
                    true,
                    "Informatika",
                    chkKolore.Checked,
                    txtTeknologia.Text
                );

                int id = DBKONEXIOA.gailuaGehitu(i);

                if (id > 0)
                {
                    DBKONEXIOA.TxertatuInprimagailua(id, i.Koloretakoa, i.Teknologia);
                    MessageBox.Show("Inprimagailua gehituta");
                }
            }
            else
            {
                MessageBox.Show("Aukeratu mota");
            }
        }
    }
}
