using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataFieldDtoMother
    {
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
                    .With("RetailEstimatedValue", "RetailEstimatedValue Label", "RetailEstimatedValue Definition")
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
                    .With(typeof(decimal).ToString())
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
                    .With(typeof(decimal).ToString())
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
                    .With(typeof(decimal).ToString())
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
                    .With(typeof(decimal).ToString())
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
                    .With(typeof(decimal).ToString())
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
                    .With(typeof(decimal).ToString())
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
                    .With(Colour, EngineNumber, LicenseNumber, Odometer, RegistrationNumber, VinNumber)
                    .Build();
            }
        }
    }
}