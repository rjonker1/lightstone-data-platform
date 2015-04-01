using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmPropertyRequest : IPointToLaceRequest
    {
        IHaveUserInformation User { get; }
        IHavePropertyInformation Property { get; }
    }
}
