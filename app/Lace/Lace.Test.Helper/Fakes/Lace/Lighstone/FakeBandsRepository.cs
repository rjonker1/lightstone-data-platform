using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBandsRepository : IReadOnlyRepository<Band>
    {
        public IEnumerable<Band> FindAllWithRequest(global::Lace.Request.ILaceRequestCarInformation request)
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

        public IEnumerable<Band> FindByMakeAndMetricTypes(int makeId, Source.Lightstone.Metrics.MetricTypes[] metricTypes)
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
