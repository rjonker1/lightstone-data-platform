using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarInfoRepository : IReadOnlyCarRepository<CarInformation>
    {
        public IEnumerable<CarInformation> Get(string sql, object param)
        {
            PropertyInfo[] props = param.GetType().GetProperties();
            var vin = props[0].GetValue(param);

            //dynamic parameter = param;
            //var vin = parameter[0].Vin;

            var data = 
                Mothers.Sources.Lightstone.CarInfoData.CarInformationWithVin().
                Where(w => w.Key == vin.ToString())
                    .Select(
                        s =>
                            new CarInformation(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId)).ToList();
            return data;
        }

        public IEnumerable<CarInformation> GetAll(string sql)
        {
            return Mothers.Sources.Lightstone.CarInfoData.CarInformation();
        }
    }
}
