using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;


namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
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
                                new DataField("Vin") {DataSource = new VinFieldSource()},
                                new DataField("BankName") {DataSource = new BankNameFieldSource()},
                                new DataField("AccountNumber") {DataSource = new AccountNumberFieldSource()},
                                new DataField("AccountOpenDate") {DataSource = new AccountOpenDateFieldSource()},
                                new DataField("AccountClosedDate")
                                {
                                    DataSource = new AccountClosedDateFieldSource()
                                }
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
