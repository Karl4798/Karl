using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ViewCorrectAreas : Page
    {

        // Observables used to display rows on data grids
        public ObservableCollection<string> Questions { get; set; }
        public ObservableCollection<string> Answers { get; set; }
        List<string> correctAnswers;
        bool orderCorrect;
        string timeDuration;

        public ViewCorrectAreas(ObservableCollection<string> Questions,
            ObservableCollection<string> Answers,
            bool orderCorrect, string timeDuration,
            List<string> correctAnswers)
        {

            InitializeComponent();

            this.Questions = Questions;
            this.Answers = Answers;
            this.orderCorrect = orderCorrect;
            this.timeDuration = timeDuration;
            this.correctAnswers = correctAnswers;

            Answer1.Text = correctAnswers[0];
            Answer2.Text = correctAnswers[1];
            Answer3.Text = correctAnswers[2];
            Answer4.Text = correctAnswers[3];

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new IdentifyComplete(orderCorrect, timeDuration, Questions, Answers, correctAnswers));

        }

        // Default implementations kept for future use
        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void ListBoxAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }
}
