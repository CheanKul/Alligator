using Microsoft.Extensions.DependencyInjection;
using Alligator.Application.Contract;
using Alligator.Persistence;
using Alligator.Persistence.Contract;
using Alligator.Domain;

namespace Alligator.Application
{
    public class Bootstrapper
    {

        public static void RegisterDependancies(IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ILoggingManager, LoggingManager>();
            services.AddScoped<IResponseModel, ResponseModel>();
        }
    }
}
