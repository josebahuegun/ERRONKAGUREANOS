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
    public partial class ERABILTZAILEASORTU : Form
    {
        public ERABILTZAILEASORTU()
        {
            InitializeComponent();
        }

        private void ERABILTZAILEASORTU_Load(object sender, EventArgs e)
        {
            // rolak
            comborola.Items.Clear();
            comborola.Items.Add("IKT arduraduna");
            comborola.Items.Add("Mintegiburua");
            comborola.Items.Add("Irakaslea");
            comborola.SelectedIndex = 0;

            // mintegiak
            combomintegia.DataSource = DBKONEXIOA.LortuMintegiak();
            combomintegia.DisplayMember = "izena";
            combomintegia.ValueMember = "id";
        }

        private void radioirakasle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsortuerabil_Click(object sender, EventArgs e)
        {
            if (txtizenaerabil.Text == "" || txtpasahitzaerabil.Text == "")
            {
                MessageBox.Show("Bete datu guztiak!");
                return;
            }

            int mintegiaId = Convert.ToInt32(combomintegia.SelectedValue);

            bool sortuta = DBKONEXIOA.SortuErabiltzailea(
                txtizenaerabil.Text,
                txtpasahitzaerabil.Text,
                comborola.Text,
                mintegiaId
            );

            if (sortuta)
            {
                MessageBox.Show("Erabiltzailea sortuta!");

                txtizenaerabil.Clear();
                txtpasahitzaerabil.Clear();
                comborola.SelectedIndex = 0;
            }
        }

        private void btngehituerabilatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }
    }
}
