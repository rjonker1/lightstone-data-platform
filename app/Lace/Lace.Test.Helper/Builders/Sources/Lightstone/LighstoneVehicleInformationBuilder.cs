using Lace.Request;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class LighstoneVehicleInformationBuilder
    {
        public static IRetrieveValuationFromMetrics ForValuationFromMetrics(ILaceRequestCarInformation request)
        {
            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public static IRetrieveCarInformation ForCarInformation(ILaceRequest request)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(request);
        }
    }
}
