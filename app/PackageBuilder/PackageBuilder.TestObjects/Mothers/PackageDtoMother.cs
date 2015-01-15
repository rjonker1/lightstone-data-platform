using System;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class PackageDtoMother
    {
        public static PackageDto VVi
        {
            get
            {
                return new PackageDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("VVi", "Description", "Notes")
                    .With("Published", "Owner")
                    .With(1)
                    .With(0.1m)
                    .With(10d, 20d)
                    .With(DateTime.UtcNow)
                    .With(IndustryMother.Automotive)
                    .With(DataProviderDtoMother.Ivid, DataProviderDtoMother.IvidTitleHolder)
                    .Build();
            }
        }

    }
}