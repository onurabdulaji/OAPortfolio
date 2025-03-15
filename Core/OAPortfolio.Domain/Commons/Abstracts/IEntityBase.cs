namespace OAPortfolio.Domain.Commons.Abstracts;

public interface IEntityBase
{
    Guid Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime ModifiedDate { get; set; }
    bool IsDeleted { get; set; }
}
