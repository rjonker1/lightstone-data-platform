using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeStatisticsRepository : IReadOnlyRepository<Statistic>
    {
        public IEnumerable<Statistic> FindAllWithRequest(IHaveCarInformation request)
        {
            return Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }

        public IEnumerable<Statistic> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Statistic> FindByMake(int makeId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Statistic> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Statistic> FindByCarIdAndYear(int? carId, int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Statistic> FindByVin(string vinNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
