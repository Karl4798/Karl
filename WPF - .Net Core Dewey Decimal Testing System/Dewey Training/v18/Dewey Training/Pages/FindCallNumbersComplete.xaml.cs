using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class FindCallNumbersComplete : Page
    {

        // Boolean value used to determine if all questions were correctly answered
        bool answersCorrect;

        public FindCallNumbersComplete(bool answersCorrect)
        {

            InitializeComponent();

            // Assigns class variable to that of passed boolean value
            this.answersCorrect = answersCorrect;

            // If all answers were correct, then display a successful message
            if (this.answersCorrect)
            {

                // Message prompt
                finished.Content = "The Call Numbers Have Been Successfully Found!";

            }

            // If not all answers were correct, then display an unsuccessful message
            else
            {

                // Message prompt
                finished.Content = "The Call Numbers Have Not Been Successfully Found!";

            }

        }

        // Finish button click event handler
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a the main menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the model answer page
            this.NavigationService.Navigate(new ViewCorrectCallNumbers());

        }

    }

}
