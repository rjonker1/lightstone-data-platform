using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarTypeRepository : IReadOnlyRepository<CarType>
    {
        public IEnumerable<CarType> FindAllWithRequest(global::Lace.Request.ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByMake(int makeId)
        {
            return CarTypeDataBuilder.ForCarTypes().Where(w => w.Make_ID == makeId).ToList();
        }

        public IEnumerable<CarType> FindByMakeAndMetricTypes(int makeId,
            Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
