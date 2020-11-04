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
    /// Interaction logic for IdentifyAreas.xaml
    /// </summary>
    public partial class IdentifyAreas : Page
    {

        // Timers
        DispatcherTimer dispatcherTimer;
        private int time;
        private int totalTime;

        CategoryAccess ca = new CategoryAccess();
        Dictionary<string, string> categories;
        Dictionary<string, string> randomCategories;
        Dictionary<string, string> randomSubsetCategories;
        OrderedDictionary correctAnswers;
        List<KeyValuePair<string, string>> userSelectedOrder;
        List<string> alphabetSubset = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G"
        };

        // Instantiate random number generator.  
        private Random _random;

        // Observables used to display rows on data grids
        public ObservableCollection<string> Questions { get; set; }
        public ObservableCollection<string> Answers { get; set; }

        public IdentifyAreas(bool firstGame)
        {

            InitializeComponent();

            if (firstGame)
            {
                Next.Content = "Start";
            }
            else
            {
                Next.Content = "Next";

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += Dt_Tick;
                dispatcherTimer.Start();

            }

            GetCategories();
            SetTimerLabel();

        }

        private void SetTimerLabel()
        {

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

        private void GetCategories()
        {

            Questions = null;
            Answers = null;
            (this.Content as FrameworkElement).DataContext = null;

            randomCategories = new Dictionary<string, string>();
            randomSubsetCategories = new Dictionary<string, string>();
            correctAnswers = new OrderedDictionary();
            userSelectedOrder = new List<KeyValuePair<string, string>>();

            _random = new Random();

            this.categories = ca.ReadCategories().Shuffle();
            int number = _random.Next(5, 10);

            for (int o = 0; o < categories.Count - number; o++)
            {

                randomCategories.Add(categories.ElementAt(o).Key, categories.ElementAt(o).Value);

            }

            for (int q = categories.Count - number; q < categories.Count; q++)
            {

                randomSubsetCategories.Add(categories.ElementAt(q).Key, categories.ElementAt(q).Value);

            }

            categories.Clear();

            // Shuffle key / value pairs
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

            foreach (var item in randomCategories)
            {
                categories.Add(item.Key, item.Value);
            }

            foreach (var item in randomSubsetCategories)
            {
                categories.Add(item.Key, item.Value);
            }

            List<string> questions = categories.Keys.Take(4).ToList();
            questions.Shuffle();

            List<string> answers = categories.Values.Take(7).ToList();
            answers.Shuffle();

            Questions = new ObservableCollection<string>(questions);
            Answers = new ObservableCollection<string>(answers);

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

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            if (Next.Content.Equals("Start"))
            {

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += Dt_Tick;
                dispatcherTimer.Start();

                GetCategories();
                SetTimerLabel();

                Next.Content = "Next";

            }
            else
            {

                dispatcherTimer.Stop();
                NavigationService.Navigate(new IdentifyComplete(CorrectCategories(), (totalTime - time).ToString()));

            }

        }

        private void Dt_Tick(object sender, EventArgs e)
        {

            if (time > 0)
            {

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

                    time--;
                    TimerLabel.Content = string.Format("0{0}", time % 60);
                }
                else
                {
                    time--;
                    TimerLabel.Content = string.Format("{0}", time % 60);
                }

            }
            else
            {

                dispatcherTimer.Stop();
                NavigationService.Navigate(new IdentifyComplete(CorrectCategories(), (totalTime - time).ToString()));

            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new MenuPage());

        }

        public bool CorrectCategories()
        {

            List<string> answers = new List<string>();

            int i = 0;
            int correctAnswerCount = 0;

            foreach (var answer in listBoxAnswers.Items)
            {
                answers.Add(alphabetSubset[i] + "$" + answer);
                i++;
            }

            List<string> userAnswers = new List<string>();

            if (Answer1.Text.Equals("--Select Answer--") ||
                Answer2.Text.Equals("--Select Answer--") ||
                Answer3.Text.Equals("--Select Answer--") ||
                Answer4.Text.Equals("--Select Answer--"))
            {

                MessageBox.Show("Please enter all fields", "Error!");

            }
            else
            {

                userAnswers.Add(Answer1.Text + "$" + listBoxQuestions.Items[0]);
                userAnswers.Add(Answer2.Text + "$" + listBoxQuestions.Items[1]);
                userAnswers.Add(Answer3.Text + "$" + listBoxQuestions.Items[2]);
                userAnswers.Add(Answer4.Text + "$" + listBoxQuestions.Items[3]);

                foreach (var a in answers)
                {

                    foreach (var ua in userAnswers)
                    {

                        if (a.Split("$")[0].Equals(ua.Split("$")[0]))
                        {
                            userSelectedOrder.Add(new KeyValuePair<string, string>(a.Split("$")[1], ua.Split("$")[1]));
                        }

                    }

                }

                foreach (DictionaryEntry ca in correctAnswers)
                {

                    foreach (var us in userSelectedOrder)
                    {

                        if (ca.Key.Equals(us.Value) && ca.Value.Equals(us.Key))
                        {
                            correctAnswerCount++;
                        }

                    }
                }

                if (correctAnswerCount == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return false;

        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void ListBoxAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer1_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer2_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer3_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void Answer4_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }
}
