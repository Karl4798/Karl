using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ViewAllScores : Page
    {

        // Observable used to display rows on data grids
        public ObservableCollection<Score> Scores { get; set; }

        // List used to store score objects
        public List<Score> scores = new List<Score>();

        // Variable used to store access object to Data Access Layer (DAL)
        private ScoreAccess sa = new ScoreAccess();

        // Constructor
        public ViewAllScores()
        {
            InitializeComponent();
        }

        // Method used to handle the return button press event
        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        // Sets the scores based on test type - e.g. replace books, identify areas, etc
        private void ScoreSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Resets the data grid and scores list
            scores.Clear();
            (this.Content as FrameworkElement).DataContext = null;

            // Gets the selected item from the combo box
            ComboBoxItem item = (ComboBoxItem)ScoreSelection.SelectedValue;

            // Inserts scores for the correct type of test
            if (ScoreSelection.SelectedIndex == 0)
            {

                userTime.Visibility = Visibility.Hidden;
                userScore.Header = "Score / Time (s)";

                foreach (var score in sa.ReadReplaceScores())
                {
                    scores.Add(new Score()
                    {
                        Username = score.Username,
                        UserScore = score.UserScore,
                        DateTime = score.DateTime
                    });
                }

                username.Width = 260;
                userScore.Width = 260;

            }

            // Inserts scores for the correct type of test
            if (ScoreSelection.SelectedIndex == 1)
            {

                userTime.Visibility = Visibility.Visible;
                userScore.Header = "Score (/4)";

                foreach (var score in sa.ReadAreasScores())
                {

                    scores.Add(new Score()
                    {
                        Username = score.Username,
                        UserTime = score.UserTime,
                        UserScore = score.UserScore,
                        DateTime = score.DateTime
                    });

                }

                username.Width = 150;
                userScore.Width = 175;
                userTime.Width = 175;

            }

            // Inserts scores for the correct type of test
            if (ScoreSelection.SelectedIndex == 2)
            {

                userTime.Visibility = Visibility.Visible;
                userScore.Header = "Score (/3)";

                foreach (var score in sa.ReadFindCallNumberScores())
                {

                    scores.Add(new Score()
                    {
                        Username = score.Username,
                        UserTime = score.UserTime,
                        UserScore = score.UserScore,
                        DateTime = score.DateTime
                    });

                }

                username.Width = 150;
                userScore.Width = 175;
                userTime.Width = 175;

            }

            // Sets the scores ObservableCollection for visual output
            if (ScoreSelection.SelectedIndex == 0)
            {

                Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Where(a => a.Username.Equals(Login.userName)));

            }
            else
            {

                Scores = new ObservableCollection<Score>(scores.OrderByDescending(a => a.UserScore).ThenBy(a => a.UserTime)
                    .Where(a => a.Username.Equals(Login.userName)));

            }

            // Sets XAML front end context
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Default implementations kept for future use
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
