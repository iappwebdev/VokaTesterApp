namespace VokaTester.Infrastructure.Extensions
{
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
            CreateUser(userManager, "Admin", IdentityRoles.Administrator);
            CreateUser(userManager, "Standard", IdentityRoles.Learner);

            static void CreateUser(UserManager<User> userManager, string userName, string role)
            {
                string emailhost = "localhost.de";

                if (userManager.FindByNameAsync(userName).Result == null)
                {
                    User user = new User
                    {
                        UserName = userName,
                        Email = $"{userName}@{emailhost}"
                    };

                    IdentityResult result = userManager.CreateAsync(user, $"{userName.Substring(0, 3)}123").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, role).Wait();
                    }
                }
            }
        }

    }
}