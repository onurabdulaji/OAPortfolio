using Microsoft.EntityFrameworkCore;
using OAPortfolio.Application.Interfaces.IRepositories;
using OAPortfolio.Domain.Commons.Abstracts;
using OAPortfolio.Persistence.Context;

namespace OAPortfolio.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }
}
