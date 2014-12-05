using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstoneResponseMother
    {
        public static IProvideDataFromLightstone Response
        {
            get
            {
                return new LightstoneResponseBuilder()
                            .With(0, 2014)
                            .With("", "", "", "", "")
                            .With(VehicleValuationMother.VehicleValuation)
                            .Build();
            }
        }
    }
}