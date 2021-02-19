using orm_implementace.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class LekceGW
    {
        public static string SQL_PRIDANI_LEKCE = "vytvorLekci";
        public static string SQL_ZMEN_DATUM = "zmenaData";
        public static string SQL_ZMEN_MISTO = "zmenaMista";
        public static string SQL_ZRUS_LEKCI = "zruseniLekci";
        public static string SQL_ZMEN_TRENINK = "zmenaTreninku";
        public static string SQL_SEZNAM_LEKCI = "SELECT id_lekce, id_mistnosti, id_trenera, id_treninku, cas_konani, cena, clenstvi" +
                                                " FROM \"Lekce\" WHERE DATEDIFF(MINUTE, CURRENT_TIMESTAMP, cas_konani) > 0";
        public static string SQL_DETAIL_LEKCE = "SELECT id_lekce, id_mistnosti, id_trenera, id_treninku, cas_konani, cena, clenstvi" +
                                                " FROM \"Lekce\" WHERE id_lekce = @idLekce";
        public static string SQL_VYPIS_DLE_VEKU = "SELECT avg_vek, id_lekce FROM prumernyVek(@vek, @idTrenera)";
        public static string SQL_PODIL_UCASTNIKU = "podilUcastniku";

        //4.1 Vytvoreni lekce
        public static int vytvorLekci(Lekce l)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    int result = 0;
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_PRIDANI_LEKCE, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idMistnosti", SqlDbType.Int).Value = l.id_mistnosti;
                    command.Parameters.AddWithValue("@idTrenera", SqlDbType.Int).Value = l.id_trenera;
                    command.Parameters.AddWithValue("@druh_treninku", SqlDbType.Int).Value = l.id_treninku;
                    command.Parameters.AddWithValue("@casKonani", SqlDbType.Int).Value = l.cas_konani;
                    command.Parameters.AddWithValue("@cena", SqlDbType.Int).Value = l.cena;
                    command.Parameters.AddWithValue("@clenstvi", SqlDbType.Int).Value = l.clenstvi;
                    command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToInt32(command.Parameters["@output"].Value);
                    sqlConnection.Close();
                    return result;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        //4.2 Změna data lekce
        public static int zmenaData(int id_lekce, DateTime datum)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    int result = 0;
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_ZMEN_DATUM, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    command.Parameters.AddWithValue("@novyDatum", SqlDbType.DateTime).Value = datum;
                    command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToInt32(command.Parameters["@output"].Value);
                    sqlConnection.Close();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        //4.3 Změna místa
        public static int zmenaMista(int id_lekce, int id_mistnosti)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    int result = 0;
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_ZMEN_MISTO, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    command.Parameters.AddWithValue("@noveMisto", SqlDbType.DateTime).Value = id_mistnosti;
                    command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToInt32(command.Parameters["@output"].Value);
                    sqlConnection.Close();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        //4.4 Zrušení lekce
        public static int zruseniLekce(int id_lekce)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    int result = 0;
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_ZRUS_LEKCI, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToInt32(command.Parameters["@output"].Value);
                    sqlConnection.Close();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        //4.5 Změna treninku
        public static int zmenaTreninku(int id_lekce, int id_treninku)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    int result = 0;
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_ZMEN_TRENINK, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    command.Parameters.AddWithValue("@novyTrenink", SqlDbType.DateTime).Value = id_treninku;
                    command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToInt32(command.Parameters["@output"].Value);
                    sqlConnection.Close();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        //4.6 Seznam lekci
        public static List<Lekce> seznamLekci()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                try
                {
                    command = new SqlCommand(SQL_SEZNAM_LEKCI, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Lekce> list = new List<Lekce>();
                    while (reader.Read())
                    {
                        Lekce l = new Lekce();
                        l.id_lekce = Int32.Parse(reader[0].ToString());
                        l.id_mistnosti = Int32.Parse(reader[1].ToString());
                        l.id_trenera = Int32.Parse(reader[2].ToString());
                        l.id_treninku = Int32.Parse(reader[3].ToString());
                        l.cas_konani = DateTime.Parse(reader[4].ToString());
                        l.cena = Decimal.Parse(reader[5].ToString());
                        l.clenstvi = Boolean.Parse(reader[6].ToString()) == true ? '1' : '0';
                        list.Add(l);
                    }
                    reader.Close();
                    transaction.Commit();
                    return list;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        //4.7 Detail lekce
        public static Lekce detailLekce(int id_lekce)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                try
                {
                    command = new SqlCommand(SQL_DETAIL_LEKCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    SqlDataReader reader = command.ExecuteReader();
                    Lekce l = new Lekce();
                    while (reader.Read())
                    {
                        l.id_lekce = Int32.Parse(reader[0].ToString());
                        l.id_mistnosti = Int32.Parse(reader[1].ToString());
                        l.id_trenera = Int32.Parse(reader[2].ToString());
                        l.id_treninku = Int32.Parse(reader[3].ToString());
                        l.cas_konani = DateTime.Parse(reader[4].ToString());
                        l.cena = Decimal.Parse(reader[5].ToString());
                        l.clenstvi = Boolean.Parse(reader[6].ToString()) == true ? '1' : '0';
                    }
                    reader.Close();
                    transaction.Commit();
                    return l;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        //4.8 Vypis lekci podle věku
        public static Dictionary<int,int> seznamLekciDleVeku(int vek, int idTrenera)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                try
                {
                    command = new SqlCommand(SQL_VYPIS_DLE_VEKU, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@vek", SqlDbType.Int).Value = vek;
                    command.Parameters.AddWithValue("@idTrenera", SqlDbType.Int).Value = idTrenera;
                    SqlDataReader reader = command.ExecuteReader();
                    Dictionary<int, int> dict = new Dictionary<int, int>();
                    while (reader.Read())
                    {
                        dict.Add(Int32.Parse(reader[1].ToString()), Int32.Parse(reader[0].ToString()));
                    }
                    reader.Close();
                    transaction.Commit();
                    return dict;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        //4.9 Procentualní podíl členů
        public static Tuple<int, int> podilClenu(int id_lekce)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_PODIL_UCASTNIKU, sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                    command.Parameters.AddWithValue("@clenove", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.AddWithValue("@neclenove", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    Tuple<int, int> t = new Tuple<int, int>(Convert.ToInt32(command.Parameters["@clenove"].Value), Convert.ToInt32(command.Parameters["@neclenove"].Value));
                    sqlConnection.Close();
                    return t;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
