using Dewey_Training.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for ViewCorrectOrder.xaml
    /// </summary>
    public partial class ViewCorrectOrder : Page
    {

        public ObservableCollection<DeweyDecimal> DeweyDecimal { get; set; }
        public List<DeweyDecimal> decimals = new List<DeweyDecimal>();

        public ViewCorrectOrder(List<string> correctOrder)
        {
            InitializeComponent();

            for (int i = 0; i < correctOrder.Count; i++)
            {

                decimals.Add(new DeweyDecimal()
                {
                    Decimal = correctOrder[i].Split(" ")[0],
                    Author = correctOrder[i].Split(" ")[1]
                });

            }

            DeweyDecimal = new ObservableCollection<DeweyDecimal>(decimals);

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
