using Refit;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck.CouchBaseBucketStats
{
    interface ICouchBucketAPI
    {
        [Get("/pools/default/buckets/{bucketName}")]
        Task<BucketStats> GetBucket(string bucketName);
    }
}
