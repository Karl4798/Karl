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
    /// Interaction logic for ViewAllScores.xaml
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

            // Sets score list based on selected score view
            if (ScoreSelection.SelectedIndex == 0)
            {

                // Adds all the Replace Scores to the list
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

            if (ScoreSelection.SelectedIndex == 1)
            {

                // Adds all the Areas Scores to the list
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

            // Sets the scores ObservableCollection for visual output
            Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Where(a => a.Username.Equals(Login.userName)));

            // Sets XAML front end context
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Default implementations kept for future use
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
