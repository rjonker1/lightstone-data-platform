using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBandsRepository : IReadOnlyRepository<Band>
    {
        public IEnumerable<Band> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetAll(string sql)
        {
            return Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands();
        }
    }
}
