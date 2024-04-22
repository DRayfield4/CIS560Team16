using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace YourNamespace
{
    public class DatabaseTest
    {
        public void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
        }
    }
}
