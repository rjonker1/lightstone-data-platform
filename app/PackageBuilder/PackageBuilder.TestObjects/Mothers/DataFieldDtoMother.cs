using PackageBuilder.Domain.Dtos;
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
                    .With("CarFullname", "Label", "Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(IndustryMother.Automotive)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CategoryCode
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CategoryCode", "Label", "Definition")
                    .With(true)
                    .With(typeof(string).ToString())
                    .With(10d)
                    .With(IndustryMother.Automotive)
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Colour
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Colour", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EngineNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EngineNumber", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LicenseNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LicenseNumber", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Odometer
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Odometer", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegistrationNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegistrationNumber", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VinNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VinNumber", "Label", "Definition")
                    .With(typeof(string).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto SpecificInformation
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("SpecificInformation", "Label", "Definition")
                    .With(10d)
                    .With(true)
                    .With(IndustryMother.Automotive, IndustryMother.Finance)
                    .With(typeof(string).ToString())
                    .With(Colour, EngineNumber, LicenseNumber, Odometer, RegistrationNumber, VinNumber)
                    .Build();
            }
        }
    }
}