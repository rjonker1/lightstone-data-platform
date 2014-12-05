using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAudatexRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
          
            return null;
            //return new Package("License plate lookup package")
            //{
            //    DataSets =
            //        new[]
            //        {
            //            new DataSet("License plate lookup DataSet")
            //            {
            //                DataFields = new[]
            //                {
            //                    new DataFieldBuilder().With("Registration").With(DataSourceMother.AudatexSource).Build(),
            //                    new DataFieldBuilder().With("Vin").With(DataSourceMother.AudatexSource).Build(),
            //                    new DataFieldBuilder().With("Engine").With(DataSourceMother.AudatexSource).Build(),
            //                    new DataFieldBuilder().With("AccidentClaim").With(DataSourceMother.AudatexSource).Build()

            //                    //new DataField("Registration") {DataSource = new RegistrationFieldSource(), Type = typeof(string).ToString()},
            //                    //new DataField("Vin") {DataSource = new VinFieldSource(), Type = typeof(string).ToString()},
            //                    //new DataField("Engine") {DataSource = new EngineFieldSource(), Type = typeof(string).ToString()},
            //                    //new DataField("AccidentClaim") {DataSource = new AccidentClaimSource(), Type = typeof(string).ToString()}
            //                }
            //            }
            //        },
            //    Action = ActionMother.LicensePlateSearchAction
            //};
        }
    }
}
