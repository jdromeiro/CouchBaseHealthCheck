using Nimator;

namespace CouchBaseHealthCheck
{
    class NumberOfDocsCheckSettings : ICheckSettings 
    {
        public CouchBaseServerInfo Server;
        public string Bucket { get; set; }
        public int MaxNumberOfDocs { get; set; }

        public NumberOfDocsCheckSettings()
        {
            Server = new CouchBaseServerInfo();
            Bucket = string.Empty;
            MaxNumberOfDocs = 100;
        }

        public ICheck ToCheck()
        {
            return new NumberOfDocsCheck(Server, Bucket, MaxNumberOfDocs);
        }
    }
}
