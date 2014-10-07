using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarInfoRepository : IReadOnlyRepository<CarInfo>
    {
        public IEnumerable<CarInfo> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByMakeAndMetricTypes(int makeId,
            MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByCarIdAndYear(int? carId, int year)
        {
            return Mothers.Sources.Lightstone.CarInfoData.CarInformation().Where(w => w.CarId == carId);
        }

        public IEnumerable<CarInfo> FindByVin(string vinNumber)
        {
            return
                Mothers.Sources.Lightstone.CarInfoData.CarInformationWithVin()
                    .Where(w => w.Key == vinNumber)
                    .Select(
                        s =>
                            new CarInfo(s.Value.CarId, s.Value.Year, s.Value.ImageUrl, s.Value.Quarter,
                                s.Value.CarFullname, s.Value.CarModel));
        }
    }
}
