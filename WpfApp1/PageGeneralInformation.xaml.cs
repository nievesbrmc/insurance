using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageGeneralInformation.xaml
    /// </summary>
    public partial class PageGeneralInformation : Page
    {
        public PageGeneralInformation()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new IsCoppelClient());
        }

        private void btnGeneralInformation_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageAddressInformation());
        }
    }
}