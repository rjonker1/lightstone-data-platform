using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public interface IUserPackageRepository : IRepository<IUserPackage>
    {
        IQueryable<IUserPackage> GetUserPackages(IUser user);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }

    public class UserPackageRepository : Repository<IUserPackage>, IUserPackageRepository
    {
        public UserPackageRepository()
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