using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Domain.Commons.Concretes;

public class EntityBase : IEntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
