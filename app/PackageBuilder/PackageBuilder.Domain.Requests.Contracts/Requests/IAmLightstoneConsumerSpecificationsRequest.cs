using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneConsumerSpecificationsRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
        IAmAccessKeyRequestField AccessKey { get; }
    }
}