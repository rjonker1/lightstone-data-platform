namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts
{
    public interface IDefineTheCredentials
    {
        string Domain { get; }
        string Username { get; }
        string Password { get; }
    }
}
