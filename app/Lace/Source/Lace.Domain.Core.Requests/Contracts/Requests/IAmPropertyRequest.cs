namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmPropertyRequest : IPointToLaceRequest
    {
        IHaveUser User { get; }
        IHaveProperty Property { get; }
    }
}
