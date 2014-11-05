using System;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ReadDataProviderMother
    {
        public static Domain.Entities.DataProviders.ReadModels.DataProvider Ivid
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"))
                    .With("Ivid")
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static Domain.Entities.DataProviders.ReadModels.DataProvider IvidTitleHolder
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B"))
                    .With("IvidTitleHolder")
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static Domain.Entities.DataProviders.ReadModels.DataProvider RgtVin
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D"))
                    .With("RgtVin")
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }

        public static Domain.Entities.DataProviders.ReadModels.DataProvider Audatex
        {
            get
            {
                return new ReadDataProviderBuilder()
                    .With(new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51"))
                    .With("Audatex")
                    .With(DateTime.Now)
                    .With(10d)
                    .With(1)
                    .Build();
            }
        }
    }
}