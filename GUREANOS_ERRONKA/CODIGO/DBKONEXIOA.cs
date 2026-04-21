using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            g.id,
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
                MySqlCommand cmd = new MySqlCommand(sqlie, KONEXIOA.konektatu);
                MySqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        string mota = r.GetString(1);
                        string marka = r.GetString(2);
                        string kokalekua = r.GetString(3);
                        DateTime erosteData = r.GetDateTime(4);
                        bool aktibo = r.GetBoolean(5);
                        string mintegia = r.GetString(6);

                        // 🖨️ INPRIMAGAILUA
                        if (mota == "Inprimagailua")
                        {
                            bool koloretakoa = r.IsDBNull(10) ? false : r.GetBoolean(10);
                            string teknologia = r.IsDBNull(11) ? "" : r.GetString(11);

                            Inprimagailua i = new Inprimagailua(
                                marka, kokalekua, erosteData, aktibo, mintegia,
                                koloretakoa, teknologia
                            );

                            i.Id = id; // 🔥 CLAVE
                            gk.Add(i);
                        }

                        // 💻 ORDENAGAILUA
                        else if (mota == "Ordenagailua")
                        {
                            string ram = r.IsDBNull(7) ? "" : r.GetString(7);
                            string rom = r.IsDBNull(8) ? "" : r.GetString(8);
                            string cpu = r.IsDBNull(9) ? "" : r.GetString(9);

                            Ordenagailua o = new Ordenagailua(
                                marka, kokalekua, erosteData, aktibo, mintegia,
                                ram, rom, cpu
                            );

                            o.Id = id; // 🔥 CLAVE
                            gk.Add(o);
                        }
                    }
                }

                r.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
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
            int txertatutakoId = -1;

            KONEXIOA.Konektatu();

            try
            {
                string sqlie = @"INSERT INTO gailua 
(marka, kokalekua, eroste_data, aktibo, mintegia_id) 
VALUES (@marka, @kokalekua, @eroste_data, @aktibo, 
(SELECT id FROM mintegia WHERE izena = @mintegia_izena));";

                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    komandue.Parameters.AddWithValue("@marka", g.Marka);
                    komandue.Parameters.AddWithValue("@kokalekua", g.Kokalekua);
                    komandue.Parameters.AddWithValue("@eroste_data", g.ErosteData);
                    komandue.Parameters.AddWithValue("@aktibo", g.Aktibo);
                    komandue.Parameters.AddWithValue("@mintegia_izena", g.Mintegia);

                    komandue.ExecuteNonQuery();

                    MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID()", KONEXIOA.konektatu);
                    txertatutakoId = Convert.ToInt32(cmdId.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message); // 🔥 IMPORTANTE
            }
            finally
            {
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
                    ondo = true;
            }
            catch (MySqlException ex)
            {
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

                string sql = "INSERT INTO inprimagailua (id, koloretakoa, teknologia) VALUES (@id, @kolorea, @tekno)";
                MySqlCommand komandoa = new MySqlCommand(sql, KONEXIOA.konektatu);

                komandoa.Parameters.AddWithValue("@id", gailuId);
                komandoa.Parameters.AddWithValue("@kolorea", koloretakoa);
                komandoa.Parameters.AddWithValue("@tekno", teknologia);

                if (komandoa.ExecuteNonQuery() > 0)
                    ondo = true;
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
        public static bool EzabatuGailua(int id)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                // insertar zaborrontzia
                string sql2 = "INSERT INTO zaborrontzia (ezabatze_data, gailua_id, erabiltzaile_id) VALUES (NOW(), @id, 1)";
                MySqlCommand cmd2 = new MySqlCommand(sql2, KONEXIOA.konektatu);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();

                // gero desaktibatu gailua
                string sql = "UPDATE gailua SET aktibo = 0 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                ondo = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        public static bool AldatuGailua(Gailua g)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = @"UPDATE gailua 
                       SET marka=@marka, kokalekua=@koka, eroste_data=@data 
                       WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@marka", g.Marka);
                cmd.Parameters.AddWithValue("@koka", g.Kokalekua);
                cmd.Parameters.AddWithValue("@data", g.ErosteData);
                cmd.Parameters.AddWithValue("@id", g.Id);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        public static void AldatuOrdenagailua(int id, string ram, string rom, string cpu)
        {
            KONEXIOA.Konektatu();

            string sql = "UPDATE ordenagailua SET ram=@ram, rom=@rom, cpu=@cpu WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

            cmd.Parameters.AddWithValue("@ram", ram);
            cmd.Parameters.AddWithValue("@rom", rom);
            cmd.Parameters.AddWithValue("@cpu", cpu);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            KONEXIOA.Deskonektatu();
        }
        public static void AldatuInprimagailua(int id, bool kolorea, string teknologia)
        {
            KONEXIOA.Konektatu();

            string sql = "UPDATE inprimagailua SET koloretakoa=@kol, teknologia=@tek WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

            cmd.Parameters.AddWithValue("@kol", kolorea);
            cmd.Parameters.AddWithValue("@tek", teknologia);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            KONEXIOA.Deskonektatu();
        }
        static public DataTable IkusiZaborrontzia()
        {
            DataTable tabla = new DataTable();

            try
            {
                KONEXIOA.Konektatu();

                string sql = @"
        SELECT 
            z.id_zaborrontzia,
            g.marka,
            g.kokalekua,
            z.ezabatze_data,
            e.izena AS erabiltzailea
        FROM zaborrontzia z
        JOIN gailua g ON z.gailua_id = g.id
        JOIN erabiltzailea e ON z.erabiltzaile_id = e.id;
        ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, KONEXIOA.konektatu);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return tabla;
        }
    }
}
