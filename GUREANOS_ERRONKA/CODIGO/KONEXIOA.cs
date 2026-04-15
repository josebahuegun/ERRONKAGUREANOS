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
        private static string connectionString = "server=localhost;database=GureanosErronkaDB;user=root;password=root;";
        public static MySqlConnection konektatu = new MySqlConnection(connectionString);

        public static void Konektatu()
        {
            try 
            { 
                konektatu.Open();
            }
            catch (Exception e)
            {

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
