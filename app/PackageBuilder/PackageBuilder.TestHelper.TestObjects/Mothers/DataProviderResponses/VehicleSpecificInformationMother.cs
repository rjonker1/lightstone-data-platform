using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses
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