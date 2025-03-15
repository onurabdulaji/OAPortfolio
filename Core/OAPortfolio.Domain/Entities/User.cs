using Microsoft.AspNetCore.Identity;
using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Domain.Entities;

public class User : IdentityUser<Guid>, IEntityBase
{
    public string? UserFullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    // Implement IEntityBase properties
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public User() { }
}
