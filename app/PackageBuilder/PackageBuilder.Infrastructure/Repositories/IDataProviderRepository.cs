using System;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IDataProviderRepository : IRepository<DataProvider>
    {
        bool Exists(Guid id, string name);
    }
}