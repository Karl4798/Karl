using System;
using System.Data.SqlClient;

namespace Dewey_Training_DAL
{

    public class DatabaseHelper
    {

        // New SQL Connection
        public static SqlConnection cn = new SqlConnection();

        // Establish connection to the database
        public bool ConnectDatabase()
        {

            // Database connection
            var appConn = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            appConn += @"App_Data\DeweyDatabase.mdf";
            string connString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={appConn}; Integrated Security=True";

            // Try Catch used to determine if a connection can be established with the database
            try
            {
                // Connects to the database
                cn.ConnectionString = connString;
                cn.Open();

                // Returns true if connection was successful
                return true;
            }
            catch (Exception)
            {
                // Returns false if connection was unsuccessful
                return false;
            }

        }

        // Close database connection
        public void DisconnectDatabase()
        {

            // Closes the database connection
            cn.Close();

        }

    }

}
