using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTest
{
    public static class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<Models.User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string adminRole = "Administrators";
            string adminName = "admin";
            string adminEmail = "admin@domain.local";
            string password = "admin";
            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(adminRole));
            }
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                var admin = new Models.User { Email = adminEmail, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }
}
