﻿using System.Windows;
using System.Windows.Controls;
using Dewey_Training.CustomDialogs;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class Login : Page
    {

        public static string userName = null;
        public static bool loggedIn = false;
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        // MessageBox variable
        CustomMessageBox MessageBox;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            UserAccess ua = new UserAccess();

            // Gets user input
            userName = username.Text;
            string pass = password.Password;

            User user = new User()
            {
                Username = userName,
                Password = pass
            };

            if (user.Username != "" && user.Password != "")
            {
                if (ua.ValidateUser(user))
                {

                    // Sets logged in user information on the main window.
                    mainWindow.SetLabels(null);

                    // Used to set main menu page elements based on logged in status
                    loggedIn = true;

                    // Set visibility of view all scores buttton to visible
                    MainWindow.viewAllScoresVisible = true;

                    // Navigate the user to the Login page
                    this.NavigationService.Navigate(new MenuPage());

                }
                else
                {
                    MessageBox = new CustomMessageBox("Incorrect login details!", "Error");
                    MessageBox.Show();
                }
            }
            else
            {

                MessageBox = new CustomMessageBox("Incorrect login details!", "Error");
                MessageBox.Show();

            }

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu page
            this.NavigationService.Navigate(new Register());

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu page
            this.NavigationService.Navigate(new MenuPage());

        }
    }
}
