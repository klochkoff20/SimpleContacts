using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;
using SimpleContacts.Common.Authorization;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Infrastructure.OptionsModels;

namespace SimpleContacts.DAL
{
    public static class DatabaseSeeder
    {
        public static async void InsertSeedData(UserManager<User> userManager,
           RoleManager<Role> roleManager, DefaultUser defaultUser)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = GetUserRoles();
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            if (defaultUser.Roles.All(r => roleManager.Roles.Any(x => x.Name == r)))
            {
                //create the default user account 
                if (!userManager.Users.Any(u => u.UserName == defaultUser.Email))
                {
                    var user = new User
                    {
                        Id = defaultUser.Id.ToString(),
                        UserName = defaultUser.Email,
                        Email = defaultUser.Email,
                        EmailConfirmed = true,
                        NormalizedUserName = defaultUser.UserName.ToUpper(),
                        FirstName = defaultUser.FirstName,
                        LastName = defaultUser.LastName,
                    };

                    var result = await userManager.CreateAsync(user, defaultUser.Password);

                    if (result.Succeeded)
                    {
                        foreach (var role in defaultUser.Roles)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }
            }
        }

        private static ICollection<Role> GetUserRoles()
        {
            return new Collection<Role>
            {
                new Role
                {
                    Id = "809ddd67-44d3-448d-8227-77f8d04ec692",
                    Name = UserRoles.SuperAdmin,
                    NormalizedName = "Super Admin",
                    Description = "Super administrator",
                },
                new Role
                {
                    Id = "0d2a7b0f-d8f1-4760-b361-57b1d7bbb20d",
                    Name = UserRoles.SCAdmin,
                    NormalizedName = "SC Admin",
                    Description = "SimpleContacts administrator",
                },
                new Role
                {
                    Id = "36df0516-50b8-4fcc-b667-509f7bef9bc1",
                    Name = UserRoles.Recruiter,
                    NormalizedName = "Recruiter",
                    Description = "Recruiter",
                }
            };
        }
    }
}
