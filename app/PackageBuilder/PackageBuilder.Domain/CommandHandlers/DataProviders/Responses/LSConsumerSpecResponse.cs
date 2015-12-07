using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneConsumerResponse
    {
        public LightstoneConsumerSpecificationsResponse Default()
        {
            var result = new LightstoneConsumerSpecificationsResponse(new List<IRespondWithRepairData>()
            {
                new RepairDataResponse("", "", 0, "", "")
            });
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}