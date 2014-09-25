namespace Lace.Certificate
{
    public interface IDefineTheCredentials
    {
        string Domain { get; }
        string Username { get; }
        string Password { get; }
    }
}
