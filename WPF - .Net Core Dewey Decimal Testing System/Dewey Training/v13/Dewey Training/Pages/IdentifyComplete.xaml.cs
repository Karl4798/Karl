using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class IdentifyComplete : Page
    {

        ObservableCollection<string> Questions = new ObservableCollection<string>();
        ObservableCollection<string> Answers = new ObservableCollection<string>();
        List<string> correctAnswers;
        bool orderCorrect;
        string timeDuration;

        // Variables used to store access objects to Data Access Layer (DAL)
        ScoreAccess sa = new ScoreAccess();
        UserAccess ua = new UserAccess();

        // Variable used to store user object
        private static User user;

        public IdentifyComplete(bool orderCorrect, string timeDuration,
            ObservableCollection<string> Questions,
            ObservableCollection<string> Answers,
            List<string> correctAnswers, bool ShouldSaveScore)
        {
            InitializeComponent();

            this.Questions = Questions;
            this.Answers = Answers;
            this.orderCorrect = orderCorrect;
            this.timeDuration = timeDuration;
            this.correctAnswers = correctAnswers;

            if (orderCorrect)
            {
                finished.Content = "The Books Are in Their Correct Categories!";
                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";

                if (ShouldSaveScore)
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
                        if (!SaveRecord(user.Username, time))
                        {

                            // Error message if the score cannot be saved
                            MessageBox.Show("The score cannot be saved!", "Error");

                        }

                    }

                }

            }
            else
            {
                finished.Content = "The Books Are Not in Their Correct Categories!";
                timeTaken.Content = null;
            }

        }

        // Method used to save a score to the database for a particular user
        private bool SaveRecord(String username, string time)
        {

            // Fetches the current date / time
            DateTime now = DateTime.Now;

            // Creates a new Score object, which includes username, score, and date / time of the save
            Score score = new Score()
            {
                Username = username,
                UserScore = time,
                DateTime = now
            };

            // Save the score object in the database, and return true
            if (sa.CreateAreasScore(score))
            {
                return true;
            }

            // If the score cannot be saved successfully to the database, return false
            return false;

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new ViewCorrectAreas(Questions, Answers, orderCorrect, timeDuration, correctAnswers));

        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a new IdentifyAreas question
            this.NavigationService.Navigate(new IdentifyAreas(false));

        }
    }
}
