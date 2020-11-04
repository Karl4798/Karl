using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dewey_Training_DAL.Models;
using static Dewey_Training_DAL.DatabaseHelper;

namespace Dewey_Training_DAL
{
    public class ScoreAccess
    {

        // Creates the score in the database
        public bool CreateScore(Score score)
        {

            // Try Catch used to determine if insert was successful
            try
            {

                // SQL Command
                string sql = $"INSERT INTO Scores(Username, UserScore, DateTime)" +
                             $"VALUES('{score.Username}', '{score.UserScore}', '{score.DateTime}')";

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

        // Gets the scores for the passed username
        public List<Score> ReadScores()
        {

            // SQL Command
            string sql = "SELECT * FROM Scores;";

            // Variables used to store scores
            List<Score> scores = new List<Score>();

            // SQL Command used to read all score information
            SqlCommand command = new SqlCommand(sql, cn);
            SqlDataReader reader = command.ExecuteReader();

            // If scores are found in the database, read them and store them in the score list
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    scores.Add(new Score()
                    {
                        Username = reader.GetString(0),
                        UserScore = reader.GetString(1),
                        DateTime = reader.GetDateTime(2)
                    });
                }

            }

            // Closes the reader
            reader.Close();

            // Returns a list of scores
            return scores;

        }

        // Gets the ID for the passed username and password combination
        public int? GetNewUserId()
        {

            // SQL Command
            string sql = "SELECT MAX(Id) FROM User;";

            // Variables used to store ids
            int? userId = null;

            // SQL Command to return user id
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {

                try
                {
                    // Set user id
                    userId = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    // Only used when parsing returned value
                }

            }

            if (userId != null)
            {
                return userId + 1;
            }

            return null;

        }

    }
}
