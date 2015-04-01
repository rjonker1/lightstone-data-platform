using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMakeRepository : IReadOnlyRepository<Make>
    {
        public IEnumerable<Make> FindAllWithRequest(IHaveCarInformation request)
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

        public IEnumerable<Make> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
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
