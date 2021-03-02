using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public class DataReader
    {
        static string connectionString;
        static DataReader()
        {
            connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_Connection = True;MultipleActiveResultSets=True";
        }
        public static DataTable ExecuteReader(string query)
        {
            DataTable dataTable = null;

            if (!string.IsNullOrWhiteSpace(query))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        SqlDataReader dataReader = command.ExecuteReader();
                        dataTable = new DataTable();
                        dataTable.Load(dataReader);
                    }
                }
            }
            return dataTable;
        }


        public static void ExecuteNonQuery(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
