using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class PCubedEzScoreResponseMother
    {
        public static IProvideDataFromPCubedEzScore Response
        {
            get
            {
                return new PCubedEzScoreResponseBuilder()
                    .With(PCubedEzScoreMother.EzScore)
                    .Build();
            }
        }
    }
}