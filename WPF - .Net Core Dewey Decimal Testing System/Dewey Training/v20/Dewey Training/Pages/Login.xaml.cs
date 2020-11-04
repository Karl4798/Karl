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
    public partial class Login : Page
    {

        // Variables used to hold user details
        public static string userName = null;
        public static bool loggedIn = false;

        // Variable used to store access object to Data Access Layer (DAL)
        UserAccess ua = new UserAccess();

        // Reference for the Main Window, used to set user label
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Constructor
        public Login()
        {

            InitializeComponent();

        }

        // Method used to handle login button click event
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            // Gets user input
            userName = username.Text;
            string pass = password.Password;

            // Create a new User object based on passed in values (username and password)
            User user = new User()
            {
                Username = userName,
                Password = pass
            };

            // Validation
            if (user.Username != "" && user.Password != "")
            {

                // Validate user
                if (ua.ValidateUser(user))
                {

                    // Sets logged in user information on the main window label
                    mainWindow.SetLabels(null);

                    // Used to set main menu page elements based on logged in status
                    loggedIn = true;

                    // Set visibility of view all scores buttton to visible
                    MainWindow.viewAllScoresVisible = true;

                    // Navigate the user to the menu page
                    this.NavigationService.Navigate(new MenuPage());

                }

                // If the user does not exist in the database, then show an error
                else
                {

                    // Show an error message
                    MessageBox = new CustomMessageBox("Incorrect login details!", "Error");
                    MessageBox.Show();

                }
            }

            // If the validation was not passed, then display a generic error
            else
            {

                // Show an error message
                MessageBox = new CustomMessageBox("Incorrect login details!", "Error");
                MessageBox.Show();

            }

        }

        // Method used to handle register button click event
        private void Register_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the register page
            this.NavigationService.Navigate(new Register());

        }

        // Method used to handle back button click event
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }
    }

}
