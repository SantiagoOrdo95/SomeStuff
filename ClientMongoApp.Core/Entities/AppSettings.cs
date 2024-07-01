namespace ClientMongoApp.Core.Entities
{
    public class AppSettings
    {
        // Database connection
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;


        // URL Proxy
        public string UrlApi { get; set; } 
    }
}
