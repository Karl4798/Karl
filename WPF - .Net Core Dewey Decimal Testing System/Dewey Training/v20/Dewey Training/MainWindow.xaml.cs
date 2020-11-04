using System.Windows;
using System.Windows.Input;
using Dewey_Training.CustomDialogs;
using Dewey_Training.Pages;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Delegate used to invoke window state method
        public delegate void InitializeDelegate();

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Database helper object
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // Global variables used accross the application
        public static string scoresView { get; set; }
        public static string difficulty { get; set; }
        public static bool viewAllScoresVisible { get; set; } = false;

        public MainWindow()
        {

            InitializeComponent();

            // Connect the application to the database
            // If the database cannot be connected, then display an error message
            if (!databaseHelper.ConnectDatabase())
            {
                MessageBox = new CustomMessageBox("Database Cannot Be Reached!", "Error");
                MessageBox.Show();
                Close();
            }

            // Creating a delegate object
            InitializeDelegate setWindowState = new InitializeDelegate(InitializeWindowState);

            // Running window state method
            setWindowState();

            // Reset the username label on the header
            SetLabels(null);

        }

        // Method to set labels (using binding notifications)
        public void SetLabels(bool? clear)
        {
            // If the username is not null, then set the label to User: <username>
            if (Login.userName != null)
            {
                User u = new User { Username = "User: " + Login.userName };
                this.DataContext = u;
            }

            // Else if the username is null set the label to Anonymous User
            else
            {
                User u = new User { Username = "Anonymous User" };
                this.DataContext = u;
            }

            // If the passed boolean value is true, then clear the data context (which affects bound labels)
            if (clear == true)
            {
                this.DataContext = null;
            }

        }

        // Sets the window state of the application - startup location, and
        // disables users from navigating backwards using windows hotkeys
        public void InitializeWindowState()
        {

            // Sets default startup location of the main window
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Disables ability for users to return to previous frame (page) using shortcut keys
            KeyGesture backKeyGesture = null;
            foreach (var gesture in NavigationCommands.BrowseBack.InputGestures)
            {
                KeyGesture keyGesture = gesture as KeyGesture;
                if ((keyGesture != null) &&
                    (keyGesture.Key == Key.Back) &&
                    (keyGesture.Modifiers == ModifierKeys.None))
                {
                    backKeyGesture = keyGesture;
                }
            }

            if (backKeyGesture != null)
            {
                NavigationCommands.BrowseBack.InputGestures.Remove(backKeyGesture);
            }

        }

        // Minimize button pressed
        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Minimize the window
            this.WindowState = WindowState.Minimized;
        }

        // The application will first display the menu page
        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            // Navigate the user to the Menu Page
            frame.NavigationService.Navigate(new MenuPage());
        }

        // Exit button pressed
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Close();
        }

        // Enables window dragging on the top portion of the window
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Allows the window to be dragged
            this.DragMove();
        }

        // Enables window dragging on the top portion of the window
        private void LblUsername_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Allows the window to be dragged
            this.DragMove();
        }

        // Enables window dragging on the top portion of the window
        private void LblId_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Allows the window to be dragged
            this.DragMove();
        }
    }
}
