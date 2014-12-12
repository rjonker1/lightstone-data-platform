using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
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