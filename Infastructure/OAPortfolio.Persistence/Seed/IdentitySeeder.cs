using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OAPortfolio.Domain.Entities;
using OAPortfolio.Persistence.Context;

namespace OAPortfolio.Persistence.Seed
{
    public class IdentitySeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Admin rolünü kontrol et ve yoksa oluştur
            var role = await roleManager.FindByNameAsync("Admin");
            if (role == null)
            {
                role = new Role { Name = "Admin" };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create Admin role.");
                }
            }

            // Admin kullanıcısını kontrol et ve yoksa oluştur
            var adminUser = await userManager.FindByEmailAsync("onurabdulaji@gmail.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "OnurAbdulaji",
                    Email = "onurabdulaji@gmail.com",
                    EmailConfirmed = true,
                    UserFullName = "Onur Abdulaji"
                };

                var password = "Admin123!@#"; // Güçlü bir şifre seçmeniz önemlidir
                var result = await userManager.CreateAsync(adminUser, password);
                if (result.Succeeded)
                {
                    // RoleManager'dan rolü alıyoruz
                    var role1 = await roleManager.FindByNameAsync("Admin");

                    if (role1 == null)
                    {
                        role1 = new Role { Name = "Admin" };
                        await roleManager.CreateAsync(role1); // Admin rolünü yaratıyoruz
                    }

                    // DbContext kullanarak ilişkiyi elle ekliyoruz
                    var userRole = new IdentityUserRole<Guid>
                    {
                        UserId = adminUser.Id,  // Admin kullanıcısının Id'si
                        RoleId = role1.Id         // Admin rolünün Id'si
                    };

                    // DbContext'e ilişkiyi ekliyoruz
                    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
                    await dbContext.Set<IdentityUserRole<Guid>>().AddAsync(userRole);
                    await dbContext.SaveChangesAsync(); // Kaydediyoruz
                }
                else
                {
                    throw new Exception("Failed to create admin user.");
                }
            }
        }
    }
}

