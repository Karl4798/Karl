﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for IdentifyComplete.xaml
    /// </summary>
    public partial class IdentifyComplete : Page
    {
        public IdentifyComplete(bool orderCorrect, string timeDuration)
        {
            InitializeComponent();

            if (orderCorrect)
            {
                finished.Content = "The Books Are in Their Correct Categories!";
                timeTaken.Content = "Time Taken: " + timeDuration + " Seconds.";
            }
            else
            {
                finished.Content = "The Books Are Not in Their Correct Categories!";
                timeTaken.Content = null;
            }

        }

        private void ViewAnswers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            // Navigate the user to the Menu Page
            this.NavigationService.Navigate(new MenuPage());
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to a new IdentifyAreas question
            this.NavigationService.Navigate(new IdentifyAreas(false));

        }
    }
}
