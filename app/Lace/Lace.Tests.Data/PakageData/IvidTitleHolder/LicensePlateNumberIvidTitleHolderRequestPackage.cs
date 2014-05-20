using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData.IvidTitleHolder
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
    {
        public static IPackage LicesenNumberPackage()
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
                    }
            };
        }
    }
}
