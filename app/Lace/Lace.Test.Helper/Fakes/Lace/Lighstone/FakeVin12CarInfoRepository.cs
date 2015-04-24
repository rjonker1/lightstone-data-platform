using System;
using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeVin12CarInfoRepository : IReadOnlyCarRepository<CarInformation>
    {
        private readonly string _vin;

        public FakeVin12CarInfoRepository(string vin)
        {
            _vin = vin;
        }


        public IEnumerable<CarInformation> Get(string sql, object param)
        {

            return
                Mothers.Sources.Lightstone.CarInfoData.CarInformationFromVinShort()
                    .Where(w => w.Key == _vin)
                    .Select(
                        s =>
                            new CarInformation(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId));
        }

        public IEnumerable<CarInformation> GetAll(string sql)
        {
            throw new NotImplementedException();
        }

    }
}
