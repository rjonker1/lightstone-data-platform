using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class LightstoneConsumerSpecificationsRequest : IAmLightstoneConsumerSpecificationsRequest
    {
        public LightstoneConsumerSpecificationsRequest(IAmVinNumberRequestField vinNumber, IAmAccessKeyRequestField accessKey)
        {
            VinNumber = vinNumber;
            AccessKey = accessKey;
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmAccessKeyRequestField AccessKey { get; private set; }
    }
}
