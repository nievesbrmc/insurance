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
            bool findOk = true;

            if (findOk)
            {
                App.ParentCoppelWindows.FrameCoppelParent.Navigate(new ClientCoppelData());
            }
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows.FrameCoppelParent.Navigate(new IsCoppelClient());
        }
    }
}
