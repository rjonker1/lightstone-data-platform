using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    //
    public class FakeMakeRepository : IReadOnlyRepository<Make>
    {
        public IEnumerable<Make> Get(string sql, object param, string cacheKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll(string sql, string cacheKey)
        {
            return Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();
        }
    }
}
