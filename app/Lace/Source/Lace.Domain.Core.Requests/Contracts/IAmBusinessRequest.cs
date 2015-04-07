namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmBusinessRequest : IPointToLaceRequest
    {
        IHaveUser User { get; }
        IHaveBusiness Business { get; }
    }
}
