using Nimator;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck
{
    public class MemoryCheck : ICheck
    {
        public decimal minPercAvailableMemory { get; set; }
        private HttpClientForRefit client;
        public string ShortName { get; }

        public MemoryCheck(CouchBaseServerInfo serverInfo,  decimal minPercAvailableMemory)
        {
            if (serverInfo == null)
                throw new ArgumentNullException(nameof(serverInfo));
            if (minPercAvailableMemory < 0 || minPercAvailableMemory >= 100)
                throw new ArgumentException("Minimum percentage of available memory should have a value between 0 and 100");

            this.minPercAvailableMemory = minPercAvailableMemory;

            client = new HttpClientForRefit(serverInfo);

            ShortName = $"Memory available in the cluster with address '{serverInfo.Address}'";
        }
        
        public Task<ICheckResult> RunAsync()
        {
            HttpClient httpClient = client.WithBasicAuthorization();

            CouchBaseStats.CouchBaseStats stats = ComputeCouchBaseStats(httpClient);

            var memAvailable = ComputeMemoryAvailable(stats);

            var level = CheckMemoryAvailable(memAvailable);

            return Task.FromResult<ICheckResult>(new CheckResult(ShortName, level));
        }

        public CouchBaseStats.CouchBaseStats ComputeCouchBaseStats(HttpClient httpClient)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            var couchBaseApi = RestService.For<CouchBaseStats.ICouchBaseAPI>(httpClient);
            return couchBaseApi.GetNodeStats().Result;
        }
        
        public decimal ComputeMemoryAvailable(CouchBaseStats.CouchBaseStats stats)
        {
            if (stats == null)
                throw new ArgumentNullException(nameof(stats));
            var memFree = stats.nodes[0].systemStats.mem_free;
            var memTotal = stats.nodes[0].systemStats.mem_total;
            return (decimal)memFree / (decimal)memTotal * (decimal)100.0;
        }

        public NotificationLevel CheckMemoryAvailable(decimal percMemAvailable)
        {
            if (percMemAvailable >= minPercAvailableMemory)
                return NotificationLevel.Okay;
            return NotificationLevel.Error;
        }
    }
}
