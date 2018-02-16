using Nimator;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CouchBaseHealthCheck.CouchBaseBucketStats;

namespace CouchBaseHealthCheck
{
    public class NumberOfDocsCheck : ICheck
    {
        private string bucket { get; set; }
        private int maxNumberOfDocs;
        private HttpClientForRefit client;
        public string ShortName { get; }
        
        public NumberOfDocsCheck(CouchBaseServerInfo serverInfo, string bucket, int maxNumberOfDocs)
        {
            if (serverInfo == null)
                throw new ArgumentNullException(nameof(serverInfo));
            if (maxNumberOfDocs < 0)
                throw new ArgumentException("Maximum number of documents cannot be negative");
            if (string.IsNullOrEmpty(serverInfo.Address))
                throw new ArgumentException("Server address cannot be null nor empty");
            if (string.IsNullOrEmpty(bucket))
                throw new ArgumentException("Bucket name cannot be null nor empty");

            this.bucket = bucket;
            this.maxNumberOfDocs = maxNumberOfDocs;

            client = new HttpClientForRefit(serverInfo);

            ShortName = $"Number of documents in bucket '{bucket}' in '{serverInfo.Address}'";
        }

        public Task<ICheckResult> RunAsync()
        {
            HttpClient httpClient = client.WithBasicAuthorization();

            BucketStats stats = ComputeCouchBaseBucketStats(httpClient);

            var numberOfDocs = ComputeNumberOfDocs(stats);

            var level = CheckNumberOfDocs(numberOfDocs);

            return Task.FromResult<ICheckResult>(new CheckResult(ShortName, level));
        }

        public BucketStats ComputeCouchBaseBucketStats(HttpClient httpClient)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            var couchBaseApi = RestService.For<ICouchBucketAPI>(httpClient);
            return couchBaseApi.GetBucket(bucket).Result;
        }

        public int ComputeNumberOfDocs(BucketStats stats)
        {
            if (stats == null)
                throw new ArgumentNullException(nameof(stats));
            return stats.basicStats.itemCount;
        }
        
        public NotificationLevel CheckNumberOfDocs(int numberOfDocs)
        {
            if (numberOfDocs <= maxNumberOfDocs)
                return NotificationLevel.Okay;
            return NotificationLevel.Error;
        }

    }

}
