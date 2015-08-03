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