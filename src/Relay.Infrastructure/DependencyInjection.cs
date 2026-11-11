using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Relay.Application.Contracts;
using Relay.Infrastructure.Persistence;
using Relay.Infrastructure.Security;

namespace Relay.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string is missing.");

        services.AddDbContext<RelayDbContext>(options =>
            options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(typeof(RelayDbContext).Assembly.FullName);
                sql.EnableRetryOnFailure();
            }));

        services.AddDataProtection()
            .SetApplicationName("WebhookRelay")
            .PersistKeysToDbContext<RelayDbContext>();

        services.AddSingleton<ISecretEncryptor, SecretEncryptor>();
        
        return services;
    }
}