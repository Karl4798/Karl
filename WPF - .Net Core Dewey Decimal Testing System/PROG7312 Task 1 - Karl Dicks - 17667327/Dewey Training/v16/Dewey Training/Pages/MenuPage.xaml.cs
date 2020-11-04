using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class MenuPage : Page
    {

        // Observable list used to store elements for visual display
        public ObservableCollection<Score> Scores { get; set; }

        // List used to store score objects
        public List<Score> scores = new List<Score>();

        // Variable used to store access object to Data Access Layer (DAL)
        private ScoreAccess sa = new ScoreAccess();

        // Variables used to store difficulty and score view preferences
        private string difficulty;
        private string scoresView;


        // Used to get the instance of the main window - in order to set labels.
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        // Constructor
        public MenuPage()
        {

            // If the difficulty is not null, then set the value to the global variable
            if (MainWindow.difficulty != null)
            {

                // Sets the difficulty preference
                difficulty = MainWindow.difficulty;

            }

            // If the score view is not null, then set the value to the global variable
            if (MainWindow.scoresView != null)
            {

                // Sets the score view preference
                scoresView = MainWindow.scoresView;

            }

            InitializeComponent();

            // Sets the visual elements based on if the user is logged in or out
            SetMenuItems();

            // Sets accessibility to view all scores based on login
            if (MainWindow.viewAllScoresVisible)
            {

                // Sets the view all scores button to visible
                ViewAllScores.Visibility = Visibility.Visible;

            }

            // Sets accessibility to view all scores based on login
            if (MainWindow.viewAllScoresVisible == false)
            {

                // Sets the view all scores button to hidden
                ViewAllScores.Visibility = Visibility.Hidden;

            }

            // Sets the difficulty level from preference
            if (difficulty != null)
            {

                if (difficulty.Equals("Easy"))
                {
                    Difficulty.SelectedIndex = 0;
                }
                if (difficulty.Equals("Medium"))
                {
                    Difficulty.SelectedIndex = 1;
                }
                if (difficulty.Equals("Hard"))
                {
                    Difficulty.SelectedIndex = 2;
                }

            }

            // Sets the score view from preference
            if (scoresView != null)
            {

                if (scoresView.Equals("Replace Books"))
                {
                    ScoreSelection.SelectedIndex = 0;
                }
                if (scoresView.Equals("Identify Areas"))
                {
                    ScoreSelection.SelectedIndex = 1;
                }
                if (scoresView.Equals("Find Call Numbers"))
                {
                    ScoreSelection.SelectedIndex = 2;
                }

            }

            // Sets background of top three scores to gold, silver, and bronze
            dataGrid.ItemContainerGenerator.StatusChanged += (s, e) =>
            {
                if (dataGrid.ItemContainerGenerator.Status ==
                                    GeneratorStatus.ContainersGenerated)
                {

                    if (dataGrid.Items.Count >= 3)
                    {

                        for (int i = 0; i < 3; i++)
                        {

                            var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                             .ContainerFromIndex(i);

                            if (i == 0)
                            {
                                row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#dbc54f"));
                            }
                            else if (i == 1)
                            {
                                row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c4c4c4"));
                            }
                            else
                            {
                                row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e67a45"));
                            }

                        }

                    }

                }

            };

        }

        // Sets the login button to either log the user out (if they are already logged in),
        // or to login, if the user is not logged in already
        private void SetMenuItems()
        {

            if (Login.loggedIn)
            {
                LoginBtn.Content = "Logout";
            }
            else
            {
                LoginBtn.Content = "Login";
            }

        }

        // Handles the replace books button click event
        private void ReplaceBooks_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Replace Books page
            this.NavigationService.Navigate(new ReplaceBooks());


        }

        // Handles the login button click event
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            // Logs the user out
            if (Login.loggedIn)
            {

                // Sets logged in user information on the main window.
                Login.userName = null;
                LoginBtn.Content = "Login";
                Login.loggedIn = false;
                mainWindow.SetLabels(true);
                mainWindow.SetLabels(null);

                // Sets visual elements based on login status
                MainWindow.viewAllScoresVisible = false;
                ViewAllScores.Visibility = Visibility.Hidden;

            }

            // Navigates the user to the login page
            else
            {

                // Navigate the user to the Login page
                this.NavigationService.Navigate(new Login());

            }

        }

        // Handles the identifying areas button click event
        private void IdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Identify Areas page
            this.NavigationService.Navigate(new IdentifyAreas(true));

        }

        // Handles the difficulty selection changed combo box
        private void Difficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Gets the combo box element
            ComboBoxItem item = (ComboBoxItem)Difficulty.SelectedValue;
            MainWindow.difficulty = item.Content.ToString();

        }

        // Handles the score selection changed event
        private void ScoreSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Clears all scores and resets the data context
            scores.Clear();
            (this.Content as FrameworkElement).DataContext = null;

            // Obtains the new selected item value
            ComboBoxItem item = (ComboBoxItem)ScoreSelection.SelectedValue;

            // Sets global variable
            MainWindow.scoresView = item.Content.ToString();

            // Inserts scores for the correct type of test
            if (ScoreSelection.SelectedIndex == 0)
            {

                foreach (var score in sa.ReadReplaceScores())
                {
                    scores.Add(new Score()
                    {
                        Username = score.Username,
                        UserScore = score.UserScore,
                        DateTime = score.DateTime
                    });
                }

            }

            // Inserts scores for the correct type of test
            if (ScoreSelection.SelectedIndex == 1)
            {

                foreach (var score in sa.ReadAreasScores())
                {
                    scores.Add(new Score()
                    {
                        Username = score.Username,
                        UserScore = score.UserScore,
                        DateTime = score.DateTime
                    });
                }

            }

            // Set the global (class) Scores variable for output data binding
            Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Take(10));

            // Set the data context to "this", so that the data grid values
            // are bound to Scores Observable collection
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Handles the view all scores button click event
        private void ViewAllScores_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the View All Scores page
            this.NavigationService.Navigate(new ViewAllScores());

        }

        // Default implementations kept for future use
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
