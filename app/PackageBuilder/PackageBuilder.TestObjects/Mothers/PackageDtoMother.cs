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
                    .With(new IndustryDto{ Id = Guid.NewGuid(), Name = "Finance"})
                    .With(DataProviderDtoMother.Ivid, DataProviderDtoMother.IvidTitleHolder)
                    .Build();
            }
        }

        public static PackageDto Internal(Guid id)
        {
            return new PackageDtoBuilder()
                .With(id)
                .With("Internal", "Description", "Notes")
                .With(StateMother.Published, "Owner")
                .With(1)
                .With(0.1m)
                .With(10m, 20m)
                .With(DateTime.UtcNow)
                .With(new IndustryDto {Id = Guid.NewGuid(), Name = "Finance"})
                .With(DataProviderDtoMother.LightstoneAuto, DataProviderDtoMother.Rgt, DataProviderDtoMother.RgtVin)
                .Build();
        }
    }
}