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
            this.FrameCoppelParent.Navigate(new calcelservice("05.0201084545002742", "CPC-0900fc0a0-aa7b-4e2f-a5a1-8c28c7da0013-prod"));
        }
    }
}