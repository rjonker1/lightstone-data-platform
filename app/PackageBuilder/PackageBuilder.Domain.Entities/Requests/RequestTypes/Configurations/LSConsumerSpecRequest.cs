using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class LightstoneConsumerSpecificationsRequest : IAmLightstoneConsumerSpecificationsRequest
    {
        public LightstoneConsumerSpecificationsRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            AccessKey = requestFields.GetRequestField<IAmAccessKeyRequestField>();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmAccessKeyRequestField AccessKey { get; private set; }
    }
}
