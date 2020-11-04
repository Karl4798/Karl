using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Dewey_Training.CustomDialogs;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ReorderComplete : Page
    {

        // Variables used to store access objects to Data Access Layer (DAL)
        ScoreAccess sa = new ScoreAccess();
        UserAccess ua = new UserAccess();

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Variable used to store user object
        private static User user;

        // Variable used to store correct order of the dewey decimals
        List<string> correctOrder;


        // Constructor
        public ReorderComplete(string timeDuration, List<string> correctOrder)
        {

            InitializeComponent();

            // Sets the global (class) variable equal to the passed in value
            this.correctOrder = correctOrder;

            // If the time duration is not null, then the books have been ordered successfully,
            // and there is a valid time duration available
            if (timeDuration != null)
            {

                // Sets display labels
                finished.Content = "The Books Have Been Successfully Ordered!";
                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";

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
                        MessageBox = new CustomMessageBox("The score cannot be saved!", "Error");
                        MessageBox.Show();

                    }

                }

            }

            // If the time duration is null, then display an appropriate message
            else
            {

                // Sets display labels
                finished.Content = "The Books Have Not Been Successfully Ordered!";
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
            if (sa.CreateReplaceScore(score))
            {
                return true;
            }

            // If the score cannot be saved successfully to the database, return false
            return false;

        }

        // Handles the "Finish" button click
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the main menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        // Handles the "View Order" button click
        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the "View Correct Order" page
            this.NavigationService.Navigate(new ViewCorrectOrder(correctOrder));

        }

    }

}
