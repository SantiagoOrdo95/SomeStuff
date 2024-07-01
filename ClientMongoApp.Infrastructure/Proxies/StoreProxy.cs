using ClientMongoApp.Core.Entities;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientMongoApp.Infrastructure.Proxies
{
    public static class StoreProxy
    {
        public static readonly HttpClient client = new();
        public static readonly string protocol = "http://";

        private static CredentialCache GetCredentialCache(string ipAddress, string user, string password)
        {
            CredentialCache credentialCache = new()
            {
                { new Uri($"{protocol}{ipAddress}"), "Digest", new NetworkCredential(user, password) }
            };
            return credentialCache;
        }

        private static StringContent GetStringContent(string stringcontent)
        {

            return new StringContent(stringcontent, Encoding.UTF8, "text/xml");
        }

        public static async Task<Store> GetStoreById(string ipAddress, string user, string password)
        {
            try
            {
                using var httpClient = new HttpClient(new HttpClientHandler { Credentials = GetCredentialCache(ipAddress, user, password)});
                var answer = await httpClient.GetAsync(new Uri($"{protocol}{ipAddress}/store/GetStore"));
                var result = answer.Content.ReadAsStringAsync().Result;

                Store store;
                XmlSerializer serializer = new XmlSerializer(typeof(Store));
                using (StringReader reader = new(result))
                {
                    store = (Store)serializer.Deserialize(reader);
                }

                return store;
            }
            catch (HttpRequestException ex)
            {
                return new Store() { ConnectionStatus = ex.Message };
            }
        }
    }
}
