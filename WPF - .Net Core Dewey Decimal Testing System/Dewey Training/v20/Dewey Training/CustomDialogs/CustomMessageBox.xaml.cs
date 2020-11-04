using System.Windows;
using System.Windows.Input;

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
