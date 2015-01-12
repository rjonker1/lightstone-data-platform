using System;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.WriteModels;
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
                    .With(DateTime.Now)
                    .With((DateTime?)DateTime.Now.AddDays(1))
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
                    .With(DateTime.Now)
                    .With((DateTime?)DateTime.Now.AddDays(1))
                    .With(DataFieldDtoMother.CategoryCode)
                    .Build();
            }
        }
    }
}