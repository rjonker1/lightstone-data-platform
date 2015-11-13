using System.Collections.Generic;
using System.Linq;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeVin12CarInfoRepository : IReadOnlyRepository
    {
        private readonly string _vin;

        public FakeVin12CarInfoRepository(string vin)
        {
            _vin = vin;
        }

        public IEnumerable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            return (IEnumerable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformationFromVinShort().Select(
                    s =>
                        new CarInformationDto(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                            s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                            s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                            s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId));
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IEnumerable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformationFromVinShort()
                    .Where(w => w.Key == _vin)
                    .Select(
                        s =>
                            new CarInformationDto(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId));
        }

    }
}
