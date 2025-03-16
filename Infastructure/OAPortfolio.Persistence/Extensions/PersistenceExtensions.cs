using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OAPortfolio.Application.Interfaces.IRepositories;
using OAPortfolio.Application.Interfaces.IUnitOfWorks;
using OAPortfolio.Domain.Entities;
using OAPortfolio.Persistence.Context;
using OAPortfolio.Persistence.Repositories;
using OAPortfolio.Persistence.Seed;
using OAPortfolio.Persistence.UnitOfWorks;

namespace OAPortfolio.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<User, Role>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 2;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = true;
        })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static async Task UseIdentityDatabaseSeederAsync(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            await IdentitySeeder.SeedAsync(userManager, roleManager);
        }
    }
}
