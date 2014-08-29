using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts.Enitities
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