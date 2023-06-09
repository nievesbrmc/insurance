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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ImagePreview.xaml
    /// </summary>
    public partial class ImagePreview : Window
    {
        public ImagePreview(BitmapImage path, bool ShowButton)
        {
            InitializeComponent();
            ImageUpload.Source = path;
            if (ShowButton)
            {
                btnRepeat.Visibility = Visibility.Hidden;
                btnOk.Content = "Cerrar";
                btnOk.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
