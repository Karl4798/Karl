using System.Collections.Generic;
using System.Data.SqlClient;
using static Dewey_Training_DAL.DatabaseHelper;

namespace Dewey_Training_DAL
{
    public class CategoryAccess
    {

        // Gets all top level categories
        public Dictionary<string, string> ReadCategories()
        {

            // SQL
            string sql = "SELECT * FROM Categories;";

            // Dictionary used to store Dewey Decimal categories
            Dictionary<string, string> DeweyCategories = new Dictionary<string, string>();

            // SQL Command used to read all category information
            SqlCommand command = new SqlCommand(sql, cn);
            SqlDataReader reader = command.ExecuteReader();

            // If scores are found in the database, read them and store them in the scored list
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeweyCategories.Add(reader.GetString(0), reader.GetString(1));
                }

            }

            // Closes the reader
            reader.Close();

            // Returns a list of scores
            return DeweyCategories;

        }

    }
}
