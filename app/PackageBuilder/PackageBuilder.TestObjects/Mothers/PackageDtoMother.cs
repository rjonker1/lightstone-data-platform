using System;
using PackageBuilder.Domain.Dtos.Write;
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
                    .With(StateMother.Published, "Owner")
                    .With(1)
                    .With(0.1m)
                    .With(10m, 20m)
                    .With(DateTime.UtcNow)
                    .With(IndustryMother.Automotive)
                    .With(DataProviderDtoMother.Ivid, DataProviderDtoMother.IvidTitleHolder)
                    .Build();
            }
        }

    }
}