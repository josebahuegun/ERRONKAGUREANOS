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
    public partial class IKUSI : Form
    {
        public IKUSI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void IKUSI_Load(object sender, EventArgs e)
        {
            // 1. Datu-basetik gailuen zerrenda ekarri
            List<Gailua> gailuZerrenda = DBKONEXIOA.ikusiGailuak();

            // 2. Zerrenda eraldatu, zutabe GUZTIAK sortuz hegan (LINQ erabiliz)
            var erakustekoTaula = gailuZerrenda.Select(g => new
            {
                // Gailu guztien datu amankomunak
                Id = g.Id,
                Mota = g.Mota,
                Marka = g.Marka,
                Kokalekua = g.Kokalekua,
                ErosteData = g.ErosteData.ToShortDateString(), // Data garbiago ikusteko
                Aktibo = g.Aktibo,
                Mintegia = g.Mintegia,

                // Ordenagailuen datuak. Gailua ez bada ordenagailua, hutsik ("") utziko du
                RAM = (g is Ordenagailua) ? ((Ordenagailua)g).RAM1 : "",
                ROM = (g is Ordenagailua) ? ((Ordenagailua)g).ROM1 : "",
                CPU = (g is Ordenagailua) ? ((Ordenagailua)g).CPU1 : "",
                
                // Inprimagailuen datuak. Ez bada inprimagailua, hutsik ("") utziko du
                Koloretakoa = (g is Inprimagailua) ? ((Inprimagailua)g).Koloretakoa.ToString() : "",
                Teknologia = (g is Inprimagailua) ? ((Inprimagailua)g).Teknologia : ""

            }).ToList();

            // 3. Eraldatutako taula hori pasatu DataGridView-ari
            dataGridView1.DataSource = erakustekoTaula;

            // 4. Ezkutatu Id zutabea hasieran ez agertzeko
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
