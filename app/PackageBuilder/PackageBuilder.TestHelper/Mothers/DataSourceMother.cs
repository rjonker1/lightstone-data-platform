﻿using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class DataSourceMother
    {
        public static IDataProvider IvidDataSource
        {
            get
            {
                return
                    new DataSourceBuilder().With("Ivid").With(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A")).Build();
            }
        }

        public static IDataProvider IvidTitleHolderDataSource
        {
            get
            {
                return
                    new DataSourceBuilder().With("IvidTitleHolder")
                        .With(new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B"))
                        .Build();
            }
        }

        public static IDataProvider RgtVinSource
        {
            get
            {
                return
                    new DataSourceBuilder().With("RgtVin")
                        .With(new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D"))
                        .Build();
            }
        }

        public static IDataProvider AudatexSource
        {
            get
            {
                return
                    new DataSourceBuilder().With("Audatex")
                        .With(new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51"))
                        .Build();
            }
        }

        public static IDataProvider LightstoneDataSource
        {
            get
            {
                return
                    new DataSourceBuilder().With("Lightstone")
                        .With(new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A"))
                        .Build();
            }
        }
    }
}