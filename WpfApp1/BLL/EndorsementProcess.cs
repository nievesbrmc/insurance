using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entity;

namespace WpfApp1.BLL
{
    public class EndorsementProcess
    {
        
        public async Task<IEnumerable<Entity.DocumentType>> GetDocumentList()
        {
            List<Entity.DocumentType> documentsList = new List<Entity.DocumentType>();
            Entity.EndorsementList endorsementList = await getEndorsment().ConfigureAwait(false);
            var documents = endorsementList.data;
            documentsList = (from lst in documents
                             select new Entity.DocumentType
                             {
                                 Description = lst.valor,
                                 Id = lst.id
                             }).ToList();
            return documentsList;
        }

        public static async Task<IEnumerable<Entity.PolicyData>> GetPolicyList(int clientId)
        {
            List<Entity.PolicyData> response = new List<Entity.PolicyData>
            {
                new Entity.PolicyData
                {
                    Id=1,
                    Description="Póliza uno"
                },
                new Entity.PolicyData
                {
                    Id=2,
                    Description="Póliza dos"
                }
            };
            return response;
        }

        public async Task<IEnumerable<Entity.DocumentList>> getEndorsment(bool fisicalPerson, int idDocument)
        {
            List<Entity.DocumentList> response = new List<Entity.DocumentList>();
            try
            {
                Entity.EndorsementList endorsementList = await getEndorsment().ConfigureAwait(false);

                if (fisicalPerson)
                {
                    var documentData = endorsementList.data.ToList().FirstOrDefault(x => x.id == idDocument);
                    var documents = documentData.datosRequeridos;
                    response = getDocuments(documents);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return response;
        }
        
        private static List<Entity.DocumentList> getDocuments(List<string> documents)
        {
            List<Entity.DocumentList> response = new List<Entity.DocumentList>();
            foreach (var item in documents)
            {
                response.Add(new Entity.DocumentList
                {
                    DocumentDescription = item,
                    ToolTip = "Descripción"
                });
            }
            return response;
        }
        
        private async Task<Entity.EndorsementList> getEndorsment()
        {
            Entity.EndorsementList endorsementList = new Entity.EndorsementList();
            Entity.TokenData token = await Agents.JsonHelper.GetToken().ConfigureAwait(false);
            Uri api = new Uri("https://service-coppel-pisys-inter-exp-api.us-e2.cloudhub.io/api/catalogo/endosos");
            try
            {
                //var data1 = Agents.JsonHelper.get(api, token);
                HttpResponseMessage response = await Agents.JsonHelper.JsonController(token.access_token,api, string.Empty, Agents.JsonHelper.JsonVerb.Select, null, !true).ConfigureAwait(false);
                if (response.IsSuccessStatusCode & response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = response.Content.ReadAsStringAsync();
                    endorsementList = JsonConvert.DeserializeObject<Entity.EndorsementList>(await data.ConfigureAwait(false), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }); 
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return endorsementList;
        }
    }
}