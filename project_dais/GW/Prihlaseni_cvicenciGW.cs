using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace orm_implementace.Tables
{
    class Prihlaseni_cvicenciGW
    {
        public static string SQL_PRIHLASENI_NA_LEKCI = "zapisCvicence";
        public static string SQL_ODHLASENI_Z_LEKCE = "DELETE FROM \"Prihlaseni_cvicenci\" WHERE id_lekce=@idlekce AND id_cvicence=@idCvicence";
        public static string SQL_SEZNAM_PRIHLASENYCH_NA_LEKCI = "SELECT pc.id_cvicence FROM Prihlaseni_cvicenci pc WHERE pc.id_lekce=@idLekce";

        //2.1 Přihlášení cvičence na lekci
        public static int zapisCvicence(Cvicenec c, int id_lekce)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {
                int result = 0;
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(SQL_PRIHLASENI_NA_LEKCI, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCvicence", SqlDbType.Int).Value = c.id_cvicence;
                command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
                command.Parameters.AddWithValue("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                result = Convert.ToInt32(command.Parameters["@output"].Value);
                sqlConnection.Close();
                return result;
            }
        }

        //2.2 Odhlášení cvičence z lekce
        public static void odhlasCvicence(Cvicenec c, int id_lekce)
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
                    command = new SqlCommand(SQL_ODHLASENI_Z_LEKCE, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@idCvicence", SqlDbType.Int).Value = c.id_cvicence;
                    command.Parameters.AddWithValue("@idLekce", SqlDbType.Int).Value = id_lekce;
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

        //2.3 Seznam přihlášených cvičenců na lekci
        public static List<int> seznamPrihlasenychCvicencu(int id_lekce)
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
                    command = new SqlCommand(SQL_SEZNAM_PRIHLASENYCH_NA_LEKCI, sqlConnection, transaction);
                    command.Parameters.AddWithValue("@idLekce", id_lekce);
                    SqlDataReader reader = command.ExecuteReader();
                    List<int> list = new List<int>();

                    while (reader.Read())
                    {
                        int id_cvicence = Int32.Parse(reader[0].ToString());
                        list.Add(id_cvicence);
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
