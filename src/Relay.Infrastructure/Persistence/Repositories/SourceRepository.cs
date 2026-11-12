using Microsoft.EntityFrameworkCore;
using Relay.Application.Contracts;
using Relay.Domain.Models;

namespace Relay.Infrastructure.Persistence.Repositories;

public class SourceRepository(RelayDbContext dbContext) : ISourceRepository
{
    private readonly RelayDbContext _dbContext = dbContext;

    public async Task<Source?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.Sources
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, ct);
    }

    public async Task<List<Source>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Sources
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Source> CreateAsync(Source source, CancellationToken ct)
    {
        await _dbContext.Sources.AddAsync(source, ct);
        await _dbContext.SaveChangesAsync(ct);
        return source;
    }
}