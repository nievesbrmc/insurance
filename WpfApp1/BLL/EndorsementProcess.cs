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
        public IEnumerable<EndorsementData> GetEndorsementList()
        {
            IEnumerable<EndorsementData> response = new List<EndorsementData>
            {
                new EndorsementData
                {
                    Id=349867,
                    Status="Activo",
                    DateRegister=DateTime.Now.ToString("dd-MM-yyyy"),
                    Judgment="Inicio del trámite",
                    ColorStatus="Green",
                    data=new DocumentData
                    {
                        id=1,
                        valor="ACTUALIZACION DE CORREO ELECTRÓNICO",
                        datosRequeridos=new List<string>
                        {
                            "Correo"
                        },
                        documentosRequeridos=new RequiredDocument
                        {
                            personaFisica=new FisicalPerson
                            {
                                documentosAsegurado="correo@gmail.com"
                            }
                        }
                    }
                },
                new EndorsementData
                {
                    Id=349898,
                    Status="Cancelado",
                    DateRegister=DateTime.Now.ToString("dd-MM-yyyy"),
                    Judgment="Tramite rechazado",
                    ColorStatus="Green",
                    data=new DocumentData
                    {
                        id=2,
                        valor="ACTUALIZACIÓN DE TELÉFONO",
                        datosRequeridos=new List<string>
                        {
                            "Numero Telefono"
                        },
                        documentosRequeridos=new RequiredDocument
                        {
                            personaFisica=new FisicalPerson
                            {
                                documentosAsegurado="5585984875"
                            }
                        }
                    }
                },
                new EndorsementData
                {
                    Id=3498999,
                    Status="Cancelado",
                    DateRegister=DateTime.Now.ToString("dd-MM-yyyy"),
                    Judgment="Tramite rechazado",
                    ColorStatus="Green",
                    data=new DocumentData
                    {
                        id=4,
                        valor="CANCELACIÓN DE LA POLIZA",
                        datosRequeridos=new List<string>
                        {
                            "Carta solicitud del cliente",
                            "Identificacion oficial"
                        },
                        documentosRequeridos=new RequiredDocument
                        {
                            personaFisica=new FisicalPerson
                            {
                                documentosAsegurado=""
                            }
                        }
                    }
                }
            };

            response.ToList().ForEach(item => item.ButtonText = item.Status == "Activo" ? "Ver solicitud" : "Ver dictamen");
            return response;
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentList(EndorsementData? data)
        {
            List<DocumentType> documentsList = new();
            IEnumerable<DocumentData> documents;
            if (data==null)
            {
                EndorsementList endorsementList = await getEndorsment().ConfigureAwait(false);
                documents = endorsementList.data;
            }
            else
            {
                documents = new List<DocumentData>
                {
                    new DocumentData
                    {
                       id= data.data.id,
                       descripcion=data.data.valor,
                       valor=data.data.valor
                    }
                };
            }

            documentsList = (from lst in documents
                             select new DocumentType
                             {
                                 Description = lst.valor,
                                 Id = lst.id
                             }).ToList();
            return documentsList;
        }

        public static async Task<IEnumerable<PolicyData>> GetPolicyList(int clientId)
        {
            List<PolicyData> response = new List<PolicyData>
            {
                new PolicyData
                {
                    Id=1,
                    Description="Póliza uno"
                },
                new PolicyData
                {
                    Id=2,
                    Description="Póliza dos"
                }
            };
            return response;
        }

        public async Task<IEnumerable<DocumentList>> getEndorsment(bool fisicalPerson, int? idDocument, EndorsementData? data)
        {
            List<DocumentList> response = new();
            List<string> documents = new();
            try
            {
                if (data != null)
                {
                    documents = data.data.datosRequeridos;
                    response = getDocuments(documents, true, data.data.documentosRequeridos, data.data.id);
                }
                else
                {
                    EndorsementList endorsementList = await getEndorsment().ConfigureAwait(false);
                    if (fisicalPerson)
                    {
                        var documentData = endorsementList.data.ToList().FirstOrDefault(x => x.id == idDocument);
                        documents = documentData.datosRequeridos;
                        response = getDocuments(documents, false, null, documentData.id);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return response;
        }
        
        private static List<DocumentList> getDocuments(List<string> documents, bool fillValue, RequiredDocument? documentValue, int documentTypeId)
        {
            List<DocumentList> response = new();
            foreach (var item in documents)
            {
                response.Add(new DocumentList
                {
                    DocumentDescription = item,
                    ToolTip = "Descripción",
                    FillValue = fillValue,
                    Value = documentValue == null ? String.Empty : documentValue.personaFisica.documentosAsegurado,
                    TextInput = getFormatItem(documentTypeId) ? "Visible" : "Hidden",
                    BtnUpload = getFormatItem(documentTypeId) ? "Hidden" : "Visible",
                    BtnText = fillValue ? "Ver" : "Cargar documento",
                });
            }
            return response;
        }
        
        private static bool getFormatItem(int value)
        {
            Dictionary<int, bool> data = new Dictionary<int, bool>();
            data.Add(1, true);
            data.Add(2, true);
            data.Add(3, true);
            data.Add(4, !true);
            data.Add(5, true);
            data.Add(6, !true);
            data.Add(7, !true);
            data.Add(8, !true);
            data.Add(9, !true);
            data.Add(10, !true);
            data.Add(11, !true);
            return data[value];
        }
        private async Task<EndorsementList> getEndorsment()
        {
            EndorsementList endorsementList = new EndorsementList();
            TokenData token = await Agents.JsonHelper.GetToken().ConfigureAwait(false);
            Uri api = new Uri("https://service-coppel-pisys-inter-exp-api.us-e2.cloudhub.io/api/catalogo/endosos");
            try
            {
                //var data1 = Agents.JsonHelper.get(api, token);
                HttpResponseMessage response = await Agents.JsonHelper.JsonController(token.access_token,api, string.Empty, Agents.JsonHelper.JsonVerb.Select, null, !true).ConfigureAwait(false);
                if (response.IsSuccessStatusCode & response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = response.Content.ReadAsStringAsync();
                    endorsementList = JsonConvert.DeserializeObject<EndorsementList>(await data.ConfigureAwait(false), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }); 
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