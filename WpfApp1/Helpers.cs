using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static Entity.GeneralConfigurations GetConfigurations()
        {
            string path = GetFile("configurations.json");
            Entity.GeneralConfigurations items = new Entity.GeneralConfigurations();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Entity.GeneralConfigurations>(json);
                items.QuotationsList = 3;
            }
            return items;
        }
        public static string GetFile(string nameFile)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string pathFull = path + nameFile;
            return pathFull;
        }

        public static byte[] ConvertFileToArray(string pathOfFile)
        {
            byte[] response = null;
            if (!string.IsNullOrEmpty(pathOfFile))
            {
                string pathFile = (pathOfFile);
                if (File.Exists(pathFile))
                {
                    response = File.ReadAllBytes(pathFile);
                }
            }
            return response;
        }
    }
}
