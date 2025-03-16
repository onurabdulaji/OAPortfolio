using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OAPortfolio.Domain.Entities;
using System.Reflection;

namespace OAPortfolio.Persistence.Context;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public AppDbContext()
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //// Rol ID ve Kullanıcı ID'si sabitlenmiş
        //Guid ADMIN_ID = Guid.NewGuid();
        //Guid ROLE_ID = ADMIN_ID;

        //builder.Entity<Role>().HasData(new Role { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        //builder.Entity<Role>().HasData(new Role { Name = "Admin", NormalizedName = "ADMIN", Id = ROLE_ID, ConcurrencyStamp = ROLE_ID.ToString() });

        //PasswordHasher<User> hasher = new PasswordHasher<User>();
        //builder.Entity<User>().HasData(new User
        //{
        //    Id = ADMIN_ID,
        //    UserFullName = "OnurAbdulaji",
        //    UserName = "OnurAbdulaji",
        //    NormalizedUserName = "ONURABDULAJI",
        //    Email = "onurabdulaji@gmail.com",
        //    IsDeleted = false,
        //    NormalizedEmail = "ONURABDULAJI@GMAIL.COM",
        //    EmailConfirmed = true,
        //    PasswordHash = hasher.HashPassword(null, "QWERTY"),
        //    SecurityStamp = string.Empty,
        //    ConcurrencyStamp = Guid.NewGuid().ToString(),
        //});

        //builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        //{
        //    RoleId = ROLE_ID,
        //    UserId = ADMIN_ID
        //});

        //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Summary> Summaries { get; set; }
}
