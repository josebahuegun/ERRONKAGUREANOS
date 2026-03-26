using GUREANOS_ERRONKA.FORMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUREANOS_ERRONKA
{
    public partial class PANELA : Form
    {
        public PANELA()
        {
            InitializeComponent();
        }

        private void iKUSIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gEHITUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PANELA.ActiveForm.Hide();
            GEHITU gehitu = new GEHITU();
            gehitu.Show();
        }

        private void PANELA_Load(object sender, EventArgs e)
        {
             
        }
    }
}
