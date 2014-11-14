using System.Linq;
using PackageBuilder.Core.Repositories;
using IPackage = PackageBuilder.Domain.Entities.Packages.WriteModels.IPackage;

namespace PackageBuilder.Domain.Entities
{
    public interface IGroupPackageRepository : IRepository<IGroupPackage>
    {
        IQueryable<IGroupPackage> GetGroupPackages(IUser user);
        IQueryable<IGroupPackage> GetGroupPackages(IUser user, IAction action);
        IPackage GetGroupPackage(IUser user, IAction action);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }
}