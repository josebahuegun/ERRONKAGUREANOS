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
    /// <summary>
    ///   <br />
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    public class DBKONEXIOA
    {
        /// <summary>
        /// Gailu aktiboen zerrenda bueltatzen du (ordenagailuak eta inprimagailuak).
        /// </summary>
        /// <returns>Gailuen zerrenda</returns>
        /// <summary>
        /// Ikusis the gailuak.
        /// </summary>
        /// <returns></returns>
        static public List<Gailua> ikusiGailuak()
        {
            KONEXIOA.Konektatu();
            List<Gailua> gk = new List<Gailua>();

            string sqlie = @"
SELECT 
    g.id,
    g.mintegia_id,
    CASE 
        WHEN o.id IS NOT NULL THEN 'Ordenagailua'
        WHEN i.id IS NOT NULL THEN 'Inprimagailua'
        ELSE 'Gailu Ezezaguna'
    END AS Mota,
    g.marka,
    g.kokalekua,
    g.eroste_data,
    g.egoera,
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
WHERE g.egoera = 'aktibo';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlie, KONEXIOA.konektatu);
                MySqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        int mintegiaId = r.GetInt32(1); 
                        string mota = r.GetString(2);
                        string marka = r.GetString(3);
                        string kokalekua = r.GetString(4);
                        DateTime erosteData = r.GetDateTime(5);
                        string egoera = r.GetString(6);
                        string mintegia = r.GetString(7);

                        
                        if (mota == "Inprimagailua")
                        {
                            bool koloretakoa = r.IsDBNull(11) ? false : r.GetBoolean(11);
                            string teknologia = r.IsDBNull(12) ? "" : r.GetString(12);

                            Inprimagailua i = new Inprimagailua(
                                marka, kokalekua, erosteData, egoera, mintegia,
                                koloretakoa, teknologia
                            );

                            i.Id = id;
                            i.MintegiaId = mintegiaId;
                            gk.Add(i);
                        }

                        /// ordenagailua bada, ram, rom eta cpu datuak jaso
                        else if (mota == "Ordenagailua")
                        {
                            string ram = r.IsDBNull(8) ? "" : r.GetString(8);
                            string rom = r.IsDBNull(9) ? "" : r.GetString(9);
                            string cpu = r.IsDBNull(10) ? "" : r.GetString(10);

                            Ordenagailua o = new Ordenagailua(
                                marka, kokalekua, erosteData, egoera, mintegia,
                                ram, rom, cpu
                            );

                            o.Id = id;
                            o.MintegiaId = mintegiaId;
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
        /// <summary>
        /// Gailuas the gehitu.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <returns></returns>
        /// update inprimagailua (gailua taula eta inprimagailua taula biyaak aldatuko dira)
        /// <summary>
        /// Aldatus the inprimagailua.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>


        /// <summary>
        /// Gailuas the gehitu.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <returns></returns>
        static public int gailuaGehitu(Gailua g)
        {
            int txertatutakoId = -1;

            /// datuak balidatu
            if (string.IsNullOrWhiteSpace(g.Marka) || string.IsNullOrWhiteSpace(g.Kokalekua))
            {
                MessageBox.Show("datuak falta dira");
                return -1;
            }

            KONEXIOA.Konektatu();

            try
            {
                /// insert zuzena (duplicadorik gabe)
                string sqlie = @"INSERT INTO gailua 
(marka, kokalekua, eroste_data, egoera, mintegia_id) 
VALUES (@marka, @kokalekua, @eroste_data, @egoera, 
(SELECT id FROM mintegia WHERE izena = @mintegia_izena));";

                using (MySqlCommand komandue = new MySqlCommand(sqlie, KONEXIOA.konektatu))
                {
                    komandue.Parameters.AddWithValue("@marka", g.Marka);
                    komandue.Parameters.AddWithValue("@kokalekua", g.Kokalekua);
                    komandue.Parameters.AddWithValue("@eroste_data", g.ErosteData);
                    komandue.Parameters.AddWithValue("@egoera", g.Egoera);
                    komandue.Parameters.AddWithValue("@mintegia_izena", g.Mintegia);

                    komandue.ExecuteNonQuery();

                    MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID()", KONEXIOA.konektatu);
                    txertatutakoId = Convert.ToInt32(cmdId.ExecuteScalar());

                    /// historiala gehitu
                    DBKONEXIOA.TxertatuHistorikoa(
                        "GEHITU",
                        "gailu berria sortu da: " + g.Marka,
                        txertatutakoId
                    );
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return txertatutakoId;
        }

        /// <summary>
        /// Txertatus the ordenagailua.
        /// </summary>
        /// <param name="gailuId">The gailu identifier.</param>
        /// <param name="ram">The ram.</param>
        /// <param name="rom">The rom.</param>
        /// <param name="cpu">The cpu.</param>
        /// <returns></returns>
        /// <summary>
        /// Txertatus the ordenagailua.
        /// </summary>
        /// <param name="gailuId">The gailu identifier.</param>
        /// <param name="ram">The ram.</param>
        /// <param name="rom">The rom.</param>
        /// <param name="cpu">The cpu.</param>
        /// <returns></returns>
        public static bool TxertatuOrdenagailua(Ordenagailua o)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = "INSERT INTO ordenagailua (id, ram, rom, cpu) VALUES (@id, @ram, @rom, @cpu)";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@id", o.Id);
                cmd.Parameters.AddWithValue("@ram", o.RAM1);
                cmd.Parameters.AddWithValue("@rom", o.ROM1);
                cmd.Parameters.AddWithValue("@cpu", o.CPU1);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (MySqlException)
            {
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Txertatus the inprimagailua.
        /// </summary>
        /// <param name="gailuId">The gailu identifier.</param>
        /// <param name="koloretakoa">if set to <c>true</c> [koloretakoa].</param>
        /// <param name="teknologia">The teknologia.</param>
        /// <returns></returns>
        /// <summary>
        /// Txertatus the inprimagailua.
        /// </summary>
        /// <param name="gailuId">The gailu identifier.</param>
        /// <param name="koloretakoa">if set to <c>true</c> [koloretakoa].</param>
        /// <param name="teknologia">The teknologia.</param>
        /// <returns></returns>
        public static bool TxertatuInprimagailua(Inprimagailua i)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = "INSERT INTO inprimagailua (id, koloretakoa, teknologia) VALUES (@id, @kolorea, @tekno)";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@kolorea", i.Koloretakoa);
                cmd.Parameters.AddWithValue("@tekno", i.Teknologia);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (MySqlException)
            {
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Ezabatus the gailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Ezabatus the gailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static bool EzabatuGailua(int id)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                /// zaborrontzira sartu (erabiltzaile izena gorde)
                string sql2 = "INSERT INTO zaborrontzia (ezabatze_data, gailua_id, erabiltzailea) VALUES (NOW(), @id, @user)";
                MySqlCommand cmd2 = new MySqlCommand(sql2, KONEXIOA.konektatu);

                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.Parameters.AddWithValue("@user", sesioa.Izena); /// hemen izena

                cmd2.ExecuteNonQuery();

                /// gailua baja egoeran jarri
                string sql = "UPDATE gailua SET egoera = 'baja' WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                ondo = true;

                /// historiala gehitu
                DBKONEXIOA.TxertatuHistorikoa(
                    "EZABATU",
                    "gailua baja moduan jarri da",
                    id
                );
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
        /// <summary>
        /// Aldatus the gailua.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <returns></returns>
        /// <summary>
        /// Aldatus the gailua.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <returns></returns>
        public static bool AldatuGailua(Gailua g)
        {
            bool ondo = false;

            try
            {
                string sql = @"UPDATE gailua 
SET marka=@marka, 
    kokalekua=@koka, 
    eroste_data=@data,
    mintegia_id = @mintegia
WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@marka", g.Marka);
                cmd.Parameters.AddWithValue("@koka", g.Kokalekua);
                cmd.Parameters.AddWithValue("@data", g.ErosteData);
                cmd.Parameters.AddWithValue("@mintegia", g.MintegiaId);
                cmd.Parameters.AddWithValue("@id", g.Id);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ondo;
        }
        /// <summary>
        /// Aldatus the ordenagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ram">The ram.</param>
        /// <param name="rom">The rom.</param>
        /// <param name="cpu">The cpu.</param>
        /// <summary>
        /// Aldatus the ordenagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ram">The ram.</param>
        /// <param name="rom">The rom.</param>
        /// <param name="cpu">The cpu.</param>
        public static void AldatuOrdenagailua(int id, string ram, string rom, string cpu)
        {

            string sql = "UPDATE ordenagailua SET ram=@ram, rom=@rom, cpu=@cpu WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

            cmd.Parameters.AddWithValue("@ram", ram);
            cmd.Parameters.AddWithValue("@rom", rom);
            cmd.Parameters.AddWithValue("@cpu", cpu);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

        }
        /// <summary>
        /// Aldatus the inprimagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="kolorea">if set to <c>true</c> [kolorea].</param>
        /// <param name="teknologia">The teknologia.</param>
        /// <summary>
        /// Aldatus the inprimagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="kolorea">if set to <c>true</c> [kolorea].</param>
        /// <param name="teknologia">The teknologia.</param>
        public static void AldatuInprimagailua(int id, bool kolorea, string teknologia)
        {

            string sql = "UPDATE inprimagailua SET koloretakoa=@kol, teknologia=@tek WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

            cmd.Parameters.AddWithValue("@kol", kolorea);
            cmd.Parameters.AddWithValue("@tek", teknologia);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

        }
        /// <summary>
        /// Ikusis the zaborrontzia.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Ikusis the zaborrontzia.
        /// </summary>
        /// <returns></returns>
        static public DataTable IkusiZaborrontzia()
        {
            DataTable tabla = new DataTable();

            try
            {
                KONEXIOA.Konektatu();

                string sql = @"
SELECT 
    z.gailua_id AS Etiketa,
    z.id_zaborrontzia,
    g.marka,
    g.kokalekua,
    m.izena AS Mintegia,  
    z.ezabatze_data,
    z.erabiltzailea
FROM zaborrontzia z
JOIN gailua g ON z.gailua_id = g.id
JOIN mintegia m ON g.mintegia_id = m.id;
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
        /// <summary>
        /// Ikusis the erabiltzaileak.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Ikusis the erabiltzaileak.
        /// </summary>
        /// <returns></returns>
        static public DataTable IkusiErabiltzaileak()
        {
            DataTable tabla = new DataTable();

            try
            {
                KONEXIOA.Konektatu();

                string sql = "";

                // ikt → denak ikusi
                if (sesioa.Rola == "IKTarduraduna")
                {
                    sql = @"
SELECT 
    e.id,
    e.izena,
    e.rola,
    e.aktibo,
    m.izena AS mintegia
FROM erabiltzailea e
LEFT JOIN mintegia m ON e.mintegia_id = m.id;
";
                }
                else
                {
                    // besteak → aktibo bakarrik
                    sql = @"
SELECT 
    e.id,
    e.izena,
    e.rola,
    e.aktibo,
    m.izena AS mintegia
FROM erabiltzailea e
LEFT JOIN mintegia m ON e.mintegia_id = m.id
WHERE e.aktibo = 1;
";
                }

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
        /// <summary>
        /// Sortus the erabiltzailea.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="rola">The rola.</param>
        /// <param name="mintegiaId">The mintegia identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Sortus the erabiltzailea.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="rola">The rola.</param>
        /// <param name="mintegiaId">The mintegia identifier.</param>
        /// <returns></returns>
        public static bool SortuErabiltzailea(ERABILTZAILEA e)
        {
            bool ondo = false;

            if (string.IsNullOrWhiteSpace(e.Izena) || string.IsNullOrWhiteSpace(e.Pasahitza))
            {
                MessageBox.Show("Datuak falta dira");
                return false;
            }

            try
            {
                KONEXIOA.Konektatu();

                // duplicado
                string check = "SELECT COUNT(*) FROM erabiltzailea WHERE izena = @izena AND aktibo = 1";
                MySqlCommand cmdCheck = new MySqlCommand(check, KONEXIOA.konektatu);
                cmdCheck.Parameters.AddWithValue("@izena", e.Izena);

                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Erabiltzailea existitzen da!");
                    return false;
                }

                // insert
                string sql = @"INSERT INTO erabiltzailea 
(izena, pasahitza, rola, aktibo, mintegia_id)
VALUES (@izena, @pass, @rola, 1, @mintegia)";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@izena", e.Izena);
                cmd.Parameters.AddWithValue("@pass", e.Pasahitza);
                cmd.Parameters.AddWithValue("@rola", e.Rola);
                cmd.Parameters.AddWithValue("@mintegia", e.MintegiaId);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Lortus the mintegiak.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Lortus the mintegiak.
        /// </summary>
        /// <returns></returns>
        static public DataTable LortuMintegiak()
        {
            DataTable tabla = new DataTable();

            try
            {
                KONEXIOA.Konektatu();

                string sql = "SELECT id, izena FROM mintegia";

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
        /// <summary>
        /// Ezabatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Ezabatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static bool EzabatuErabiltzailea(int id)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                /// zenbat ikt?
                string sqlCount = "SELECT COUNT(*) FROM erabiltzailea WHERE rola = 'IKTarduraduna' AND aktibo = 1";
                MySqlCommand cmdCount = new MySqlCommand(sqlCount, KONEXIOA.konektatu);

                int kopurua = Convert.ToInt32(cmdCount.ExecuteScalar());

                /// ikt den egiaztatu
                string sqlCheck = "SELECT rola FROM erabiltzailea WHERE id = @id";
                MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, KONEXIOA.konektatu);
                cmdCheck.Parameters.AddWithValue("@id", id);

                string rola = cmdCheck.ExecuteScalar().ToString();

                /// azken ikt bada, ez utzi ezabatzen
                if (rola == "IKTarduraduna" && kopurua <= 1)
                {
                    MessageBox.Show("Ezin da azken IKT ezabatu!");
                    return false;
                }

                /// ezabatzen den erabiltzailea baja moduan jarri (aktibo = 0)
                string sql = "UPDATE erabiltzailea SET aktibo = 0 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", id);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Sortus the mintegia.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <returns></returns>
        /// <summary>
        /// Sortus the mintegia.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <returns></returns>
        public static bool SortuMintegia(string izena)
        {
            bool ondo = false;

            if (string.IsNullOrWhiteSpace(izena))
            {
                MessageBox.Show("Izena hutsik");
                return false;
            }

            try
            {
                KONEXIOA.Konektatu();

                /// duplikatua egiaztatu
                string check = "SELECT COUNT(*) FROM mintegia WHERE izena = @izena";
                MySqlCommand cmdCheck = new MySqlCommand(check, KONEXIOA.konektatu);
                cmdCheck.Parameters.AddWithValue("@izena", izena);

                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Mintegia existitzen da!");
                    return false;
                }

                /// insert mintegia
                string sql = "INSERT INTO mintegia (izena) VALUES (@izena)";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@izena", izena);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Ezabatus the mintegia.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Ezabatus the mintegia.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static bool EzabatuMintegia(int id)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                /// idtik mintegiaren izena lortu
                string sqlAlma = "SELECT id FROM mintegia WHERE izena = 'Almazena'";
                MySqlCommand cmdAlma = new MySqlCommand(sqlAlma, KONEXIOA.konektatu);
                int almazenaId = Convert.ToInt32(cmdAlma.ExecuteScalar());

                /// gailuak almazenera pasa
                string sqlUpdate = "UPDATE gailua SET mintegia_id = @alma WHERE mintegia_id = @id";
                MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, KONEXIOA.konektatu);

                cmdUpdate.Parameters.AddWithValue("@alma", almazenaId);
                cmdUpdate.Parameters.AddWithValue("@id", id);

                cmdUpdate.ExecuteNonQuery();

                /// ezabatu mintegia
                string sqlDelete = "DELETE FROM mintegia WHERE id = @id";
                MySqlCommand cmdDelete = new MySqlCommand(sqlDelete, KONEXIOA.konektatu);

                cmdDelete.Parameters.AddWithValue("@id", id);

                if (cmdDelete.ExecuteNonQuery() > 0)
                    ondo = true;
            }       
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Ikusis the historikoa.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Ikusis the historikoa.
        /// </summary>
        /// <returns></returns>
        public static DataTable IkusiHistorikoa()
        {
            DataTable tabla = new DataTable();

            try
            {
                KONEXIOA.Konektatu();

                string sql = "SELECT * FROM historiala";

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
        /// <summary>
        /// Ezabatus the historikoa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Ezabatus the historikoa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static bool EzabatuHistorikoa(int id)
        {
            bool ondo = false;

            try
            {
                /// ezabatu historiala id-aren arabera
                KONEXIOA.Konektatu();

                string sql = "DELETE FROM historiala WHERE id_historiala = @id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", id);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Editatus the historikoa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="desk">The desk.</param>
        /// <param name="mota">The mota.</param>
        /// <returns></returns>
        /// editatu historiala (deskribapena eta mota bakarrik editatu ahal izango dira, data eta gailua_id ez dira editatuko)
        /// <summary>
        /// Editatus the historikoa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="desk">The desk.</param>
        /// <param name="mota">The mota.</param>
        /// <returns></returns>
        public static bool EditatuHistorikoa(int id, string desk, string mota)
        {
            bool ondo = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = @"UPDATE historiala 
                       SET deskribapena=@desk, mota=@mota 
                       WHERE id_historiala=@id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@desk", desk);
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.Parameters.AddWithValue("@id", id);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return ondo;
        }
        /// <summary>
        /// Txertatus the historikoa.
        /// </summary>
        /// <param name="mota">The mota.</param>
        /// <param name="desk">The desk.</param>
        /// <param name="gailuaId">The gailua identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Txertatus the historikoa.
        /// </summary>
        /// <param name="mota">The mota.</param>
        /// <param name="desk">The desk.</param>
        /// <param name="gailuaId">The gailua identifier.</param>
        /// <returns></returns>
        public static bool TxertatuHistorikoa(string mota, string desk, int gailuaId)
        {
            bool ondo = false;

            try
            {
                /// ionsert historiala (data automatikoki sartu, NOW() erabiliz)

                string sql = @"INSERT INTO historiala 
               (data, deskribapena, mota, gailua_id)
               VALUES (NOW(), @desk, @mota, @id)";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@desk", desk);
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.Parameters.AddWithValue("@id", gailuaId);

                if (cmd.ExecuteNonQuery() > 0)
                    ondo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ondo;
        }
        /// <summary>
        /// Aldatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="izena">The izena.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="rola">The rola.</param>
        /// <param name="mintegiId">The mintegi identifier.</param>
        /// erabiltzailea eguneratu
        /// <summary>
        /// Aldatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="izena">The izena.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="rola">The rola.</param>
        /// <param name="mintegiId">The mintegi identifier.</param>
        public static void AldatuErabiltzailea(ERABILTZAILEA e)
        {
            try
            {
                KONEXIOA.Konektatu();

                string sql = @"UPDATE erabiltzailea 
SET izena=@iz, 
    pasahitza=@pas, 
    rola=@rol, 
    mintegia_id=@min
WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                cmd.Parameters.AddWithValue("@iz", e.Izena);
                cmd.Parameters.AddWithValue("@pas", e.Pasahitza);
                cmd.Parameters.AddWithValue("@rol", e.Rola);
                cmd.Parameters.AddWithValue("@min", e.MintegiaId);
                cmd.Parameters.AddWithValue("@id", e.Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }
        }
        /// <summary>
        /// Kontatus the ikt.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Kontatus the ikt.
        /// </summary>
        /// <returns></returns>
        public static int KontatuIKT()
        {
            int kopurua = 0;

            try
            {
                KONEXIOA.Konektatu();

                string sql = "SELECT COUNT(*) FROM erabiltzailea WHERE rola = 'IKTarduraduna' AND aktibo = 1";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);

                kopurua = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return kopurua;
        }
        /// <summary>
        /// Mintegiaks the irakasleak ditu.
        /// </summary>
        /// <param name="mintegiaId">The mintegia identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Mintegiaks the irakasleak ditu.
        /// </summary>
        /// <param name="mintegiaId">The mintegia identifier.</param>
        /// <returns></returns>
        public static bool MintegiakIrakasleakDitu(int mintegiaId)
        {
            bool baditu = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = "SELECT COUNT(*) FROM erabiltzailea WHERE mintegia_id = @id AND aktibo = 1";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", mintegiaId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                    baditu = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return baditu;
        }
        /// <summary>
        /// Ezabatus the ordenagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <summary>
        /// Ezabatus the ordenagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void EzabatuOrdenagailua(int id)
        {
            KONEXIOA.Konektatu();

            string sql = "DELETE FROM ordenagailua WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            KONEXIOA.Deskonektatu();
        }

        /// <summary>
        /// Ezabatus the inprimagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <summary>
        /// Ezabatus the inprimagailua.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void EzabatuInprimagailua(int id)
        {
            KONEXIOA.Konektatu();

            string sql = "DELETE FROM inprimagailua WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            KONEXIOA.Deskonektatu();
        }
        /// <summary>
        /// Mintegiburuaexistitus the specified mintegi identifier.
        /// </summary>
        /// <param name="mintegiId">The mintegi identifier.</param>
        /// <param name="erabiltzaileaid">The erabiltzaileaid.</param>
        /// <returns></returns>
        /// <summary>
        /// Mintegiburuaexistitus the specified mintegi identifier.
        /// </summary>
        /// <param name="mintegiId">The mintegi identifier.</param>
        /// <param name="erabiltzaileaid">The erabiltzaileaid.</param>
        /// <returns></returns>
        public static bool mintegiburuaexistitu(int mintegiId, int erabiltzaileaid)
        {
            bool badago = false;

            try
            {
                KONEXIOA.Konektatu();

                string sql = @"SELECT COUNT(*) 
FROM erabiltzailea 
WHERE rola='Mintegiburua' 
AND mintegia_id=@mintegiId
AND id != @id";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@mintegiId", mintegiId);
                cmd.Parameters.AddWithValue("@id", erabiltzaileaid);

                int kop = Convert.ToInt32(cmd.ExecuteScalar());

                if (kop > 0)
                    badago = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return badago;
        }
        /// <summary>
        /// Lortus the mintegi identifier izena.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <returns></returns>
        /// mintegi izenetik id lortu
        /// <summary>
        /// Lortus the mintegi identifier izena.
        /// </summary>
        /// <param name="izena">The izena.</param>
        /// <returns></returns>
        public static int LortuMintegiIdIzena(string izena)
        {
            int id = -1;

            try
            {
                KONEXIOA.Konektatu();

                string sql = "SELECT id FROM mintegia WHERE izena=@izena";

                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@izena", izena);

                object emaitza = cmd.ExecuteScalar();

                if (emaitza != null && emaitza != DBNull.Value)
                    id = Convert.ToInt32(emaitza);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }

            return id;
        }
        /// <summary>
        /// Aktibatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <summary>
        /// Aktibatus the erabiltzailea.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void AktibatuErabiltzailea(int id)
        {
            try
            {
                KONEXIOA.Konektatu();

                string sql = "UPDATE erabiltzailea SET aktibo = 1 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                KONEXIOA.Deskonektatu();
            }
        }
        /// <summary>
        /// Mintegiaks the erabiltzaileak ditu.
        /// </summary>
        /// <param name="mintegiId">The mintegi identifier.</param>
        /// <returns></returns>
        /// <summary>
        /// Mintegiaks the erabiltzaileak ditu.
        /// </summary>
        /// <param name="mintegiId">The mintegi identifier.</param>
        /// <returns></returns>
        public static bool MintegiakErabiltzaileakDitu(int mintegiId)
{
    bool baditu = false;

    try
    {
        KONEXIOA.Konektatu();

        string sql = "SELECT COUNT(*) FROM erabiltzailea WHERE mintegia_id = @id AND aktibo = 1";
        MySqlCommand cmd = new MySqlCommand(sql, KONEXIOA.konektatu);
        cmd.Parameters.AddWithValue("@id", mintegiId);

        int kop = Convert.ToInt32(cmd.ExecuteScalar());

        if (kop > 0)
            baditu = true;
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        KONEXIOA.Deskonektatu();
    }

    return baditu;
}
    }
}
