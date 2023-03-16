using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace AspNetCoreTodo
{
    public static class Constants
    {
        public const string AdministratorRole = "Administrator";
    }


    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            await EnsureTestAdminAsync(userManager);

        }

        private static async Task EnsureTestAdminAsync(UserManager<IdentityUser> userManager)
        {
            var testAdmin = userManager.Users
                    .Where(x => x.UserName == "admin1@todo.local")
                    .FirstOrDefault();

            if (testAdmin != null)
                return;
            
            testAdmin = new IdentityUser{
                UserName = "admin1@todo.local",
                Email = "admin1@todo.local"
            };

            userManager.CreateAsync(testAdmin, "NotSecure123!");
            userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);

        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists)
                return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }
    }
}