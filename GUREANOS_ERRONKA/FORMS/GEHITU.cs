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

        private void btnGehitu_Click(object sender, EventArgs e)
        {
            if (txtmarka.Text == "" || txtkokalekua.Text == "")
            {
                MessageBox.Show("Bete datu guztiak");
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
        }
    }
}
