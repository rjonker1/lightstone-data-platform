using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class LighstoneVehicleInformationBuilder
    {
        public static IRetrieveValuationFromMetrics ForValuationFromMetrics(IHaveCarInformation request)
        {
            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public static IRetrieveCarInformation ForCarInformation(ICollection<IPointToLaceRequest> request)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(request);
        }
    }
}
