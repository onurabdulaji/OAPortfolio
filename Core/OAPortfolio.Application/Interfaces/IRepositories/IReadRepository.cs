using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Application.Interfaces.IRepositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
}
