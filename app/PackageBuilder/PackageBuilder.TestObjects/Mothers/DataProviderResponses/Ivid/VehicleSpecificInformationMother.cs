using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Ivid;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Ivid
{
    public class VehicleSpecificInformationMother
    {
        public static IProvideVehicleSpecificInformation Response
        {
            get
            {
                return new VehicleSpecificInformationBuilder()
                            .With("", "", "", "", "", "", "")
                            .Build();
            }
        }
    }
}