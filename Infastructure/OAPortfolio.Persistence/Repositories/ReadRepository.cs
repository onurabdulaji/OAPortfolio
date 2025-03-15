using Microsoft.EntityFrameworkCore;
using OAPortfolio.Application.Interfaces.IRepositories;
using OAPortfolio.Domain.Commons.Abstracts;
using OAPortfolio.Persistence.Context;

namespace OAPortfolio.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }
}
