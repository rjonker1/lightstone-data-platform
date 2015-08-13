using System;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataFieldDtoMother
    {
        public static DataProviderFieldItemDto StatusMessage
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StatusMessage", "StatusMessage Label", "StatusMessage Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Reference
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Reference", "Reference Label", "Reference Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto License
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("License", "License Label", "License Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Registration
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Registration", "Registration Label", "Registration Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegistrationDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegistrationDate", "RegistrationDate Label", "RegistrationDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Engine
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Engine", "Engine Label", "Engine Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Displacement
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Displacement", "Displacement Label", "Displacement Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Tare
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Tare", "Tare Label", "Tare Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MakeCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MakeCode", "MakeCode Label", "MakeCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MakeDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MakeDescription", "MakeDescription Label", "MakeDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ModelCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ModelCode", "ModelCode Label", "ModelCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ModelDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ModelDescription", "ModelDescription Label", "ModelDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ColourCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ColourCode", "ColourCode Label", "ColourCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ColourDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ColourDescription", "ColourDescription Label", "ColourDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DrivenCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DrivenCode", "DrivenCode Label", "DrivenCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DrivenDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DrivenDescription", "DrivenDescription Label", "DrivenDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CategoryDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CategoryDescription", "CategoryDescription Label", "CategoryDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DescriptionCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DescriptionCode", "DescriptionCode Label", "DescriptionCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Description
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Description", "Description Label", "Description Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EconomicSectorCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EconomicSectorCode", "EconomicSectorCode Label", "EconomicSectorCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EconomicSectorDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EconomicSectorDescription", "EconomicSectorDescription Label", "EconomicSectorDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LifeStatusCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LifeStatusCode", "LifeStatusCode Label", "LifeStatusCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LifeStatusDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LifeStatusDescription", "LifeStatusDescription Label", "LifeStatusDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SapMarkCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SapMarkCode", "SapMarkCode Label", "SapMarkCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SapMarkDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SapMarkDescription", "SapMarkDescription Label", "SapMarkDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto HasIssues
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("HasIssues", "HasIssues Label", "HasIssues Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto HasErrors
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("HasErrors", "HasErrors Label", "HasErrors Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto HasNoRecords
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("HasNoRecords", "HasNoRecords Label", "HasNoRecords Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CarFullname
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CarFullname", "CarFullname Label", "CarFullname Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CarId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CarId", "CarId Label", "CarId Definition")
                    .With(true)
                    .With(typeof(int?).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CategoryCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CategoryCode", "CategoryCode Label", "CategoryCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BankName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BankName", "BankName Label", "BankName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AccountNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AccountNumber", "AccountNumber Label", "AccountNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DateOpened
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DateOpened", "DateOpened Label", "DateOpened Definition")
                    .With(true)
                    .With(typeof(DateTime?).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FlaggedOnAnpr
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FlaggedOnAnpr", "FlaggedOnAnpr Label", "FlaggedOnAnpr Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FinancialInterestsHeading
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FinancialInterestsHeading", "FinancialInterestsHeading Label", "FinancialInterestsHeading Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AccountOpenDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AccountOpenDate", "AccountOpenDate Label", "AccountOpenDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AccountClosedDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AccountClosedDate", "AccountClosedDate Label", "AccountClosedDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AgreementType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AgreementType", "AgreementType Label", "AgreementType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto YearOfLiabilityForLicensing
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("YearOfLiabilityForLicensing", "YearOfLiabilityForLicensing Label", "YearOfLiabilityForLicensing Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RequestFinancialInterestInvite
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RequestFinancialInterestInvite", "RequestFinancialInterestInvite Label", "RequestFinancialInterestInvite Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FinancialInterestAvailable
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FinancialInterestAvailable", "FinancialInterestAvailable Label", "FinancialInterestAvailable Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PartialResponse
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PartialResponse", "PartialResponse Label", "PartialResponse Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ExpiredMessage
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ExpiredMessage", "ExpiredMessage Label", "ExpiredMessage Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Colour
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Colour", "Colour Label", "Colour Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EngineNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EngineNumber", "EngineNumber Label", "EngineNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ImageUrl
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ImageUrl", "ImageUrl Label", "ImageUrl Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Year
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Year", "Year Label", "Year Definition")
                    .With(true)
                    .With(typeof(int?).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Month
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Month", "Month Label", "Month Definition")
                    .With(true)
                    .With(typeof(int?).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Model
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Model", "Model Label", "Model Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Manufacturer
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Manufacturer", "Manufacturer Label", "Manufacturer Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ModelYear
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ModelYear", "ModelYear Label", "ModelYear Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ModelType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ModelType", "ModelType Label", "ModelType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Make
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Make", "Make Label", "Make Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TopSpeed
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TopSpeed", "TopSpeed Label", "TopSpeed Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Kilowatts
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Kilowatts", "Kilowatts Label", "Kilowatts Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FuelEconomy
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FuelEconomy", "FuelEconomy Label", "FuelEconomy Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Acceleration
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Acceleration", "Acceleration Label", "Acceleration Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Torque
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Torque", "Torque Label", "Torque Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Emissions
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Emissions", "Emissions Label", "Emissions Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EngineSize
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EngineSize", "EngineSize Label", "EngineSize Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BodyShape
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BodyShape", "BodyShape Label", "BodyShape Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FuelType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FuelType", "FuelType Label", "FuelType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TransmissionType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TransmissionType", "TransmissionType Label", "TransmissionType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RainSensorWindscreenWipers
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RainSensorWindscreenWipers", "RainSensorWindscreenWipers Label", "RainSensorWindscreenWipers Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto HeadUpDisplay
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("HeadUpDisplay", "HeadUpDisplay Label", "HeadUpDisplay Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleType", "VehicleType Label", "VehicleType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleModel
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleModel", "VehicleModel Label", "VehicleModel Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleMake
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleMake", "VehicleMake Label", "VehicleMake Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DrivingLicense
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DrivingLicense", "DrivingLicense Label", "DrivingLicense Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(CertificateNumber, CountryOfIssue)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IdentityDocument
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IdentityDocument", "IdentityDocument Label", "IdentityDocument Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Number, IdentityType)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SrId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SrId", "SrId Label", "SrId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PropertyId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PropertyId", "PropertyId Label", "PropertyId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Id
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Id", "Id Label", "Id Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DirectorId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DirectorId", "DirectorId Label", "DirectorId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyId", "CompanyId Label", "CompanyId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EnterpriseType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EnterpriseType", "EnterpriseType Label", "EnterpriseType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ShortenType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ShortenType", "ShortenType Label", "ShortenType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyRegNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyRegNumber", "CompanyRegNumber Label", "CompanyRegNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto OldRegistrationNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("OldRegistrationNumber", "OldRegistrationNumber Label", "OldRegistrationNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TypeDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TypeDate", "TypeDate Label", "TypeDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyName", "CompanyName Label", "CompanyName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ShortName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ShortName", "ShortName Label", "ShortName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TranslatedName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TranslatedName", "TranslatedName Label", "TranslatedName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessStartDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessStartDate", "BusinessStartDate Label", "BusinessStartDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto WithdrawnPublic
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("WithdrawnPublic", "WithdrawnPublic Label", "WithdrawnPublic Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StatusCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StatusCode", "StatusCode Label", "StatusCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StatusDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StatusDate", "StatusDate Label", "StatusDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisterNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisterNumber", "RegisterNumber Label", "RegisterNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ExecutorName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ExecutorName", "ExecutorName Label", "ExecutorName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ExecutorAppointDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ExecutorAppointDate", "ExecutorAppointDate Label", "ExecutorAppointDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TrusteeName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TrusteeName", "TrusteeName Label", "TrusteeName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FormLodgeDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FormLodgeDate", "FormLodgeDate Label", "FormLodgeDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FormReceiveDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FormReceiveDate", "FormReceiveDate Label", "FormReceiveDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FoundingStatementDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FoundingStatementDate", "FoundingStatementDate Label", "FoundingStatementDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MemberSize
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MemberSize", "MemberSize Label", "MemberSize Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MemberContribution
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MemberContribution", "MemberContribution Label", "MemberContribution Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MemberContributionType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MemberContributionType", "MemberContributionType Label", "MemberContributionType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ExclCon
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ExclCon", "ExclCon Label", "ExclCon Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisteredAddress1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisteredAddress1", "RegisteredAddress1 Label", "RegisteredAddress1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisteredAddress2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisteredAddress2", "RegisteredAddress2 Label", "RegisteredAddress2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisteredAddress3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisteredAddress3", "RegisteredAddress3 Label", "RegisteredAddress3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisteredAddress4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisteredAddress4", "RegisteredAddress4 Label", "RegisteredAddress4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisteredPostCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisteredPostCode", "RegisteredPostCode Label", "RegisteredPostCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResidentialAddress1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResidentialAddress1", "ResidentialAddress1 Label", "ResidentialAddress1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResidentialAddress2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResidentialAddress2", "ResidentialAddress2 Label", "ResidentialAddress2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResidentialAddress3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResidentialAddress3", "ResidentialAddress3 Label", "ResidentialAddress3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResidentialAddress4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResidentialAddress4", "ResidentialAddress4 Label", "ResidentialAddress4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResidentialPostCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResidentialPostCode", "ResidentialPostCode Label", "ResidentialPostCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessAddress1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessAddress1", "BusinessAddress1 Label", "BusinessAddress1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessAddress2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessAddress2", "BusinessAddress2 Label", "BusinessAddress2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessAddress3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessAddress3", "BusinessAddress3 Label", "BusinessAddress3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessAddress4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessAddress4", "BusinessAddress4 Label", "BusinessAddress4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BusinessPostCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BusinessPostCode", "BusinessPostCode Label", "BusinessPostCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SicCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SicCode", "SicCode Label", "SicCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FinancialYearEnd
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FinancialYearEnd", "FinancialYearEnd Label", "FinancialYearEnd Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FinancialEffectiveDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FinancialEffectiveDate", "FinancialEffectiveDate Label", "FinancialEffectiveDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PhysicalAddress1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PhysicalAddress1", "PhysicalAddress1 Label", "PhysicalAddress1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PhysicalAddress2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PhysicalAddress2", "PhysicalAddress2 Label", "PhysicalAddress2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PhysicalAddress3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PhysicalAddress3", "PhysicalAddress3 Label", "PhysicalAddress3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PhysicalAddress4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PhysicalAddress4", "PhysicalAddress4 Label", "PhysicalAddress4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PhysicalPostCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PhysicalPostCode", "PhysicalPostCode Label", "PhysicalPostCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalAddress1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalAddress1", "PostalAddress1 Label", "PostalAddress1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalAddress2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalAddress2", "PostalAddress2 Label", "PostalAddress2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalAddress3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalAddress3", "PostalAddress3 Label", "PostalAddress3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalAddress4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalAddress4", "PostalAddress4 Label", "PostalAddress4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalPostCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalPostCode", "PostalPostCode Label", "PostalPostCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto OccupationCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("OccupationCode", "OccupationCode Label", "OccupationCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FineExpiryDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FineExpiryDate", "FineExpiryDate Label", "FineExpiryDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto NatureOfChange
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("NatureOfChange", "NatureOfChange Label", "NatureOfChange Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto NationalityCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("NationalityCode", "NationalityCode Label", "NationalityCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Profession
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Profession", "Profession Label", "Profession Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResignationDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResignationDate", "ResignationDate Label", "ResignationDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Estate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Estate", "Estate Label", "Estate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LsId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LsId", "LsId Label", "LsId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StatusOrder
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StatusOrder", "StatusOrder Label", "StatusOrder Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CountryCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CountryCode", "CountryCode Label", "CountryCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TypeCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TypeCode", "TypeCode Label", "TypeCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CountryOfOrigin
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CountryOfOrigin", "CountryOfOrigin Label", "CountryOfOrigin Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegionCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegionCode", "RegionCode Label", "RegionCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AuthorisedCapital
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AuthorisedCapital", "AuthorisedCapital Label", "AuthorisedCapital Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AuthorisedShares
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AuthorisedShares", "AuthorisedShares Label", "AuthorisedShares Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IssuedCapital
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IssuedCapital", "IssuedCapital Label", "IssuedCapital Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IssuedShares
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IssuedShares", "IssuedShares Label", "IssuedShares Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DeedId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DeedId", "DeedId Label", "DeedId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PropertyTypeId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PropertyTypeId", "PropertyTypeId Label", "PropertyTypeId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SsId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SsId", "SsId Label", "SsId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto NadId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("NadId", "NadId Label", "NadId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PropertyType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PropertyType", "PropertyType Label", "PropertyType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FormReceivedDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FormReceivedDate", "FormReceivedDate Label", "FormReceivedDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FormDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FormDate", "FormDate Label", "FormDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ConversionNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ConversionNumber", "ConversionNumber Label", "ConversionNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TaxNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TaxNumber", "TaxNumber Label", "TaxNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Cpa
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Cpa", "Cpa Label", "Cpa Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StatusCodeDesc
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StatusCodeDesc", "StatusCodeDesc Label", "StatusCodeDesc Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegionCodeDesc
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegionCodeDesc", "RegionCodeDesc Label", "RegionCodeDesc Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SicDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SicDescription", "SicDescription Label", "SicDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Province
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Province", "Province Label", "Province Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Muncipality
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Muncipality", "Muncipality Label", "Muncipality Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Deedtown
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Deedtown", "Deedtown Label", "Deedtown Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FarmName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FarmName", "FarmName Label", "FarmName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SectionalTitle
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SectionalTitle", "SectionalTitle Label", "SectionalTitle Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Unit
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Unit", "Unit Label", "Unit Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Portion
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Portion", "Portion Label", "Portion Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BuyerName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BuyerName", "BuyerName Label", "BuyerName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FirstName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FirstName", "FirstName Label", "FirstName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SecondMiddleName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SecondMiddleName", "SecondMiddleName Label", "SecondMiddleName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ThirdMiddleName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ThirdMiddleName", "ThirdMiddleName Label", "ThirdMiddleName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PersonTypeId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PersonTypeId", "PersonTypeId Label", "PersonTypeId Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BuyerIdCk
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BuyerIdCk", "BuyerIdCk Label", "BuyerIdCk Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MunicId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MunicId", "MunicId Label", "MunicId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ProvId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ProvId", "ProvId Label", "ProvId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StreetNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StreetNumber", "StreetNumber Label", "StreetNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StreetType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StreetType", "StreetType Label", "StreetType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Suburb
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Suburb", "Suburb Label", "Suburb Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PostalCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PostalCode", "PostalCode Label", "PostalCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TitleDeedNo
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TitleDeedNo", "TitleDeedNo Label", "TitleDeedNo Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Township
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Township", "Township Label", "Township Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto UserId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("UserId", "UserId Label", "UserId Definition")
                    .With(true)
                    .With(typeof(Guid).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PurchasePrice
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PurchasePrice", "PurchasePrice Label", "PurchasePrice Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PurchaseDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PurchaseDate", "PurchaseDate Label", "PurchaseDate Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Garage
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Garage", "Garage Label", "Garage Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Size
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Size", "Size Label", "Size Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto XCoOrdinates
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("XCoOrdinates", "XCoOrdinates Label", "XCoOrdinates Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto YCoOrdinates
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("YCoOrdinates", "YCoOrdinates Label", "YCoOrdinates Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SectionalSchemeUnitTo
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SectionalSchemeUnitTo", "SectionalSchemeUnitTo Label", "SectionalSchemeUnitTo Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SectionlSchemeUnitNoFrom
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SectionlSchemeUnitNoFrom", "SectionlSchemeUnitNoFrom Label", "SectionlSchemeUnitNoFrom Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SectionSchemeNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SectionSchemeNumber", "SectionSchemeNumber Label", "SectionSchemeNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Number
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Number", "Number Label", "Number Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BondNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BondNumber", "BondNumber Label", "BondNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TownshipAlt
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TownshipAlt", "TownshipAlt Label", "TownshipAlt Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RemainingExtent
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RemainingExtent", "RemainingExtent Label", "RemainingExtent Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AdditionalDescription
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AdditionalDescription", "AdditionalDescription Label", "AdditionalDescription Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SuburbId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SuburbId", "SuburbId Label", "SuburbId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MiddleName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MiddleName", "MiddleName Label", "MiddleName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EstimatedCoOrdinates
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EstimatedCoOrdinates", "EstimatedCoOrdinates Label", "EstimatedCoOrdinates Definition")
                    .With(true)
                    .With(typeof(bool).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto StreetId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("StreetId", "StreetId Label", "StreetId Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ReqStatusId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ReqStatusId", "ReqStatusId Label", "ReqStatusId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EstateId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EstateId", "EstateId Label", "EstateId Definition")
                    .With(true)
                    .With(typeof(int).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EstateName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EstateName", "EstateName Label", "EstateName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ActiveStatus
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ActiveStatus", "ActiveStatus Label", "ActiveStatus Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IdentityType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IdentityType", "IdentityType Label", "IdentityType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Person
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Person", "Person Label", "Person Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Surname, Initials, DriverRestriction1, DriverRestriction2, DateOfBirthString, PreferenceLanguage, Gender)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DriverRestriction1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DriverRestriction1", "DriverRestriction1 Label", "DriverRestriction1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DriverRestriction2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DriverRestriction2", "DriverRestriction2 Label", "DriverRestriction2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DateOfBirthString
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DateOfBirth", "DateOfBirth Label", "DateOfBirth Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PreferenceLanguage
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PreferenceLanguage", "PreferenceLanguage Label", "PreferenceLanguage Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Gender
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Gender", "Gender Label", "Gender Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DrivingLicenseCard
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DrivingLicense", "DrivingLicense Label", "DrivingLicense Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(
                      IdentityDocument
                    , Person
                    , DrivingLicense
                    , Card
                    , ProfessionalDrivingPermit
                    , VehicleClass1
                    , VehicleClass2
                    , VehicleClass3
                    , VehicleClass4
                    , Photo
                    , Cellphone
                    , EmailAddress
                    )
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PropertyInformation
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PropertyInformation", "PropertyInformation Label", "PropertyInformation Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(
                      SrId
                    , PropertyId
                    , DeedId
                    , PropertyTypeId
                    , SsId
                    , NadId
                    , PropertyType
                    , Province
                    , Muncipality
                    , Deedtown
                    , FarmName
                    , SectionalTitle
                    , Unit
                    , Portion
                    , BuyerName
                    , FirstName
                    , SecondMiddleName
                    , ThirdMiddleName
                    , Surname
                    , PersonTypeId
                    , BuyerIdCk
                    , MunicId
                    , ProvId
                    , StreetNumber
                    , StreetType
                    , PostalCode
                    , UserId
                    , Garage
                    , SectionSchemeNumber
                    , SectionlSchemeUnitNoFrom
                    , SectionalSchemeUnitTo
                    , Size
                    , XCoOrdinates
                    , YCoOrdinates
                    , Suburb
                    , TitleDeedNo
                    , RegistrationDate
                    , Township
                    , PurchasePrice
                    , PurchaseDate
                    , BondNumber
                    , TownshipAlt
                    , RemainingExtent
                    , AdditionalDescription
                    , SuburbId
                    , StreetId
                    , ActiveStatus
                    , EstateName
                    , EstateId
                    , ReqStatusId
                    , EstimatedCoOrdinates
                    , MiddleName
                    )
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Companies
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Companies", "Companies Label", "Companies Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(
                      Id
                    , EnterpriseType
                    , ShortenType
                    , CompanyRegNumber
                    , OldRegistrationNumber
                    , TypeDate
                    , CompanyName
                    , ShortName
                    , TranslatedName
                    , RegistrationDate
                    , BusinessStartDate
                    , WithdrawnPublic
                    , StatusCode
                    , StatusDate
                    , SicCode
                    , FinancialYearEnd
                    , FinancialEffectiveDate
                    , PhysicalAddress1
                    , PhysicalAddress2
                    , PhysicalAddress3
                    , PhysicalAddress4
                    , PhysicalPostCode
                    , PostalAddress1
                    , PostalAddress2
                    , PostalAddress3
                    , PostalAddress4
                    , PostalPostCode
                    , CountryCode
                    , CountryOfOrigin
                    , RegionCode
                    , AuthorisedCapital
                    , AuthorisedShares
                    , IssuedCapital
                    , IssuedShares
                    , FormReceivedDate
                    , FormDate
                    , ConversionNumber
                    , TaxNumber
                    , Cpa
                    , StatusCodeDesc
                    , RegionCodeDesc
                    , SicDescription
                    )
                    .Build();
            }
        }

        public static DataProviderFieldItemDto Directors
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Directors", "Directors Label", "Directors Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(
                      Id
                    , DirectorId
                    , CompanyId
                    , CompanyRegNumber
                    , FirstName
                    , Initials
                    , Surname
                    , SurnameParticular
                    , PreviousSurname
                    , IdNumberString
                    , BirthDate
                    , DesignationCode
                    , RsaResident
                    , WithdrawPublic
                    , CountryCode
                    , TypeCode
                    , StatusCode
                    , StatusDate
                    , RegisterNumber
                    , ExecutorName
                    , ExecutorAppointDate
                    , TrusteeName
                    , FormLodgeDate
                    , FormReceiveDate
                    , FoundingStatementDate
                    , MemberSize
                    , MemberContribution
                    , MemberContributionType
                    , ExclCon
                    , RegisteredAddress1
                    , RegisteredAddress2
                    , RegisteredAddress3
                    , RegisteredAddress4
                    , RegisteredPostCode
                    , ResidentialAddress1
                    , ResidentialAddress2
                    , ResidentialAddress3
                    , ResidentialAddress4
                    , ResidentialPostCode
                    , BusinessAddress1
                    , BusinessAddress2
                    , BusinessAddress3
                    , BusinessAddress4
                    , BusinessPostCode
                    , PostalAddress1
                    , PostalAddress2
                    , PostalAddress3
                    , PostalAddress4
                    , PostalPostCode
                    , OccupationCode
                    , FineExpiryDate
                    , NatureOfChange
                    , NationalityCode
                    , Profession
                    , ResignationDate
                    , Estate
                    , LsId
                    , StatusOrder
                    )
                    .Build();
            }
        }

        public static DataProviderFieldItemDto CertificateNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CertificateNumber", "CertificateNumber Label", "CertificateNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CountryOfIssue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CountryOfIssue", "CountryOfIssue Label", "CountryOfIssue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DateValidFrom
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DateValidFrom", "DateValidFrom Label", "DateValidFrom Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DateValidUntil
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DateValidUntil", "DateValidUntil Label", "DateValidUntil Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ProfessionalDrivingPermit
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ProfessionalDrivingPermit", "ProfessionalDrivingPermit Label", "ProfessionalDrivingPermit Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Category, DateValidUntil)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Category
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Category", "Category Label", "Category Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Code
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Code", "Code Label", "Code Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleRestriction
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleRestriction", "VehicleRestriction Label", "VehicleRestriction Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Photo
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Photo", "Photo Label", "Photo Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Cellphone
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Cellphone", "Cellphone Label", "Cellphone Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EmailAddress
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EmailAddress", "EmailAddress Label", "EmailAddress Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FirstIssueDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FirstIssueDate", "FirstIssueDate Label", "FirstIssueDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleClass1
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleClass1", "VehicleClass1 Label", "VehicleClass1 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Code, VehicleRestriction, FirstIssueDate)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleClass2
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleClass2", "VehicleClass2 Label", "VehicleClass2 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Code, VehicleRestriction, FirstIssueDate)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleClass3
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleClass3", "VehicleClass3 Label", "VehicleClass3 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Code, VehicleRestriction, FirstIssueDate)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleClass4
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleClass4", "VehicleClass4 Label", "VehicleClass4 Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(Code, VehicleRestriction, FirstIssueDate)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IssueNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IssueNumber", "IssueNumber Label", "IssueNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Card
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Card", "Card Label", "Card Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(new IndustryDto())
                    .With(IssueNumber, DateValidFrom, DateValidUntil)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LicenseNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LicenseNumber", "LicenseNumber Label", "LicenseNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Odometer
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Odometer", "Odometer Label", "Odometer Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegistrationNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegistrationNumber", "RegistrationNumber Label", "RegistrationNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Vin
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Vin", "Vin Label", "Vin Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TransactionToken
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TransactionToken", "TransactionToken Label", "TransactionToken Definition")
                    .With(true)
                    .With(typeof(Guid).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IdNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IdNumber", "IdNumber Label", "IdNumber Definition")
                    .With(true)
                    .With(typeof(Int64).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IdNumberString
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IdNumber", "IdNumber Label", "IdNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto BirthDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("BirthDate", "BirthDate Label", "BirthDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DesignationCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DesignationCode", "DesignationCode Label", "DesignationCode Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RsaResident
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RsaResident", "RsaResident Label", "RsaResident Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto WithdrawPublic
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("WithdrawPublic", "WithdrawPublic Label", "WithdrawPublic Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Initials
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Initials", "Initials Label", "Initials Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Surname
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Surname", "Surname Label", "Surname Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SurnameParticular
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SurnameParticular", "SurnameParticular Label", "SurnameParticular Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto PreviousSurname
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("PreviousSurname", "PreviousSurname Label", "PreviousSurname Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CellNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CellNumber", "CellNumber Label", "CellNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LifeStatus
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LifeStatus", "LifeStatus Label", "LifeStatus Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto DateOfBirth
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("DateOfBirth", "DateOfBirth Label", "DateOfBirth Definition")
                    .With(true)
                    .With(typeof(DateTime?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ResponseDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ResponseDate", "ResponseDate Label", "ResponseDate Definition")
                    .With(true)
                    .With(typeof(DateTime).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VinNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VinNumber", "VinNumber Label", "VinNumber Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto QuarterString
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Quarter", "Quarter Label", "Quarter Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto QuarterDoubleNullable
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Quarter", "Quarter Label", "Quarter Definition")
                    .With(true)
                    .With(typeof(double?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto QuarterIntNullable
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Quarter", "Quarter Label", "Quarter Definition")
                    .With(true)
                    .With(typeof(int?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RgtCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RgtCode", "RgtCode Label", "RgtCode Definition")
                    .With(true)
                    .With(typeof(int?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Price
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Price", "Price Label", "Price Definition")
                    .With(true)
                    .With(typeof(decimal?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EstimatedValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EstimatedValue", "EstimatedValue Label", "EstimatedValue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(RetailEstimatedValue, RetailEstimatedLow, RetailEstimatedHigh, RetailConfidenceValue, RetailConfidenceLevel, TradeEstimatedValue, TradeEstimatedLow, TradeEstimatedHigh, TradeConfidenceValue, TradeConfidenceLevel)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RetailEstimatedValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RetailEstimatedValue", "RetailEstimatedValue Label", "RetailEstimatedValue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RetailEstimatedLow
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RetailEstimatedLow", "RetailEstimatedLow Label", "RetailEstimatedLow Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RetailEstimatedHigh
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RetailEstimatedHigh", "RetailEstimatedHigh Label", "RetailEstimatedHigh Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RetailConfidenceValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RetailConfidenceValue", "RetailConfidenceValue Label", "RetailConfidenceValue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RetailConfidenceLevel
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RetailConfidenceLevel", "RetailConfidenceLevel Label", "RetailConfidenceLevel Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TradeEstimatedValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TradeEstimatedValue", "TradeEstimatedValue Label", "TradeEstimatedValue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TradeEstimatedLow
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TradeEstimatedLow", "TradeEstimatedLow Label", "TradeEstimatedLow Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TradeEstimatedHigh
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TradeEstimatedHigh", "TradeEstimatedHigh Label", "TradeEstimatedHigh Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TradeConfidenceValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TradeConfidenceValue", "TradeConfidenceValue Label", "TradeConfidenceValue Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto TradeConfidenceLevel
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("TradeConfidenceLevel", "TradeConfidenceLevel Label", "TradeConfidenceLevel Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LastFiveSales
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LastFiveSales", "LastFiveSales Label", "LastFiveSales Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(SalesDate, LicensingDistrict, SalesPrice)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SalesDate
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SalesDate", "SalesDate Label", "SalesDate Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LicensingDistrict
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LicensingDistrict", "LicensingDistrict Label", "LicensingDistrict Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SalesPrice
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SalesPrice", "SalesPrice Label", "SalesPrice Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Prices
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Prices", "Prices Label", "Prices Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(Name, ValueDecimal)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Name
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Name", "Name Label", "Name Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ValueDecimal
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Value", "Value Label", "Value Definition")
                    .With(true)
                    .With(typeof(decimal).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ValueDouble
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Value", "Value Label", "Value Definition")
                    .With(true)
                    .With(typeof(double).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ValueDoubleNullable
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Value", "Value Label", "Value Definition")
                    .With(true)
                    .With(typeof(double?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Frequency
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Frequency", "Frequency Label", "Frequency Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(CarType, Year, ValueDouble)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Confidence
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Confidence", "Confidence Label", "Confidence Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(CarType, Year, ValueDouble)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto AmortisedValues
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("AmortisedValues", "AmortisedValues Label", "AmortisedValues Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(Year, ValueDecimal)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CarType
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CarType", "CarType Label", "CarType Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ImageGauges
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ImageGauges", "ImageGauges Label", "ImageGauges Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(MinValue, MaxValue, ValueDoubleNullable, QuarterDoubleNullable, GaugeName)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MinValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MinValue", "MinValue Label", "MinValue Definition")
                    .With(true)
                    .With(typeof(double?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto MaxValue
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("MaxValue", "MaxValue Label", "MaxValue Definition")
                    .With(true)
                    .With(typeof(double?).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto GaugeName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("GaugeName", "GaugeName Label", "GaugeName Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VehicleValuation
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VehicleValuation", "VehicleValuation Label", "VehicleValuation Definition")
                    .With(10d)
                    .With(true)
                    .With(new IndustryDto())
                    .With(typeof(string).ToString())
                    .With(EstimatedValue, LastFiveSales, Prices, Frequency, Confidence, AmortisedValues, ImageGauges)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SpecificInformation
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SpecificInformation", "SpecificInformation Label", "SpecificInformation Definition")
                    .With(10d)
                    .With(true)
                    .With(new IndustryDto())
                    .With(typeof(string).ToString())
                    .With(Odometer, Colour, RegistrationNumber, VinNumber, LicenseNumber, EngineNumber, CategoryDescription)
                    .Build();
            }
        }
    }
}