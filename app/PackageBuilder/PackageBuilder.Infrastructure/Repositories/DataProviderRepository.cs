using System;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class DataProviderRepository : Repository<DataProvider>, IDataProviderRepository
    {
        public DataProviderRepository(ISession session) : base(session)
        {
        }

        public bool Exists(Guid id, string name)
        {
            return this.FirstOrDefault(x => x.Id != id && x.Name.ToLower() == name) != null;
        }
    }
}