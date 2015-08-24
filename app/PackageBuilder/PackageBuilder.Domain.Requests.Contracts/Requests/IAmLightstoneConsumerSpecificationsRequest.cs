using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneConsumerSpecificationsRequest : IAmDataProviderRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
        IAmAccessKeyRequestField AccessKey { get; }
    }
}