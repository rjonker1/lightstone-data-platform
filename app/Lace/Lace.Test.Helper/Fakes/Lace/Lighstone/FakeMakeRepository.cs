using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    //
    public class FakeMakeRepository : IReadOnlyRepository<Make>
    {
        public IEnumerable<Make> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll(string sql)
        {
            return Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();
        }
    }
}
