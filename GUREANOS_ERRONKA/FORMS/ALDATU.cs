using GUREANOS_ERRONKA.CODIGO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA.FORMS
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ALDATU : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ALDATU" /> class.
        /// </summary>
        public ALDATU()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Click event of the btnaldatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnaldatu_Click(object sender, EventArgs e)
        {
            if (dataaldatu.CurrentRow == null)
            {
                MessageBox.Show("Aukeratu gailu bat!");
                return;
            }

            if (txtKokalekua.Text == "")
            {
                MessageBox.Show("Sartu kokalekua!");
                return;
            }

            if (comboMintegia.SelectedValue == null)
            {
                MessageBox.Show("Aukeratu mintegia!");
                return;
            }

            if (dataaldatu.CurrentRow.Cells["id"] == null ||
    dataaldatu.CurrentRow.Cells["id"].Value == null ||
    dataaldatu.CurrentRow.Cells["id"].Value == DBNull.Value)
            {
                MessageBox.Show("ID ez dago!");
                return;
            }

            int id = Convert.ToInt32(dataaldatu.CurrentRow.Cells["id"].Value);

            string motaActual = dataaldatu.CurrentRow.Cells["Mota"]?.Value?.ToString() ?? "";

            string motaBerria = "";

            if (radioordenagailua.Checked)
                motaBerria = "Ordenagailua";
            else if (radioinprimagailua.Checked)
                motaBerria = "Inprimagailua";

            if (motaBerria == "")
            {
                MessageBox.Show("Aukeratu mota!");
                return;
            }
            if (sesioa.Rola == "Mintegiburua")
            {
                int mintegiIdGailua = Convert.ToInt32(
                    dataaldatu.CurrentRow.Cells["MintegiaId"].Value
                );

                int mintegiAukeratua = Convert.ToInt32(comboMintegia.SelectedValue);

                /// ez duzu gailua aldatzeko baimenik, baina mintegi bereko gailuak bakarrik alda ditzakezu
                if (mintegiIdGailua != sesioa.MintegiaId)
                {
                    MessageBox.Show("Ezin duzu beste mintegi bateko gailua aldatu!");
                    return;
                }

                /// ezin duzu mintegiz moitu
                if (mintegiAukeratua != sesioa.MintegiaId)
                {
                    MessageBox.Show("Ezin duzu gailua beste mintegi batera mugitu!");
                    return;
                }
            }

            try
            {
                KONEXIOA.Konektatu();

                string ram = txtRAM?.Text ?? "";
                string rom = txtROM?.Text ?? "";
                string cpu = txtCPU?.Text ?? "";
                string tekno = txttekno?.Text ?? "";

                /// gailua sortu
                Gailua g = new Gailua(
                    id,
                    data.Value,
                    txtKokalekua.Text,
                    txtMarka.Text,
                    "aktibo",
                    comboMintegia.SelectedValue.ToString()
                );

                DBKONEXIOA.AldatuGailua(g);

                if (motaActual != motaBerria)
                {
                    if (motaActual == "Ordenagailua")
                    {
                        DBKONEXIOA.EzabatuOrdenagailua(id);
                        Inprimagailua i = new Inprimagailua(
    txtMarka.Text,
    txtKokalekua.Text,
    data.Value,
    "aktibo",
    comboMintegia.Text,
    chkkolore.Checked,
    tekno
);

                        i.Id = id;
                        i.MintegiaId = Convert.ToInt32(comboMintegia.SelectedValue);

                        DBKONEXIOA.TxertatuInprimagailua(i);
                    }
                    else
                    {
                        DBKONEXIOA.EzabatuInprimagailua(id);
                        Ordenagailua o = new Ordenagailua("", "", DateTime.Now, "", "", ram, rom, cpu);
                        o.Id = id;

                        DBKONEXIOA.TxertatuOrdenagailua(o);
                    }

                    DBKONEXIOA.TxertatuHistorikoa("ALDATU", "mota aldatu da", id);
                }
                else
                {
                    if (motaActual == "Ordenagailua")
                        DBKONEXIOA.AldatuOrdenagailua(id, ram, rom, cpu);
                    else
                        DBKONEXIOA.AldatuInprimagailua(id, chkkolore.Checked, tekno);

                    DBKONEXIOA.TxertatuHistorikoa("ALDATU", "gailua eguneratu da", id);
                }

                MessageBox.Show("Aldatuta!");

                GarbituFormularioa();

                dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }
        }

        /// <summary>
        /// Handles the CellClick event of the dataaldatu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void dataaldatu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataaldatu.CurrentRow == null) return;

            txtMarka.Text = dataaldatu.CurrentRow.Cells["marka"].Value?.ToString();
            txtKokalekua.Text = dataaldatu.CurrentRow.Cells["kokalekua"].Value?.ToString();

            var mintegiId = dataaldatu.CurrentRow.Cells["MintegiaId"].Value;

            if (mintegiId != null && mintegiId != DBNull.Value)
            {
                comboMintegia.SelectedValue = Convert.ToInt32(mintegiId);
            }

            var dataValue = dataaldatu.CurrentRow.Cells["eroste_data"].Value;

            if (dataValue != null && dataValue != DBNull.Value)
            {
                data.Value = Convert.ToDateTime(dataValue);
            }
            else
            {
                data.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Garbitus the formularioa.
        /// </summary>
        private void GarbituFormularioa()
        {
            if (txtMarka != null) txtMarka.Text = "";
            if (txtRAM != null) txtRAM.Text = "";
            if (txtROM != null) txtROM.Text = "";
            if (txtCPU != null) txtCPU.Text = "";
            if (txttekno != null) txttekno.Text = "";
            if (txtKokalekua != null) txtKokalekua.Text = "";

            if (comboMintegia != null && comboMintegia.Items.Count > 0)
                comboMintegia.SelectedIndex = 0;

            data.Value = DateTime.Now;

            chkkolore.Checked = false;

            radioordenagailua.Checked = true;

            panelor.Visible = false;
            panelin.Visible = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioordenagailua control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void radioordenagailua_CheckedChanged(object sender, EventArgs e)
        {
            panelor.Visible = radioordenagailua.Checked;
            panelin.Visible = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioinprimagailua control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void radioinprimagailua_CheckedChanged(object sender, EventArgs e)
        {
            panelin.Visible = radioinprimagailua.Checked;
            panelor.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the btnaldatuatzera control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnaldatuatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnaldatuirten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnaldatuirten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Handles the Load event of the ALDATU control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ALDATU_Load(object sender, EventArgs e)
        {
            /// mintegiak kargatu
            comboMintegia.DataSource = DBKONEXIOA.LortuMintegiak();
            comboMintegia.DisplayMember = "izena";
            comboMintegia.ValueMember = "id";
            comboMintegia.SelectedIndex = 0;

            /// datuak kargatu
            dataaldatu.DataSource = DBKONEXIOA.ikusiGailuak();

            /// etiketa
            dataaldatu.Columns["id"].DisplayIndex = 0;
            dataaldatu.Columns["id"].HeaderText = "Etiketa";

            /// zutabeak
            dataaldatu.Columns["MintegiaId"].Visible = false;
            dataaldatu.Columns["Mintegia"].HeaderText = "Mintegia";
            dataaldatu.Columns["kokalekua"].HeaderText = "Kokalekua";

            /// panelak ezkutatu
            panelor.Visible = false;
            panelin.Visible = false;

            /// estiloa
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(240, 244, 248);

            dataaldatu.BackgroundColor = Color.White;
            dataaldatu.GridColor = Color.LightGray;

            /// botoien estiloa
            btnaldatuatzera.BackColor = Color.FromArgb(100, 100, 100);
            btnaldatuatzera.ForeColor = Color.White;
            btnaldatuatzera.FlatStyle = FlatStyle.Flat;

            btnaldatu.BackColor = Color.FromArgb(0, 120, 215);
            btnaldatu.ForeColor = Color.White;
            btnaldatu.FlatStyle = FlatStyle.Flat;

            btnaldatuirten.BackColor = Color.FromArgb(120, 120, 120);
            btnaldatuirten.ForeColor = Color.White;
            btnaldatuirten.FlatStyle = FlatStyle.Flat;

            rekolokatu();
        }

        /// <summary>
        /// Rekolokatus this instance.
        /// </summary>
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;

            int startY = 50;

            /// dataaldatu kokatu eta tamaina ezarri
            dataaldatu.Width = 750;
            dataaldatu.Height = 200;
            dataaldatu.Left = centroX - dataaldatu.Width / 2;
            dataaldatu.Top = startY;

            /// kokalekua eta mota
            int fila1Y = dataaldatu.Bottom + 15;

            radioordenagailua.Left = centroX - 300;
            radioordenagailua.Top = fila1Y;

            radioinprimagailua.Left = centroX - 300;
            radioinprimagailua.Top = fila1Y + 25;

            label4.Left = centroX - 60;
            label4.Top = fila1Y;

            txtKokalekua.Left = label4.Right + 10;
            txtKokalekua.Top = fila1Y;

            int panelX = centroX + 200;

            panelor.Left = panelX;
            panelor.Top = fila1Y;

            panelin.Left = panelX;
            panelin.Top = fila1Y;

            panel1.Left = centroX - panel1.Width / 2;
            panel1.Top = fila1Y + 60;

            int botonesY = panel1.Bottom + 20;
            int separacion = 160;

            btnaldatu.Top = botonesY;
            btnaldatu.Left = centroX - btnaldatu.Width / 2;

            btnaldatuatzera.Top = botonesY;
            btnaldatuatzera.Left = btnaldatu.Left - separacion;

            btnaldatuirten.Top = botonesY;
            btnaldatuirten.Left = btnaldatu.Left + separacion;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
    }
}