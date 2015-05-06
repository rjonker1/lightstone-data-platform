using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository<Sale>
    {
        public IEnumerable<Sale> Get(string sql, object param, string cacheKey)
        {
            return SaleDataBuilder.ForCarSalesOnCarId_107483();
        }

        public IEnumerable<Sale> GetAll(string sql, string cacheKey)
        {
            throw new NotImplementedException();
        }
    }
}
