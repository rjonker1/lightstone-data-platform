using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {

            var audatexProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.Audatex, 0.00, false, new List<IDataField>() {});

            var lightstoneProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.Lightstone, 0.00, false, new List<IDataField>() {});

            var ividProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.Ivid, 0.00, false, new List<IDataField>() {});

            var ividTitleHolderProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.IvidTitleHolder, 0.00, false, new List<IDataField>() {});

            var rgtProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.Rgt, 0.00, false, new List<IDataField>() {});

            var rgtVinProvider = new PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider(
                Guid.NewGuid(), DataProviderName.RgtVin, 0.00, false, new List<IDataField>() {});

            return new Package(Guid.NewGuid(), "License plate search",
                new PackageBuilder.Domain.Entities.Action("License plate search"),
                new List<IDataProvider>()
                {
                    audatexProvider,
                    lightstoneProvider,
                    ividProvider,
                    ividTitleHolderProvider,
                    rgtProvider,
                    rgtVinProvider
                });
        }
    }
}
