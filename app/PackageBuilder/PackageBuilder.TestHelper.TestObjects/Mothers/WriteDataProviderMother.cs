using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class WriteDataProviderMother
    {
        public static DataProvider Ivid
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Ivid)
                    .With("Ivid")
                    .With(10d)
                    .With(typeof(IProvideDataFromIvid))
                    .Build();
            }
        }

        public static DataProvider IvidTitleHolder
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.IvidTitleHolder)
                    .With("IvidTitleHolder")
                    .With(10d)
                    .With(typeof(IProvideDataFromIvidTitleHolder))
                    .Build();
            }
        }

        public static IDataProvider RgtVin
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.RgtVin)
                    .With("RgtVin")
                    .With(10d)
                    .With(typeof(IProvideDataFromRgtVin))
                    .Build();
            }
        }

        public static IDataProvider Rgt
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Rgt)
                    .With("Rgt")
                    .With(10d)
                    .With(typeof(IProvideDataFromRgt))
                    .Build();
            }
        }
    }
}