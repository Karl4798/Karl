﻿using Dewey_Training.CustomDialogs;
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

        // Observable lists used to store elements for visual display
        ObservableCollection<string> Questions = new ObservableCollection<string>();
        ObservableCollection<string> Answers = new ObservableCollection<string>();

        // List used to store correct answers
        List<string> correctAnswers;

        // Boolean value used to determine if all questions were correctly answered
        int? orderCorrect;

        // Variable used to hold time duration of the test
        string timeDuration;

        // Variables used to store access objects to Data Access Layer (DAL)
        ScoreAccess sa = new ScoreAccess();
        UserAccess ua = new UserAccess();

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Variable used to store user object
        private static User user;

        // Constructor
        public IdentifyComplete(int? orderCorrect, string timeDuration,
            ObservableCollection<string> Questions,
            ObservableCollection<string> Answers,
            List<string> correctAnswers, bool ShouldSaveScore)
        {
            InitializeComponent();

            // Sets global variables equal to the passed in values (parameters)
            this.Questions = Questions;
            this.Answers = Answers;
            this.orderCorrect = orderCorrect;
            this.timeDuration = timeDuration;
            this.correctAnswers = correctAnswers;

            // Set the time label to the value passed in as a parameter
            timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";

            // If the order is correct then run the following logic
            if (orderCorrect == 4)
            {

                // Set the label text
                finished.Content = "The Books Are in Their Correct Categories!";

            }

            // If the order is not correct, run the following logic
            else if (orderCorrect != 4)
            {

                // Set the label text
                finished.Content = "The Books Are Not in Their Correct Categories!";

            }

            // Displays the number of correct answers via a label
            if (orderCorrect != null)
            {

                // Sets the label content
                noOfCorrectAnswers.Content = "Number of Correct Answers: " + orderCorrect + " / 4";

            }
            else
            {

                // Sets the label content
                noOfCorrectAnswers.Content = null;

            }

            // If the score should be saved to the database, then save the value, else do not
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

                    // If the number of correct answers is greater than 0 (null), then save the score
                    if (orderCorrect != null)
                    {

                        // Saves the score for the user, and if it cannot, it will show an error message
                        if (!SaveRecord(user.Username, orderCorrect.ToString(), time))
                        {

                            // Error message if the score cannot be saved
                            MessageBox = new CustomMessageBox("The score cannot be saved!", "Error");
                            MessageBox.Show();

                        }

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