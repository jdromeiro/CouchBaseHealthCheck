namespace CouchBaseHealthCheck
{
    public class CouchBaseServerInfo
    {
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public CouchBaseServerInfo()
        {
            Address = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        public CouchBaseServerInfo(string address, string userName, string password)
        {
            Address = address;
            Username = userName;
            Password = password;
        }
    }
}
