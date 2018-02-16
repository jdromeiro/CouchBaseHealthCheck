using Refit;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck.CouchBaseStats
{
    interface ICouchBaseAPI
    {
        [Get("/pools/default")]
        Task<CouchBaseStats> GetNodeStats();
    }
}
