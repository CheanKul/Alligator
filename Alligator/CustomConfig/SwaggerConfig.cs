using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

//using Swashbuckle.AspNetCore.Swagger;


namespace Alligator.CustomConfig
{
    public class SwaggerConfig
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Mongo API", Version = "v1" });
                config.OperationFilter<MyHeaderFilter>();
            });
        }

        public static void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();



            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                string swaggerpath;
                if (!string.IsNullOrEmpty(configuration.GetValue<string>("AppSettings:SwaggerPath")))
                {
                    swaggerpath = configuration.GetValue<string>("AppSettings:SwaggerPath");
                }
                else
                {
                    swaggerpath = "/swagger/v1/swagger.json";
                }
                swaggerpath = "/swagger/v1/swagger.json";
                c.SwaggerEndpoint(swaggerpath, "✌✌API Template✌✌");
            });
        }
    }

    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class MyHeaderFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Required = false // set to false if this is optional
            });
        }
    }
}
