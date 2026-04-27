using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUREANOS_ERRONKA.CODIGO
{
    /// <summary>
    /// 
    /// </summary>
    public class KONEXIOA
    {
        /// unaien ordenagailuko datuak, ip-a, datu basearen izena, erabiltzailea eta pasahitza (ip-a mugikorra da, ahal da aldau)
        /// erabiltzailea eta pasahitza lehenago CREATE USER komandoarekin sortu behar dira mysql-en
        /// <summary>
        /// The connection string
        /// </summary>
        private static string connectionString = "server=192.168.80.28;database=GureanosErronkaDB;user=joseba;password=1234;";

        /// <summary>
        /// The konektatu
        /// </summary>
        public static MySqlConnection konektatu;

        /// <summary>
        /// Konektatus this instance.
        /// </summary>
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

        /// <summary>
        /// Deskonektatus this instance.
        /// </summary>
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
