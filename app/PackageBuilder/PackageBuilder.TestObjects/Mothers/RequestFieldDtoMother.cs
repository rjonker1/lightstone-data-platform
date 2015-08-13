using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class RequestFieldDtoMother
    {
        public static DataProviderFieldItemDto CarId
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CarId", "Car Id", "Definition")
                    .With(((int)RequestFieldType.CarId).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Year
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Year", "Year", "Definition")
                    .With(((int)RequestFieldType.Year).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Make
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Make", "Make", "Definition")
                    .With(((int)RequestFieldType.Make).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto VinNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("VinNumber", "VinNumber", "Definition")
                    .With(((int)RequestFieldType.VinNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto RegisterNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("RegisterNumber", "RegisterNumber", "Definition")
                    .With(((int)RequestFieldType.RegisterNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto EngineNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("EngineNumber", "EngineNumber", "Definition")
                    .With(((int)RequestFieldType.EngineNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto ChassisNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("ChassisNumber", "ChassisNumber", "Definition")
                    .With(((int)RequestFieldType.ChassisNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto LicenseNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("LicenseNumber", "LicenseNumber", "Definition")
                    .With(((int)RequestFieldType.LicenseNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto IdentityNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("IdentityNumber", "IdentityNumber", "Definition")
                    .With(((int)RequestFieldType.IdentityNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto FirstName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("FirstName", "FirstName", "Definition")
                    .With(((int)RequestFieldType.FirstName).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto Surname
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("Surname", "Surname", "Definition")
                    .With(((int)RequestFieldType.Surname).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyName
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyName", "CompanyName", "Definition")
                    .With(((int)RequestFieldType.CompanyName).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyRegistrationNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyRegistrationNumber", "CompanyRegistrationNumber", "Definition")
                    .With(((int)RequestFieldType.CompanyRegistrationNumber).ToString())
                    .Build();
            }
        }
        public static DataProviderFieldItemDto CompanyVatNumber
        {
            get
            {
                return new DataFieldDtoBuilder()
                    .With("CompanyVatNumber", "CompanyVatNumber", "CompanyVatNumber")
                    .With(((int)RequestFieldType.CompanyVatNumber).ToString())
                    .Build();
            }
        }
    }
}