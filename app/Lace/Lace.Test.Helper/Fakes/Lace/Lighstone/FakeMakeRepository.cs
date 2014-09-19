using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMakeRepository : IReadOnlyRepository<Make>
    {
        public IEnumerable<Make> FindAllWithRequest(global::Lace.Request.IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll()
        {
            return Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();
        }

        public IEnumerable<Make> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByMakeAndMetricTypes(int makeId, Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
