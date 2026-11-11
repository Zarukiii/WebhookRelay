using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Relay.Domain.Models;

namespace Relay.Infrastructure.Persistence;

public class RelayDbContext(DbContextOptions<RelayDbContext> options) : DbContext(options), IDataProtectionKeyContext
{
    public DbSet<Source> Sources => Set<Source>();
    
    public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RelayDbContext).Assembly);
    }
}