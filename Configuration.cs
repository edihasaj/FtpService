namespace FtpService
{
    public class Configuration
    {
        public int Id { get; set; } 
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string PathList { get; set; }
    }
}
