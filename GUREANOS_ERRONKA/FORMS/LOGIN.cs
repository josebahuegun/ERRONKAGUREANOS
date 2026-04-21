using GUREANOS_ERRONKA.CODIGO;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
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
            try
            {
                KONEXIOA.Konektatu(); // 🔥 ESTO FALTABA

                string sql = "SELECT id, izena FROM erabiltzailea WHERE izena=@izena AND pasahitza=@pass";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@izena", txtizenalogin.Text);
                cmd.Parameters.AddWithValue("@pass", txtpasahitzalogin.Text);

                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    sesioa.ErabiltzaileId = r.GetInt32(0);
                    sesioa.Izena = r.GetString(1);

                    MessageBox.Show("Login zuzena");

                    PANELA f = new PANELA();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }

                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu(); // 🔥 TAMBIÉN IMPORTANTE
            }
        }

        private void irtenlogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
