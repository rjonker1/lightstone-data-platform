using System.Linq;
using PackageBuilder.Core.Repositories;
using IPackage = PackageBuilder.Domain.Entities.Packages.WriteModels.IPackage;

namespace PackageBuilder.Domain.Entities
{
    public interface IUserPackageRepository : IRepository<IUserPackage>
    {
        IQueryable<IUserPackage> GetUserPackages(IUser user);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }
}