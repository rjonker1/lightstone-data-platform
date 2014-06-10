using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData.RgtVin
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IPackage LicesenNumberPackage()
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
