using System;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Packages.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(ISession session)
            : base(session)
        {
        }

        public bool Exists(Guid id, string name)
        {
            return this.Any(x => x.PackageId != id && x.Name.Trim().ToLower() == name.Trim().ToLower() && x.State.Name == StateName.Published);
        }

        public bool HasPublishedVersions(Guid id)
        {
            return this.Any(x => x.PackageId == id && x.State.Name == StateName.Published);
        }

        public IQueryable<Package> GetAllVersions(Guid id)
        {
            return this.Where(x => x.PackageId == id);
        }
    }
}