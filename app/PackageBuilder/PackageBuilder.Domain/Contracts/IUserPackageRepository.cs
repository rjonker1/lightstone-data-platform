using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts
{
    public interface IUserPackageRepository : IRepository<IUserPackage>
    {
        IQueryable<IUserPackage> GetUserPackages(IUser user);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }
}