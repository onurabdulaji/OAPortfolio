using Microsoft.AspNetCore.Identity;
using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Domain.Entities;
public class Role : IdentityRole<Guid>, IEntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public Role()
    {
        
    }
}
