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
    public partial class HISTORIALAKUDEATU : Form
    {
        public HISTORIALAKUDEATU()
        {
            InitializeComponent();
        }

        private void btnatzerahistoriala_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }

        private void btnirtenhistoriala_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HISTORIALAKUDEATU_Load(object sender, EventArgs e)
        {
            string rola = sesioa.Rola.ToLower();

            if (rola == "irakaslea")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                this.Close();
                return;
            }

            if (rola != "iktarduraduna")
            {
                btnezabatu.Visible = false;
                btnaldatuhistoriala.Visible = false;
            }

            // 🔥 AQUI VA EL COMBO
            combogailua.DataSource = DBKONEXIOA.ikusiGailuak();
            combogailua.DisplayMember = "Marka";
            combogailua.ValueMember = "Id";

            // GRID
            datahistoriala.AutoGenerateColumns = true;
            datahistoriala.DataSource = DBKONEXIOA.IkusiHistorikoa();
            combomota.Items.Add("GEHITU");
            combomota.Items.Add("ALDATU");
            combomota.Items.Add("EZABATU");
            combomota.Items.Add("MATXURA");
            combomota.Items.Add("KONPONDU");
        }

        private void datahistoriala_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            if (datahistoriala.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erregistro bat!");
                return;
            }

            int id = Convert.ToInt32(datahistoriala.CurrentRow.Cells["id_historiala"].Value);

            DialogResult r = MessageBox.Show("Ziur zaude ezabatu nahi duzula?", "Ezabatu", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                DBKONEXIOA.EzabatuHistorikoa(id);

                MessageBox.Show("Ezabatuta!");

                datahistoriala.DataSource = DBKONEXIOA.IkusiHistorikoa();
            }
        }

        private void btnaldatuhistoriala_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            if (datahistoriala.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erregistro bat!");
                return;
            }

            int id = Convert.ToInt32(datahistoriala.CurrentRow.Cells["id_historiala"].Value);
            string desk = datahistoriala.CurrentRow.Cells["deskribapena"].Value.ToString();
            string mota = datahistoriala.CurrentRow.Cells["mota"].Value.ToString();

            // 👉 puedes usar TextBox o InputBox
            string nuevaDesk = Microsoft.VisualBasic.Interaction.InputBox("Deskribapena berria:", "Editatu", desk);
            string nuevaMota = Microsoft.VisualBasic.Interaction.InputBox("Mota berria:", "Editatu", mota);

            DBKONEXIOA.EditatuHistorikoa(id, nuevaDesk, nuevaMota);

            MessageBox.Show("Aldatuta!");

            datahistoriala.DataSource = DBKONEXIOA.IkusiHistorikoa();
        }

        private void btnsortu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola.ToLower() != "iktarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            if (combogailua.SelectedValue == null)
            {
                MessageBox.Show("Aukeratu gailu bat!");
                return;
            }

            int gailuaId = Convert.ToInt32(combogailua.SelectedValue);

            string desk = txtdeskribapena.Text;
            string mota = combomota.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(desk) || string.IsNullOrWhiteSpace(mota))
            {
                MessageBox.Show("Datuak falta dira!");
                return;
            }

            DBKONEXIOA.TxertatuHistorikoa(mota, desk, gailuaId);

            MessageBox.Show("Historiala sortuta!");

            datahistoriala.DataSource = DBKONEXIOA.IkusiHistorikoa();
        }
    }
}
