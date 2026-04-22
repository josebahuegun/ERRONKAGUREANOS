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
    public partial class ZABORRONTZIAIKUSI : Form
    {
        public ZABORRONTZIAIKUSI()
        {
            InitializeComponent();
        }

        private void datazabor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ZABORRONTZIAIKUSI_Load(object sender, EventArgs e)
        {
            datazabor.DataSource = DBKONEXIOA.IkusiZaborrontzia();
            datazabor.Columns["id_zaborrontzia"].Visible = false;
        }

        private void btnzaboratzera_Click(object sender, EventArgs e)
        {
            PANELA p = new PANELA();
            p.Show();
            this.Close(); // 🔥 importante (no Hide)
        }
    }
}
