using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneAutoRequest : IAmDataProviderRequest
    {
        IAmCarIdRequestField CarId { get; }
        IAmYearRequestField Year { get; }
        IAmMakeRequestField Make { get; }
        IAmVinNumberRequestField VinNumber { get; }
    }
}