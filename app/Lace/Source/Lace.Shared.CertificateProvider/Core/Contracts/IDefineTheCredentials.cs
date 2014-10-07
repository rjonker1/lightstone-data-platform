namespace Lace.Shared.CertificateProvider.Core.Contracts
{
    public interface IDefineTheCredentials
    {
        string Domain { get; }
        string Username { get; }
        string Password { get; }
    }
}
