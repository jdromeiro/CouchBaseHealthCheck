using Nimator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck
{
    class NumberOfDocsCheckSettings : ICheckSettings 
    {
        public CouchBaseServerInfo Server;
        public string Bucket { get; set; }
        public int MaxNumberOfDocs { get; set; }

        public NumberOfDocsCheckSettings()
        {
            Server = new CouchBaseServerInfo()
            {
                Address = "",
                Username = "",
                Password = "",
            };
            Bucket = "";
            MaxNumberOfDocs = 100;
        }

        public ICheck ToCheck()
        {
            return new NumberOfDocsCheck(Server, Bucket, MaxNumberOfDocs);
        }
    }
}
