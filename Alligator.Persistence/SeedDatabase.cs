﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alligator.Persistence;

namespace Alligator.Persistence
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDBContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "Admin@admin.Com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Admin"
                };

                Task.FromResult(userManager.CreateAsync(user, "Password@123"));

            }

        }
    }
}
