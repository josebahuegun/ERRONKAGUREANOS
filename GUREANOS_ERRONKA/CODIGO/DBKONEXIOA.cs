using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    internal class DBKONEXIOA
    {
       
        static public List<Gailua> ikusiGailuak()
        {
            KONEXIOA.Konektatu();
            List<Gailua> gk = new List<Gailua>();
            string sqlie = "select * from kontaktua";
            try
            {
                MySqlCommand neresqlkomandue = new MySqlCommand(sqlie, KONEXIOA.konektatu);
                MySqlDataReader resultauek = neresqlkomandue.ExecuteReader();
                if (resultauek.HasRows)
                {
                    while (resultauek.Read())
                    {
                        //getName > kanpoan izena ateratzen du
                        //getValue > balorea ateratzen du
                        Gailua g = new Gailua(resultauek.GetValue(0).ToString(), resultauek.GetValue(1).ToString());
                        gk.Add(g);
                    }
                }
                //using gabe erabilita, beraz komandoa itxi egin behar da.
                resultauek.Close();
            }
            catch (MySqlException e)
            {
            }
            finally
            {
                //deskonektatu
                KONEXIOA.Deskonektatu();
            }
            return gk;
        }
    }
}
