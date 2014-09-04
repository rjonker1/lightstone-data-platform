using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository<Metric>
    {
        public IEnumerable<Metric> FindAllWithRequest(global::Lace.Request.ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> GetAll()
        {
            return Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics();
        }

        public IEnumerable<Metric> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByMakeAndMetricTypes(int makeId, Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
