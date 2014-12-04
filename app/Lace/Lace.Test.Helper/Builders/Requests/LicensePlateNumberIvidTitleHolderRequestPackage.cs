using PackageBuilder.Domain.Entities.Packages.WriteModels;
namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
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

            //                    new DataFieldBuilder().With("Vin").With(DataSourceMother.IvidTitleHolderDataSource).Build(),
            //                    new DataFieldBuilder().With("BankName").With(DataSourceMother.IvidTitleHolderDataSource).Build(),
            //                    new DataFieldBuilder().With("AccountNumber").With(DataSourceMother.IvidTitleHolderDataSource).Build(),
            //                    new DataFieldBuilder().With("AccountOpenDate").With(DataSourceMother.IvidTitleHolderDataSource).Build(),
            //                    new DataFieldBuilder().With("AccountClosedDate").With(DataSourceMother.IvidTitleHolderDataSource).Build()
            //                }
            //            }
            //        },
            //    Action = ActionMother.LicensePlateSearchAction
            //};
        }
    }
}
