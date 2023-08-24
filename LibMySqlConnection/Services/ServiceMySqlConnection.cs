using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMySqlConnection.Services
{
    public class ServiceMySqlConnection
    {
        public MySqlProcessing sql;
        //private readonly ILogger<Worker> _logger;
        public ServiceMySqlConnection(IConfiguration clientConfig)
        {
            sql = new MySqlProcessing(clientConfig.GetConnectionString("Production"));
 
        }

      

        //private string GetConnectionString( string connectionString = "Default")
        //{
        //    string output;
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        //    var config = builder.Build();
        //    return output = config.GetConnectionString(connectionString);
        //}
    }
}
