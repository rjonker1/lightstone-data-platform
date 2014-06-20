using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData.Audatex
{
    public class LicensePlateNumberAudatexRequestPackage
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
                                new DataField {Name = "AccidentClaim", DataSource = new AccidentClaimSource()}
                            }
                        }
                    }
            };
        }
    }
}
