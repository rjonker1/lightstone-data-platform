using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmRgtRequest : IAmDataProviderRequest
    {
        IAmCarIdRequestField CarId { get; }
    }
}