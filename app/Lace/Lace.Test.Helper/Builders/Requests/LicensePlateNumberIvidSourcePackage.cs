using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities;

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

                                new DataFieldBuilder().With("Registration")
                                    .With(DataSourceMother.IvidDataSource)
                                    .Build(),
                                new DataFieldBuilder().With("Vin").With(DataSourceMother.IvidDataSource).Build(),
                                new DataFieldBuilder().With("Engine").With(DataSourceMother.IvidDataSource).Build(),
                                new DataFieldBuilder().With("MakeDescription")
                                    .With(DataSourceMother.IvidDataSource)
                                    .Build(),


                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
