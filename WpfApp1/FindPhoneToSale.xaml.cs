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
    /// Interaction logic for FindPhoneToSale.xaml
    /// </summary>
    public partial class FindPhoneToSale : Page
    {
        public FindPhoneToSale()
        {
            InitializeComponent();
        }

        private void btnFindData_Click(object sender, RoutedEventArgs e)
        {
            //valida si hay información respecto al sku
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new IsCoppelClient());
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //Valida si el telefono tiene opcion a seguro y lo ma manda a la cotizacion, si no salta ese paso y lo manda a la venta
            bool insure = true;
            if (insure)
            {
                App.ParentCoppelWindows.FrameCoppelParent.Navigate(new PageGeneralInformation());
            }
            else
            {
                //lo manda a cerrar la venta
            }
        }
    }
}
