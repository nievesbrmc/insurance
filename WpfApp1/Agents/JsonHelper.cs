using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WpfApp1.Agents
{
    public class JsonHelper
    {
        private const int TIMEOUT = 5;
        public enum JsonVerb { Select, Insert, Update, Delete }

        public static async Task<Entity.TokenData> GetToken()
        {
            Entity.TokenData? tokenData = new Entity.TokenData();
            var client = new RestClient();
            var request = new RestRequest("https://oauth-authorization-api.us-e2.cloudhub.io/token", Method.Post);
            request.AddHeader("client_id", "services-exp");
            request.AddHeader("client_secret", "services-exp123");
            request.AddHeader("grant_type", "CLIENT_CREDENTIALS");
            var response = await client.ExecuteAsync(request).ConfigureAwait(false);
            string? result =  response.Content;
            tokenData = JsonConvert.DeserializeObject<Entity.TokenData>(result, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            //Console.WriteLine(response.Content);
            return tokenData;
        }

        public static object get(Uri url, string token)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Authorization", "Bearer "+token);
            //request.AddHeader("My-Custom-Header", "foobar");
            var response = client.ExecuteGet(request);

            // deserialize json string response to JsonNode object
            var data = System.Text.Json.JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            return data;
        }
        /// <summary>
        /// Controller to send a request 
        /// </summary>
        /// <param name="urlWebApi">Url of service</param>
        /// <param name="path">Part of url</param>
        /// <param name="verJson">Verb to petition</param>
        /// <param name="content">Object to send at service</param>
        /// <param name="userVersionHeader">Indicate if the request use version header</param>
        /// <returns>Response from service</returns>
        public static async Task<HttpResponseMessage> JsonController(string token, Uri urlWebApi, string path, JsonVerb verJson, HttpContent content, bool userVersionHeader)
        {
            return await jsonHelperCoreAsync(token,urlWebApi, path, verJson, content, userVersionHeader).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Call to service
        /// </summary>
        /// <param name="urlWebApi">Uri to service</param>
        /// <param name="path">Path from service</param>
        /// <param name="verJson">verb to call service</param>
        /// <param name="httpContent">content to send service</param>
        /// <param name="userVersionHeader">indicate if the service use a version header</param>
        /// <returns>Result of the process</returns>
        private static async Task<HttpResponseMessage> jsonHelperCoreAsync(string token, Uri urlWebApi, string path, JsonVerb verbJson, HttpContent httpContent, bool useVersionHeader)
         {
            if (!string.IsNullOrEmpty(path))
            {
                Uri webUri = new Uri(string.Concat(urlWebApi.AbsoluteUri, "/", path));
                urlWebApi = webUri;
            }
            using (var client = new HttpClient())
            {
                //client.BaseAddress = urlWebApi;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.Timeout = TimeSpan.FromMinutes(5);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (useVersionHeader)
                {
                    client.DefaultRequestHeaders.Add("Api-Version", "1");
                }

                switch (verbJson)
                {
                    case JsonVerb.Select:
                        return await client.GetAsync(urlWebApi).ConfigureAwait(false);
                    case JsonVerb.Insert:
                        return await client.PostAsync(urlWebApi, httpContent).ConfigureAwait(false);
                    case JsonVerb.Update:
                        return await client.PutAsync(urlWebApi, httpContent).ConfigureAwait(false);
                    default:
                        return await client.DeleteAsync(path).ConfigureAwait(false);
                }
            }
        }
        
        /// <summary>
        /// Send a request to service
        /// </summary>
        /// <param name="urlWebApi">Url to send request</param>
        /// <param name="path">Part from Url</param>
        /// <param name="verJson">Verb to petition</param>
        /// <param name="content">Object send to service</param>
        /// <param name="userVersionHeader">Indicate if the request use a version header</param>
        /// <param name="useLastSlash">Indicate if the requets are last slash in the url</param>
        /// <returns>Response from service</returns>
        private static HttpResponseMessage jsonControllerCore(Uri urlWebApi, string path, JsonVerb verJson, object content, bool userVersionHeader, bool useLastSlash)
        {
            HttpResponseMessage response;
            using(HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                client.DefaultRequestHeaders.Accept.Clear();                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (userVersionHeader)
                {
                    client.DefaultRequestHeaders.Add("Api-Version", "1");
                }

                client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", getVerb(verJson));

                if (!string.IsNullOrEmpty(path))
                {
                    Uri webUri = new Uri(string.Concat(urlWebApi.AbsoluteUri, "/", path, useLastSlash ? "/" : string.Empty));
                    urlWebApi = webUri;
                }
                response = content != null ? client.PostAsJsonAsync(urlWebApi, content).Result : client.GetAsync(urlWebApi).Result;
            }
            return response;
        }
        
        private static string getVerb(JsonVerb verbJson)
        {
            string response = string.Empty;
            switch (verbJson)
            {
                case JsonVerb.Select:
                    response = "GET";
                    break;
                case JsonVerb.Insert:
                    response = "POST";
                    break;
                case JsonVerb.Update:
                    response = "PUT";
                    break;
                case JsonVerb.Delete:
                    response = "DELETE";
                    break;
                default:
                    break;
            }
            return response;
        }
    }
}
