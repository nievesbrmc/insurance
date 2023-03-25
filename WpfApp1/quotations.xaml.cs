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
    public class Quotation
    {
        public string name { get; set; }
        public string fernando { get; set; }
        public string lastName { get; set; }
        public string secondLastName { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public decimal pricing { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public DateTime soldAt { get; set; }
        public long presaleId { get; set; }
        public int branchId { get; set; }
        public string externalId { get; set; }
    }

    public class data : Notifications
    {
        public string quotationId { get; set; }
        public Quotations quotations { get; set; }
    }

    public class Quotations
    {
        public string paymentMethod { get; set; }
        public string insuranceAmount { get; set; }
        public string installments { get; set; }
    }

    public class BBL
    {
        public data SendRequest(Quotation request)
        {
            data response = new()
            {
                quotations = new Quotations()
            };
            return response;

        }
    }

    /// <summary>
    /// Interaction logic for quotations.xaml
    /// </summary>
    public partial class quotations : Page
    {
        public quotations()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Quotation request = new Quotation
            {
                name = txtName.Text,
                lastName = txtApPaterno.Text,
                secondLastName = txtApMaterno.Text,
                birthDate = DateTime.Parse(calDateBirth.Text),
                email = txtEmail.Text,
                pricing=decimal.Parse(txtPricing.Text),
                brand=txtBrand.Text,
                model=txtModel.Text,
                color=txtColor.Text,
                soldAt=DateTime.Parse(calSoldAt.Text)
            };
            new BBL().SendRequest(request);
        }

        private void calDateBirth_Loaded(object sender, RoutedEventArgs e)
        { 
            DatePicker datePicker = new DatePicker();
            if (datePicker != null)
            {
                System.Windows.Controls.Primitives.DatePickerTextBox datePickerTextBox = FindVisualChild<System.Windows.Controls.Primitives.DatePickerTextBox>(datePicker);
                if (datePickerTextBox != null)
                {

                    ContentControl watermark = (ContentControl)datePickerTextBox.Template.FindName("PART_Watermark", datePickerTextBox);
                    if (watermark != null)
                    {
                        watermark.Content = "Seleccione una fecha";
                    }
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject) where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }


    }
}
