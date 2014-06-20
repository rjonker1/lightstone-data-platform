using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class LicensePlateNumberSourcePackage
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
                                new DataField {Name = "License plate number"},
                            }
                        }
                    }
            };
        }
    }
    
}
