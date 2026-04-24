using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUREANOS_ERRONKA.CODIGO
{
    public class KONEXIOA
    {
        private static string connectionString = "server=192.168.80.21;database=GureanosErronkaDB;user=joseba;password=1234;";

        public static MySqlConnection konektatu;

        public static void Konektatu()
        {
            try
            {
                if (konektatu == null)
                {
                    konektatu = new MySqlConnection(connectionString);
                }

                if (konektatu.State != System.Data.ConnectionState.Open)
                {
                    konektatu.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Deskonektatu()
        {
            try
            {
                if (konektatu != null && konektatu.State == System.Data.ConnectionState.Open)
                {
                    konektatu.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
