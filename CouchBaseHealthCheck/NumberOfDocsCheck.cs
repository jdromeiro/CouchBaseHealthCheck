using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Linq;
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
    class NumberOfDocsCheck : ICheck
    {
        private readonly string bucket;
        private readonly CouchBaseServerInfo serverInfo;
        private readonly int maxNumberOfDocs;

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

            this.serverInfo = serverInfo;
            this.bucket = bucket;
            this.maxNumberOfDocs = maxNumberOfDocs;

            ShortName = $"Number of documents in bucket '{bucket}' in {serverInfo.Address}";
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
            var couchBaseApi = RestService.For<BucketStats.ICouchBucketAPI>(httpClient);
            var bucketNodeSTats = couchBaseApi.GetBucket(bucket).Result;
            
            //compute values
            var numberOfDocs = bucketNodeSTats.basicStats.itemCount;

            //calculate notification level
            var level = (numberOfDocs < maxNumberOfDocs)
                ? NotificationLevel.Okay
                : NotificationLevel.Error;

            return Task.FromResult<ICheckResult>(new CheckResult(ShortName, level));
        }

    }

}
