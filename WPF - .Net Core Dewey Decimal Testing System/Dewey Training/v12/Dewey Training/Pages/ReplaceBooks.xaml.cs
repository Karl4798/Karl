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
using static Dewey_Training.Services.DataGridExtension;

namespace Dewey_Training.Pages
{
    /// <summary>
    /// Karl Dicks - 17667327
    /// </summary>
    public partial class ReplaceBooks : Page
    {

        // Observable list used to store elements for visual display
        public ObservableCollection<DeweyDecimal> DeweyDecimal { get; set; }

        // Doubly Linked list used for storing dewey decimal values (objects)
        LinkedList decimals = new LinkedList();

        // Doubly Linked list used for storing dewey decimal values(objects) in the correct order
        LinkedList orderedDeweyDecimals = new LinkedList();

        // List<T> used to store the dewey decimals temporarily for comparisons
        public static List<string> orderedDeweyDecimalsString = new List<string>();

        // Timer
        DispatcherTimer dispatcherTimer;

        // Variables used to store time
        private int time;
        private int totalTime;

        // Constructor
        public ReplaceBooks()
        {

            InitializeComponent();

            // Generates random dewey decimal call numbers (e.g. ###.#### ABC)
            GenerateBooks();

            // Sets the times for difficulty level, and labels
            SetTimerLabel();

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

        // Detects changes to the datagrid (dragged rows),
        // which in turn determines if the order is, or is
        // not, correct for the provided list of call numbers
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Checks the current book order
            CheckOrder();

        }

        // Checks the current book order
        private void CheckOrder()
        {

            // Variables used to store user defined book order
            List<string> decimals = new List<string>();
            List<string> authors = new List<string>();
            List<string> userSelection = new List<string>();

            // Try / catch used for the dragging of rows in the data grid
            try
            {

                // Gets all rows from the data grid
                var rows = GetDataGridRows(dataGrid);

                // Iterates through all rows in the data grid, and extracts information
                // to determine if the order of the books is correct
                foreach (DataGridRow row in rows)
                {

                    // Iterates through all columns in the data grid, and extracts information
                    // from each cell
                    foreach (DataGridColumn column in dataGrid.Columns)
                    {

                        // Ensures the cell is valid
                        if (column.GetCellContent(row) is TextBlock)
                        {

                            // Gets the cell content
                            TextBlock cellContent = column.GetCellContent(row) as TextBlock;

                            // If the cell content length of characters is three, then the cell
                            // must contain the first three letters of the author's surname
                            // Add this to the list of authors
                            if (cellContent.Text.Split(" ")[0].Length == 3)
                            {
                                authors.Add(cellContent.Text);
                            }

                            // Else the cell contents must contain the dewey decimal value,
                            // and therefore store this content in the list of authors
                            else
                            {
                                decimals.Add(cellContent.Text);
                            }

                        }
                    }

                }

                // Add the current state of the data grid to a list of "rows"
                for (int i = 0; i < decimals.Count; i++)
                {

                    userSelection.Add(decimals[i] + " " + authors[i]);

                }

                // Determines if the user defined order is equal to that of the correct order
                bool equal = userSelection.SequenceEqual(orderedDeweyDecimalsString);

                // If the order of the dewey decimals are correct, then stop the timer,
                // navigate the user to a confirmation page, and reset the timer
                if (equal)
                {

                    // Stop the timer
                    dispatcherTimer.Stop();

                    // Navigate the user to a confirmation page
                    this.NavigationService.Navigate(new ReorderComplete((totalTime - time).ToString(), orderedDeweyDecimalsString));

                    // Reset the timer
                    time = totalTime;

                }

            }

            // Catch any errors when dragging rows, while re-ordering the call numbers,
            // and display the error in the console
            catch (Exception ex)
            {

                // Catch the error and display it in console logs
                Console.WriteLine(ex.Message);

            }

        }

