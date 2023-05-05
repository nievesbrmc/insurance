using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Entity.NotClientCoppel data = new Entity.NotClientCoppel();
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
