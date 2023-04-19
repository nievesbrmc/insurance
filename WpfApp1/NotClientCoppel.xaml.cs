using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NotClientCoppel.xaml
    /// </summary>
    public partial class NotClientCoppel : Page
    {
        public NotClientCoppel()
        {
            InitializeComponent();
        }

        private void btnFindClient_Click(object sender, RoutedEventArgs e)
        {
            //avanzar a los datos del telefono
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new FindPhoneToSale());
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new IsCoppelClient());
        }
    }
}
