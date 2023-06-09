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
        
        public NewEndorsement(string clientId, EndorsementData? data)
        {
            InitializeComponent();
            fillDocuments(data);
            if (data != null)
            {
                var documents = GetEndosmentList(default, data);
                DocumentsList.ItemsSource = documents;

                PolicyList.SelectedIndex = 0;
                btnAceptar.Visibility = Visibility.Hidden;
            }
            fillPolicy();
            NameClient.Content = "Cliente: " + getNameClient(clientId);
        }

        private static string getNameClient(string clientId)
        {
            return "Yair Lopez";
        }

        public void fillDocuments(EndorsementData? data)
        {
            var documentslist = new BLL.EndorsementProcess().GetDocumentList(data);
            DocumentTypes.ItemsSource = documentslist.Result;
            if (data!=null)
            {
                DocumentTypes.SelectedIndex = 0;
            }
        }

        public void fillPolicy()
        {
            var policy = BLL.EndorsementProcess.GetPolicyList(1);
            PolicyList.ItemsSource = policy.Result;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private IEnumerable<DocumentList> GetEndosmentList(int? Id, EndorsementData? data)
        {
            return new BLL.EndorsementProcess().getEndorsment(true, Id, data).Result;
        }

        private void DocumentTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DocumentType selectItem = (DocumentType)DocumentTypes.SelectedValue;
            var documents = GetEndosmentList(selectItem.Id, null);
            DocumentsList.ItemsSource = documents;
        }

        private void btnAddEndoso_Click(object sender, RoutedEventArgs e)
        {
            var document = (DocumentList)((Button)e.Source).DataContext;

            if (document.FillValue)
            {
                //muestra la imagen
            }
            else
            {

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.DefaultExt = ".jpg";
                fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

                var hasFile = fileDialog.ShowDialog();

                if (hasFile.HasValue && hasFile.Value)
                {
                    BitmapImage image = new BitmapImage(new Uri(fileDialog.FileName));
                    string fullPath = fileDialog.FileName;

                    System.IO.FileInfo file = new System.IO.FileInfo(fullPath);
                    string newFile = file.Name;
                    newFile = Helpers.GetFile(newFile);
                    file.CopyTo(newFile, true);
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

        private void btnVerEndoso_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}