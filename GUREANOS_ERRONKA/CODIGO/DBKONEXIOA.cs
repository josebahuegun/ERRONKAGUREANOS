using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string sqlie = @"
                SELECT 
                    CASE 
                        WHEN o.id IS NOT NULL THEN 'Ordenagailua'
                        WHEN i.id IS NOT NULL THEN 'Inprimagailua'
                        ELSE 'Gailu Ezezaguna'
                    END AS Mota,
                    g.marka,
                    g.kokalekua,
                    g.eroste_data,
                    g.aktibo,
                    m.izena AS Mintegia,
                    o.ram,
                    o.rom,
                    o.cpu,  
                    i.koloretakoa,
                    i.teknologia
                FROM gailua g
                LEFT JOIN mintegia m ON g.mintegia_id = m.id
                LEFT JOIN ordenagailua o ON g.id = o.id
                LEFT JOIN inprimagailua i ON g.id = i.id
                WHERE g.aktibo = 1;";
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
                        string mota = resultauek.GetString(0);    // 0 zutabea testu gisa irakurri
                        string marka = resultauek.GetString(1);
                        string kokalekua = resultauek.GetString(2);     // 2 zutabea testu gisa irakurri
                        DateTime erosteData = resultauek.GetDateTime(3);
                        bool aktibo = resultauek.GetBoolean(4);    // 4 zutabea boolear gisa irakurri
                        string mintegia = resultauek.GetString(5);


                        if (mota == "Imprimagailua")
                        {
                            bool koloretakoa = resultauek.GetBoolean(7);
                            string teknologia = resultauek.GetString(8);
                            Inprimagailua i = new Inprimagailua(marka, kokalekua, erosteData, aktibo, mintegia, koloretakoa, teknologia);
                            gk.Add(i);
                        }
                        if(mota == "Ordenagailua")
                        {
                            string ram = resultauek.GetString(6);
                            string rom = resultauek.GetString(7);
                            string cpu = resultauek.GetString(8);
                            Ordenagailua o = new Ordenagailua(marka, kokalekua, erosteData, aktibo, mintegia, ram, rom, cpu);
                            gk.Add(o);
                        }
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
                string sqlie = "UPDATE gailua set aktiboa=@telefonoa WHERE izena=@izena;";
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
                string sqlie = "UPDATE Gailua where id=@id set aktibo = 0;";
                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    komandue.Parameters.AddWithValue("@id", g.Id);
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
            int txertatutakoId = -1;
            //1.- Konektatu
            KONEXIOA.Konektatu();
            //2. inserta egin

            try
            {
                //inserta, PARAMETRO BIDEZ, PRAKTIKA ONA
                string sqlie = "INSERT INTO gailua (marka, kokalekua, oeroste_data, aktibo, mintegia_id) VALUES (@marka, @kokalekua, @eroste_data, @aktibo, (SELECT id FROM mintegia WHERE izena = @mintegia_izena));";

                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    // Parametroak gehitu
                    komandue.Parameters.AddWithValue("@marka", g.Marka);
                    komandue.Parameters.AddWithValue("@kokalekua", g.Kokalekua);
                    komandue.Parameters.AddWithValue("@eroste_data", g.ErosteData);
                    komandue.Parameters.AddWithValue("@aktibo", g.Aktibo);
                    komandue.Parameters.AddWithValue("@mintegia_id", g.Mintegia);

                    // ExecuteScalar()-ek lehen zutabeko lehen datua bueltatzen du (Gure ID-a!)
                    txertatutakoId = Convert.ToInt32(komandue.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {

            }
            finally // try edo catchera joan, beti konexioa izteko. Beste aukera bat, hau gabe, return aurretik close
            {
                //deskonektatu
                KONEXIOA.Deskonektatu();
            }
            return txertatutakoId;
        }

        public static bool TxertatuOrdenagailua(int gailuId, string ram, string rom, string cpu)
        {
            bool ondo = false;
            try
            {
                KONEXIOA.Konektatu();
                string sqlie = "INSERT INTO ordenagailua (id, ram, rom, cpu) VALUES (@id, @ram, @rom, @cpu);";
                MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu);
                komandue.Parameters.AddWithValue("@id", gailuId);
                komandue.Parameters.AddWithValue("@ram", ram);
                komandue.Parameters.AddWithValue("@rom", rom);
                komandue.Parameters.AddWithValue("@cpu", cpu);
                if (komandue.ExecuteNonQuery() > 0)
                {
                    ondo = true;
                }
            }
            catch (MySqlException ex)
            {
                // Erroreak kudeatu
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }
            return ondo;
        }
        public static bool TxertatuInprimagailua(int gailuId, bool koloretakoa, string teknologia)
        {
            bool ondo = false;
            try
            {
                KONEXIOA.Konektatu();

                // Zure datu-baseko zutabe zehatzak jarri ditugu hemen:
                string sql = "INSERT INTO inprimagailua (id, koloretakoa, teknologia) VALUES (@id, @kolorea, @tekno)";
                MySqlCommand komandoa = new MySqlCommand(sql, KONEXIOA.konektatu);

                // Parametroak lotu
                komandoa.Parameters.AddWithValue("@id", gailuId);
                komandoa.Parameters.AddWithValue("@kolorea", koloretakoa);
                komandoa.Parameters.AddWithValue("@tekno", teknologia);

                if (komandoa.ExecuteNonQuery() > 0)
                {
                    ondo = true;
                }
            }
            catch (MySqlException e)
            {
                
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
    }
}
