namespace CouchBaseHealthCheck.CouchBaseStats
{
    public class CouchBaseStats
    {
        public Storagetotals storageTotals { get; set; }
        public int ftsMemoryQuota { get; set; }
        public int indexMemoryQuota { get; set; }
        public int memoryQuota { get; set; }
        public string name { get; set; }
        public object[] alerts { get; set; }
        public string alertsSilenceURL { get; set; }
        public Node[] nodes { get; set; }
        public Buckets buckets { get; set; }
        public Remoteclusters remoteClusters { get; set; }
        public Controllers controllers { get; set; }
        public string rebalanceStatus { get; set; }
        public string rebalanceProgressUri { get; set; }
        public string stopRebalanceUri { get; set; }
        public string nodeStatusesUri { get; set; }
        public int maxBucketCount { get; set; }
        public Autocompactionsettings autoCompactionSettings { get; set; }
        public Tasks tasks { get; set; }
        public Counters counters { get; set; }
        public string indexStatusURI { get; set; }
        public string checkPermissionsURI { get; set; }
        public string serverGroupsUri { get; set; }
        public string clusterName { get; set; }
        public bool balanced { get; set; }
    }

    public class Storagetotals
    {
        public Ram ram { get; set; }
        public Hdd hdd { get; set; }
    }

    public class Ram
    {
        public long total { get; set; }
        public long quotaTotal { get; set; }
        public long quotaUsed { get; set; }
        public long used { get; set; }
        public int usedByData { get; set; }
        public long quotaUsedPerNode { get; set; }
        public long quotaTotalPerNode { get; set; }
    }

    public class Hdd
    {
        public long total { get; set; }
        public long quotaTotal { get; set; }
        public long used { get; set; }
        public int usedByData { get; set; }
        public long free { get; set; }
    }

    public class Buckets
    {
        public string uri { get; set; }
        public string terseBucketsBase { get; set; }
        public string terseStreamingBucketsBase { get; set; }
    }

    public class Remoteclusters
    {
        public string uri { get; set; }
        public string validateURI { get; set; }
    }

    public class Controllers
    {
        public Addnode addNode { get; set; }
        public Rebalance rebalance { get; set; }
        public Failover failOver { get; set; }
        public Startgracefulfailover startGracefulFailover { get; set; }
        public Readdnode reAddNode { get; set; }
        public Refailover reFailOver { get; set; }
        public Ejectnode ejectNode { get; set; }
        public Setrecoverytype setRecoveryType { get; set; }
        public Setautocompaction setAutoCompaction { get; set; }
        public Clusterlogscollection clusterLogsCollection { get; set; }
        public Replication replication { get; set; }
    }

    public class Addnode
    {
        public string uri { get; set; }
    }

    public class Rebalance
    {
        public string uri { get; set; }
    }

    public class Failover
    {
        public string uri { get; set; }
    }

    public class Startgracefulfailover
    {
        public string uri { get; set; }
    }

    public class Readdnode
    {
        public string uri { get; set; }
    }

    public class Refailover
    {
        public string uri { get; set; }
    }

    public class Ejectnode
    {
        public string uri { get; set; }
    }

    public class Setrecoverytype
    {
        public string uri { get; set; }
    }

    public class Setautocompaction
    {
        public string uri { get; set; }
        public string validateURI { get; set; }
    }

    public class Clusterlogscollection
    {
        public string startURI { get; set; }
        public string cancelURI { get; set; }
    }

    public class Replication
    {
        public string createURI { get; set; }
        public string validateURI { get; set; }
    }

    public class Autocompactionsettings
    {
        public bool parallelDBAndViewCompaction { get; set; }
        public Databasefragmentationthreshold databaseFragmentationThreshold { get; set; }
        public Viewfragmentationthreshold viewFragmentationThreshold { get; set; }
        public string indexCompactionMode { get; set; }
        public Indexcircularcompaction indexCircularCompaction { get; set; }
        public Indexfragmentationthreshold indexFragmentationThreshold { get; set; }
    }

    public class Databasefragmentationthreshold
    {
        public int percentage { get; set; }
        public string size { get; set; }
    }

    public class Viewfragmentationthreshold
    {
        public int percentage { get; set; }
        public string size { get; set; }
    }

    public class Indexcircularcompaction
    {
        public string daysOfWeek { get; set; }
        public Interval interval { get; set; }
    }

    public class Interval
    {
        public int fromHour { get; set; }
        public int toHour { get; set; }
        public int fromMinute { get; set; }
        public int toMinute { get; set; }
        public bool abortOutside { get; set; }
    }

    public class Indexfragmentationthreshold
    {
        public int percentage { get; set; }
    }

    public class Tasks
    {
        public string uri { get; set; }
    }

    public class Counters
    {
    }

    public class Node
    {
        public Systemstats systemStats { get; set; }
        public Interestingstats interestingStats { get; set; }
        public string uptime { get; set; }
        public long memoryTotal { get; set; }
        public long memoryFree { get; set; }
        public int mcdMemoryReserved { get; set; }
        public int mcdMemoryAllocated { get; set; }
        public string couchApiBase { get; set; }
        public string couchApiBaseHTTPS { get; set; }
        public string otpCookie { get; set; }
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
