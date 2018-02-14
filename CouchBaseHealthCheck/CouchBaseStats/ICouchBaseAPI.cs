using Couchbase.Management;
using Refit;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck.Stats
{
    interface ICouchBaseAPI
    {
        [Get("/pools/default")]
        Task<CouchBaseStats> GetNodeStats();
    }
}
