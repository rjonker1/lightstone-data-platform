using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface IUserPackageRepository : IRepository<IUserPackage>
    {
        IQueryable<IUserPackage> GetUserPackages(IUser user);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }

    public class UserPackageCannedRepository : CannedRepository<IUserPackage>, IUserPackageRepository
    {
        public UserPackageCannedRepository()
        {
            Add(
                new UserPackage()
                );
        }

        public IQueryable<IUserPackage> GetUserPackages(IUser user)
        {
            return Entities.Where(x => Equals(x.User, user) && x.Package != null).AsQueryable();
        }

        public IQueryable<IAction> GetActions(IUser user)
        {
            var actions = GetUserPackages(user).Select(x => x.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var userPackage = GetUserPackages(user).FirstOrDefault(x => Equals(x.Action, action));
            return userPackage != null ? userPackage.Package : null;
        }
    }
}