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
                // 🔥 VALIDACIÓN
                if (string.IsNullOrWhiteSpace(txtizenalogin.Text) || string.IsNullOrWhiteSpace(txtpasahitzalogin.Text))
                {
                    MessageBox.Show("Sartu erabiltzailea eta pasahitza");
                    return;
                }

                KONEXIOA.Konektatu();

                // 🔥 AÑADIMOS rola + mintegia_id + aktibo
                string sql = @"SELECT id, izena, rola, mintegia_id 
               FROM erabiltzailea 
               WHERE izena=@izena AND pasahitza=@pass AND aktibo=1";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@izena", txtizenalogin.Text);
                cmd.Parameters.AddWithValue("@pass", txtpasahitzalogin.Text);

                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    // 🔥 GUARDAR SESIÓN COMPLETA
                    sesioa.ErabiltzaileId = r.GetInt32("id");
                    sesioa.Izena = r.GetString("izena");
                    sesioa.Rola = r.GetString("rola");          
                    sesioa.MintegiaId = r.GetInt32("mintegia_id"); 

                    MessageBox.Show("Login zuzena");

                    PANELA f = new PANELA();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erabiltzailea edo pasahitza okerra!");
                }

                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }
        }

        private void irtenlogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            // leihoa pantaila osoan
            this.WindowState = FormWindowState.Maximized;

            // fondo kolore argia
            this.BackColor = Color.FromArgb(240, 244, 248);

            // titulua estiloa
            lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitulo.AutoSize = true;

            // labelak
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;

            label1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // textbox estiloa
            txtizenalogin.BackColor = Color.White;
            txtizenalogin.ForeColor = Color.Black;
            txtizenalogin.BorderStyle = BorderStyle.FixedSingle;

            txtpasahitzalogin.BackColor = Color.White;
            txtpasahitzalogin.ForeColor = Color.Black;
            txtpasahitzalogin.BorderStyle = BorderStyle.FixedSingle;

            // pasahitza ezkutatu
            txtpasahitzalogin.UseSystemPasswordChar = true;

            // botoiak
            sartulogin.BackColor = Color.FromArgb(0, 120, 215);
            sartulogin.ForeColor = Color.White;
            sartulogin.FlatStyle = FlatStyle.Flat;

            irtenlogin.BackColor = Color.FromArgb(200, 50, 50);
            irtenlogin.ForeColor = Color.White;
            irtenlogin.FlatStyle = FlatStyle.Flat;

            // elementuak kokatu
            rekolokatu();
        }
        private void rekolokatu()
        {
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 2;

            int startY = centroY - 120;

            // titulua goian
            lblTitulo.Left = centroX - lblTitulo.Width / 2;
            lblTitulo.Top = 80;

            // erabiltzailea
            label1.Left = centroX - 150;
            label1.Top = startY;

            txtizenalogin.Left = centroX + 20;
            txtizenalogin.Top = startY;

            // pasahitza
            label2.Left = centroX - 150;
            label2.Top = startY + 60;

            txtpasahitzalogin.Left = centroX + 20;
            txtpasahitzalogin.Top = startY + 60;

            // botoiak
            sartulogin.Top = startY + 130;
            sartulogin.Left = centroX - 120;

            irtenlogin.Top = startY + 130;
            irtenlogin.Left = centroX + 40;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            rekolokatu();
        }
    }
}
