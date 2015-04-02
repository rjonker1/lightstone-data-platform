using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository<Sale>
    {
        public IEnumerable<Sale> FindAllWithRequest(IHaveCarInformation request)
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
            MetricTypes[] metricTypes)
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
