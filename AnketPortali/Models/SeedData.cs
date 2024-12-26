using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using AnketPortali.Models;

namespace AnketPortali.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roleNames = new[] { "Admin", "User", "Moderator" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new AppRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
