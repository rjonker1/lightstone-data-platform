namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmPropertyRequest : IPointToLaceRequest
    {
        IHaveUser User { get; }
        IHaveProperty Property { get; }
    }
}
