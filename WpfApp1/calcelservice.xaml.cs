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
using WpfApp1.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para calcelservice.xaml
    /// </summary>
    public partial class calcelservice : Page
    {
        public string policyNumber;
        public string external;
        public calcelservice(string policeNumber, string externalid)
        {
            policyNumber = policeNumber;
            external = externalid;
            InitializeComponent();
            //fill combo
            comboreasons.ItemsSource = new BLL.CalceledData().getReasons;
        }

        private async void send_Click(object sender, RoutedEventArgs e)
        {
            ReasonCatalog combo =(ReasonCatalog)comboreasons.SelectedItem;
            requestService DATA = new requestService
            {
                date = DateTime.Now.ToString("yyyy-MM-dd"),
                externalId = external,
                policyNumber = policyNumber,
                reason = combo.codigo,
                reasonDetails = combo.descripcion
            };

            response txt = await new BLL.CalceledData().sendCancelService(DATA).ConfigureAwait(false);
            //lblmsg.Content = txt;
        }
    }
}
