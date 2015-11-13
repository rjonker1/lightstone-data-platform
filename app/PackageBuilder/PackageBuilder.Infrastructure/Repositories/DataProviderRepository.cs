using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class DataProviderRepository : Repository<DataProvider>, IDataProviderRepository
    {
        public DataProviderRepository(ISession session) : base(session)
        {
        }

        public bool Exists(Guid id, DataProviderName name)
        {
            return this.Any(x => x.DataProviderId != id && x.Name == name);
        }

        public IEnumerable<Guid> GetUniqueIds()
        {
            return this.Select(x => x.DataProviderId).Distinct().ToList();
        }
    }
}