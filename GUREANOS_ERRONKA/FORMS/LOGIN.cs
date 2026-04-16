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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void sartulogin_Click(object sender, EventArgs e)
        {
            PANELA menu = new PANELA();
            menu.Show();
            this.Hide();
        }

        private void irtenlogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
