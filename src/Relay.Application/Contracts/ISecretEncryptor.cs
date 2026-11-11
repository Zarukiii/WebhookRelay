namespace Relay.Application.Contracts;

public interface ISecretEncryptor
{
    string EncryptAsync(string secret);
    string DecryptAsync(string secret);
}