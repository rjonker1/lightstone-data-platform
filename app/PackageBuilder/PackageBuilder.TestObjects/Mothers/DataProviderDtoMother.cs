using System;
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
                    .With(10m)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(false, DataFieldDtoMother.CarFullname, DataFieldDtoMother.SpecificInformation)
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
                    .With(10m)
                    .With(true)
                    .With(1)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(false, DataFieldDtoMother.CategoryCode)
                    .Build();
            }
        }

        public static DataProviderDto LightstoneAuto
        {
            get
            {
                return new DataProviderDtoBuilder()
                    .With(Guid.NewGuid())
                    .With("LightstoneAuto", "Lightstone Auto")
                    .With("Owner")
                    .With(10m)
                    .With(true)
                    .With(2)
                    .With(DateTime.UtcNow)
                    .With((DateTime?)DateTime.UtcNow.AddDays(1))
                    .With(true, RequestFieldDtoMother.CarId, RequestFieldDtoMother.Make, RequestFieldDtoMother.Year, RequestFieldDtoMother.VinNumber)
                    .With(false, DataFieldDtoMother.CarId
                    , DataFieldDtoMother.Year
                    , DataFieldDtoMother.Vin
                    , DataFieldDtoMother.ImageUrl
                    , DataFieldDtoMother.QuarterString
                    , DataFieldDtoMother.CarFullname
                    , DataFieldDtoMother.Model
                    , DataFieldDtoMother.VehicleValuation)
                    .Build();
            }
        }
    }
}