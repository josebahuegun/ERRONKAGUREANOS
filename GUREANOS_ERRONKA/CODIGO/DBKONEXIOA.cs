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
       
        static public List<Gailua> ikusiGailuak(Gailua g)
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
                    //while (resultauek.Read())
                    {
                        //getName > kanpoan izena ateratzen du
                        //getValue > balorea ateratzen du
                        //Gailua g = new Gailua();
                        //gk.Add(g);
                    }
                }
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

        static public int aldatuGailuak(Gailua g)
        {
            int num;
            KONEXIOA.Konektatu();
            try
            {
                string sqlie = "UPDATE gailua set telefonoa=@telefonoa WHERE izena=@izena;";
                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    //komandue.Parameters.AddWithValue("@izena", g.Izena);
                   // komandue.Parameters.AddWithValue("@telefonoa", g.Telefonoa);
                    num = komandue.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                num = ex.Number;
            }
            finally
            {
                //deskonektatu
                KONEXIOA.Deskonektatu();
            }
            //3.- Bueltatu zenbakia: 0 edo 1 querytik, edo bestela errore zenbakia          
            return num;

        }
    }
}
