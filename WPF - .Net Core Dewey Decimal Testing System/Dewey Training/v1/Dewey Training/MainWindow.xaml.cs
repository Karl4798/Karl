using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dewey_Training.Pages;
using Dewey_Training_DAL;

namespace Dewey_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Delegate used to invoke window state method
        public delegate void initializeDelegate();

        // Database helper object
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public MainWindow()
        {
            InitializeComponent();

            // Read all data
            if (!databaseHelper.ConnectDatabase())
            {
                MessageBox.Show("Database Cannot Be Reached!", "Error");
                Close();
            }

            // Creating a delegate object
            initializeDelegate setWindowState = new initializeDelegate(InitializeWindowState);
            // Running window state method
            setWindowState();

        }

        public void InitializeWindowState()
        {

            // Sets default startup location
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Disables ability for users to return to previous frame (page) using shortcut keys - security
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
            this.DragMove();
        }
    }
}
