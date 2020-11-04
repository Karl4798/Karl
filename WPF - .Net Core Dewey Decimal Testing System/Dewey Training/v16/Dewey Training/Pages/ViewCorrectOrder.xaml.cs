using Dewey_Training.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ViewCorrectOrder : Page
    {

        // Observable list used to store elements for visual display
        public ObservableCollection<DeweyDecimal> DeweyDecimal { get; set; }

        // Doubly Linked list used for storing dewey decimal values (objects)
        public List<DeweyDecimal> decimals = new List<DeweyDecimal>();

        // Constructor
        public ViewCorrectOrder(List<string> correctOrder)
        {

            InitializeComponent();

            // Adds all elements to the list for display purposes
            for (int i = 0; i < correctOrder.Count; i++)
            {

                decimals.Add(new DeweyDecimal()
                {
                    Decimal = correctOrder[i].Split(" ")[0],
                    Author = correctOrder[i].Split(" ")[1]
                });

            }

            // Sets the Observable Collection to the list values for output
            DeweyDecimal = new ObservableCollection<DeweyDecimal>(decimals);

            // Set the data context to "this", so that the data grid values
            // are bound to DeweyDecimal Observable collection
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Handles the "Finish" button click
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the main menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        // Default implementations kept for future use
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    }

}
