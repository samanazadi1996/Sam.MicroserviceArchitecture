using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Context
{
    public class DataSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataSeeder(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                var roleNames = new[] { "Admin", "User" };
                foreach (var item in roleNames)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var defaultUser = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "Admin@Admin.com",
                    EmailConfirmed = true,
                };

                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Sam@12345");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                    await userManager.AddToRoleAsync(defaultUser, "User");
                }

            }

        }
    }
}
