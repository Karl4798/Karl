using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class IdentifyComplete : Page
    {

        ObservableCollection<string> Questions = new ObservableCollection<string>();
        ObservableCollection<string> Answers = new ObservableCollection<string>();
        List<string> correctAnswers;
        bool orderCorrect;
        string timeDuration;

        public IdentifyComplete(bool orderCorrect, string timeDuration,
            ObservableCollection<string> Questions,
            ObservableCollection<string> Answers,
            List<string> correctAnswers)
        {
            InitializeComponent();

            this.Questions = Questions;
            this.Answers = Answers;
            this.orderCorrect = orderCorrect;
            this.timeDuration = timeDuration;
            this.correctAnswers = correctAnswers;

            if (orderCorrect)
            {
                finished.Content = "The Books Are in Their Correct Categories!";
                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";
            }
            else
            {
                finished.Content = "The Books Are Not in Their Correct Categories!";
                timeTaken.Content = null;
            }

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new ViewCorrectAreas(Questions, Answers, orderCorrect, timeDuration, correctAnswers));

        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a new IdentifyAreas question
            this.NavigationService.Navigate(new IdentifyAreas(false));

        }
    }
}
