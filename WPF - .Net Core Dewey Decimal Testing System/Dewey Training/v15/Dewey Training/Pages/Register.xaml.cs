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

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            // Color variable used for validation
            Brush red = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ca3e47"));
            Brush black = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));

            UserAccess ua = new UserAccess();

            // Sets user information from user input
            string userName = username.Text;
            string pass = password.Password;
            string confirmPass = confirmPassword.Password;
            bool validation = true;

            username.Foreground = black;
            password.Foreground = black;
            confirmPassword.Foreground = black;

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

                int id = ua.GetNewUserId();

                if (id == -9)
                {
                    // Confirmation message
                    MessageBox = new CustomMessageBox("Cannot create a unique id for the user.", "Error");
                    MessageBox.Show();
                }
                else
                {

                    User user = new User()
                    {
                        Id = id,
                        Username = userName,
                        Password = pass
                    };

                    if (ua.CreateUser(user))
                    {

                        // Confirmation message
                        MessageBox = new CustomMessageBox("The account has been created successfully.", "Account Created");
                        MessageBox.Show();

                        // Navigate to the Login page
                        this.NavigationService.Navigate(new Login());

                    }
                    else
                    {

                        // Error message
                        MessageBox = new CustomMessageBox("The account cannot be created.", "Error");
                        MessageBox.Show();

                    }

                }

            }
            else if (ua.CheckUsernameInUse(userName))
            {

                // Form validation
                username.Foreground = red;
                MessageBox = new CustomMessageBox("Entered username is in use!\nPlease choose a different username.", "Error");
                MessageBox.Show();

            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Login page
            this.NavigationService.Navigate(new Login());

        }
    }
}
