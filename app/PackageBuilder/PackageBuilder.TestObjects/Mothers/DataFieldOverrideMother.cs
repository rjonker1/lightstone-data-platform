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
    }
}