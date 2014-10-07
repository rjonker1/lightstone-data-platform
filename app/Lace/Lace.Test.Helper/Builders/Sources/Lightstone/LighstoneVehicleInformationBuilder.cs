using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Cars;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class LighstoneVehicleInformationBuilder
    {
        public static IRetrieveValuationFromMetrics ForValuationFromMetrics(IProvideCarInformationForRequest request)
        {
            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public static IRetrieveCarInformation ForCarInformation(ILaceRequest request)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(request);
        }
    }
}
