using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUREANOS_ERRONKA.CODIGO
{
    public class Konexioa
    {
        private string connectionString = "server=localhost;database=inbentarioa;user=root;password=root;";

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
    }
}
