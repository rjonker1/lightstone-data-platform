using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmMmCodeRequest : IAmDataProviderRequest
    {
        IAmCarIdRequestField CarId { get; }
    }
}
