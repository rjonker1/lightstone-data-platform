using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
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
                                new TestDataField("Registration") {DataSource = new RegistrationFieldSource()},
                                new TestDataField("Vin") {DataSource = new VinFieldSource()},
                                new TestDataField("Engine") {DataSource = new EngineFieldSource()},
                                new TestDataField("MakeDescription") {DataSource = new MakeDescriptionFiledSource()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
