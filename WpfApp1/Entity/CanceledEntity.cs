using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    public class ReasonCatalog
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class requestService
    {
        public string policyNumber { get; set; }
        public string date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int reason { get; set; }
        public string reasonDetails { get; set; }
        public string externalId { get; set; } 
    }

    public class response
    {
                         public notifications data { get; set; }
    }
    public class notifications
    {
        public string code { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
    }
}
