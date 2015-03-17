using System;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class DataProviderDtoMother
    {
        public static DataProviderDto Ivid
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("Ivid", "Ivid")
                    .With("Owner")
                    .With(10d)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(DataFieldDtoMother.CarFullname, DataFieldDtoMother.SpecificInformation)
                    .Build();
            }
        }
        public static DataProviderDto IvidTitleHolder
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("IvidTitleHolder", "IvidTitleHolder")
                    .With("Owner")
                    .With(10d)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(DataFieldDtoMother.CategoryCode)
                    .Build();
            }
        }
    }
}