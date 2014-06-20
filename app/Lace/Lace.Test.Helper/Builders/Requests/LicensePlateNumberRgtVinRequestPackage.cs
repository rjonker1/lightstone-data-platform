using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return new Package
            {
                Name = "License plate lookup package",
                DataSets =
                    new[]
                    {
                        new DataSet
                        {
                            Name = "License plate lookup DataSet",
                            DataFields = new[]
                            {
                                new DataField {Name = "VehicleMake", DataSource = new PriceFieldSource()},
                                new DataField {Name = "Colour", DataSource = new ColourFieldSource()},
                                new DataField {Name = "Price", DataSource = new PriceFieldSource()}
                            }
                        }
                    }
            };
        }
    }
}
