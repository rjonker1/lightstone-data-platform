namespace Lace.CrossCutting.DataProvider.Certificate.Core.Contracts
{
    public interface IDefineTheCredentials
    {
        string Domain { get; }
        string Username { get; }
        string Password { get; }
    }
}
