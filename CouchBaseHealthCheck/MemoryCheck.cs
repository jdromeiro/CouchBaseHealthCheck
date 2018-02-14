using Nimator;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck
{
    class MemoryCheck : ICheck
    {
        private readonly CouchBaseServerInfo serverInfo;
        private readonly decimal minPercAvailableMemory;

        public string ShortName { get; }

        public MemoryCheck(CouchBaseServerInfo serverInfo,  decimal minPercAvailableMemory)
        {
            if (serverInfo == null)
                throw new ArgumentNullException(nameof(serverInfo));
            if (minPercAvailableMemory < 0)
                throw new ArgumentException("Minimum percentage of available memory cannot be negative");
            if (string.IsNullOrEmpty(serverInfo.Address))
                throw new ArgumentException("Server address cannot be null nor empty");

            this.serverInfo = serverInfo;
            this.minPercAvailableMemory = minPercAvailableMemory;

            ShortName = $"Memory available in the cluster with address '{serverInfo.Address}'";
        }

        public Task<ICheckResult> RunAsync()
        {
            //authentication
            var authByteArray = Encoding.ASCII.GetBytes($"{serverInfo.Username}:{serverInfo.Password}");
            var authString = Convert.ToBase64String(authByteArray);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            httpClient.BaseAddress = new Uri(serverInfo.Address);

            //rest Api
            var couchBaseApi = RestService.For<Stats.ICouchBaseAPI>(httpClient);
            var nodeStats = couchBaseApi.GetNodeStats().Result;

            //compute values
            var memFree = nodeStats.nodes[0].systemStats.mem_free;
            var memTotal = nodeStats.nodes[0].systemStats.mem_total;
            var percMemAvailable = (decimal)memFree / (decimal)memTotal * (decimal)100.0;

            //calculate notification level
            var level = (percMemAvailable >= minPercAvailableMemory)
                ? NotificationLevel.Okay
                : NotificationLevel.Error;

            return Task.FromResult<ICheckResult>(new CheckResult(ShortName, level));
        }
    }
}
