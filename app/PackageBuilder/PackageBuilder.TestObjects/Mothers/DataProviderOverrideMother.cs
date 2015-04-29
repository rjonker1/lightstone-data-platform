using System;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataProviderOverrideMother
    {
        public static IDataProviderOverride Ivid
        {
            get
            {
                return new DataProviderOverrideBuilder()
                    .With(Guid.NewGuid())
                    .With(20m)
                    .With(DataFieldOverrideMother.Vin, DataFieldOverrideMother.License, DataFieldOverrideMother.Registration, DataFieldOverrideMother.SpecificInformation)
                    .Build();
            }
        }
    }
}