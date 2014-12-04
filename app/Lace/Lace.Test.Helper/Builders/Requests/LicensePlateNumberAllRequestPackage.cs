using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
           // return PackageBuilder.TestHelper.Mothers.PackageMother.LicensePlateSearchPackage;
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

            //                    new DataFieldBuilder().With("Registration")
            //                        .With(DataSourceMother.IvidDataSource)
            //                        .Build(),
            //                    new DataFieldBuilder().With("Vin").With(DataSourceMother.IvidDataSource).Build(),
            //                    new DataFieldBuilder().With("Engine").With(DataSourceMother.IvidDataSource).Build(),
            //                    new DataFieldBuilder().With("MakeDescription")
            //                        .With(DataSourceMother.IvidDataSource)
            //                        .Build(),

            //                    new DataFieldBuilder().With("BankName")
            //                        .With(DataSourceMother.IvidTitleHolderDataSource)
            //                        .Build(),
            //                    new DataFieldBuilder().With("AccountNumber")
            //                        .With(DataSourceMother.IvidTitleHolderDataSource)
            //                        .Build(),
            //                    new DataFieldBuilder().With("AccountOpenDate")
            //                        .With(DataSourceMother.IvidTitleHolderDataSource)
            //                        .Build(),
            //                    new DataFieldBuilder().With("AccountClosedDate")
            //                        .With(DataSourceMother.IvidTitleHolderDataSource)
            //                        .Build(),

            //                    new DataFieldBuilder().With("VehicleMake").With(DataSourceMother.RgtVinSource).Build(),
            //                    new DataFieldBuilder().With("Colour").With(DataSourceMother.RgtVinSource).Build(),
            //                    new DataFieldBuilder().With("Price").With(DataSourceMother.RgtVinSource).Build(),

            //                    new DataFieldBuilder().With("AccidentClaim")
            //                        .With(DataSourceMother.AudatexSource)
            //                        .Build()

            //                }
            //            }
            //        },
            //    Action = ActionMother.LicensePlateSearchAction
            //};
        }
    }
}
