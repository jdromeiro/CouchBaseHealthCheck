namespace CouchBaseHealthCheck.CouchBaseBucketStats
{
    public class BucketStats
    {
        public string name { get; set; }
        public string bucketType { get; set; }
        public string authType { get; set; }
        public int proxyPort { get; set; }
        public string uri { get; set; }
        public string streamingUri { get; set; }
        public string localRandomKeyUri { get; set; }
        public Controllers controllers { get; set; }
        public Node[] nodes { get; set; }
        public Stats stats { get; set; }
        public string nodeLocator { get; set; }
        public string saslPassword { get; set; }
        public Ddocs ddocs { get; set; }
        public bool replicaIndex { get; set; }
        public bool autoCompactionSettings { get; set; }
        public string uuid { get; set; }
        public Vbucketservermap vBucketServerMap { get; set; }
        public int replicaNumber { get; set; }
        public int threadsNumber { get; set; }
        public Quota quota { get; set; }
        public Basicstats basicStats { get; set; }
        public string evictionPolicy { get; set; }
        public string conflictResolutionType { get; set; }
        public string bucketCapabilitiesVer { get; set; }
        public string[] bucketCapabilities { get; set; }
    }

    public class Controllers
    {
        public string compactAll { get; set; }
        public string compactDB { get; set; }
        public string purgeDeletes { get; set; }
        public string startRecovery { get; set; }
    }

    public class Stats
    {
        public string uri { get; set; }
        public string directoryURI { get; set; }
        public string nodeStatsListURI { get; set; }
    }

    public class Ddocs
    {
        public string uri { get; set; }
    }

    public class Vbucketservermap
    {
        public string hashAlgorithm { get; set; }
        public int numReplicas { get; set; }
        public string[] serverList { get; set; }
        public int[][] vBucketMap { get; set; }
    }

    public class Quota
    {
        public int ram { get; set; }
        public int rawRAM { get; set; }
    }

    public class Basicstats
    {
        public float quotaPercentUsed { get; set; }
        public int opsPerSec { get; set; }
        public int diskFetches { get; set; }
        public int itemCount { get; set; }
        public int diskUsed { get; set; }
        public int dataUsed { get; set; }
        public int memUsed { get; set; }
        public int vbActiveNumNonResident { get; set; }
    }

    public class Node
    {
        public string couchApiBaseHTTPS { get; set; }
        public string couchApiBase { get; set; }
        public Systemstats systemStats { get; set; }
        public Interestingstats interestingStats { get; set; }
        public string uptime { get; set; }
        public long memoryTotal { get; set; }
        public long memoryFree { get; set; }
        public int mcdMemoryReserved { get; set; }
        public int mcdMemoryAllocated { get; set; }
        public int replication { get; set; }
        public string clusterMembership { get; set; }
        public string recoveryType { get; set; }
        public string status { get; set; }
        public string otpNode { get; set; }
        public bool thisNode { get; set; }
        public string hostname { get; set; }
        public int clusterCompatibility { get; set; }
        public string version { get; set; }
        public string os { get; set; }
        public Ports ports { get; set; }
        public string[] services { get; set; }
    }

    public class Systemstats
    {
        public float cpu_utilization_rate { get; set; }
        public long swap_total { get; set; }
        public long swap_used { get; set; }
        public long mem_total { get; set; }
        public long mem_free { get; set; }
    }

    public class Interestingstats
    {
        public int cmd_get { get; set; }
        public int couch_docs_actual_disk_size { get; set; }
        public int couch_docs_data_size { get; set; }
        public int couch_spatial_data_size { get; set; }
        public int couch_spatial_disk_size { get; set; }
        public int couch_views_actual_disk_size { get; set; }
        public int couch_views_data_size { get; set; }
        public int curr_items { get; set; }
        public int curr_items_tot { get; set; }
        public int ep_bg_fetched { get; set; }
        public int get_hits { get; set; }
        public int mem_used { get; set; }
        public int ops { get; set; }
        public int vb_active_num_non_resident { get; set; }
        public int vb_replica_curr_items { get; set; }
    }

    public class Ports
    {
        public int sslProxy { get; set; }
        public int httpsMgmt { get; set; }
        public int httpsCAPI { get; set; }
        public int proxy { get; set; }
        public int direct { get; set; }
    }

}
