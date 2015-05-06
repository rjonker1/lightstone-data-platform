using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBandsRepository : IReadOnlyRepository<Band>
    {
        public IEnumerable<Band> Get(string sql, object param, string cacheKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetAll(string sql, string cacheKey)
        {
            return Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands();
        }
    }
}
