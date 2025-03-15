using Microsoft.EntityFrameworkCore;
using OAPortfolio.Application.Interfaces.IRepositories;
using OAPortfolio.Application.Interfaces.IUnitOfWorks;
using OAPortfolio.Persistence.Context;
using OAPortfolio.Persistence.Repositories;

namespace OAPortfolio.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
    {
        return new ReadRepository<T>(_context);
    }

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
    {
        return new WriteRepository<T>(_context);
    }
}
