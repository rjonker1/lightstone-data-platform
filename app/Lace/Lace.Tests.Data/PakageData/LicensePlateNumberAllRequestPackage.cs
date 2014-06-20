using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class LicensePlateNumberAllRequestPackage
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
                                //ivid
                                new DataField {Name = "Registration", DataSource = new RegistrationFieldSource()},
                                new DataField {Name = "Vin", DataSource = new VinFieldSource()},
                                new DataField {Name = "Engine", DataSource = new EngineFieldSource()},
                                new DataField {Name = " MakeDescription", DataSource = new MakeDescriptionFiledSource()},

                                //ivid title holder
                                new DataField {Name = "BankName", DataSource = new BankNameFieldSource()},
                                new DataField {Name = "AccountNumber", DataSource = new AccountNumberFieldSource()},
                                new DataField {Name = "AccountOpenDate", DataSource = new AccountOpenDateFieldSource()},
                                new DataField
                                {
                                    Name = " AccountClosedDate",
                                    DataSource = new AccountClosedDateFieldSource()
                                },

                                //rgt vin
                                new DataField {Name = "VehicleMake", DataSource = new PriceFieldSource()},
                                new DataField {Name = "Colour", DataSource = new ColourFieldSource()},
                                new DataField {Name = "Price", DataSource = new PriceFieldSource()},

                                //audatx
                                new DataField {Name = "AccidentClaim", DataSource = new AccidentClaimSource()}
                            }
                        }
                    }
            };
        }
    }
}
