
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FindClientCoppel.xaml
    /// </summary>
    public partial class FindClientCoppel : Page
    {
        public FindClientCoppel()
        {
            InitializeComponent();
        }

        private void btnFindClient_Click(object sender, RoutedEventArgs e)
        {
           //busca los datos del cliente
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new IsCoppelClient());
        }

        private void btnFindPhone_Click(object sender, RoutedEventArgs e)
        {
            bool findOk = true;

            if (findOk)
            {
                App.ParentCoppelWindows.FrameCoppelParent.Navigate(new FindPhoneToSale());
            }
        }
    }
}
