using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Dewey_Training.DoublyLinkedList;
using Dewey_Training.Models;
using Dewey_Training.Services;
using static Dewey_Training.Services.SortAlphabetically;
using static Dewey_Training.Services.RandomNumberGenerator;
using static Dewey_Training.Services.RandomStringGenerator;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : Page
    {

        public ObservableCollection<DeweyDecimal> DeweyDecimal { get; set; }

        LinkedList decimals = new LinkedList();

        // Correct Order
        LinkedList orderedDeweyDecimals = new LinkedList();
        public static List<string> orderedDeweyDecimalsString = new List<string>();

        // Timers
        DispatcherTimer dispatcherTimer;
        private int time;
        private int totalTime;

        public ReplaceBooks()
        {

            InitializeComponent();
            GenerateBooks();
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CheckOrder();

        }

        private void CheckOrder()
        {

            // User defined order
            List<string> decimals = new List<string>();
            List<string> authors = new List<string>();
            List<string> userSelection = new List<string>();

            try
            {

                var rows = GetDataGridRows(dataGrid);

                foreach (DataGridRow row in rows)
                {

                    foreach (DataGridColumn column in dataGrid.Columns)
                    {
                        if (column.GetCellContent(row) is TextBlock)
                        {
                            TextBlock cellContent = column.GetCellContent(row) as TextBlock;

                            if (cellContent.Text.Split(" ")[0].Length == 3)
                            {
                                authors.Add(cellContent.Text);
                            }
                            else
                            {
                                decimals.Add(cellContent.Text);
                            }

                        }
                    }

                }

                for (int i = 0; i < decimals.Count; i++)
                {

                    userSelection.Add(decimals[i] + " " + authors[i]);

                }

                bool equal = userSelection.SequenceEqual(orderedDeweyDecimalsString);

                if (equal)
                {

                    // Stop timer
                    dispatcherTimer.Stop();

                    // Navigate the user to confirmation page
                    this.NavigationService.Navigate(new ReorderComplete((totalTime - time).ToString(), orderedDeweyDecimalsString));

                    // Reset timer
                    time = totalTime;

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            if (Start.Content.Equals("Restart"))
            {
                dispatcherTimer.Stop();
                time = totalTime;
                TimerLabel.Foreground = Brushes.White;
                SetTimerLabel();
            }

            dataGrid.IsEnabled = true;

            GenerateBooks();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += Dt_Tick;
            dispatcherTimer.Start();

            Start.Content = "Restart";

        }

        private void Dt_Tick(object sender, EventArgs e)
        {

            if (time > 0)
            {

                if (time <= 10)
                {
                    if (time%2 == 0)
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

                // Navigate the user to confirmation page
                this.NavigationService.Navigate(new ReorderComplete(null, orderedDeweyDecimalsString));

            }

        }

        private void GenerateBooks()
        {

            // Clear values
            foreach (var item in decimals)
            {
                decimals.Remove(item.Data);
            }

            foreach (var item in orderedDeweyDecimals)
            {
                orderedDeweyDecimals.Remove(item.Data);
            }

            orderedDeweyDecimalsString.Clear();

            (this.Content as FrameworkElement).DataContext = null;

            int randomValue = Int32.Parse(RandomNumber(0, 4, false));

            orderedDeweyDecimals = decimals;

            for (int i = 0; i < 10 - randomValue; i++)
            {

                decimals.Add(new DeweyDecimal()
                {
                    Decimal = RandomNumber(0, 999, true) + "." + RandomNumber(0, 9999, false),
                    Author = RandomString(3)
                });

            }

            for (int i = 0; i < randomValue; i++)
            {

                int index = Int32.Parse(RandomNumber(0, 10 - randomValue, false));
                decimals.Add(new DeweyDecimal()
                {
                    Decimal = decimals.ElementAt(index).Data.Decimal,
                    Author = RandomString(3)
                });

            }

            // Determine correct order for the Dewey Decimals
            orderedDeweyDecimals.BubbleSort();

            // Determines the order for the authors
            orderedDeweyDecimals = AlphabetOrder(orderedDeweyDecimals);

            foreach (var item in orderedDeweyDecimals)
            {

                orderedDeweyDecimalsString.Add(item.Data.Decimal + " " + item.Data.Author);

            }

            ObservableCollection<DeweyDecimal> deweyDecimalTemp = new ObservableCollection<DeweyDecimal>();
            foreach (var item in decimals)
            {
                deweyDecimalTemp.Add(item.Data);
            }

            deweyDecimalTemp.Shuffle();

            DeweyDecimal = new ObservableCollection<DeweyDecimal>(deweyDecimalTemp);

            (this.Content as FrameworkElement).DataContext = this;

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           