        // Method used to handle the "Start" button press and "Reset" button press
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            // If the game / training has already started, then the button name would
            // have changed to "Restart".
            // In this case, stop the timer, reset the timer, foreground color of the timer text,
            // and reset the timer labels and values
            if (Start.Content.Equals("Restart"))
            {
                dispatcherTimer.Stop();
                time = totalTime;
                TimerLabel.Foreground = Brushes.White;
                SetTimerLabel();
            }

            // Enable the data grid, so the users can re-order rows (book call numbers)
            dataGrid.IsEnabled = true;

            // Randomly generate call numbers (books)
            GenerateBooks();

            // Start a new instance of the timer, and start counting down in seconds
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += Dt_Tick;
            dispatcherTimer.Start();

            // Change the text of the "Start" button to "Restart"
            Start.Content = "Restart";

        }

        // This method is called each time the timer "ticks" for every second
        private void Dt_Tick(object sender, EventArgs e)
        {

            // If the timer has more than one second, then run the below logic,
            // else stop the timer and navigate the user to a confirmation page
            // If the timer reaches 0 seconds, the user would have lost the game,
            // as the user is navigated to the confirmation page automatically,
            // as soon as they re-order the books correctly.
            if (time > 0)
            {

                // If the timer has reached less than or equal to 10 seconds,
                // then alternate foreground text color between white and red
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

                // Stop the timer
                dispatcherTimer.Stop();

                // Navigate the user to confirmation page
                this.NavigationService.Navigate(new ReorderComplete(null, orderedDeweyDecimalsString));

            }

        }

        // Randomly generate dewey decimal call numbers (books)
        private void GenerateBooks()
        {

            // Clear values from previous games / training sessions
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

            // Obtain a new random integer between 0 and 4
            int randomValue = Int32.Parse(RandomNumber(0, 4, false));

            // Generate dewey decimals, and randomize number of decimal places
            for (int i = 0; i < 10 - randomValue; i++)
            {

                decimals.Add(new DeweyDecimal()
                {
                    Decimal = RandomNumber(0, 999, true) + "." + RandomNumber(0, 9999, false),
                    Author = RandomString(3)
                });

            }

            // Generate dewey decimals, and randomize number of decimal places
            for (int i = 0; i < randomValue; i++)
            {

                int index = Int32.Parse(RandomNumber(0, 10 - randomValue, false));
                decimals.Add(new DeweyDecimal()
                {
                    Decimal = decimals.ElementAt(index).Data.Decimal,
                    Author = RandomString(3)
                });

            }

            // Start ordering the dewey decimal call numbers in their correct order
            orderedDeweyDecimals = decimals;

            // Determine the correct order for the Dewey Decimals by number (decimal)
            orderedDeweyDecimals.BubbleSort();

            // Determine the order for the dewey decimals by author (switch the authors to be in ascending order)
            orderedDeweyDecimals = AlphabetOrder(orderedDeweyDecimals);

            // Add all ordered dewey decimal values to a List<T> for comparisons
            foreach (var item in orderedDeweyDecimals)
            {

                orderedDeweyDecimalsString.Add(item.Data.Decimal + " " + item.Data.Author);

            }

            // Temporary Observable collection used to store dewey decimals for display
            ObservableCollection<DeweyDecimal> deweyDecimalTemp = new ObservableCollection<DeweyDecimal>();

            // Add all the elements in "decimals" to the Observable collection
            foreach (var item in decimals)
            {
                deweyDecimalTemp.Add(item.Data);
            }

            // Shuffle the temporary dewey decimal list
            deweyDecimalTemp.Shuffle();

            // Set the global (class) DeweyDecimal variable for output data binding
            DeweyDecimal = new ObservableCollection<DeweyDecimal>(deweyDecimalTemp);

            // Set the data context to "this", so that the data grid values
            // are bound to DeweyDecimal Observable collection
            (this.Content as FrameworkElement).DataContext = this;

        }

        // Method used to handle the "Return" button click event
        private void Return_Click(object sender, RoutedEventArgs e)
        {

            // If the timer is not null, then stop it - e.g. reset it
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }

            // Navigate the user to the menu page
            this.NavigationService.Navigate(new MenuPage());

        }

    }

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           