using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmBusinessRequest : IPointToLaceRequest
    {
        IHaveUserInformation User { get; }
        IHaveBusinessInformation Business { get; }
    }
}
