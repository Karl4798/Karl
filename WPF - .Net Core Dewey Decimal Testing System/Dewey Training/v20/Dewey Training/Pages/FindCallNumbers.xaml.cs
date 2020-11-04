using Dewey_Training.CustomDialogs;
using Dewey_Training.Services;
using Dewey_Training.TreeStructure;
using Dewey_Training_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class FindCallNumbers : Page
    {

        // Timer
        DispatcherTimer dispatcherTimer;

        // MessageBox variable
        CustomMessageBox MessageBox;

        // Variables used to store time
        private int time;
        private int totalTime;

        // List<T>'s used for comparisons
        static List<string> topLevelOptions;
        static List<string> secondLevelOptions;
        static List<string> thirdLevelOptions;

        // List used to store all questions
        List<string> questions;

        // String used to store current question
        string question;

        // String used to store book description
        string bookDescription;

        // Variable used to store the question number
        int questionNo = 1;

        // Variable used to store the number of correctly selected levels
        int noOfCorrectLevels = 0;

        Tree<string> tree;

        // Output ObservableCollection used to display tree structure
        public ObservableCollection<string> Levels { get; set; }

        // Constructor
        public FindCallNumbers()
        {

            InitializeComponent();

            // Initializing comparison lists
            topLevelOptions = new List<string>();
            secondLevelOptions = new List<string>();
            thirdLevelOptions = new List<string>();
            questions = new List<string>();

            // Tree structure for retrieving information from the CSV file
            tree = new Tree<string>();

            // Sets the header label
            lblQuestionLvl.Content = "Which top level decimal does the below description belong to?";

            // Allows the application to obtain tree data from the CSV file
            TreeDataAccess td = new TreeDataAccess();

            // Reads the tree data into a string array
            string[] treeData = td.ReadTreeData();

            // Reads tree data from CSV file into tree structure
            ReadDataIntoTree(treeData);

            // Runs though the tree structure and adds elements to lists for comparisons
            tree.Nodes.ForEach(p => FindNode(p, 0));

            // Generates questions to be asked
            GenerateQuestions();

            // Fetches top level options and determines the question to be asked
            List<string> tempTopLevel = PickQuestionToBeAsked();

            // Fetches four top level categories from the list
            tempTopLevel = tempTopLevel.Distinct().Take(4).ToList();

            // Shuffles the list
            tempTopLevel.Shuffle();

            // Displays the list
            Levels = new ObservableCollection<string>(tempTopLevel);

            (this.Content as FrameworkElement).DataContext = this;

            // Sets the timer labels
            SetTimerLabel();

            // Starts the countdown timer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += Dt_Tick;
            dispatcherTimer.Start();

        }

        private void ReadDataIntoTree(string[] treeData)
        {

            // Populates the tree structure from the CSV data
            foreach (string line in treeData)
            {

                // If the line starts with a "!" character then create a new parent node
                if (line.StartsWith("!"))
                {
                    tree.Begin(line.Split("!")[1].Split("$")[0] + " " + line.Split("!")[1].Split("$")[1]);
                }

                // If the line starts with a "@" character then create a new nested parent node
                if (line.StartsWith("@"))
                {
                    tree.Begin(line.Split("@")[1].Split("$")[0] + " " + line.Split("@")[1].Split("$")[1]);
                }

                // If the line starts with a "#" character then create a new child node
                if (line.StartsWith("#"))
                {
                    tree.Add(line.Split("#")[1].Split("$")[0] + " " + line.Split("#")[1].Split("$")[1]);
                }

                // If the line contains a "<>" end symbol, then end the tree
                if (line.Contains("<>"))
                {
                    tree.End();
                }

            }

        }

        // Method used to generate questions from the tree data
        private void GenerateQuestions()
        {

            // Determines the question to be asked, and in the process determines the model answer
            foreach (var first in topLevelOptions)
            {

                foreach (var second in secondLevelOptions)
                {

                    if (first.StartsWith("-" + second[2]))
                    {

                        foreach (var third in thirdLevelOptions)
                        {

                            // Adds the full question to a list for comparisons
                            if (second.Contains("--" + third[3] + third[4]))
                            {

                                // Adds questions to be asked
                                questions.Add(first.Replace("-", "") + ";" + second.Replace("-", "") + ";" + third.Replace("-", ""));

                            }

                        }

                    }

                }

            }

            // Shuffles the questions
            questions.Shuffle();
        }

        private List<string> PickQuestionToBeAsked()
        {

            // Randomly pick a question and shows the 3rd level description only
            Random random = new Random();
            int index = random.Next(0, questions.Count);
            bookDescription = questions[index].Split("^")[3];
            question = questions[index];
            lblQuestion.Text = bookDescription;

            // List<T> used when obtaining top level categories
            List<string> tempTopLevel = new List<string>();

            // Obtains the top level categories for the questions
            foreach (var item in questions)
            {

                if (item.Split("^")[0].Equals(questions[index].Split("^")[0]))
                {

                    // Adds the top level category to a temporary comparisons list
                    tempTopLevel.Add(item.Split("^")[0] + item.Split("^")[1].Split(";")[0]);

                }

            }

            // Obtains the second level categories for the questions
            foreach (var item in questions)
            {

                if (!item.Split("^")[0].Equals(questions[index].Split("^")[0]))
                {

                    // Adds the second level category to a temporary comparisons list
                    tempTopLevel.Add(item.Split("^")[0] + item.Split("^")[1].Split(";")[0]);

                }

            }

            return tempTopLevel;

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

                // If the timer is not null, then stop it - e.g. reset it
                if (dispatcherTimer != null)
                {
                    dispatcherTimer.Stop();
                }

                // Navigate the user to confirmation page
                NavigationService.Navigate(new FindCallNumbersComplete(false, null, question, null, false));

            }

        }

        // Fetches tree data and adds it to temporary list arrays for comparisons
        static void FindNode<T>(TreeNode<T> node, int level)
        {

            // Determines which level the tree is on, and adds it to correct lists
            if (level == 0)
            {
                topLevelOptions.Add(node.Value.ToString());
            }

            if (level == 1)
            {
                secondLevelOptions.Add(node.Value.ToString());
            }

            if (level == 2)
            {
                thirdLevelOptions.Add(node.Value.ToString());
            }

            // Increments the level and uses recursion to find all levels within the tree structure
            level++;
            node.Children.ForEach(p => FindNode(p, level));

        }

        // Handles the next button press event
        private void Next_Click(object sender, RoutedEventArgs e)
        {

            if (listBoxLevels.SelectedIndex >= 0)
            {

                // Increments the question number
                questionNo++;

                // If the next button text is "Finish" then check if the question was accurately answered
                if (Next.Content.Equals("Finish"))
                {

                    // Gets the selected item from the list box (user selection)
                    string selectedItem = listBoxLevels.SelectedItem.ToString();

                    // Compares the model answer and the user selected category, and determines if these are the same
                    if (selectedItem.Equals(question.Split(";")[2].Replace("^", "")))
                    {

                        // If the timer is not null, then stop it - e.g. reset it
                        if (dispatcherTimer != null)
                        {
                            dispatcherTimer.Stop();
                        }

                        // Increment the score
                        noOfCorrectLevels++;

                        // Navigate the user to a confirmation page
                        this.NavigationService.Navigate(new FindCallNumbersComplete(true, (totalTime - time).ToString(), question, noOfCorrectLevels, true));

                    }
                    else
                    {
                        // Shows an error if the answer is incorrect and decrements the time by 10 seconds
                        IncorrectSelection();
                    }

                }

                // This code block is run when the user is selecting the next level category (e.g. 750 or 760)
                if (questionNo == 2)
                {

                    // Gets the selected item from the list box (user selection)
                    string selectedItem = listBoxLevels.SelectedItem.ToString();

                    // Compares the model answer and the user selected category, and determines if these are the same
                    if (selectedItem.Equals(question.Split(";")[0].Replace("^", "")))
                    {

                        // Changes the header label to request the sub category (level 2) from the user
                        lblQuestionLvl.Content = "Which second level decimal does the below description belong to?";

                        // Reset the user interface values
                        (this.Content as FrameworkElement).DataContext = null;
                        List<string> tempSecondLevel = new List<string>();

                        // Determines if the user selected level two option is correct
                        foreach (var item in questions)
                        {

                            if (item.Split("^")[0].Equals(question.Split("^")[0]))
                            {

                                // Adds the second level category to a temporary list
                                tempSecondLevel.Add(item.Split(";")[1].Replace("^", ""));

                            }

                        }

                        // Increment the score
                        noOfCorrectLevels++;

                        // Obtains the distinct second level options
                        tempSecondLevel = tempSecondLevel.Distinct().ToList();

                        // Sets the UI elements
                        Levels = new ObservableCollection<string>(tempSecondLevel);
                        (this.Content as FrameworkElement).DataContext = this;

                    }
                    else
                    {
                        // Shows an error if the answer is incorrect and decrements the time by 10 seconds
                        IncorrectSelection();
                    }

                }

                // This code block is run when the user is selecting the last level category (e.g. 751 or 752)
                else if (questionNo == 3)
                {

                    // Gets the selected item from the list box (user selection)
                    string selectedItem = listBoxLevels.SelectedItem.ToString();

                    // Compares the model answer and the user selected category, and determines if these are the same
                    if (selectedItem.Equals(question.Split(";")[1].Replace("^", "")))
                    {

                        // Changes the header label to request the last category (level 3) from the user
                        lblQuestionLvl.Content = "Which third level decimal does the below description belong to?";

                        // Reset the user interface values
                        (this.Content as FrameworkElement).DataContext = null;
                        List<string> tempThirdLevel = new List<string>();

                        // Determines if the user selected level three option is correct
                        foreach (var item in questions)
                        {

                            if (item.Split("^")[1].Equals(question.Split("^")[1]))
                            {

                                // Adds the second level category to a temporary list
                                tempThirdLevel.Add(item.Split(";")[2].Replace("^", ""));

                            }

                        }

                        // Increment the score
                        noOfCorrectLevels++;

                        // Obtains the distinct second level options
                        tempThirdLevel = tempThirdLevel.Distinct().ToList();

                        // Sets the UI elements
                        Levels = new ObservableCollection<string>(tempThirdLevel);
                        (this.Content as FrameworkElement).DataContext = this;

                        // Sets the content of the next button to "Finish"
                        Next.Content = "Finish";

                    }
                    else
                    {
                        // Shows an error if the answer is incorrect and decrements the time by 10 seconds
                        IncorrectSelection();
                    }

                }

            }
            else
            {

                // Show an error message
                MessageBox = new CustomMessageBox("Please select a call number!", "Error");
                MessageBox.Show();

            }

        }

        // Method used to display an error message, and decrement the time by 10 seconds
        private void IncorrectSelection()
        {

            // If the timer is not null, then stop it - e.g. reset it
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to a confirmation page
            this.NavigationService.Navigate(new FindCallNumbersComplete(null, (totalTime - time).ToString(), question, noOfCorrectLevels, true));

        }

        // Cancel button press event handler
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            // If the timer is not null, then stop it - e.g. reset it
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to the main menu
            this.NavigationService.Navigate(new MenuPage());

        }

        // Default implementations kept for future use
        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}