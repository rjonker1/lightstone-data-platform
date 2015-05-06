using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        public IEnumerable<Municipality> Get(string sql, object param, string cacheKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll(string sql, string cacheKey)
        {
            return MuncipalityDataBuilder.ForAllMunicipalities();
        }
    }
}
