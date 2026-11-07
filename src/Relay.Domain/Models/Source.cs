using Relay.Domain.Enums;

namespace Relay.Domain.Models;

public class Source
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProviderType ProviderType { get; set; }
    public string? Description { get; set; }
    public string EncryptedKey { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public void Create(
        string name,
        ProviderType providerType,
        string? description,
        string encryptedKey)
    {
        Name = name;
        ProviderType = providerType;
        Description = description;
        EncryptedKey = encryptedKey;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string name,
        ProviderType providerType,
        string? description,
        string encryptedKey)
    {
        Name = name;
        ProviderType = providerType;
        Description = description;
        EncryptedKey = encryptedKey;
        UpdatedAt = DateTime.UtcNow;
    }
}