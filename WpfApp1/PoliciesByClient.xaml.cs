using RawPrint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Printing;
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
    /// Lógica de interacción para PoliciesByClient.xaml
    /// </summary>
    public partial class PoliciesByClient : Page
    {
        public int? ClientIdentifier;
        bool policyToPrint = false;
        Policies itemSelect = new Policies();

        public PoliciesByClient()
        {
            InitializeComponent();
            ClientIdentifier = 0442517923;
            lvData.ItemsSource = DataSource.GetData;
            cmbDocument.ItemsSource = DataSource.GetDocumentType;
            cmbDocument.SelectedIndex = 0;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Policies itemSelect = (Policies)lvData.SelectedItem;
            policyToPrint = cmbDocument.SelectedIndex == 1 ? true : false;
            if (policyToPrint && itemSelect != null && !string.IsNullOrEmpty(itemSelect.urlpdfpoliza) && !string.IsNullOrEmpty(itemSelect.id_poliza))
            {
                print(getPdf(itemSelect.urlpdfpoliza, itemSelect.id_poliza));
            }
            else
            {
                print(GetFile(itemSelect.id_recibo, "pdf", GetTicket(itemSelect.id_recibo)));
            }
        }
        
        //private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
                      
        //}
        private void print(string pathFile)
        {
            try
            {
                //Process p = new Process();
                //p.StartInfo = new ProcessStartInfo()
                //{
                //    CreateNoWindow = true,
                //    Verb = "print",
                //    FileName = pathFile
                //};
                //p.Start();
                IPrinter  printer = new Printer();
                string defaultPrint = GetDefaultPrinterName();
                printer.PrintRawFile(defaultPrint, pathFile, "poliza");
            }
            catch (Exception ex)
            {
                string messageBoxText = "Asegurese de tener instalado PdfReader";
                string caption = "Error al imprimir";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        public static string GetDefaultPrinterName()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_Printer");
            var searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in searcher.Get())
            {
                if (((bool?)mo["Default"]) ?? false)
                {
                    return mo["Name"] as string;
                }
            }

            return null;
        }

        private string getPdf(string url, string numPolicy)
        {
            WebClient client = new WebClient();
            byte[] buff = client.DownloadData(new Uri(url));
            string pathFile = GetFile(numPolicy, "pdf", buff);
            return pathFile;
        }
        private string GetFile(string fileName,string ext, byte[] file)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string pathFile = string.Concat(path,@"\Image\",fileName,".",ext);
            System.IO.File.WriteAllBytes(pathFile, file);
            return pathFile;
        }
        private byte[] GetTicket(string idTicket)
        {
            byte[] response = null;
            try
            {
                Tickets ticket = new Tickets
                {
                    code = "200",
                    response = "true",
                    mensaje = "",
                    id_recibo = idTicket,
                    recibo = null,
                };
                response = ticket.recibo;
            }
            catch (Exception ex)
            {
                string messageBoxText = "Error al obtener el recibo.";
                string caption = "Servicio n responde";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            return response;
        }
    }

    public class DataSource
    {
        public static IEnumerable<Policies> GetData
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string pathImage = path + @"\Image\casco.png";

                return new List<Policies>
                {
                  new Policies
                  {
                      Image=pathImage      ,
                       id_poliza="0253QXH02",
                       des_seguro="seguro RC",
                       id_recibo="N° 12523",
                       des_articulo="Vento xr-123 2023",
                       num_serie="125235475",
                       des_estatus="A",
                       urlpdfpoliza="https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
                       des_siniestro="false",
                       id_tipointngible="1"
                  } ,
                  new Policies
                  {
                      Image=pathImage      ,
                       id_poliza="0253QXH02",
                       des_seguro="SEGURO PLUS",
                       id_recibo="12523",
                       des_articulo="Italica xr-123 2023",
                       num_serie="125235475",
                       des_estatus="A",
                       urlpdfpoliza="https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
                       des_siniestro="false",
                       id_tipointngible="1"
                  }
                };
            }
        }
        public static IEnumerable<DocumentsTypes> GetDocumentType
        {
            get
            {
                return new List<DocumentsTypes>
                {
                    new DocumentsTypes
                    {
                        IdDocument=1,
                        DocumentType="Recibo"
                    },
                    new DocumentsTypes
                    {
                        IdDocument=2,
                        DocumentType="Póliza"
                    }
                };
            }
        }
    }
    public class Tickets
    {
        public string? code { get; set; }
        public string? response { get; set; }
        public string? mensaje { get; set; }
        public string? id_recibo { get; set; }
        public byte[]? recibo { get; set; }
    }

    public class Policies
    {
        public string? Image { get; set; }
        public string? id_poliza { get; set; }
        public string? des_seguro { get; set; }
        public string? id_recibo { get; set; }
        public string? des_articulo { get; set; }
        public string? num_serie { get; set; }
        public string? des_estatus { get; set; }
        public string? urlpdfpoliza { get; set; }
        public string? des_siniestro { get; set; }
        public string? id_tipointngible { get; set; }
    }
    public class DocumentsTypes
    {
        public int? IdDocument { get; set; }
        public string? DocumentType { get; set; }
    }

}
