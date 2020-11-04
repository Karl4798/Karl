using System;
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

        public Complete(string timeDuration)
        {

            InitializeComponent();
            timeTaken.Content = "Time Taken: " + timeDuration;

            user = ua.ReadUser(Login.userName);

            timeDuration.Remove(0, 6);

            string time = timeDuration;

            if (user != null)
            {

                if (!SaveRecord(user.Username, time))
                {

                    MessageBox.Show("The score cannot be saved!", "Error");

                }

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
    }
}
