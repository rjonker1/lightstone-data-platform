using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneConsumerResponse
    {
        public LightstoneConsumerSpecificationsResponse EmptyLightstoneConsumerSpecifications()
        {
            return new LightstoneConsumerSpecificationsResponse(new List<IRespondWithRepairData>()
            {
                new RepairDataResponse("", "", 0, "", "")
            });
        }
    }
}