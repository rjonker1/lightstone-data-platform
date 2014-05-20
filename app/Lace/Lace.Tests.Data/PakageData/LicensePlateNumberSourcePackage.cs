using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class LicensePlateNumberSourcePackage
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
                                new DataField {Name = "License plate number"},
                            }
                        }
                    }
            };
        }
    }
    
}
