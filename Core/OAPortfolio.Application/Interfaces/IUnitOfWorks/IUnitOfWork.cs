using OAPortfolio.Application.Interfaces.IRepositories;
using OAPortfolio.Domain.Commons.Abstracts;

namespace OAPortfolio.Application.Interfaces.IUnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync();
    int Save();
}
