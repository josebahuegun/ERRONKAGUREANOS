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
            this.Close();
        }

        private void btnirtenhistoriala_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HISTORIALAKUDEATU_Load(object sender, EventArgs e)
        {
            // erabiltzailearen rola lortu
            string rola = sesioa.Rola.ToLower();

            // irakaslea bada ezin sartu
            if (rola == "irakaslea")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                this.Close();
                return;
            }

            // ikt ez bada botoiak ezkutatu
            if (rola != "iktarduraduna")
            {
                btnezabatu.Visible = false;
                btnaldatuhistoriala.Visible = false;
            }
            if (sesioa.Rola == "Mintegiburua")
            {
                btnsortu.Enabled = false;   // ixkutatu botoia
            }

            // gailuak combobox-ean kargatu
            combogailua.DataSource = DBKONEXIOA.ikusiGailuak();
            combogailua.DisplayMember = "Marka";
            combogailua.ValueMember = "Id";

            // mota aukerak
            combomota.Items.Clear();
            combomota.Items.Add("GEHITU");
            combomota.Items.Add("ALDATU");
            combomota.Items.Add("EZABATU");
            combomota.Items.Add("MATXURA");
            combomota.Items.Add("KONPONDU");

            // datagrid kargatu
            datahistoriala.AutoGenerateColumns = true;
            datahistoriala.DataSource = DBKONEXIOA.IkusiHistorikoa();

            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // label estiloa
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor = Color.Black;
                    c.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }

            // combobox estiloa
            combogailua.BackColor = Color.White;
            combomota.BackColor = Color.White;

            // textbox estiloa
            txtdeskribapena.BackColor = Color.White;
            txtdeskribapena.BorderStyle = BorderStyle.FixedSingle;

            // datagrid estiloa
            datahistoriala.BackgroundColor = Color.White;
            datahistoriala.GridColor = Color.LightGray;
            datahistoriala.EnableHeadersVisualStyles = false;
            datahistoriala.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            datahistoriala.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // botoiak estiloa
            btnatzerahistoriala.BackColor = Color.FromArgb(100, 100, 100);
            btnatzerahistoriala.ForeColor = Color.White;
            btnatzerahistoriala.FlatStyle = FlatStyle.Flat;

            btnsortu.BackColor = Color.FromArgb(0, 120, 215);
            btnsortu.ForeColor = Color.White;
            btnsortu.FlatStyle = FlatStyle.Flat;

            btnaldatuhistoriala.BackColor = Color.FromArgb(0, 120, 215);
            btnaldatuhistoriala.ForeColor = Color.White;
            btnaldatuhistoriala.FlatStyle = FlatStyle.Flat;

            btnezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnezabatu.ForeColor = Color.White;
            btnezabatu.FlatStyle = FlatStyle.Flat;

            btnirtenhistoriala.BackColor = Color.FromArgb(120, 120, 120);
            btnirtenhistoriala.ForeColor = Color.White;
            btnirtenhistoriala.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }

        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int anchoTotal = 900;
            int altoTotal = 500;

            int startY = centroY - altoTotal / 2;

            int anchoCombo = 200;
            int anchoTxt = 250;
            int separacionTop = 20;

            int anchoTotalTop = anchoCombo + separacionTop + anchoCombo + separacionTop + anchoTxt;
            int startTopX = centroX - (anchoTotalTop / 2);

            combogailua.Width = anchoCombo;
            combogailua.Left = startTopX;
            combogailua.Top = startY;

            combomota.Width = anchoCombo;
            combomota.Left = combogailua.Right + separacionTop;
            combomota.Top = startY;

            txtdeskribapena.Width = anchoTxt;
            txtdeskribapena.Left = combomota.Right + separacionTop;
            txtdeskribapena.Top = startY;

            // labels
            label1.Left = combogailua.Left;
            label1.Top = combogailua.Top - 25;

            label2.Left = combomota.Left;
            label2.Top = combomota.Top - 25;

            label3.Left = txtdeskribapena.Left;
            label3.Top = txtdeskribapena.Top - 25;


            btnsortu.Top = combogailua.Bottom + 20;
            btnsortu.Left = centroX - btnsortu.Width / 2;


            datahistoriala.Width = 900;
            datahistoriala.Height = 280;
            datahistoriala.Left = centroX - datahistoriala.Width / 2;
            datahistoriala.Top = btnsortu.Bottom + 20;


            int botonesY = datahistoriala.Bottom + 30;
            int espacio = 20;

            btnaldatuhistoriala.Width = 120;
            btnezabatu.Width = 120;
            btnatzerahistoriala.Width = 120;
            btnirtenhistoriala.Width = 120;

            int anchoTotalBotones =
                btnaldatuhistoriala.Width +
                btnezabatu.Width +
                btnatzerahistoriala.Width +
                btnirtenhistoriala.Width +
                (espacio * 3);

            int startBotonesX = centroX - (anchoTotalBotones / 2);

            btnaldatuhistoriala.Top = botonesY;
            btnaldatuhistoriala.Left = startBotonesX;

            btnezabatu.Top = botonesY;
            btnezabatu.Left = btnaldatuhistoriala.Right + espacio;

            btnatzerahistoriala.Top = botonesY;
            btnatzerahistoriala.Left = btnezabatu.Right + espacio;

            btnirtenhistoriala.Top = botonesY;
            btnirtenhistoriala.Left = btnatzerahistoriala.Right + espacio;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
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
