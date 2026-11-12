using Relay.Domain.Models;

namespace Relay.Application.Contracts;

public interface ISourceRepository
{
    Task<Source?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<Source>> GetAllAsync(CancellationToken ct = default);
    Task<Source> CreateAsync(Source source, CancellationToken ct = default);
}