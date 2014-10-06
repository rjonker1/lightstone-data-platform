using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface IRolePackageRepository : IRepository<IRolePackage>
    {
        IQueryable<IRolePackage> GetRolePackages(IUser user);
        IQueryable<IRolePackage> GetRolePackages(IUser user, IAction action);
        IPackage GetRolePackage(IUser user, IAction action);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }
}