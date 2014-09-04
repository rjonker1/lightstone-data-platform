using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;


namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAudatexRequestPackage
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
                                new TestDataField("Registration") {DataSource = new RegistrationFieldSource(), Type = typeof(string).ToString()},
                                new TestDataField("Vin") {DataSource = new VinFieldSource(), Type = typeof(string).ToString()},
                                new TestDataField("Engine") {DataSource = new EngineFieldSource(), Type = typeof(string).ToString()},
                                new TestDataField("AccidentClaim") {DataSource = new AccidentClaimSource(), Type = typeof(string).ToString()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
