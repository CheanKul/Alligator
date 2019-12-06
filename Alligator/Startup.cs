using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Alligator.CustomConfig;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Alligator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IConfigurationBuilder en_US { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            en_US = new ConfigurationBuilder().AddJsonFile("en_US.json"); 
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);




            // Register the Swagger generator, defining 1 or more Swagger documents
            SwaggerConfig.Register(services);

            //For Getting current Context
            HttpServiceCollectionExtensions.AddHttpContextAccessor(services);

           

            //Register Identity
            IdentityConfig.RegisterAppDatabase(services, Configuration);
            IdentityConfig.Register(services, Configuration);


            //Dependancy registraion
            RegisterDependancyConfig.Register(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("/Error");
            }
            
            app.UseStaticFiles();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            SwaggerConfig.Configure(app, Configuration);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
