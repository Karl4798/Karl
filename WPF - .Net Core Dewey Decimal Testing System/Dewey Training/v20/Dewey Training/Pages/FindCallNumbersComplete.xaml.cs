using Dewey_Training.CustomDialogs;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class FindCallNumbersComplete : Page
    {

        // Values used to store answers and user selected answers
        bool? answersCorrect;
        string timeDuration;
        string answer;
        int? noOfCorrectLevels;

        // Variables used to store access objects to Data Access Layer (DAL)
        ScoreAccess sa = new ScoreAccess();
        UserAccess ua = new UserAccess();

        // Variable used to store user object
        private static User user;

        // MessageBox variable
        CustomMessageBox MessageBox;

        public FindCallNumbersComplete(bool? answersCorrect,
            string timeDuration,
            string answer,
            int? noOfCorrectLevels,
            bool shouldSave)
        {

            InitializeComponent();

            // Assigns class variable to that of passed boolean value
            this.answersCorrect = answersCorrect;
            this.timeDuration = timeDuration;
            this.answer = answer;
            this.noOfCorrectLevels = noOfCorrectLevels;

            // If all answers were correct, then display a successful message
            if (this.answersCorrect == true)
            {

                // Message prompt
                finished.Content = "The Correct Call Number Has Been Found!";

            }

            // If not all answers were correct, then display an unsuccessful message
            else if (this.answersCorrect == false)
            {

                // Message prompt
                finished.Content = "The Correct Call Number Has Not Been Found!";

            }
            else
            {

                // Message prompt
                finished.Content = "Incorrect Selection, Please Continue to the Next Question.";

            }

            // Display the time taken to complete the test
            if (timeDuration != null)
            {

                // Sets the timeTaken label
                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";

            }
            else
            {

                // Sets the timeTaken label
                timeTaken.Content = null;

            }

            // Displays the number of correct answers via a label
            if (noOfCorrectLevels != null)
            {

                // Sets the label content
                noOfCorrectAnswers.Content = "Number of Correctly Identified Levels: " + noOfCorrectLevels + " / 3";

            }
            else
            {

                // Sets the label content
                noOfCorrectAnswers.Content = null;

            }

            // If the score should be saved to the database, then save the value, else do not
            if (shouldSave)
            {

                // Reads the user info from the unique username
                user = ua.ReadUser(Login.userName);

                // Gets the time duration from the passed in value
                string time = timeDuration;

                // If the user object is not null (they are logged in),
                // then save the score for the user
                if (user != null)
                {

                    // Saves the score for the user, and if it cannot, it will show an error message
                    if (!SaveRecord(user.Username, noOfCorrectLevels.ToString(), time))
                    {

                        // Error message if the score cannot be saved
                        MessageBox = new CustomMessageBox("The score cannot be saved!", "Error");
                        MessageBox.Show();

                    }

                }

            }

        }

        // Method used to save a score to the database for a particular user
        private bool SaveRecord(string username, string noOfCorrectAnswers, string time)
        {

            // Fetches the current date / time
            DateTime now = DateTime.Now;

            // Creates a new Score object, which includes username, score, and date / time of the save
            Score score = new Score()
            {
                Username = username,
                UserTime = time,
                UserScore = noOfCorrectAnswers,
                DateTime = now
            };

            // Save the score object in the database, and return true
            if (sa.CreateFindCallNumberScore(score))
            {
                return true;
            }

            // If the score cannot be saved successfully to the database, return false
            return false;

        }

        // Finish button click event handler
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a the main menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the model answer page
            this.NavigationService.Navigate(new ViewCorrectCallNumbers(answer, answersCorrect, timeDuration, noOfCorrectLevels));

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            // Navigate the user to a new Find Call Numbers question
            this.NavigationService.Navigate(new FindCallNumbers());
        }

    }

}
