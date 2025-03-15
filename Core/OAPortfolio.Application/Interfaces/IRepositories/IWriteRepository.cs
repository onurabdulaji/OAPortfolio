using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Application.Interfaces.IRepositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
}
