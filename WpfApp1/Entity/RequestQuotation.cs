using System;

namespace WpfApp1.Entity
{
    public class RequestQuotation
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Decimal Pricing { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime SoldAt { get; set; }
        public string PresaleId { get; set; }
        public string BrachId { get; set; }
        public string ExternalId { get; set; }
    }
}