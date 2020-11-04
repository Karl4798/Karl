using System;
using System.Data.SqlClient;

namespace Dewey_Training_DAL
{

    // Class used to connect and disconnect from the database
    public class DatabaseHelper
    {
        // New SQL Connection
        public static SqlConnection cn = new SqlConnection();

        // Establish connection to the database
        public bool ConnectDatabase()
        {

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
