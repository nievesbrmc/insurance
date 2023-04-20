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
    /// Interaction logic for Quotations.xaml
    /// </summary>
    public partial class QuotationsPage : Page
    {
        public QuotationsPage(RequestQuotation quotationData)
        {
            InitializeComponent();
            QuotationsData response = SendData(quotationData);
            GeneralConfigurations conf = Helpers.GetConfigurations();
            QuotationsList.ItemsSource = response.data.Quotations.Skip(conf.QuotationsList).Take(conf.QuotationsList);
        }
        private static QuotationsData SendData(RequestQuotation quotationData)
        {
            QuotationsData response;

            /*Send data to service*/

            /*Response data from service*/
            response = new QuotationsData
            {
                data = new Data
                {
                    QuotationId = "b95cf17c-46f8-4cdc-84b1-fa52caddffba",
                    Quotations = new List<Quotations>()
                    {
                        new Quotations
                        {
                            PaymentMethod = "CONTADO",
                            Installments = 1,
                            InsuranceAmount = 2185.50,
                            MonthlyPayment = 2185.50
                        },
                         new Quotations
                        {
                            PaymentMethod = "CREDITO",
                            Installments = 12,
                            InsuranceAmount = 2185.50,
                            MonthlyPayment = 182.12
                        },
                          new Quotations
                        {
                            PaymentMethod = "CREDITO",
                            Installments = 18,
                            InsuranceAmount = 3278.25,
                            MonthlyPayment = 182.12
                        }                          ,
                        new Quotations
                        {
                            PaymentMethod = "CREDITO",
                            Installments = 24,
                            InsuranceAmount = 4371.00,
                            MonthlyPayment = 182.12
                        },
                         new Quotations
                        {
                            PaymentMethod = "CREDITO",
                            Installments = 30,
                            InsuranceAmount = 5463.75,
                            MonthlyPayment = 182.12
                        },
                         new Quotations
                        {
                            PaymentMethod = "CREDITO",
                            Installments = 36,
                            InsuranceAmount = 6556.50,
                            MonthlyPayment = 182.12
                        }
                    }
                },
                Code = "VE-000",
                Message = "Cotización efectuada correctamente.",
                TimeStamp = DateTime.Today
            };
            return response;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
