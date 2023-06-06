using Microsoft.Win32;
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
    /// Interaction logic for NewEndorsement.xaml
    /// </summary>
    public partial class NewEndorsement : Page
    {
        
        public NewEndorsement(string clientId)
        {
            InitializeComponent();
            fillPolicy();
            fillDocuments();
            NameClient.Content = "Cliente: " + getNameClient(clientId);
        }

        private static string getNameClient(string clientId)
        {
            return "Yair Lopez";
        }

        public void fillDocuments()
        {
            var documentslist = new BLL.EndorsementProcess().GetDocumentList();
            DocumentTypes.ItemsSource = documentslist.Result;
            
        }

        public void fillPolicy()
        {
            var policy = BLL.EndorsementProcess.GetPolicyList(1);
            PolicyList.ItemsSource = policy.Result;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DocumentTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DocumentType selectItem = (DocumentType)DocumentTypes.SelectedValue;
            var documents = new BLL.EndorsementProcess().getEndorsment(true, selectItem.Id).Result;
            DocumentsList.ItemsSource = documents;
        }

        private void btnAddEndoso_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".jpg";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
          "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
          "Portable Network Graphic (*.png)|*.png";

            var hasFile = fileDialog.ShowDialog();

            if (hasFile.HasValue && hasFile.Value)
            {
                BitmapImage  image = new BitmapImage(new Uri(fileDialog.FileName));
                string  fullPath = fileDialog.FileName;

                System.IO.FileInfo file = new System.IO.FileInfo(fullPath);
                string newFile = file.Name;
                newFile = Helpers.GetFile(newFile);
                file.CopyTo(newFile,true);
                byte[] fileArray = Helpers.ConvertFileToArray(newFile);
                Window ImagePreview = new ImagePreview(image);
                ImagePreview.WindowStartupLocation = WindowStartupLocation.Manual;
                ImagePreview.Left = 0;
                ImagePreview.Top = 0;
                ImagePreview.Topmost = true;
                ImagePreview.Show();
            }
        }
    }
}