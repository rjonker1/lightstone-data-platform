using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        public IEnumerable<Municipality> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll(string sql)
        {
            return MuncipalityDataBuilder.ForAllMunicipalities();
        }
    }
}
