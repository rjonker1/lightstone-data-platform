using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
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
                                new DataField {Name = "Registration", DataSource = new RegistrationFieldSource()},
                                new DataField {Name = "Vin", DataSource = new VinFieldSource()},
                                new DataField {Name = "Engine", DataSource = new EngineFieldSource()},
                                new DataField {Name = " MakeDescription", DataSource = new MakeDescriptionFiledSource()}
                            }
                        }
                    }
            };
        }
            //return new Package
            //{
            //    Name = "License plate lookup package",
            //    DataSets =
            //        new[]
            //        {
            //            new DataSet
            //            {
            //                Name = "License plate lookup DataSet",
            //                DataFields = new[]
            //                {
            //                    new DataField {Name = "License plate number"},
            //                }
            //            }
            //        }
            //};
        
    }
    
}
