﻿using System;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class WriteDataProviderMother
    {
        public static DataProvider Ivid
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Ivid)
                    .With(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"))
                    .With(new []{ DataFieldMother.ColourField, DataFieldMother.LicenseField })
                    .Build();
            }
        }

        public static DataProvider IvidTitleHolder
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.IvidTitleHolder)
                    .With(new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B"))
                    .With(new[] { DataFieldMother.ColourField, DataFieldMother.LicenseField })
                    .Build();
            }
        }

        public static IDataProvider RgtVin
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.RgtVin)
                    .With(new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D"))
                    .With(new[] { DataFieldMother.ColourField, DataFieldMother.LicenseField })
                    .Build();
            }
        }

        public static IDataProvider Rgt
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Rgt)
                    .With(new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51"))
                    .With(new[] { DataFieldMother.ColourField, DataFieldMother.LicenseField })
                    .Build();
            }
        }
    }
}