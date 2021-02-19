using orm_implementace;
using orm_implementace.Tables;
using project_dais.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_dais
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        public static bool prepareDB()
        {
            string SQL_PREPARE_DB = "prepareDatabase";
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ConnectionString))
            {

                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                SqlTransaction transaction;
                transaction = sqlConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                try
                {
                    command = new SqlCommand(SQL_PREPARE_DB, sqlConnection, transaction);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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

        static void Main()
        {
            prepareDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new hlavniMenu());
        }
    }
}
