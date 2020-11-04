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

        public ObservableCollection<Score> Scores { get; set; }
        public List<Score> scores = new List<Score>();
        private ScoreAccess sa = new ScoreAccess();

        public ViewAllScores()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ScoreSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            scores.Clear();
            (this.Content as FrameworkElement).DataContext = null;

            ComboBoxItem item = (ComboBoxItem)ScoreSelection.SelectedValue;
            MainWindow.scoresView = item.Content.ToString();

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

            Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Where(a => a.Username.Equals(Login.userName)));
            (this.Content as FrameworkElement).DataContext = this;

        }

    }

}
