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
            if (!string.IsNullOrEmpty(request))
            {
                DateTime date = DateTime.ParseExact(request, "dd/MM/yyyy", null);
                return date;
            }
            return default;
        }

        public static bool yearsOldValidate(DateTime? yearsOld)
        {
            DateTime? old = yearsOld;
            DateTime? now = DateTime.Today.AddYears(-18);
            bool response = old > now;
            return response;
            
        }
    }
}
