using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dewey_Training.CustomDialogs
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {

        public CustomMessageBox(string messageContent, string messageHeader)
        {

            InitializeComponent();

            Message.Content = messageContent;
            MessageHeader.Content = messageHeader;

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Enables window dragging on the top portion of the window
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }

}
