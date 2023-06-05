using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        private async Task<string> Gettoken()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "oauth-authorization-api.us-e2.cloudhub.io/token");
            request.Headers.Add("client_id", "services-exp");
            request.Headers.Add("client_secret", "services-exp123");
            request.Headers.Add("grant_type", "CLIENT_CREDENTIALS");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
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
                    var documents = documentData.datosRequeridos.Split(",");
                    response = getDocuments(documents);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return response;
        }
        
        private static List<Entity.DocumentList> getDocuments(string[] documents)
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
            //string token = await Gettoken();
            Uri api = new Uri("https://service-coppel-pisys-inter-exp-api.us-e2.cloudhub.io/api/catalogo/:utilidad");
            try
            {
                HttpResponseMessage response = await Agents.JsonHelper.JsonController(api, string.Empty, Agents.JsonHelper.JsonVerb.Select, null, true).ConfigureAwait(false);
                if (response.IsSuccessStatusCode & response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = response.Content.ReadAsStringAsync();
                    endorsementList = JsonConvert.DeserializeObject<Entity.EndorsementList>(await data.ConfigureAwait(false), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }); 
                }
                endorsementList = new Entity.EndorsementList
                {
                    codigo = "200",
                    response = true,
                    mensaje = "ok",
                    data = new List<DocumentData>
                    {
                        new DocumentData
                        {
                            id=1,
                            valor="ACTUALIZACION DE CORREO ELECTRÓNICO",
                            descripcion="",
                            RequiredDocument=new RequiredDocument
                            {
                                FisicalPerson=new FisicalPerson
                                {
                                    DocumentsVehicle=null,
                                    DocumentInsured=null,
                                    DocumentQualitas=null
                                },
                                MoralPerson =new MoralPerson
                                {
                                    DocumentsVehicle=null,
                                    DocumentInsured=null,
                                    DocumentQualitas=null
                                }
                            },
                            datosRequeridos="Correo"
                        },
                        new DocumentData
                        {
                            id=2,
                            valor="ACTUALIZACIÓN DE TELÉFONO",
                            descripcion="",
                            RequiredDocument=new RequiredDocument
                            {
                                FisicalPerson=new FisicalPerson
                                {
                                    DocumentsVehicle=null,
                                    DocumentInsured=null,
                                    DocumentQualitas=null
                                },
                                MoralPerson =new MoralPerson
                                {
                                    DocumentsVehicle=null,
                                    DocumentInsured=null,
                                    DocumentQualitas=null
                                }
                            },
                            datosRequeridos="Numero telefonico"
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return endorsementList;
        }
    }
}