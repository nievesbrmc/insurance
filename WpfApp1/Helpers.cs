using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Helpers
    {
        public static DateTime? GetDate(string request)
        {
            DateTime date = DateTime.ParseExact(request, "dd/MM/yyyy", null);
            return date;
        }
    }
}
