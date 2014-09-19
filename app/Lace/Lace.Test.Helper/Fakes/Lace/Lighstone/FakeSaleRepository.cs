using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository<Sale>
    {
        public IEnumerable<Sale> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByMakeAndMetricTypes(int makeId,
            Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByCarIdAndYear(int? carId, int year)
        {
            return SaleDataBuilder.ForCarSalesOnCarId_107483();
        }

        public IEnumerable<Sale> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
