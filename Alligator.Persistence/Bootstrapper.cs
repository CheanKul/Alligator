using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Alligator.Persistence.Contract;
using Alligator.Persistence.Repository;

namespace Alligator.Persistence
{
    public class Bootstrapper
    {

        public static void RegisterDependancies(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            
            services.AddScoped<ILoggerRepository, LoggerRepository>();
        }
    }
}
