using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for IsCoppelClient.xaml
    /// </summary>
    public partial class IsCoppelClient : Page
    {
        public IsCoppelClient()
        {
            InitializeComponent();
        }

        private void ClientCoppelYes_Checked(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new FindClientCoppel());
        }

        private void ClientCoppelNo_Checked(object sender, RoutedEventArgs e)
        {
            ClientCoppelYes.IsChecked = false;
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new NotClientCoppel());
        }
    }
}