using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Metadata.Entrypoint;
using Lace.Test.Helper.Builders.Requests;

namespace Recoveries.Test.Helper.Mothers.DataProviders
{
    public class LaceExecution
    {
        private readonly IAdvancedBus bus;
        public static ICollection<IPointToLaceProvider> ExecuteVehicleSearch()
        {
            var entryPoint = new MetadataEntryPointService();
            var request = new LicensePlateRequestBuilder().ForAllSources();

            return entryPoint.GetResponses(request);
        }
    }
}