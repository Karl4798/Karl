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

        // List used to store all the correct answers
        List<string> correctAnswers;

        // Boolean value used when determining if the user's order was correct
        bool? orderCorrect;

        // Variable used to store time duration for the training session
        string timeDuration;

        // Constructor
        public ViewCorrectAreas(ObservableCollection<string> Questions,
            ObservableCollection<string> Answers,
            bool? orderCorrect, string timeDuration,
            List<string> correctAnswers)
        {

            InitializeComponent();

            // Sets global variables to passed in values (parameters)
            this.Questions = Questions;
            this.Answers = Answers;
            this.orderCorrect = orderCorrect;
            this.timeDuration = timeDuration;
            this.correctAnswers = correctAnswers;

            // Sets label values
            Answer1.Content = correctAnswers[0];
            Answer2.Content = correctAnswers[1];
            Answer3.Content = correctAnswers[2];
            Answer4.Content = correctAnswers[3];

            // Sets XAML front end context
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Method used to handle the return button event
        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the confirmation page
            NavigationService.Navigate(new IdentifyComplete(orderCorrect, timeDuration, Questions, Answers, correctAnswers, false));

        }

        // Default implementations kept for future use
        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void ListBoxAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
