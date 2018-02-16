using Nimator;

namespace CouchBaseHealthCheck
{
    class MemoryCheckSettings : ICheckSettings
    {
        public CouchBaseServerInfo Server; 
        public decimal MinPercAvailableMemory { get; set; }

        public MemoryCheckSettings()
        {
            Server = new CouchBaseServerInfo();
            MinPercAvailableMemory = 1000;
        }

        public ICheck ToCheck()
        {
            return new MemoryCheck(Server, MinPercAvailableMemory);
        }
    }
}
