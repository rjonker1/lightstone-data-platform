using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Shared.DataProvider.Repositories;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMunicipalityRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            return (IQueryable<TItem>)MuncipalityDataBuilder.ForAllMunicipalities().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IQueryable<TItem>)MuncipalityDataBuilder.ForAllMunicipalities().AsQueryable();
        }
    }
}
