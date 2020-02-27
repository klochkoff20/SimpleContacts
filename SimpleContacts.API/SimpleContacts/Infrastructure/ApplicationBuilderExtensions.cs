using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleContacts.DAL;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Infrastructure.OptionsModels;

namespace SimpleContacts.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app, DefaultUser user)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;

            try
            {
                var roleManager = serviceProvider.GetService<RoleManager<Role>>();
                var userManager = serviceProvider.GetService<UserManager<User>>();

                DatabaseSeeder.InsertSeedData(userManager, roleManager, user);
            }
            catch (Exception )
            {
               
            }
            return app;
        }
    }
}
