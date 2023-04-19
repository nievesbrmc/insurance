using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddressInformation.xaml
    /// </summary>
    public partial class PageAddressInformation : Page
    {
        public PageAddressInformation()
        {
            InitializeComponent();
        }

        private void btnContactInformation_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageProductInformation());
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageGeneralInformation());
        }
    }
}