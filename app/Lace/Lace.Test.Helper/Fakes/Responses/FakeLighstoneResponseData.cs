using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Factories;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLighstoneRetrievalData
    {
        public static IRetrieveValuationFromMetrics GetValuationFromMetrics(IHaveCarInformation request)
        {
            return new FakeBaseRetrievalMetric(request, new Valuation())
                .SetupDataSources()
                .GenerateData()
                .BuildValuation();
        }

        public static IRetrieveCarInformation GetCarInformation(string vinNumber)
        {
            return new GetCarInformation(vinNumber, new CarInformationQueryFactory(new FakeCarInfoRepository()).Build())
                .GenerateData()
                .BuildCarInformation()
                .BuildCarInformationRequest();
        }
    }
}
