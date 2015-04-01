using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBandsRepository : IReadOnlyRepository<Band>
    {
        public IEnumerable<Band> FindAllWithRequest(IHaveCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetAll()
        {
            return Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands();
        }

        public IEnumerable<Band> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
