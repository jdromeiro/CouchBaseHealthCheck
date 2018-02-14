using Couchbase.Management;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck.BucketStats
{
    interface ICouchBucketAPI
    {
        [Get("/pools/default/buckets/{bucketName}")]
        Task<CouchBaseBucketStats> GetBucket(string bucketName);
    }
}
