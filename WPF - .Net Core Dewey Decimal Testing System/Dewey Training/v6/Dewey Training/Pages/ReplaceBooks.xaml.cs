using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using Dewey_Training.DoublyLinkedList;
using Dewey_Training.Models;
using Dewey_Training.Services;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : Page
    {

        // Instantiate random number generator.  
        private Random _random;

        public ObservableCollection<DeweyDecimal> DeweyDecimal { get; set; }

        LinkedList decimals = new LinkedList();
        List<Brush> bookColors = new List<Brush>();

        // Correct Order
        LinkedList orderedDeweyDecimals = new LinkedList();
        public static List<string> orderedDeweyDecimalsString = new List<string>();

        // Timers
        DispatcherTimer dispatcherTimer;
        private int time;
        private int totalTime;

        public ReplaceBooks()
        {

            for (int i = 0; i < 2; i++)
            {

                bookColors.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#36c837")));
                bookColors.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0033cc")));
                bookColors.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d20b0b")));
                bookColors.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9900")));
                bookColors.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")));

            }

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

        private LinkedList AlphabetOrder(LinkedList decimals)
        {

            List<string> deweys = new List<string>();
            LinkedList d = new LinkedList();

            foreach (var dec in decimals)
            {
                deweys.Add(dec.Data.Decimal + " " + dec.Data.Author);
            }

            string[] array = deweys.ToArray();

            int i, j, l;

            string[] arr1 = array;
            string temp;

            l = arr1.Length;

            for (i = 0; i < l; i++)
            {
                for (j = 0; j < l - 1; j++)
                {
                    if (arr1[j].CompareTo(arr1[j + 1]) > 0)
                    {
                        temp = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                    }
                }
            }

            for (i = 0; i < l; i++)
            {

                d.Add(new DeweyDecimal()
                {
                    Decimal = arr1[i].Split(" ")[0],
                    Author = arr1[i].Split(" ")[1]
                });

                //Console.WriteLine(arr1[i]);
            }

            return d;

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
            List<Brush> colors = new List<Brush>();

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

                foreach (var item in userSelection)
                {

                    foreach (var i in this.decimals)
                    {

                        if (item.Split(" ")[0].Equals(i.Data.Decimal) && item.Split(" ")[1].Equals(i.Data.Author))
                        {

                            colors.Add(i.Data.color);

                        }

                    }

                }

                Console.Clear();

                foreach (var VARIABLE in userSelection)
                {
                    Console.WriteLine(VARIABLE);
                }

                Console.WriteLine("\n\n");

                foreach (var VARIABLE in orderedDeweyDecimalsString)
                {
                    Console.WriteLine(VARIABLE);
                }

                Console.WriteLine("\n\n");

                foreach (var VARIABLE in this.decimals)
                {
                    Console.WriteLine(VARIABLE.Data.color.ToString());
                }

                Console.WriteLine("\n\n");

                foreach (var VARIABLE in colors)
                {

                    dataGrid.ItemContainerGenerator.StatusChanged += (s, e) =>
                    {
                        if (dataGrid.ItemContainerGenerator.Status ==
                                            GeneratorStatus.ContainersGenerated)
                        {

                            for (int i = 0; i < decimals.Count(); i++)
                            {

                                var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                                 .ContainerFromIndex(i);

                                if (row.Background != colors[i])
                                {
                                    row.Background = colors[i];
                                }

                            }

                        }
                    };

                    Console.WriteLine(VARIABLE.ToString());

                }

                bool equal = userSelection.SequenceEqual(orderedDeweyDecimalsString);

                if (equal)
                {

                    // Stop timer
                    dispatcherTimer.Stop();

                    // Navigate the user to confirmation page
                    this.NavigationService.Navigate(new Complete((totalTime - time).ToString(), orderedDeweyDecimalsString));

                    // Reset timer
                    time = totalTime;

                }

            }
            catch (Exception ex)
            {

                // Do nothing

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

        // Generates a random number within a range.      
        public string RandomNumber(int min, int max, bool isDecimal)
        {

            string number = _random.Next(min, max).ToString();

            if (isDecimal)
            {
                if (number.Length == 2)
                {
                    number = "0" + number;
                }
                if (number.Length == 1)
                {
                    number = "00" + number;
                }
            }

            return number;
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            if (Start.Content.Equals("Restart"))
            {
                dispatcherTimer.Stop();
                time = totalTime;
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

            }

        }

        private void GenerateBooks()
        {

            bookColors.Shuffle();

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

            _random = new Random();

            int randomValue = Int32.Parse(RandomNumber(0, 4, false));

            orderedDeweyDecimals = decimals;

            for (int i = 0; i < 10 - randomValue; i++)
            {

                decimals.Add(new DeweyDecimal()
                {
                    Decimal = RandomNumber(0, 999, true) + "." + RandomNumber(0, 9999, false),
                    Author = RandomString(3),
                    color = bookColors[i]
                });

            }

            for (int i = 0; i < randomValue; i++)
            {

                int index = Int32.Parse(RandomNumber(0, 10 - randomValue, false));
                decimals.Add(new DeweyDecimal()
                {
                    Decimal = decimals.ElementAt(index).Data.Decimal,
                    Author = RandomString(3),
                    color = bookColors[i]
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

            DeweyDecimal = new ObservableCollection<DeweyDecimal>(deweyDecimalTemp);

            (this.Content as FrameworkElement).DataContext = this;

            dataGrid.ItemContainerGenerator.StatusChanged += (s, e) =>
            {
                if (dataGrid.ItemContainerGenerator.Status ==
                                    GeneratorStatus.ContainersGenerated)
                {

                    for (int i = 0; i < decimals.Count(); i++)
                    {

                        var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                         .ContainerFromIndex(i);
                        row.Background = decimals.ElementAt(i).Data.color;

                    }
                    
                }
            };

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           