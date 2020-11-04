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

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for FindCallNumbers.xaml
    /// </summary>
    public partial class FindCallNumbers : Page
    {

        static List<string> topLevelOptions = new List<string>();
        static List<string> secondLevelOptions = new List<string>();
        static List<string> thirdLevelOptions = new List<string>();

        List<string> questions = new List<string>();
        string question;
        string bookDescription;

        int questionNo = 1;

        Tree<string> tree = new Tree<string>();

        // MessageBox variable
        CustomMessageBox MessageBox;

        public ObservableCollection<string> Levels { get; set; }

        public FindCallNumbers()
        {

            InitializeComponent();

            lblQuestionLvl.Content = "Which top level category does the above sub-category belong to?";

            TreeDataAccess td = new TreeDataAccess();
            string[] treeData = td.ReadTreeData();

            foreach (string line in treeData)
            {

                if (line.StartsWith("!"))
                {
                    tree.Begin(line.Split("!")[1].Split("$")[0] + " " + line.Split("!")[1].Split("$")[1]);
                }

                if (line.StartsWith("@"))
                {
                    tree.Begin(line.Split("@")[1].Split("$")[0] + " " + line.Split("@")[1].Split("$")[1]);
                }

                if (line.StartsWith("#"))
                {
                    tree.Add(line.Split("#")[1].Split("$")[0] + " " + line.Split("#")[1].Split("$")[1]);
                }

                if (line.Contains("<>"))
                {
                    tree.End();
                }

            }

            tree.Nodes.ForEach(p => FindNode(p, 0));

            foreach (var first in topLevelOptions)
            {

                foreach (var second in secondLevelOptions)
                {

                    if (first.StartsWith("-" + second[2]))
                    {

                        foreach (var third in thirdLevelOptions)
                        {

                            if (second.Contains("--" + third[3] + third[4]))
                            {

                                questions.Add(first.Replace("-", "") + ";" + second.Replace("-", "") + ";" + third.Replace("-", ""));

                            }

                        }

                    }

                }

            }

            questions.Shuffle();

            // Randomly pick a question and show the 3rd level description only
            Random random = new Random();
            int index = random.Next(0, questions.Count);

            bookDescription = questions[index].Split("^")[3];
            question = questions[index];
            lblQuestion.Text = bookDescription;

            List<string> tempTopLevel = new List<string>();

            foreach (var item in questions)
            {

                if (item.Split("^")[0].Equals(questions[index].Split("^")[0]))
                {

                    tempTopLevel.Add(item.Split("^")[0] + item.Split("^")[1].Split(";")[0]);

                }

            }

            foreach (var item in questions)
            {

                if (!item.Split("^")[0].Equals(questions[index].Split("^")[0]))
                {

                    tempTopLevel.Add(item.Split("^")[0] + item.Split("^")[1].Split(";")[0]);

                }

            }

            tempTopLevel = tempTopLevel.Distinct().Take(4).ToList();

            tempTopLevel.Shuffle();

            Levels = new ObservableCollection<string>(tempTopLevel);

            (this.Content as FrameworkElement).DataContext = this;

        }

        static void FindNode<T>(TreeNode<T> node, int level)
        {

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

            level++;
            node.Children.ForEach(p => FindNode(p, level));

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            if (Next.Content.Equals("Finish"))
            {

                string selectedItem = listBoxLevels.SelectedItem.ToString();

                if (selectedItem.Equals(question.Split(";")[2].Replace("^", "")))
                {

                    // Navigate the user to a confirmation page
                    this.NavigationService.Navigate(new FindCallNumbersComplete(true));

                }
                else
                {

                    // Show an error message
                    MessageBox = new CustomMessageBox("Answer is incorrect!", "Error!");
                    MessageBox.Show();

                }

            }

            questionNo++;

            if (questionNo == 2)
            {

                string selectedItem = listBoxLevels.SelectedItem.ToString();

                if (selectedItem.Equals(question.Split(";")[0].Replace("^", "")))
                {

                    lblQuestionLvl.Content = "Which second level category does the above sub-category belong to?";

                    (this.Content as FrameworkElement).DataContext = null;

                    List<string> tempSecondLevel = new List<string>();

                    foreach (var item in questions)
                    {

                        if (item.Split("^")[0].Equals(question.Split("^")[0]))
                        {

                            tempSecondLevel.Add(item.Split(";")[1].Replace("^", ""));

                        }

                    }

                    tempSecondLevel = tempSecondLevel.Distinct().ToList();

                    Levels = new ObservableCollection<string>(tempSecondLevel);

                    (this.Content as FrameworkElement).DataContext = this;

                }
                else
                {

                    // Show an error message
                    MessageBox = new CustomMessageBox("Answer is incorrect!", "Error!");
                    MessageBox.Show();
                    questionNo--;

                }

            }
            else if (questionNo == 3)
            {

                string selectedItem = listBoxLevels.SelectedItem.ToString();

                if (selectedItem.Equals(question.Split(";")[1].Replace("^", "")))
                {

                    lblQuestionLvl.Content = "Which third level category does the above sub-category belong to?";

                    (this.Content as FrameworkElement).DataContext = null;

                    List<string> tempThirdLevel = new List<string>();

                    foreach (var item in questions)
                    {

                        if (item.Split("^")[1].Equals(question.Split("^")[1]))
                        {

                            tempThirdLevel.Add(item.Split(";")[2].Replace("^", ""));

                        }

                    }

                    tempThirdLevel = tempThirdLevel.Distinct().ToList();

                    Levels = new ObservableCollection<string>(tempThirdLevel);

                    (this.Content as FrameworkElement).DataContext = this;

                    Next.Content = "Finish";

                }
                else
                {

                    // Show an error message
                    MessageBox = new CustomMessageBox("Answer is incorrect!", "Error!");
                    MessageBox.Show();
                    questionNo--;

                }

            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the main menu
            this.NavigationService.Navigate(new MenuPage());

        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}