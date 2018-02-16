using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CouchBaseHealthCheck
{
    public class HttpClientForRefit
    {
        private readonly CouchBaseServerInfo serverInfo;

        public HttpClientForRefit(CouchBaseServerInfo serverInfo)
        {
            if (serverInfo == null)
                throw new ArgumentNullException(nameof(serverInfo));
            if (string.IsNullOrEmpty(serverInfo.Address))
                throw new ArgumentException("Server address cannot be null nor empty");

            this.serverInfo = serverInfo;
        }

        public HttpClient WithBasicAuthorization()
        {
            var authByteArray = Encoding.ASCII.GetBytes($"{serverInfo.Username}:{serverInfo.Password}");

            var authString = Convert.ToBase64String(authByteArray);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            httpClient.BaseAddress = new Uri(serverInfo.Address);

            return httpClient;
        }
    }

}
