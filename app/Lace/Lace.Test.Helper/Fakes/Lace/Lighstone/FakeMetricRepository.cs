using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository<Metric>
    {
        public IEnumerable<Metric> FindAllWithRequest(IProvideCarInformationForRequest request)
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

        public IEnumerable<Metric> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
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
