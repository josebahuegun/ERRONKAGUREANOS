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
    public partial class ERABILTZAILEAKIKUSI : Form
    {
        public ERABILTZAILEAKIKUSI()
        {
            InitializeComponent();
        }

        private void ERABILTZAILEAKIKUSI_Load(object sender, EventArgs e)
        {
            dataikusierabil.DataSource = DBKONEXIOA.IkusiErabiltzaileak();
            dataikusierabil.Columns["id"].Visible = false;
        }

        private void btnikusierabilatzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }
    }
}

