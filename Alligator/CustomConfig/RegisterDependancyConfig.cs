using Microsoft.Extensions.DependencyInjection;
using Alligator.Application;
using Alligator.Application.Contract;
using Alligator.Persistence;
using Alligator.Persistence.Contract;
using AppBootstrapper = Alligator.Application.Bootstrapper;
using PersistBootstrapper = Alligator.Persistence.Bootstrapper;

namespace Alligator.CustomConfig
{
    public class RegisterDependancyConfig
    {
        /// <summary>
        /// Add new Dependacy Class entry here
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            //Application Dependancy registraion   
            AppBootstrapper.RegisterDependancies(services);

            //Repository Dependancy registraion
            PersistBootstrapper.RegisterDependancies(services);

        }
    }
}
