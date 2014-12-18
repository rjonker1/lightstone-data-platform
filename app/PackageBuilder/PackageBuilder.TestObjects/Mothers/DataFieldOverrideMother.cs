using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataFieldOverrideMother
    {
        public static DataFieldOverride Vin
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Vin", "Vin", "Vin")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride License
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("License", "License", "License")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride Registration
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Registration", "Registration", "Registration")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride SpecificInformation
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("SpecificInformation", "SpecificInformation", "SpecificInformation")
                    .With(10d)
                    .With(Colour, EngineNumber,LicenseNumber, Odometer, RegistrationNumber, VinNumber)
                    .Build();
            }
        }

        public static DataFieldOverride Colour
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Colour", "Colour", "Colour")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride EngineNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("EngineNumber", "EngineNumber", "EngineNumber")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride LicenseNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("LicenseNumber", "LicenseNumber", "LicenseNumber")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride Odometer
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("Odometer", "Odometer", "Odometer")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride RegistrationNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("RegistrationNumber", "RegistrationNumber", "RegistrationNumber")
                    .With(10d)
                    .Build();
            }
        }

        public static DataFieldOverride VinNumber
        {
            get
            {
                return new DataFieldOverrideBuilder()
                    .With("VinNumber", "VinNumber", "VinNumber")
                    .With(10d)
                    .Build();
            }
        }
    }
}