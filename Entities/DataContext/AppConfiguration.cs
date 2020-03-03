using System.IO;
using Microsoft.Extensions.Configuration;

namespace Entities.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "/home/valli/RiderProjects/University/WebApp/appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }
        
        public string sqlConnectionString { get; set; }
    }
}