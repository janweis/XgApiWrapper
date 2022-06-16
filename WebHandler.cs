using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace XgApiWrapper
{
    public class WebHandler
    {
        private readonly HttpClient WebClient = new HttpClient();

        public WebHandler()
        {
            // Create Webhandler configuration for ignoring invalid certificates
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };

            WebClient = new HttpClient(handler);
        }

        /// <summary>
        /// Send GET Request to Webserver
        /// </summary>
        public async Task<string> SubmitConnectionStringAsync(string connectionString)
        {
            return await WebClient.GetStringAsync(connectionString);
        }

        /// <summary>
        /// Build Connection String URI
        /// </summary>
        public string BuildConnectionString(string xmlRequest, Connection connection)
        {
            return $"https://{connection.IPAddress}:{connection.Port}/webconsole/APIController?reqxml={xmlRequest}";
        }
    }
}
