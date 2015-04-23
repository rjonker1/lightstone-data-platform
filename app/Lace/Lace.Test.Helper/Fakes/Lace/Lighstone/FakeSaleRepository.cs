using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository<Sale>
    {
        public IEnumerable<Sale> Get(string sql, object param)
        {
            return SaleDataBuilder.ForCarSalesOnCarId_107483();
        }

        public IEnumerable<Sale> GetAll(string sql)
        {
            throw new NotImplementedException();
        }
       
    }
}
