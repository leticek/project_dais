using orm_implementace.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class TrenerGW
    {
        public static string SQL_PRIDANI_TRENERA = "INSERT INTO \"Trener\" VALUES ((SELECT MAX(id_trenera) + 1 FROM Trener), @jmeno, @prijmeni, @pohlavi, @datum_narozeni," +
                                                        "@telefonni_cislo, @email, @adresa)";
        public static string SQL_UPRAVA_TRENERA = "UPDATE \"Trener\" SET jmeno=@jmeno, prijmeni=@prijmeni, pohlavi=@pohlavi, datum_narozeni=@datum_narozeni, telefonni_cislo=@telefonni_cislo," +
                                                        "email=@email, adresa=@adresa WHERE id_trenera=@id_trenera";
        public static string SQL_SEZNAM_TRENERU = "SELECT id_trenera, jmeno, prijmeni, pohlavi, datum_narozeni, telefonni_cislo, email, adresa FROM \"Trener\"";
        public static string SQL_TRENEROVY_LEKCE = "SELECT id_lekce, id_mistnosti, id_trenera, id_treninku, cas_konani, cena, clenstvi" +
                                                   " FROM \"Lekce\" WHERE id_trenera=@id_trenera AND DATEDIFF(YEAR, cas_konani, CURRENT_TIMESTAMP) < 20";
        public static string SQL_DETAIL_TRENERA = "SELECT id_trenera, jmeno, prijmeni, pohlavi, datum_narozeni, telefonni_cislo, email, adresa" +
                                                    " FROM \"Trener\" WHERE id_trenera = @id_trenera";
        public static string SQL_SMAZAT_TRENERA = "DELETE FROM Trener WHERE NOT EXISTS( SELECT * FROM Lekce WHERE id_trenera=@id_trenera) AND id_trenera = @id_trenera";

        //5.1 Registrace nového trenera
        public static void pridaniTrenera(Trener t)
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
                    command = new SqlCommand(SQL_PRIDANI_TRENERA, sqlConnection, transaction);
                    command = pripravPrikaz(command, t);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                }
            }
        }

        //5.2 Uprava udaju trenera
        public static void upravaTrenera(Trener t)
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
                    command = new SqlCommand(SQL_UPRAVA_TRENERA, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_trenera", t.id_trenera);
                    command = pripravPrikaz(command, t);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                }
            }
        }

        //5.3 Zobrazeni seznamu treneru
        public static List<Trener> seznamTreneru()
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
                    command = new SqlCommand(SQL_SEZNAM_TRENERU, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Trener> list = new List<Trener>();
                    while (reader.Read())
                    {
                        Trener t = new Trener();
                        t.id_trenera = Int32.Parse(reader[0].ToString());
                        t.jmeno = reader[1].ToString();
                        t.prijmeni = reader[2].ToString();
                        t.pohlavi = reader[3].ToString();
                        t.datum_narozeni = DateTime.Parse(reader[4].ToString());
                        t.telefonni_cislo = reader[5].ToString();
                        t.email = reader[6].ToString();
                        t.adresa = reader[7].ToString();
                        list.Add(t);
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

        //5.4 Zobrazeni seznamu svych lekci
        public static List<Lekce> seznamTrenerovychLekci(int id_trenera)
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
                    command = new SqlCommand(SQL_TRENEROVY_LEKCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_trenera", id_trenera);
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

        //5.5 Smazani trenera
        public static void smazaniTrenera(Trener t)
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
                    command = new SqlCommand(SQL_SMAZAT_TRENERA, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_trenera", t.id_trenera);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                }
            }
        }

        //Přidaná funkce kvůli formůlářům
        public static Trener detailTrenera(Trener t)
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
                    command = new SqlCommand(SQL_DETAIL_TRENERA, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_trenera", t.id_trenera);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        t.id_trenera = Int32.Parse(reader[0].ToString());
                        t.jmeno = reader[1].ToString();
                        t.prijmeni = reader[2].ToString();
                        t.pohlavi = reader[3].ToString();
                        t.datum_narozeni = DateTime.Parse(reader[4].ToString());
                        t.telefonni_cislo = reader[5].ToString();
                        t.email = reader[6].ToString();
                        t.adresa = reader[7].ToString();
                    }
                    reader.Close();
                    transaction.Commit();
                    return t;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        private static SqlCommand pripravPrikaz(SqlCommand command, Trener t)
        {
            command.Parameters.AddWithValue("@jmeno", t.jmeno == null ? "null" : t.jmeno);
            command.Parameters.AddWithValue("@prijmeni", t.prijmeni == null ? "null" : t.prijmeni);
            command.Parameters.AddWithValue("@pohlavi", t.pohlavi == null ? "null" : t.pohlavi);
            command.Parameters.AddWithValue("@datum_narozeni", t.datum_narozeni == null ? DateTime.Parse("1.1.1900") : t.datum_narozeni);
            command.Parameters.AddWithValue("@telefonni_cislo", t.telefonni_cislo == null ? "000-000-000" : t.telefonni_cislo);
            command.Parameters.AddWithValue("@email", t.email == null ? "null" : t.email);
            command.Parameters.AddWithValue("@adresa", t.adresa == null ? "null" : t.adresa);
            return command;
        }
    }
}
