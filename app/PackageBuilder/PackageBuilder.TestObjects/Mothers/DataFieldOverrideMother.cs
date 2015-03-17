using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataFieldOverrideMother
    {
        public static IDataFieldOverride Vin
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Vin", "Vin", "Vin")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride License
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("License", "License", "License")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride Registration
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Registration", "Registration", "Registration")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride SpecificInformation
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("SpecificInformation", "SpecificInformation", "SpecificInformation")
                    .With(25d)
                    .With(Colour, EngineNumber,LicenseNumber, Odometer, RegistrationNumber, VinNumber)
                    .Build();
            }
        }

        public static IDataFieldOverride Colour
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Colour", "Colour", "Colour")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride EngineNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("EngineNumber", "EngineNumber", "EngineNumber")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride LicenseNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("LicenseNumber", "LicenseNumber", "LicenseNumber")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride Odometer
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Odometer", "Odometer", "Odometer")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride RegistrationNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("RegistrationNumber", "RegistrationNumber", "RegistrationNumber")
                    .With(25d)
                    .Build();
            }
        }

        public static IDataFieldOverride VinNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("VinNumber", "VinNumber", "VinNumber")
                    .With(25d)
                    .Build();
            }
        }
    }
}