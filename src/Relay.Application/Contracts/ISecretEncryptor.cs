namespace Relay.Application.Contracts;

public interface ISecretEncryptor
{
    string Encrypt(string secret);
    string Decrypt(string secret);
}