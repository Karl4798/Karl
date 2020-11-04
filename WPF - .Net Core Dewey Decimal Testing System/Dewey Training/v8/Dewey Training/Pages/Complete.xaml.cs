using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for Complete.xaml
    /// </summary>
    public partial class Complete : Page
    {

        ScoreAccess sa = new ScoreAccess();
        UserAccess ua = new UserAccess();
        private static User user;
        List<string> correctOrder;

        public Complete(string timeDuration, List<string> correctOrder)
        {

            InitializeComponent();

            this.correctOrder = correctOrder;

            if (timeDuration != null)
            {

                finished.Content = "The Books Have Been Successfully Ordered!";

                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";

                user = ua.ReadUser(Login.userName);

                string time = timeDuration;

                if (user != null)
                {

                    if (!SaveRecord(user.Username, time))
                    {

                        MessageBox.Show("The score cannot be saved!", "Error");

                    }

                }

            }
            else
            {

                finished.Content = "The Books Have Not Been Successfully Ordered!";
                timeTaken.Content = "";

            }

        }

        private bool SaveRecord(String username, string time)
        {

            DateTime now = DateTime.Now;

            Score score = new Score()
            {
                Username = username,
                UserScore = time,
                DateTime = now
            };

            if (sa.CreateScore(score))
            {
                return true;
            }

            return false;

        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the View Correct Order page
            this.NavigationService.Navigate(new ViewCorrectOrder(correctOrder));

        }
    }
}
