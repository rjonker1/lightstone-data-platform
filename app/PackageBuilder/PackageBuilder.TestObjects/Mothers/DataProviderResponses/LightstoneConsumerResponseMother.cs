using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstoneConsumerResponseMother
    {
        public static IProvideDataFromLightstoneConsumerSpecifications Response
        {
            get
            {
                return new LightstoneConsumerResponseBuilder()
                    .With(RepairDataMother.RepairData)
                    .Build();
            }
        }
    }
}