using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entity;
using System.Windows.Documents;

namespace WpfApp1.BLL
{
    public class CalceledData
    {
        public async Task<response> sendCancelService(requestService data)
        {
            TokenCanceledService token = await getToken().ConfigureAwait(false);
            Uri api = new Uri("http://vps-afca919a.vps.ovh.ca:8084/api/v1/seguro/celulares/cancelacion");
            response notify = new response();
            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Agents.JsonHelper.JsonController(token.token, api, string.Empty, Agents.JsonHelper.JsonVerb.PATCH, httpContent, !true).ConfigureAwait(false);
                var result = response.Content.ReadAsStringAsync();
                notify = JsonConvert.DeserializeObject<response>(await result.ConfigureAwait(false), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return notify;
        }

        public async Task<TokenCanceledService> getToken()
        {
            return await Agents.JsonHelper.GetCanceledToken().ConfigureAwait(false);
        }

        public IEnumerable<ReasonCatalog> getReasons
        {
            get
            {
                List<ReasonCatalog> reasonCatalogs = new List<ReasonCatalog>
                {
                    new ReasonCatalog
                    {
                         codigo=2,
                         descripcion="Ya no pudo pagar"
                    },
                    new ReasonCatalog
                    {
                         codigo=5,
                         descripcion="se le hace caro"
                    },
                    new ReasonCatalog
                    {
                         codigo=3,
                         descripcion="no entiendo"
                    },
                    new ReasonCatalog
                    {
                         codigo=9,
                         descripcion="yo no contrate"
                    }
                };
                return reasonCatalogs;
            }
        }
    }
}
