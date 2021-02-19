using orm_implementace.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class MistnostGW
    {
        public static string SQL_PRIDANI_MISTNOSTI = "INSERT INTO \"Mistnost\" VALUES((SELECT MAX(id_mistnosti) + 1 FROM Mistnost), @kapacita_mistnosti)";
        public static string SQL_UPRAVA_MISTNOSTI = "UPDATE \"Mistnost\" SET kapacita_mistnosti=@kapacita_mistnosti WHERE id_mistnosti=@id_mistnosti";
        public static string SQL_SMAZANI_MISTNOSTI = "UPDATE \"Lekce\" SET id_mistnosti=0 WHERE id_mistnosti=@id_mistnosti\n" + 
                                                     "DELETE FROM \"Mistnost\" WHERE id_mistnosti=@id_mistnosti";
        public static string SQL_SEZNAM_MISTNOSTI = "SELECT id_mistnosti, kapacita_mistnosti FROM \"Mistnost\" WHERE id_mistnosti != 0";
        public static string SQL_DETAIL_MISTNOSTI= "SELECT id_mistnosti, kapacita_mistnosti FROM \"Mistnost\" WHERE id_mistnosti = @id_mistnosti";

        //3.1 Přidání nové místnosti
        public static void pridaniMistnosti(Mistnost m)
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
                    command = new SqlCommand(SQL_PRIDANI_MISTNOSTI, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@kapacita_mistnosti", m.kapacita_mistnosti);
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

        //3.2 Uprava stavajici mistnosti
        public static void upravaMistnosti(Mistnost m)
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
                    command = new SqlCommand(SQL_UPRAVA_MISTNOSTI, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_mistnosti", m.id_mistnosti);
                    command.Parameters.AddWithValue("@kapacita_mistnosti", m.kapacita_mistnosti);
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

        //3.3 Smazani mistnosti
        public static void smazaniMistnosti(Mistnost m)
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
                    command = new SqlCommand(SQL_SMAZANI_MISTNOSTI, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_mistnosti", m.id_mistnosti);
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

        //3.4 Seznam mistnosti
        public static List<Mistnost> seznamMistnosti()
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
                    command = new SqlCommand(SQL_SEZNAM_MISTNOSTI, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Mistnost> list = new List<Mistnost>();
                    while (reader.Read())
                    {
                        Mistnost m = new Mistnost();
                        m.id_mistnosti = Int32.Parse(reader[0].ToString());
                        m.kapacita_mistnosti = Int32.Parse(reader[1].ToString());
                        list.Add(m);
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

        //Přidaná funkce kvůli formůlářům
        public static Mistnost detailMistnosti(int id)
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
                    command = new SqlCommand(SQL_DETAIL_MISTNOSTI, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_mistnosti", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Mistnost m = new Mistnost();
                    while (reader.Read())
                    {
                        m.id_mistnosti = Int32.Parse(reader[0].ToString());
                        m.kapacita_mistnosti = Int32.Parse(reader[1].ToString());
                    }
                    reader.Close();
                    transaction.Commit();
                    return m;
                }
                catch (SqlException sqlError)
                {
                    Console.WriteLine(sqlError);
                    transaction.Rollback();
                    return null;
                }
            }
        }
    }
}
