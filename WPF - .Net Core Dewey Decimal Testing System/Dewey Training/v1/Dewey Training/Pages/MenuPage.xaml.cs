using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        public ObservableCollection<Score> Scores { get; set; }
        public List<Score> scores = new List<Score>();
        private ScoreAccess sa = new ScoreAccess();

        public MenuPage()
        {

            InitializeComponent();

            foreach (var score in sa.ReadScores())
            {
                scores.Add(new Score()
                {
                    Username = score.Username,
                    UserScore = score.UserScore,
                    DateTime = score.DateTime
                });
            }

            Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Take(10));

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void ReplaceBooks_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Replace Books page
            this.NavigationService.Navigate(new ReplaceBooks());


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Login page
            this.NavigationService.Navigate(new Login());

        }

        private void IdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
