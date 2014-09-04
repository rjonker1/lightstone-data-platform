using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
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
                                //ivid
                                new DataField("Registration") { DataSource = new RegistrationFieldSource()},
                                new DataField("Vin") { DataSource = new VinFieldSource()},
                                new DataField("Engine") { DataSource = new EngineFieldSource()},
                                new DataField(" MakeDescription") { DataSource = new MakeDescriptionFiledSource()},

                                //ivid title holder
                                new DataField("BankName") { DataSource = new BankNameFieldSource()},
                                new DataField("AccountNumber") { DataSource = new AccountNumberFieldSource()},
                                new DataField("AccountOpenDate") { DataSource = new AccountOpenDateFieldSource()},
                                new DataField("AccountClosedDate") {
                                    DataSource = new AccountClosedDateFieldSource()
                                },

                                //rgt vin
                                new DataField("VehicleMake") { DataSource = new PriceFieldSource()},
                                new DataField("Colour") { DataSource = new ColourFieldSource()},
                                new DataField("Price") { DataSource = new PriceFieldSource()},

                                //audatx
                                new DataField("AccidentClaim") { DataSource = new AccidentClaimSource()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
