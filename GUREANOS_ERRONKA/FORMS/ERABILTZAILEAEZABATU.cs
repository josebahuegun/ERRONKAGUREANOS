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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ERABILTZAILEAEZABATU : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ERABILTZAILEAEZABATU" /> class.
        /// </summary>
        public ERABILTZAILEAEZABATU()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CellContentClick event of the dataerabilezabatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void dataerabilezabatu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the ERABILTZAILEAEZABATU control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ERABILTZAILEAEZABATU_Load(object sender, EventArgs e)
        {
            /// erabiltzailearen rola lortu
            string rola = sesioa.Rola.ToLower();

            /// irakaslea bada ezin sartu
            if (rola == "irakaslea")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                this.Close();
                return;
            }

            /// ikt ez bada botoiak ezkutatu
            if (rola != "iktarduraduna")
            {
                btnaldatu.Visible = false;
                btnerabilezabatu.Visible = false;
            }

            /// datuak kargatu
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            dataerabilezabatu.Columns["id"].Visible = false;

            /// leihoa maximizatu
            this.WindowState = FormWindowState.Maximized;

            /// fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            /// datagrid estiloa
            dataerabilezabatu.BackgroundColor = Color.White;
            dataerabilezabatu.GridColor = Color.LightGray;
            dataerabilezabatu.EnableHeadersVisualStyles = false;
            dataerabilezabatu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataerabilezabatu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            /// botoien estiloa
            btnerabilezabatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnerabilezabatuatzera.ForeColor = Color.White;
            btnerabilezabatuatzera.FlatStyle = FlatStyle.Flat;

            btnaldatu.BackColor = Color.FromArgb(0, 120, 215);
            btnaldatu.ForeColor = Color.White;
            btnaldatu.FlatStyle = FlatStyle.Flat;

            btnerabilezabatu.BackColor = Color.FromArgb(200, 50, 50);
            btnerabilezabatu.ForeColor = Color.White;
            btnerabilezabatu.FlatStyle = FlatStyle.Flat;

            btnerabilezabatuirten.BackColor = Color.FromArgb(120, 120, 120);
            btnerabilezabatuirten.ForeColor = Color.White;
            btnerabilezabatuirten.FlatStyle = FlatStyle.Flat;

            ///aktibatu botoia

            btnaktibatu.BackColor = Color.FromArgb(40, 167, 69);
            btnaktibatu.ForeColor = Color.White;
            btnaktibatu.FlatStyle = FlatStyle.Flat;

            /// elementuak kokatu
            rekolokatu();
        }
        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 180;

            /// tabla
            dataerabilezabatu.Width = 700;
            dataerabilezabatu.Height = 250;
            dataerabilezabatu.Left = centroX - dataerabilezabatu.Width / 2;
            dataerabilezabatu.Top = startY;

            /// botoiak azpian
            int botonesY = dataerabilezabatu.Bottom + 30;
            int espacio = 20;

            btnaldatu.Width = 120;
            btnerabilezabatu.Width = 120;
            btnerabilezabatuatzera.Width = 120;
            btnerabilezabatuirten.Width = 120;
            btnaktibatu.Width = 120;

            int anchoTotalBotones =
                btnerabilezabatuatzera.Width +
                btnaldatu.Width +
                btnerabilezabatu.Width +
                btnaktibatu.Width +
                btnerabilezabatuirten.Width +
                (espacio * 4);

            int startBotonesX = centroX - (anchoTotalBotones / 2);

            btnerabilezabatuatzera.Top = botonesY;
            btnerabilezabatuatzera.Left = startBotonesX;

            btnaldatu.Top = botonesY;
            btnaldatu.Left = btnerabilezabatuatzera.Right + espacio;

            btnerabilezabatu.Top = botonesY;
            btnerabilezabatu.Left = btnaldatu.Right + espacio;

            btnaktibatu.Top = botonesY;
            btnaktibatu.Left = btnerabilezabatu.Right + espacio;

            btnerabilezabatuirten.Top = botonesY;
            btnerabilezabatuirten.Left = btnaktibatu.Right + espacio;
        }

        /// <summary>
        /// Handles the Click event of the btnerabilezabatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnerabilezabatu_Click(object sender, EventArgs e)
        {
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);

            if (id == sesioa.ErabiltzaileId)
            {
                MessageBox.Show("Ezin duzu zeure burua ezabatu!");
                return;
            }

            DialogResult r = MessageBox.Show("Ziur zaude?", "EZABATU", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                DBKONEXIOA.EzabatuErabiltzailea(id);

                dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnerabilezabatuatzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnerabilezabatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the Click event of the btnerabilezabatuirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnerabilezabatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the btnaldatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnaldatu_Click(object sender, EventArgs e)
        {
            /// bakarrik ikt
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            /// aukeraketa egiaztatu
            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            /// datuak hartu
            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);
            string izena = dataerabilezabatu.CurrentRow.Cells["izena"].Value.ToString();
            string rolaActual = dataerabilezabatu.CurrentRow.Cells["rola"].Value.ToString();

            /// mintegia izena hartu (EZ ID)
            string mintegiIzena = dataerabilezabatu.CurrentRow.Cells["Mintegia"].Value.ToString();

            /// id lortu datu basetik
            int mintegiId = DBKONEXIOA.LortuMintegiIdIzena(mintegiIzena);

            /// datu berriak eskatu
            string nuevaIzena = Microsoft.VisualBasic.Interaction.InputBox("Izena berria:", "Editatu", izena);
            string nuevaPass = Microsoft.VisualBasic.Interaction.InputBox("Pasahitza berria:", "Editatu", "");
            string nuevaRola = Microsoft.VisualBasic.Interaction.InputBox("Rola berria (Irakaslea / Mintegiburua / IKTarduraduna):", "Editatu", rolaActual);

            /// mintegi berria testu moduan
            string nuevaMintegi = Microsoft.VisualBasic.Interaction.InputBox("Mintegia berria:", "Editatu", mintegiIzena);

            /// hutsik ez
            if (string.IsNullOrWhiteSpace(nuevaIzena) || string.IsNullOrWhiteSpace(nuevaPass))
            {
                MessageBox.Show("Datuak falta dira!");
                return;
            }

            /// rola normalizatu
            string r = nuevaRola.ToLower();

            if (r != "irakaslea" && r != "mintegiburua" && r != "iktarduraduna")
            {
                MessageBox.Show("Rola okerra!");
                return;
            }

            if (r == "irakaslea") nuevaRola = "Irakaslea";
            if (r == "mintegiburua") nuevaRola = "Mintegiburua";
            if (r == "iktarduraduna") nuevaRola = "IKTarduraduna";

            /// mintegi berria id bihurtu
            int mintegiBerriaId = DBKONEXIOA.LortuMintegiIdIzena(nuevaMintegi);

            if (mintegiBerriaId == -1)
            {
                MessageBox.Show("Mintegia ez da existitzen!");
                return;
            }

            /// ikt kopurua
            int kopurua = DBKONEXIOA.KontatuIKT();

            if (rolaActual == "IKTarduraduna" && kopurua <= 1 && nuevaRola != "IKTarduraduna")
            {
                MessageBox.Show("Ezin da azken IKT aldatu!");
                return;
            }

            if (id == sesioa.ErabiltzaileId && rolaActual == "IKTarduraduna" && nuevaRola != "IKTarduraduna")
            {
                MessageBox.Show("Ezin duzu zeure rola kendu!");
                return;
            }

            /// mintegiburua bakarra
            if (nuevaRola == "Mintegiburua")
            {
                if (DBKONEXIOA.mintegiburuaexistitu(mintegiBerriaId, id))
                {
                    MessageBox.Show("Mintegi honek dagoeneko Mintegiburua dauka!");
                    return;
                }
            }

            /// EGUNERATU (ORAIN ONDO)
            DBKONEXIOA.AldatuErabiltzailea(id, nuevaIzena, nuevaPass, nuevaRola, mintegiBerriaId);

            MessageBox.Show("Erabiltzailea aldatuta!");

            /// taula berritu
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
        }

        /// <summary>
        /// Handles the Click event of the btnaktibatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnaktibatu_Click(object sender, EventArgs e)
        {
            /// ikt bakarrik
            if (sesioa.Rola != "IKTarduraduna")
            {
                MessageBox.Show("Ez daukazu baimenik!");
                return;
            }

            /// egiaztatu aukeraketa
            if (dataerabilezabatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu erabiltzaile bat!");
                return;
            }

            int id = Convert.ToInt32(dataerabilezabatu.CurrentRow.Cells["id"].Value);
            bool aktibo = Convert.ToBoolean(dataerabilezabatu.CurrentRow.Cells["aktibo"].Value);

            /// aktibo dagoen egiaztatu
            if (aktibo)
            {
                MessageBox.Show("Erabiltzailea jada aktibo dago!");
                return;
            }

            /// aktibatu
            DBKONEXIOA.AktibatuErabiltzailea(id);

            MessageBox.Show("Erabiltzailea aktibatuta!");

            /// refreshhhh
            dataerabilezabatu.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
        }
    }
}
