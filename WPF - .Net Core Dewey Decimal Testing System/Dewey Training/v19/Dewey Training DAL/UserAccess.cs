using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dewey_Training_DAL.Models;
using static Dewey_Training_DAL.DatabaseHelper;

namespace Dewey_Training_DAL
{
    public class UserAccess
    {

        // Creates the user in the database
        public bool CreateUser(User user)
        {

            // Try Catch used to determine if insert was successful
            try
            {
                // SQL Command
                string sql = $"INSERT INTO [User](Id, Username, Password)" +
                             $"VALUES('{user.Id}', '{user.Username}', '{user.Password}')";

                // Runs command to insert user record into the database
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();

                // If inserted correctly, then return true
                return true;
            }
            catch (Exception)
            {
                // If the record was not inserted correctly, then return false
                return false;
            }

        }

        // Checks if the username is currently in use by another user
        public bool CheckUsernameInUse(string username)
        {

            // SQL Command
            string sql = "SELECT COUNT(*) FROM [User] WHERE Username=@username";
            int users;

            // Runs SQL command
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                users = (int)cmd.ExecuteScalar();
            }

            // If the username is used by any user in the system, then return true
            if (users > 0)
            {
                return true;
            }

            // If there are no users using the username, then return false
            return false;

        }

        // Gets the user object for the passed Id
        public User ReadUser(int Id)
        {

            // SQL Command
            string sql = "SELECT * FROM [User] WHERE Id=@id;";

            // Variables used to store ids
            User user = null;

            // SQL Command to return user
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {

                // SQL Parameters
                cmd.Parameters.AddWithValue("@id", Id);
                try
                {
                    // Set user
                    user = (User)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    // Only used when parsing returned value
                }

            }

            if (user != null)
            {
                return user;
            }

            return null;

        }

        // Gets the user object for the passed Id
        public User ReadUser(String username)
        {

            if (username != null)
            {

                // SQL Command
                string sql = "SELECT Id, Username, Password FROM [User] WHERE Username=@username";

                // SQL command retrieves all user information from the database
                SqlCommand command = new SqlCommand(sql, cn);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                // List to hold all user information
                List<User> users = new List<User>();

                // If there are user records, then read this information into the users list
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                        });
                    }

                }

                // Closes the reader
                reader.Close();

                // Returns user
                return users[0];

            }

            return null;

        }

        // Gets the user object for the passed Id
        public bool ValidateUser(User user)
        {

            // SQL Command
            string sql = "SELECT COUNT(*) FROM [User] WHERE Username=@username AND Password=@password;";

            // Runs SQL command
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {

                // SQL Parameters
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);

                if ((int)cmd.ExecuteScalar() > 0)
                {

                    return true;

                }

            }

            return false;

        }

        // Gets the ID for the passed username and password combination
        public int GetNewUserId()
        {

            // SQL Command
            string sql = "SELECT MAX(Id) FROM [User];";

            // Variables used to store ids
            int id;

            // SQL Command to return user id
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {

                try
                {
                    // Set user id
                    id = (int)cmd.ExecuteScalar();

                    return id + 1;

                }
                catch (Exception ex)
                {
                    return 0;
                }

            }

        }

    }
}
