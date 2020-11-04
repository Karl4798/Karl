using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Dewey_Training.CustomDialogs;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class Register : Page
    {

        // MessageBox variable
        CustomMessageBox MessageBox;

        public Register()
        {
            InitializeComponent();
        }

        // Method used to handle register button press event
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            // Color variables used for validation
            Brush red = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ca3e47"));
            Brush white = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));

            // Variable used to hold access to scores in the database
            UserAccess ua = new UserAccess();

            // Sets user information from user input
            string userName = username.Text;
            string pass = password.Password;
            string confirmPass = confirmPassword.Password;
            bool validation = true;

            // Resets the text colors for validation
            username.Foreground = white;
            password.Foreground = white;
            confirmPassword.Foreground = white;

            // Validation for input
            if (userName.Equals(""))
            {
                username.Foreground = red;
                MessageBox = new CustomMessageBox("Username cannot be empty!", "Error");
                MessageBox.Show();
                validation = false;
            }
            if (pass.Equals("") || pass.Length < 6)
            {
                password.Foreground = red;
                MessageBox = new CustomMessageBox("Password cannot be empty!", "Error");
                MessageBox.Show();
                validation = false;
            }
            if (confirmPass.Equals("") || !pass.Equals(confirmPass))
            {
                confirmPassword.Foreground = red;
                MessageBox = new CustomMessageBox("Passwords do not match!", "Error");
                MessageBox.Show();
                validation = false;
            }

            // Check that the username is not in use by another user
            if (!ua.CheckUsernameInUse(userName) && validation)
            {

                // Get a new user ID from the database
                int id = ua.GetNewUserId();

                // Create a new User object, including id, username, and password
                User user = new User()
                {
                    Id = id,
                    Username = userName,
                    Password = pass
                };

                // Save the user to the database
                if (ua.CreateUser(user))
                {

                    // Confirmation message
                    MessageBox = new CustomMessageBox("The account has been created successfully.", "Account Created");
                    MessageBox.Show();

                    // Navigate to the Login page
                    this.NavigationService.Navigate(new Login());

                }

                // If the user account cannot be created, display an error message
                else
                {

                    // Error message
                    MessageBox = new CustomMessageBox("The account cannot be created.", "Error");
                    MessageBox.Show();

                }

            }

            // If the username is in use, then display an error message
            else if (ua.CheckUsernameInUse(userName))
            {

                // Form validation
                username.Foreground = red;
                MessageBox = new CustomMessageBox("Entered username is in use!\nPlease choose a different username.", "Error");
                MessageBox.Show();

            }

        }

        // Method to handle back button click event
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Login page
            this.NavigationService.Navigate(new Login());

        }

    }

}
