using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberLightstoneSourcePackage
    {
        public static IPackage LicenseNumberPackage()
        {
            var dataProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.Lightstone, 0.00, false, new List<IDataField>() {});

            return new Package(Guid.NewGuid(), "License plate search",
                new PackageBuilder.Domain.Entities.Action("License plate search"),
                new List<IDataProvider>() {dataProvider});
        }
    }
}
