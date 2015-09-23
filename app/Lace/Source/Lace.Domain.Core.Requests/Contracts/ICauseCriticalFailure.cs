namespace Lace.Domain.Core.Requests.Contracts
{
    public interface ICauseCriticalFailure
    {
        bool True { get; }
        string Message { get; }
    }
}
