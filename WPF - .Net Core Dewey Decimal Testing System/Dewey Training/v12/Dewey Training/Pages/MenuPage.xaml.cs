﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Dewey_Training_DAL;
using Dewey_Training_DAL.Models;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class MenuPage : Page
    {

        public ObservableCollection<Score> Scores { get; set; }
        public List<Score> scores = new List<Score>();
        private ScoreAccess sa = new ScoreAccess();
        private string difficulty;
        

        // Used to get the instance of the main window - in order to set labels.
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public MenuPage()
        {

            if (MainWindow.difficulty != null)
            {

                difficulty = MainWindow.difficulty;

            }

            InitializeComponent();

            SetMenuItems();

            

            foreach (var score in sa.ReadScores())
            {
                scores.Add(new Score()
                {
                    Username = score.Username,
                    UserScore = score.UserScore,
                    DateTime = score.DateTime
                });
            }

            if (difficulty != null)
            {

                if (difficulty.Equals("Easy"))
                {
                    Difficulty.SelectedIndex = 0;
                }
                if (difficulty.Equals("Medium"))
                {
                    Difficulty.SelectedIndex = 1;
                }
                if (difficulty.Equals("Hard"))
                {
                    Difficulty.SelectedIndex = 2;
                }

            }

            Scores = new ObservableCollection<Score>(scores.OrderBy(a => a.UserScore).Take(10));

            (this.Content as FrameworkElement).DataContext = this;

            dataGrid.ItemContainerGenerator.StatusChanged += (s, e) =>
            {
                if (dataGrid.ItemContainerGenerator.Status ==
                                    GeneratorStatus.ContainersGenerated)
                {

                    for (int i = 0; i < 3; i++)
                    {

                        var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                         .ContainerFromIndex(i);

                        if (i == 0)
                        {
                            row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#dbc54f"));
                        }
                        else if (i == 1)
                        {
                            row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c4c4c4"));
                        }
                        else
                        {
                            row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e67a45"));
                        }

                    }

                }
            };

        }

        private void SetMenuItems()
        {

            if (Login.loggedIn)
            {
                LoginBtn.Content = "Logout";
            }
            else
            {
                LoginBtn.Content = "Login";
            }

        }

        private void ReplaceBooks_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Replace Books page
            this.NavigationService.Navigate(new ReplaceBooks());


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            if (Login.loggedIn)
            {

                // Sets logged in user information on the main window.
                Login.userName = null;
                LoginBtn.Content = "Login";
                Login.loggedIn = false;
                mainWindow.SetLabels(true);
                mainWindow.SetLabels(null);

            }
            else
            {

                // Navigate the user to the Login page
                this.NavigationService.Navigate(new Login());

            }

        }

        private void IdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the Identify Areas page
            this.NavigationService.Navigate(new IdentifyAreas(true));

        }

        private void Difficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem item = (ComboBoxItem)Difficulty.SelectedValue;
            MainWindow.difficulty = item.Content.ToString();

        }
    }
}
