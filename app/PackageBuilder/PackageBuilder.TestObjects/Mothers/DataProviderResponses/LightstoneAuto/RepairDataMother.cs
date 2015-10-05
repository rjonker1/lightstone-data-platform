using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class RepairDataMother
    {
        public static IRespondWithRepairData RepairData
        {
            get
            {
                return new LightstoneConsumerBuilder()
                    .With(20150101)
                    .With(
                        "50000",
                        "DriversName",
                        "Location",
                        "VehicleDescription"
                    )
                    .Build();
            }
        }
    }
}