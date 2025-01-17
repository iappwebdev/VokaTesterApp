﻿namespace VokaTester.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Identity;
    using VokaTester.Data.Models;
    using VokaTester.Features.Identity;

    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

        public static void SeedRoles(this RoleManager<IdentityRole> roleManager)
        {
            CreateRole(roleManager, IdentityRoles.Administrator);
            CreateRole(roleManager, IdentityRoles.Learner);

            static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = roleName
                    };

                    _ = roleManager.CreateAsync(role).Result;
                }
            }
        }

        public static void SeedUsers(this UserManager<User> userManager)
        {
            List<KeyValuePair<string, string>> initialUsers = new List<KeyValuePair<string, string>>();

            initialUsers.ForEach(x => CreateUser(userManager, x.Value, IdentityRoles.Learner, x.Key));

            static void CreateUser(UserManager<User> userManager, string userName, string role, string password)
            {
                string emailhost = "ba-server.de";

                if (userManager.FindByNameAsync(userName).Result == null)
                {
                    User user = new User
                    {
                        UserName = userName,
                        Email = $"{userName}@{emailhost}"
                    };

                    IdentityResult result = userManager.CreateAsync(user, password).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, role).Wait();
                    }
                }
            }
        }

    }
}