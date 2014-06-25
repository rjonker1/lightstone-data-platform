using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
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
                                new DataField {Name = "BankName", DataSource = new BankNameFieldSource()},
                                new DataField {Name = "AccountNumber", DataSource = new AccountNumberFieldSource()},
                                new DataField {Name = "AccountOpenDate", DataSource = new AccountOpenDateFieldSource()},
                                new DataField
                                {
                                    Name = " AccountClosedDate",
                                    DataSource = new AccountClosedDateFieldSource()
                                }
                            }
                        }
                    },
            };
        }
    }
}
