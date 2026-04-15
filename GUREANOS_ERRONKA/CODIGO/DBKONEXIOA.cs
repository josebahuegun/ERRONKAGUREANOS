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
            string sqlie = "select * from gailua";
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
                        Gailua g = new Gailua(resultauek.GetInt32(0),      // 0 zutabea zenbaki oso gisa irakurri
                                              resultauek.GetDateTime(3),   // 3 zutabea data gisa irakurri
                                              resultauek.GetString(2),     // 2 zutabea testu gisa irakurri
                                              resultauek.GetString(1),     // 1 zutabea testu gisa irakurri
                                              resultauek.GetBoolean(4)    // 4 zutabea boolear gisa irakurri);
                        );
                        gk.Add(g);
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

        static public int gailuaEzabatu(Gailua g)
        {
            int num;
            KONEXIOA.Konektatu();
            try
            {
                string sqlie = "DELETE FROM kontaktua where izena=@izena and telefonoa=@telefonoa;";
                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    //komandue.Parameters.AddWithValue("@izena", g.Izena);
                    //komandue.Parameters.AddWithValue("@telefonoa", g.Telefonoa);
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

        static public int gailuaGehitu(Gailua g)
        {
            int num;
            //1.- Konektatu
            KONEXIOA.Konektatu();
            //2. inserta egin
            
            try
            {
                //inserta, PARAMETRO BIDEZ, PRAKTIKA ONA
                string sqlie = "INSERT INTO gailua (izena, telefonoa) VALUES (@izena, @telefonoa);";
                //using erabilita komandue aldagia "hustu" egiten da agindua amaitzena, baina ez konexioa adibidez, nik egin behar close horrela jarrita
                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    // Parametroak gehitu
                    //komandue.Parameters.AddWithValue("@izena", g.Izena);
                    //komandue.Parameters.AddWithValue("@telefonoa", g.Telefonoa);
                    num = komandue.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                num = ex.Number;
            }
            finally // try edo catchera joan, beti konexioa izteko. Beste aukera bat, hau gabe, return aurretik close
            {
                //deskonektatu
                KONEXIOA.Deskonektatu();
            }
            //3.- Bueltatu zenbakia: 0 edo 1 querytik, edo bestela errore zenbakia          
            return num;
        }

    }
}
