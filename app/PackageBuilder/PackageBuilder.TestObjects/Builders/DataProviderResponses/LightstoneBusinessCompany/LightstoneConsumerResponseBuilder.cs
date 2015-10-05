using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class LightstoneConsumerResponseBuilder
    {
        private IEnumerable<IRespondWithRepairData> _repairData;
        public IProvideDataFromLightstoneConsumerSpecifications Build()
        {
            return new LightstoneConsumerSpecificationsResponse(_repairData);
        }

        public LightstoneConsumerResponseBuilder With(params IRespondWithRepairData[] repairData)
        {
            _repairData = repairData;
            return this;
        }
    }
}