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
        private static string connectionString = "server=192.168.1.123;database=GureanosErronkaDB;user=joseba;password=1234;";
        //private static string connectionString = "server=localhost;database=inbentarioa;user=root;password=root;";
        public static MySqlConnection konektatu = new MySqlConnection(connectionString);

        public static void Konektatu()
        {
            try
            {
                konektatu.Open();
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
                konektatu.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
