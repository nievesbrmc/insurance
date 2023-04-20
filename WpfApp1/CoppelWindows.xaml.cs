using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CoppelWindows.xaml
    /// </summary>
    public partial class CoppelWindows : Window
    {
        public Entity.ProcessDataDto? ClientData { get; set; }
        public CoppelWindows()
        {
            InitializeComponent();
            this.ClientData = new Entity.ProcessDataDto();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentCoppelWindows = this;
            this.FrameCoppelParent.Navigate(new QuotationsPage(null));
        }
    }
}