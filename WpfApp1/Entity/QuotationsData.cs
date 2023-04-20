using System.Collections.Generic;

namespace WpfApp1.Entity
{
    public class QuotationsData:Notifications
    {
        public Data data { get; set; }
        public QuotationsData()
        {
            data = new Data();
        }
    }
    public class Data
    {
        public string QuotationId { get; set; }
        public IEnumerable<Quotations> Quotations { get;set;}
    }
    public class Quotations
    {
        public string PaymentMethod { get; set; }
        public int Installments { get; set; }
        public double InsuranceAmount { get; set; }
        public double MonthlyPayment { get; set; }
    }
}