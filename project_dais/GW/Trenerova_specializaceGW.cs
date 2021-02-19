using orm_implementace.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class Trenerova_specializaceGW
    {
        public static string SQL_PRIDANI_SPECIALIZACE = "INSERT INTO \"Trenerova_specializace\" VALUES(@id_trenera, @id_treninku)";
        public static string SQL_ODEBRANI_SPECIALIZACE = "DELETE FROM \"Trenerova_specializace\" WHERE id_treninku=@id_treninku AND id_trenera = @id_trenera";
        public static string SQL_SEZNAM_SPECIALIZACI = "SELECT id_treninku, id_trenera FROM \"Trenerova_specializace\"";

        //7.1 Přidání nové specializace
        public static void pridaniSpecializace(Trenerova_specializace ts)
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
                    command = new SqlCommand(SQL_PRIDANI_SPECIALIZACE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_treninku", ts.id_treninku);
                    command.Parameters.AddWithValue("@id_trenera", ts.id_trenera);
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

        //7.2 Odebrani specializace
        public static void odebraniSpecializace(Trenerova_specializace ts)
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
                    command = new SqlCommand(SQL_ODEBRANI_SPECIALIZACE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_treninku", ts.id_treninku);
                    command.Parameters.AddWithValue("@id_trenera", ts.id_trenera);
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

        //7.3 Seznam specializaci
        public static List<Trenerova_specializace> seznamSpecializaci()
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
                    command = new SqlCommand(SQL_SEZNAM_SPECIALIZACI, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Trenerova_specializace> list = new List<Trenerova_specializace>();
                    while (reader.Read())
                    {
                        Trenerova_specializace ts = new Trenerova_specializace();
                        ts.id_treninku = Int32.Parse(reader[0].ToString());
                        ts.id_trenera = Int32.Parse(reader[1].ToString());
                        list.Add(ts);
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
    }
}
