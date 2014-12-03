using System;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IPackageRepository : IRepository<Package>
    {
        bool Exists(Guid id, string name);
    }
}