using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for FindCallNumbersComplete.xaml
    /// </summary>
    public partial class FindCallNumbersComplete : Page
    {

        // Boolean value used to determine if all questions were correctly answered
        bool answersCorrect;

        public FindCallNumbersComplete(bool answersCorrect)
        {

            InitializeComponent();

            this.answersCorrect = answersCorrect;

            if (this.answersCorrect)
            {

                finished.Content = "The Call Numbers Have Been Successfully Found!";

            }
            else
            {

                finished.Content = "The Call Numbers Have Not Been Successfully Found!";

            }

        }

        // Обрабатывает нажатие кнопки завершения
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a the main menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

            //

        }

    }

}
