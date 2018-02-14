using Nimator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchBaseHealthCheck
{
    class MemoryCheckSettings : ICheckSettings
    {
        public CouchBaseServerInfo Server { get; set; }
        public decimal MinPercAvailableMemory { get; set; }

        public MemoryCheckSettings()
        {
            Server = new CouchBaseServerInfo()
            {
                Address = "",
                Username = "",
                Password = "",
            };
            MinPercAvailableMemory = 1000;
        }

        public ICheck ToCheck()
        {
            return new MemoryCheck(Server, MinPercAvailableMemory);
        }
    }
}
