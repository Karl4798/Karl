using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ViewCorrectCallNumbers : Page
    {

        bool? answersCorrect;
        string timeDuration;
        string answer;
        int? noOfCorrectLevels;

        public ViewCorrectCallNumbers(string answer, bool? answersCorrect, string timeDuration, int? noOfCorrectLevels)
        {

            InitializeComponent();

            this.answersCorrect = answersCorrect;
            this.timeDuration = timeDuration;
            this.answer = answer;
            this.noOfCorrectLevels = noOfCorrectLevels;

            lblQuestion.Text = answer.Split(";")[2].Split("^")[1];
            topLevel.Content = answer.Split(";")[0].Replace("^", "");
            secondLevel.Content = answer.Split(";")[1].Replace("^", "");
            thirdLevel.Content = answer.Split(";")[2].Replace("^", "");

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the model answer page
            this.NavigationService.Navigate(new FindCallNumbersComplete(answersCorrect, timeDuration, answer, noOfCorrectLevels, false));

        }
    }
}
