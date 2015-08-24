using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneConsumerResponse
    {
        public LightstoneConsumerSpecificationsResponse EmptyLightstoneConsumerSpecifications()
        {
            return new LightstoneConsumerSpecificationsResponse();
        }
    }
}
