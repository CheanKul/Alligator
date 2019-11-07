
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;

namespace Alligator.Persistence
{
   public class ConnectionStringProvider
    {
        //public readonly IConfiguration configuration;
        //public ConnectionStringProvider(IConfiguration _configuration)
        //{
        //    configuration = _configuration;
        //}
        public static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetSection("ConnectionString").GetSection("DefaultConnection").Value;
        }

    }
}
