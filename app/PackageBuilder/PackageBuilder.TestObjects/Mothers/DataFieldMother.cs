using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataFieldMother
    {
        public static IDataField CarFullname
        {
            get
            {
                return new DataFieldBuilder().With("CarFullname").With(typeof(string)).Build();
            }
        }
        public static IDataField CategoryCode
        {
            get
            {
                return new DataFieldBuilder().With("CategoryCode").With(typeof(string)).Build();
            }
        }
        public static IDataField CategoryDescription
        {
            get
            {
                return new DataFieldBuilder().With("CategoryDescription").With(typeof(string)).Build();
            }
        }
        public static IDataField ColourCode
        {
            get
            {
                return new DataFieldBuilder().With("ColourCode").With(typeof(string)).Build();
            }
        }
        public static IDataField ColourDescription
        {
            get
            {
                return new DataFieldBuilder().With("ColourDescription").With(typeof(string)).Build();
            }
        }
        public static IDataField Colour
        {
            get
            {
                return new DataFieldBuilder().With("Colour").With(typeof(string)).Build();
            }
        }
        public static IDataField EngineNumber
        {
            get
            {
                return new DataFieldBuilder().With("EngineNumber").With(typeof(string)).Build();
            }
        }
        public static IDataField LicenseNumber
        {
            get
            {
                return new DataFieldBuilder().With("LicenseNumber").With(typeof(string)).Build();
            }
        }
        public static IDataField Odometer
        {
            get
            {
                return new DataFieldBuilder().With("Odometer").With(typeof(string)).Build();
            }
        }
        public static IDataField RegistrationNumber
        {
            get
            {
                return new DataFieldBuilder().With("RegistrationNumber").With(typeof(string)).Build();
            }
        }
        public static IDataField VinNumber
        {
            get
            {
                return new DataFieldBuilder().With("VinNumber").With(typeof(string)).Build();
            }
        }
        public static IDataField SpecificInformation
        {
            get
            {
                return new DataFieldBuilder()
                    .With("SpecificInformation", "Label", "Definition")
                    .With(10d)
                    .With(true)
                    .With(IndustryMother.Automotive, IndustryMother.Finance)
                    .With(typeof(string))
                    .With(Colour, EngineNumber, LicenseNumber, Odometer, RegistrationNumber, VinNumber)
                    .Build();
            }
        }
        public static IDataField LicenseField
        {
            get
            {
                return new DataFieldBuilder().With("LicenceNo").With(typeof(string)).Build();
            }
        }
        public static IDataField BankNameField
        {
            get
            {
                return new DataFieldBuilder().With("BankName").With(typeof(string)).Build();
            }
        }
        public static IDataField AccidentClaimsField
        {
            get
            {
                return new DataFieldBuilder().With("AccidentClaims").With(typeof(string)).Build();
            }
        }

        public static IDataField ErfNumberField
        {
            get
            {
                return new DataFieldBuilder().With("ErfNumber").With(typeof(string)).Build();
            }
        }
    }
}