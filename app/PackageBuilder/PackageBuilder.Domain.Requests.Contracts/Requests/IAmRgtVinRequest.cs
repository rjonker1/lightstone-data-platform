using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmRgtVinRequest : IAmDataProviderRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
    }
}