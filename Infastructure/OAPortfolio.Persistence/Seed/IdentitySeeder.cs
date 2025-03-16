using Microsoft.AspNetCore.Identity;
using OAPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAPortfolio.Persistence.Seed;

public class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        const string adminRoleName = "Admin";
        const string adminEmail = "onurabdulaji@gmail.com";
        const string adminPassword = "Admin123!@#";

        var roleExist = await roleManager.RoleExistsAsync(adminRoleName);
        if (!roleExist) await roleManager.CreateAsync(new Role { Name = adminRoleName });

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser is null)
        {
            adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                UserFullName = "Onur Abdulaji",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded) await userManager.AddToRoleAsync(adminUser, adminRoleName);
        }
    }
}
