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
    /// Interaction logic for Endosos.xaml
    /// </summary>
    public partial class endorsement : Page
    {
        public endorsement(string clientId)
        {
            InitializeComponent();
            NameClient.Content = "Cliente: " + getNameClient(clientId);

            lvEndorsementList.ItemsSource = GetEndorsementList();
        }

        private IEnumerable<EndorsementData> GetEndorsementList()
        {
            return new BLL.EndorsementProcess().GetEndorsementList();
        }

        private static string getNameClient(string clientId)
        {
            return "Yair Lopez";
        }

        private void btnAddEndoso_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new NewEndorsement(""));
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var data = (Entity.EndorsementData)((Button)e.Source).DataContext;
            if (data == null)
            {

            }
            else
            {

            }
        }
    }
}
