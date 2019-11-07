using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Alligator.Persistence.Contract;

namespace Alligator.Persistence
{
    public class Bootstrapper
    {

        public static void RegisterDependancies(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
        }
    }
}
