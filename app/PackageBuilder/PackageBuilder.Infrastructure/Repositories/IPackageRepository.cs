using System;
using System.Linq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Packages.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IPackageRepository : IRepository<Package>
    {
        bool Exists(Guid id, string name);
        bool HasPublishedVersions(Guid id);
        IQueryable<Package> GetAllVersions(Guid id);
    }
}