using orm_implementace.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class Druh_treninkuGW
    {
        public static string SQL_PRIDANI_TRENINKU = "INSERT INTO \"Druhy_treninku\" VALUES((SELECT MAX(id_treninku) + 1 FROM \"Druhy_treninku\"), @druh_treninku)";
        public static string SQL_ODEBRANI_TRENINKU = "DELETE FROM \"Trenerova_specializace\" WHERE id_treninku=@id_treninku\n" +
            "UPDATE \"Lekce\" SET id_treninku=0 WHERE id_treninku=@id_treninku\nDELETE FROM \"Druhy_treninku\" WHERE id_treninku=@id_treninku";
        public static string SQL_SEZNAM_TRENINKU = "SELECT id_treninku, druh_treninku FROM \"Druhy_treninku\" WHERE id_treninku != 0";
        public static string SQL_DETAIL_DRUHU_TRENINKU = "SELECT id_treninku, druh_treninku FROM \"Druhy_treninku\" WHERE id_treninku = @id_treninku";

        //6.1 Přidání nového tréninku
        public static void pridaniTreninku(Druh_treninku dt)
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
                    command = new SqlCommand(SQL_PRIDANI_TRENINKU, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@druh_treninku", dt.druh_treninku);
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

        //6.2 Odebrani treninku
        public static void odebraniTreninku(Druh_treninku dt)
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
                    command = new SqlCommand(SQL_ODEBRANI_TRENINKU, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_treninku", dt.id_treninku);
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


        //6.3 Seznam druhu treninku
        public static List<Druh_treninku> seznamDruhuTreninku()
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
                    command = new SqlCommand(SQL_SEZNAM_TRENINKU, sqlConnection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Druh_treninku> list = new List<Druh_treninku>();
                    while (reader.Read())
                    {
                        Druh_treninku dt = new Druh_treninku();
                        dt.id_treninku = Int32.Parse(reader[0].ToString());
                        dt.druh_treninku = reader[1].ToString();
                        list.Add(dt);
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
        public static string detailDruhuTreninku(int id)
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
                    command = new SqlCommand(SQL_DETAIL_DRUHU_TRENINKU, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@id_treninku", id);
                    SqlDataReader reader = command.ExecuteReader();
                    string result = null;
                    while (reader.Read())
                    {
                        result = reader[1].ToString();
                    }
                    reader.Close();
                    transaction.Commit();
                    return result;
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
