using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class LightstoneConsumerSpecificationsRequest : IAmLightstoneConsumerSpecificationsRequest
    {
        public static LightstoneConsumerSpecificationsRequest WithDefault(string accesskey, string vinNumber)
        {
            return new LightstoneConsumerSpecificationsRequest()
            {
                VinNumber = VinNumberRequestField.Get(vinNumber),
                AccessKey = AccessKeyRequestField.Get(accesskey)
            };
        }

        public IAmAccessKeyRequestField AccessKey { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}
