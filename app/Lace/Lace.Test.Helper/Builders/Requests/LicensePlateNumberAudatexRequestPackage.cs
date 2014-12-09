using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAudatexRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
            var dataProvider = new DataProvider(
                Guid.NewGuid(), DataProviderName.Audatex, 0.00, false,null);

            return new Package(Guid.NewGuid(), "License plate search",
                new PackageBuilder.Domain.Entities.Action("License plate search"),
                new List<IDataProvider>() {dataProvider});
        }
    }
}
