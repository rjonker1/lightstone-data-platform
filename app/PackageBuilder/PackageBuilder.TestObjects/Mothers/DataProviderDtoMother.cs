using System;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataProviderDtoMother
    {
        public static DataProviderDto Ivid
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("Ivid", "Ivid")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.EngineNumber, RequestFieldDtoMother.ChassisNumber, RequestFieldDtoMother.VinNumber, 
                            RequestFieldDtoMother.LicenseNumber, RequestFieldDtoMother.RegisterNumber, RequestFieldDtoMother.Make)
                    .With(false
                    , DataFieldDtoMother.SpecificInformation
                    , DataFieldDtoMother.StatusMessage
                    , DataFieldDtoMother.Reference
                    , DataFieldDtoMother.License
                    , DataFieldDtoMother.Registration
                    , DataFieldDtoMother.RegistrationDate
                    , DataFieldDtoMother.Vin
                    , DataFieldDtoMother.Engine
                    , DataFieldDtoMother.Displacement
                    , DataFieldDtoMother.Tare
                    , DataFieldDtoMother.MakeCode
                    , DataFieldDtoMother.MakeDescription
                    , DataFieldDtoMother.ModelCode
                    , DataFieldDtoMother.ModelDescription
                    , DataFieldDtoMother.ColourCode
                    , DataFieldDtoMother.ColourDescription
                    , DataFieldDtoMother.DrivenCode
                    , DataFieldDtoMother.DrivenDescription
                    , DataFieldDtoMother.CategoryCode
                    , DataFieldDtoMother.CategoryDescription
                    , DataFieldDtoMother.DescriptionCode
                    , DataFieldDtoMother.Description
                    , DataFieldDtoMother.EconomicSectorCode
                    , DataFieldDtoMother.EconomicSectorDescription
                    , DataFieldDtoMother.LifeStatusCode
                    , DataFieldDtoMother.LifeStatusDescription
                    , DataFieldDtoMother.SapMarkCode
                    , DataFieldDtoMother.SapMarkDescription
                    , DataFieldDtoMother.HasIssues
                    , DataFieldDtoMother.HasErrors
                    , DataFieldDtoMother.HasNoRecords
                    , DataFieldDtoMother.CarFullname)
                    .Build();
            }
        }
        public static DataProviderDto IvidTitleHolder
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("IvidTitleHolder", "IvidTitleHolder")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, DataFieldDtoMother.VinNumber)
                    .With(false
                    , DataFieldDtoMother.BankName
                    , DataFieldDtoMother.AccountNumber
                    , DataFieldDtoMother.DateOpened
                    , DataFieldDtoMother.FlaggedOnAnpr
                    , DataFieldDtoMother.FinancialInterestsHeading
                    , DataFieldDtoMother.AccountOpenDate
                    , DataFieldDtoMother.AccountClosedDate
                    , DataFieldDtoMother.AgreementType
                    , DataFieldDtoMother.YearOfLiabilityForLicensing
                    , DataFieldDtoMother.RequestFinancialInterestInvite
                    , DataFieldDtoMother.FinancialInterestAvailable
                    , DataFieldDtoMother.PartialResponse
                    , DataFieldDtoMother.HasErrors
                    , DataFieldDtoMother.ExpiredMessage)
                    .Build();
            }
        }

        public static DataProviderDto LightstoneAuto
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("LightstoneAuto", "Lightstone Auto")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.CarId, RequestFieldDtoMother.Make, RequestFieldDtoMother.Year, RequestFieldDtoMother.VinNumber)
                    .With(false
                    , DataFieldDtoMother.CarId
                    , DataFieldDtoMother.Year
                    , DataFieldDtoMother.Vin
                    , DataFieldDtoMother.ImageUrl
                    , DataFieldDtoMother.QuarterString
                    , DataFieldDtoMother.CarFullname
                    , DataFieldDtoMother.Model
                    , DataFieldDtoMother.VehicleValuation)
                    .Build();
            }
        }

        public static DataProviderDto Rgt
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("Rgt", "Rgt")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.CarId)
                    .With(false
                    , DataFieldDtoMother.Manufacturer
                    , DataFieldDtoMother.ModelYear
                    , DataFieldDtoMother.ModelType
                    , DataFieldDtoMother.TopSpeed
                    , DataFieldDtoMother.Kilowatts
                    , DataFieldDtoMother.FuelEconomy
                    , DataFieldDtoMother.Acceleration
                    , DataFieldDtoMother.Torque
                    , DataFieldDtoMother.Emissions
                    , DataFieldDtoMother.EngineSize
                    , DataFieldDtoMother.BodyShape
                    , DataFieldDtoMother.FuelType
                    , DataFieldDtoMother.TransmissionType
                    , DataFieldDtoMother.CarFullname
                    , DataFieldDtoMother.Colour
                    , DataFieldDtoMother.RainSensorWindscreenWipers
                    , DataFieldDtoMother.HeadUpDisplay
                    , DataFieldDtoMother.VehicleType
                    , DataFieldDtoMother.Model
                    , DataFieldDtoMother.Make
                    , DataFieldDtoMother.CarType)
                    .Build();
            }
        }

        public static DataProviderDto RgtVin
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("RgtVin", "RgtVin")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.VinNumber)
                    .With(false
                    , DataFieldDtoMother.Vin
                    , DataFieldDtoMother.VehicleMake
                    , DataFieldDtoMother.VehicleType
                    , DataFieldDtoMother.VehicleModel
                    , DataFieldDtoMother.Year
                    , DataFieldDtoMother.Month
                    , DataFieldDtoMother.QuarterIntNullable
                    , DataFieldDtoMother.RgtCode
                    , DataFieldDtoMother.Price
                    , DataFieldDtoMother.Colour
                    , DataFieldDtoMother.CarFullname)
                    .Build();
            }
        }

        public static DataProviderDto PCubedFica
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("PCubedFica", "PCubedFica")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    //.With(true, RequestFieldDtoMother.VinNumber)
                    .With(false
                    , DataFieldDtoMother.TransactionToken
                    , DataFieldDtoMother.IdNumber
                    , DataFieldDtoMother.Initials
                    , DataFieldDtoMother.Surname
                    , DataFieldDtoMother.CellNumber
                    , DataFieldDtoMother.LifeStatus
                    , DataFieldDtoMother.DateOfBirth
                    , DataFieldDtoMother.ResponseDate)
                    .Build();
            }
        }

        public static DataProviderDto SignioDecryptDriversLicense
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("SignioDecryptDriversLicense", "SignioDecryptDriversLicense")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    //.With(true, RequestFieldDtoMother.VinNumber)
                    .With(false, DataFieldDtoMother.DrivingLicenseCard)
                    .Build();
            }
        }

        public static DataProviderDto LightstoneProperty
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("LightstoneProperty", "LightstoneProperty")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.IdentityNumber)
                    .With(false, DataFieldDtoMother.PropertyInformation)
                    .Build();
            }
        }

        public static DataProviderDto LightstoneBusinessCompany
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("LightstoneBusinessCompany", "LightstoneBusinessCompany")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.CompanyName, RequestFieldDtoMother.CompanyRegistrationNumber, RequestFieldDtoMother.CompanyVatNumber)
                    .With(false, DataFieldDtoMother.Companies)
                    .Build();
            }
        }

        public static DataProviderDto LightstoneBusinessDirector
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("LightstoneBusinessDirector", "LightstoneBusinessDirector")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.IdentityNumber, RequestFieldDtoMother.FirstName, RequestFieldDtoMother.Surname)
                    .With(false, DataFieldDtoMother.Directors)
                    .Build();
            }
        }
    }
}