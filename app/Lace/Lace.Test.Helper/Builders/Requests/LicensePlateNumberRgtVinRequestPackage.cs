using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return new Package("License plate lookup package")
            {
                DataSets =
                    new[]
                    {
                        new DataSet("License plate lookup DataSet")
                        {
                            DataFields = new[]
                            {
                                new DataField("Vin") {DataSource = new VinFieldSource()},
                                new DataField("VehicleMake") {DataSource = new PriceFieldSource()},
                                new DataField("Colour") {DataSource = new ColourFieldSource()},
                                new DataField("Price") {DataSource = new PriceFieldSource()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
