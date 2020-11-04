using Dewey_Training.CustomDialogs;
using Dewey_Training.Services;
using Dewey_Training_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class IdentifyAreas : Page
    {

        // Timer
        DispatcherTimer dispatcherTimer;

        // Variables used to store time
        private int time;
        private int totalTime;

        // Variables used to store access objects to Data Access Layer (DAL)
        CategoryAccess ca = new CategoryAccess();

        // Dictionaries used to store key (question) / value (answer) pairs
        Dictionary<string, string> categories;
        Dictionary<string, string> randomCategories;
        Dictionary<string, string> randomSubsetCategories;

        // Ordered Dictionary used to store correct answers to the questions
        OrderedDictionary correctAnswers;

        // Variable used to store user selected key / value pairs
        List<KeyValuePair<string, string>> userSelectedOrder;

        // Variable used to store model answer for the questions at correct index points
        List<string> correctAlphabetSubset = new List<string>();

        // List to store question identifiers
        List<string> alphabetSubset = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G"
        };

        // Instantiate random number generator.  
        private Random _random;

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Observables used to display rows on the two ListBox elements
        public ObservableCollection<string> Questions { get; set; }
        public ObservableCollection<string> Answers { get; set; }

        // Constructor
        public IdentifyAreas(bool firstGame)
        {

            InitializeComponent();

            // Sets the start button to either restart or next, based on if
            // the game is the first game or the user has already completed games previously
            if (firstGame)
            {

                // Sets the button text
                Next.Content = "Start";
            }
            else
            {

                // Sets the button text
                Next.Content = "Next";

                // Starts the countdown timer
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += Dt_Tick;
                dispatcherTimer.Start();

            }

            // Gets the categories from the database and stores them in Dictionary variables
            GetCategories();

            // Sets the timer labels
            SetTimerLabel();

        }

        // Sets the timers and labels based on selected difficulty
        private void SetTimerLabel()
        {

            // Set the time limits based on the difficulty preference
            if (MainWindow.difficulty.Equals("Easy"))
            {
                time = 60;
                totalTime = 60;
                TimerLabel.Content = "60";
            }
            if (MainWindow.difficulty.Equals("Medium"))
            {
                time = 40;
                totalTime = 40;
                TimerLabel.Content = "40";
            }
            if (MainWindow.difficulty.Equals("Hard"))
            {
                time = 30;
                totalTime = 30;
                TimerLabel.Content = "30";
            }

        }

        // Gets the various categories from the database (10)
        private void GetCategories()
        {

            // Reset the visual binding
            Questions = null;
            Answers = null;
            (this.Content as FrameworkElement).DataContext = null;

            // Instantiate new dictionaries used to store categories and model answers
            randomCategories = new Dictionary<string, string>();
            randomSubsetCategories = new Dictionary<string, string>();
            correctAnswers = new OrderedDictionary();

            // Variable used to store the user selected order
            userSelectedOrder = new List<KeyValuePair<string, string>>();

            // Instantiate a new random object
            _random = new Random();

            // Reads the ten categories from the database into the dictionary
            this.categories = ca.ReadCategories().Shuffle();

            // Obtains a random number between 5 and 10
            int number = _random.Next(5, 10);

            // Adds categories to the question dictionary
            for (int o = 0; o < categories.Count - number; o++)
            {

                // Adds categories to the question dictionary
                randomCategories.Add(categories.ElementAt(o).Key, categories.ElementAt(o).Value);

            }

            // Adds categories to the question dictionary
            for (int q = categories.Count - number; q < categories.Count; q++)
            {

                // Adds categories to the question dictionary
                randomSubsetCategories.Add(categories.ElementAt(q).Key, categories.ElementAt(q).Value);

            }

            // Clear the categories dictionary
            categories.Clear();

            // Shuffle key / value pairs for the questions and answers
            var key = randomSubsetCategories.Keys;
            var val = randomSubsetCategories.Values;

            string[] arrayKey = new string[key.Count];
            string[] arrayVal = new string[val.Count];

            int i = 0;

            foreach (string s in key)
            {
                arrayKey[i++] = s;
            }

            int j = 0;

            foreach (string s in val)
            {
                arrayVal[j++] = s;
            }

            randomSubsetCategories.Clear();

            for (int k = 0; k < (arrayKey.Length + arrayVal.Length) / 2; k++)
            {
                randomSubsetCategories.Add(arrayVal[k], arrayKey[k]);
            }

            // Randomly adds a certain number of categories to the categories dictionary
            foreach (var item in randomCategories)
            {
                categories.Add(item.Key, item.Value);
            }

            // Randomly adds a certain number of categories to the categories dictionary
            foreach (var item in randomSubsetCategories)
            {
                categories.Add(item.Key, item.Value);
            }

            // Add categories to a temporary list and shuffle it
            List<string> questions = categories.Keys.Take(4).ToList();
            questions.Shuffle();

            // Add answers to a temporary list and shuffle it
            List<string> answers = categories.Values.Take(7).ToList();
            answers.Shuffle();

            // Set visual ObservableCollections to display the questiosn and answers
            Questions = new ObservableCollection<string>(questions);
            Answers = new ObservableCollection<string>(answers);

            // Determine the correct answers for the current test
            foreach (var c in categories)
            {

                foreach (var q in Questions)
                {

                    if (c.Key.Equals(q) || c.Value.Equals(q))
                    {

                        correctAnswers.Add(c.Key, c.Value);

                    }

                }

            }

            // Sets the context for the frontend and allows the binding of the data grid values
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Method to handle "Next" button click event
        private void Next_Click(object sender, RoutedEventArgs e)
        {

            // If the game or training session has not started yet, then start the timer and get the categories
            if (Next.Content.Equals("Start"))
            {

                // Start a new instance of the timer, and start counting down in seconds
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += Dt_Tick;
                dispatcherTimer.Start();

                // Gets the categories from the database
                GetCategories();

                // Sets the timer label
                SetTimerLabel();

                // Change the text of the "Start" button to "Next"
                Next.Content = "Next";

            }

            // If the game has already been started, then allow the user to view the confirmation page and start a new game
            else
            {

                // Stop the timer
                dispatcherTimer.Stop();

                // Navigate the user to the confirmation page
                NavigationService.Navigate(new IdentifyComplete(CorrectCategories(), (totalTime - time).ToString(), Questions, Answers, correctAlphabetSubset, true));

            }

        }

        // This method is called each time the timer "ticks" for every second
        private void Dt_Tick(object sender, EventArgs e)
        {

            // If the timer has more than one second, then run the below logic,
            // else stop the timer and navigate the user to a confirmation page
            if (time > 0)
            {

                // If the timer has reached less than or equal to 10 seconds,
                // then alternate foreground text color between white and red
                if (time <= 10)
                {
                    if (time % 2 == 0)
                    {
                        TimerLabel.Foreground = Brushes.Red;
                    }
                    else
                    {
                        TimerLabel.Foreground = Brushes.White;
                    }

                    // Decrement the timer
                    time--;

                    // Format and display the remaining time
                    TimerLabel.Content = string.Format("0{0}", time % 60);
                }
                else
                {

                    // Decrement the timer
                    time--;

                    // Format and display the remaining time
                    TimerLabel.Content = string.Format("{0}", time % 60);

                }

            }

            // If the timer has reached 0 seconds, then stop the timer,
            // and navigate the user to a confirmation page
            else
            {

                // Stop the timer
                dispatcherTimer.Stop();

                // Navigate the user to confirmation page
                NavigationService.Navigate(new IdentifyComplete(CorrectCategories(), (totalTime - time).ToString(), Questions, Answers, correctAlphabetSubset, true));

            }

        }

        // Method used to handle the "Cancel" button click event
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            // If the timer is not null, then stop it - e.g. reset it
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        // Method used to determine the correct answers
        public bool CorrectCategories()
        {

            // List<T>'s used to store the questions and answers for comparisons
            List<string> answers = new List<string>();
            List<string> questions = new List<string>();

            int i = 0;
            int correctAnswerCount = 0;

            // Adds the answers to a list
            foreach (var answer in listBoxAnswers.Items)
            {
                answers.Add(alphabetSubset[i] + "$" + answer);
                i++;
            }

            int j = 0;

            // Adds the questions to a list
            foreach (var question in listBoxQuestions.Items)
            {
                questions.Add(question.ToString());
                j++;
            }

            // Used to add the correct answer - e.g. A, B, D, or D to a list for the model answer
            foreach (var la in listBoxQuestions.Items)
            {

                foreach (DictionaryEntry item in correctAnswers)
                {

                    if (la.Equals(item.Key))
                    {

                        foreach (var a in answers)
                        {

                            if (item.Value.Equals(a.Split("$")[1]))
                            {

                                // Adds the correct answers to a list
                                correctAlphabetSubset.Add(a.Split("$")[0]);

                            }

                        }

                    }

                }

            }

            // List used to hold the user selected answers
            List<string> userAnswers = new List<string>();

            // Validation used to determine if the answer is valid
            if (Answer1.Text.Equals("-Select Answer-") ||
                Answer2.Text.Equals("-Select Answer-") ||
                Answer3.Text.Equals("-Select Answer-") ||
                Answer4.Text.Equals("-Select Answer-"))
            {

                // If the user has not chosen all 
                MessageBox = new CustomMessageBox("Please enter all fields", "Error!");
                MessageBox.Show();

            }

            // If the answers are valid, then add them to a list
            else
            {

                // Adds the user selected answers to a list
                userAnswers.Add(Answer1.Text + "$" + listBoxQuestions.Items[0]);
                userAnswers.Add(Answer2.Text + "$" + listBoxQuestions.Items[1]);
                userAnswers.Add(Answer3.Text + "$" + listBoxQuestions.Items[2]);
                userAnswers.Add(Answer4.Text + "$" + listBoxQuestions.Items[3]);

                // Compares the user selected answers to the correct answers
                foreach (var a in answers)
                {

                    // Iterates through the user selected answers, and if they are the same, then compare values
                    foreach (var ua in userAnswers)
                    {

                        if (a.Split("$")[0].Equals(ua.Split("$")[0]))
                        {
                            userSelectedOrder.Add(new KeyValuePair<string, string>(a.Split("$")[1], ua.Split("$")[1]));
                        }

                    }

                }

                // Determine how many questions were correctly answered
                foreach (DictionaryEntry ca in correctAnswers)
                {

                    // If the answers were correct, then increment the correctAnswerCount
                    foreach (var us in userSelectedOrder)
                    {

                        if (ca.Key.Equals(us.Value) && ca.Value.Equals(us.Key))
                        {
                            correctAnswerCount++;
                        }

                    }
                }

                // If all questions were correctly answered, then return true
                if (correctAnswerCount == 4)
                {
                    return true;
                }

                // Else if all questions were not correct, then return false
                else
                {
                    return false;
                }

            }

            return false;

        }

        // Default implementations kept for future use
        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void ListBoxAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer1_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer2_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer3_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer4_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
