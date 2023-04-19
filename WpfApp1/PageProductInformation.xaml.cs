using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PageProductInformation.xaml
    /// </summary>
    public partial class PageProductInformation : Page
    {
        public PageProductInformation()
        {
            InitializeComponent();
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageAddressInformation());
        }

        private void btnSendData_Click(object sender, RoutedEventArgs e)
        {
            //Generar venta con seguro
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageAddressInformation());
        }
    }
}