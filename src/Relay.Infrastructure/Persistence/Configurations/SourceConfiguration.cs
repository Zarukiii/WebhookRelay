using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relay.Domain.Models;

namespace Relay.Infrastructure.Persistence.Configurations;

internal sealed class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.ToTable("Sources");
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(500);
        builder.Property(s => s.SigningSecret).HasMaxLength(512).IsRequired();
        
        builder.Property(s => s.ProviderType).HasConversion<string>().HasMaxLength(50);
        
        builder.HasIndex(s => s.Name).IsUnique();
    }
}