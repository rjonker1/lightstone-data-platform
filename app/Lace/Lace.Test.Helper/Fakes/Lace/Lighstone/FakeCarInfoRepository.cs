using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarInfoRepository : IReadOnlyRepository<CarInfo>
    {
        public IEnumerable<CarInfo> FindAllWithRequest(ILaceRequestCarInformation request)
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

        public IEnumerable<CarInfo> FindByMakeAndMetricTypes(int makeId, Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByCarIdAndYear(int? carId, int year)
        {
            return Mothers.Sources.Lightstone.CarInfoData.CarInformation().Where(w => w.CarId == carId);
        }

        public IEnumerable<CarInfo> FindByVin(string vinNumber)
        {
            return new List<CarInfo>();
        }
    }
}
