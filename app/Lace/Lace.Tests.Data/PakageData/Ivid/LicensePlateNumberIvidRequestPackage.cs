using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData.Ivid
{
    public class LicensePlateNumberIvidRequestPackage
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
                                new DataField {Name = "Registration", DataSource = new RegistrationFieldSource()},
                                new DataField {Name = "Vin", DataSource = new VinFieldSource()},
                                new DataField {Name = "Engine", DataSource = new EngineFieldSource()},
                                new DataField {Name = " MakeDescription", DataSource = new MakeDescriptionFiledSource()}
                            }
                        }
                    }
            };
        }
    }
}
