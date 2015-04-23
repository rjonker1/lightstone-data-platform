namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmBusinessRequest : IPointToLaceRequest
    {
        IHaveUser User { get; }
        IHaveBusiness Business { get; }
    }
}
