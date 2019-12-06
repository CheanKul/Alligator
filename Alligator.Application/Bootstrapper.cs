using Microsoft.Extensions.DependencyInjection;
using Alligator.Application.Contract;
using Alligator.Persistence;
using Alligator.Persistence.Contract;
using Alligator.Domain;
using Alligator.Application.Bussiness;

namespace Alligator.Application
{
    public class Bootstrapper
    {

        public static void RegisterDependancies(IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITechnologyApplication, TechnologyApplication>();

            services.AddScoped<ICommonApplication, CommonApplication>();

            services.AddScoped<ILoggingManager, LoggingManager>();
            services.AddScoped<IResponseModel, ResponseModel>();
        }
    }
}
