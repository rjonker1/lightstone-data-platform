﻿using System.Collections.Generic;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository
    {
        public IEnumerable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            return (IEnumerable<TItem>)SaleDataBuilder.ForCarSalesOnCarId_107483();
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IEnumerable<TItem>)SaleDataBuilder.ForCarSalesOnCarId_107483();
        }
    }
}
