using System;
using System.Configuration;
using System.Text;
using BooksApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Alligator.Domain.Model;
using Alligator.Persistence;

namespace Alligator.CustomConfig {
    public class IdentityConfig {
        public static void Register (IServiceCollection services, IConfiguration configuration) {

            services.Configure<Settings> (options => {
                options.ConnectionString = configuration.GetSection ("MongoConnection:ConnectionString").Value;
                options.Database = configuration.GetSection ("MongoConnection:DatabaseName").Value;
            });

            services.AddSingleton<IMongoDbContext, MongoDbContext> ();

            services.AddAuthentication (options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters () {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "http://oec.com",
                        ValidIssuer = "http://oec.com",
                        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("MyAdvanceSupperKey"))
                    };
                });
        }

        public static void RegisterAppDatabase (IServiceCollection services, IConfiguration configuration) {
            var constr = configuration.GetValue<string> ("ConnectionString:DefaultConnection");
            services.AddDbContext<AppDBContext> (options => options.UseMySql (constr, options => {
                options.ServerVersion (new Version (5, 7, 17), ServerType.MySql);
            }));
        }

        public static void SeedDataBase (IApplicationBuilder app) {
            SeedDatabase.Initialize (app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ().CreateScope ().ServiceProvider);
        }

        public static void Configure (IApplicationBuilder app) {
            app.UseAuthentication ();
        }

    }
}