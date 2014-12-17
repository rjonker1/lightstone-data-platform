﻿using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class ReadDataProviderMother
    {
        public static DataProvider Ivid
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"))
                    .With(DataProviderName.Ivid)
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static DataProvider IvidTitleHolder
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B"))
                    .With(DataProviderName.IvidTitleHolder)
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static DataProvider RgtVin
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D"))
                    .With(DataProviderName.RgtVin)
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static DataProvider Rgt
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51"))
                    .With(DataProviderName.Rgt)
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }
    }
}