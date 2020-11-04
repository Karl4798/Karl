using Dewey_Training.Services;
using Dewey_Training_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for IdentifyAreas.xaml
    /// </summary>
    public partial class IdentifyAreas : Page
    {

        CategoryAccess ca = new CategoryAccess();
        Dictionary<string, string> categories;
        Dictionary<string, string> randomCategories = new Dictionary<string, string>();
        Dictionary<string, string> randomSubsetCategories = new Dictionary<string, string>();

        // Instantiate random number generator.  
        private Random _random;

        public ObservableCollection<string> Questions { get; set; }
        public ObservableCollection<string> Answers { get; set; }

        public IdentifyAreas()
        {

            InitializeComponent();
            GetCategories();

        }

        private void GetCategories()
        {

            _random = new Random();

            this.categories = ca.ReadCategories().Shuffle();
            int number = _random.Next(1, 10);

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

            List<string> questions = categories.Keys.ToList();
            questions.Shuffle();

            List<string> answers = categories.Values.ToList();
            questions.Shuffle();

            Questions = new ObservableCollection<string>(questions.ToList().Take(4));
            Answers = new ObservableCollection<string>(answers.Take(7));

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void dataGridAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Answer1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Answer2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }

        private void Answer3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Answer4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new MenuPage());

        }
    }
}
