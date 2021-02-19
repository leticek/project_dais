using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class CvicenecGW
    {
        public static string SQL_REGISTRACE_CVICENCE = "INSERT INTO \"Cvicenec\" VALUES ((SELECT MAX(id_cvicence) + 1 FROM cvicenec), @jmeno, @prijmeni, @pohlavi, @datum_narozeni," + 
                                                        "@telefonni_cislo, @email, @adresa, @clen_klubu)";
        public static string SQL_SMAZANI_CVICENCE = "DELETE FROM \"Cvicenec\" WHERE id_cvicence = @id_cvicence";
        public static string SQL_UPRAVA_CVICENCE = "UPDATE \"Cvicenec\" SET jmeno=@jmeno, prijmeni=@prijmeni, pohlavi=@pohlavi, datum_narozeni=@datum_narozeni, telefonni_cislo=@telefonni_cislo," + 
                                                        "email=@email, adresa=@adresa, clen_klubu=@clen_klubu WHERE id_cvicence=@id_cvicence";
        public static string SQL_DETAIL_CVICENCE = "SELECT id_cvicence, jmeno, prijmeni, pohlavi, datum_narozeni, telefonni_cislo, email, adresa, clen_klubu" +
                                                    " FROM \"Cvicenec\" WHERE id_cvicence = @id_cvicence";
        public static string SQL_SEZNAM_CVICENCU = "SELECT id_cvicence, jmeno, prijmeni, pohlavi, datum_narozeni, telefonni_cislo, email, adresa, clen_klubu FROM \"Cvicenec\"";

        //1.1 Registrace nového cvičence
        public static bool registraceCvicence(Cvicenec c)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand command= sqlConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                try
                {
                    command = new SqlCommand(SQL_REGISTRACE_CVICENCE, sqlConnection, transaction);
                    command = pripravPrikaz(command, c);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        //1.2 Změna údajů registrovaného cvičence
        public static bool upravaCvicence(Cvicenec c)
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
                    command = new SqlCommand(SQL_UPRAVA_CVICENCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_cvicence", c.id_cvicence);
                    command = pripravPrikaz(command, c);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        //1.3 Smazani cvicence
        public static bool smazaniCvicence(Cvicenec c)
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
                    command = new SqlCommand(SQL_SMAZANI_CVICENCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_cvicence", c.id_cvicence);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        //1.4 Detail cvicence
        public static Cvicenec detailCvicence(Cvicenec c)
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
                    command = new SqlCommand(SQL_DETAIL_CVICENCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_cvicence", c.id_cvicence);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        c.id_cvicence = Int32.Parse(reader[0].ToString());
                        c.jmeno = reader[1].ToString();
                        c.prijmeni = reader[2].ToString();
                        c.pohlavi = reader[3].ToString();
                        c.datum_narozeni = DateTime.Parse(reader[4].ToString());
                        c.telefonni_cislo = reader[5].ToString();
                        c.email = reader[6].ToString();
                        c.adresa = reader[7].ToString();
                        c.clen_klubu = Boolean.Parse(reader[8].ToString()) == true ? '1' : '0';
                    }
                    reader.Close();
                    transaction.Commit();
                    return c;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        //1.5 Seznam cvicencu
        public static List<Cvicenec> seznamCvicencu()
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
                    command = new SqlCommand(SQL_SEZNAM_CVICENCU, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Cvicenec> list = new List<Cvicenec>();                  
                    while (reader.Read())
                    {
                        Cvicenec c = new Cvicenec();
                        c.id_cvicence = Int32.Parse(reader[0].ToString());
                        c.jmeno = reader[1].ToString();
                        c.prijmeni = reader[2].ToString();
                        c.pohlavi = reader[3].ToString();
                        c.datum_narozeni = DateTime.Parse(reader[4].ToString());
                        c.telefonni_cislo = reader[5].ToString();
                        c.email = reader[6].ToString();
                        c.adresa = reader[7].ToString();
                        c.clen_klubu = Boolean.Parse(reader[8].ToString()) == true ? '1' : '0';
                        list.Add(c);
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

        private static SqlCommand pripravPrikaz(SqlCommand command, Cvicenec c)
        {
            //odstranil jsem možnost null hodnot, budou řešeny při ošetření vstupu formuláře
            command.Parameters.AddWithValue("@jmeno", c.jmeno);
            command.Parameters.AddWithValue("@prijmeni", c.prijmeni);
            command.Parameters.AddWithValue("@pohlavi", c.pohlavi);
            command.Parameters.AddWithValue("@datum_narozeni", c.datum_narozeni);
            command.Parameters.AddWithValue("@telefonni_cislo", c.telefonni_cislo);
            command.Parameters.AddWithValue("@email",c.email);
            command.Parameters.AddWithValue("@adresa", c.adresa);
            command.Parameters.AddWithValue("@clen_klubu", c.clen_klubu);
            return command;
        }
    }
}
