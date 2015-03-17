using System;
using System.Collections.Generic;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Read;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IDataProviderRepository : IRepository<DataProvider>
    {
        bool Exists(Guid id, DataProviderName name);
        IEnumerable<Guid> GetUniqueIds();
    }
}