using Microsoft.AspNetCore.DataProtection;
using Relay.Application.Contracts;

namespace Relay.Infrastructure.Security;

public class SecretEncryptor(IDataProtectionProvider dataProtectionProvider) : ISecretEncryptor
{
    private const string Purpose = "Relay.Sources.SigningSecret";
    
    private readonly IDataProtector _dataProtector = dataProtectionProvider.CreateProtector(Purpose);

    public string Encrypt(string secret)
    {
        ArgumentException.ThrowIfNullOrEmpty(secret);
        return _dataProtector.Protect(secret);
    }

    public string Decrypt(string secret)
    {
        ArgumentException.ThrowIfNullOrEmpty(secret);
        return _dataProtector.Unprotect(secret);
    }
}