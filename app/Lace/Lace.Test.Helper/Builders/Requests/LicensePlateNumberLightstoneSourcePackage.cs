using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberLightstoneSourcePackage
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

            //                    new DataFieldBuilder().With("AmortisationFactors").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("AreaFactors").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("AccidentDistribution").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("RepairIndexModel").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("EstimatedValue").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("LastFiveSales").With(DataSourceMother.LightstoneDataSource).Build(),
            //                    new DataFieldBuilder().With("AmortisedValues").With(DataSourceMother.LightstoneDataSource).Build()
            //                }
            //            }
            //        },
            //    Action = ActionMother.LicensePlateSearchAction
            //};
        }
    }
}
