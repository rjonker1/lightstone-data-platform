using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestUserPackageRepository : CannedRepository<IUserPackage>, IUserPackageRepository
    {
        public IQueryable<IUserPackage> GetUserPackages(IUser user)
        {
            return Entities.Where(x => Equals(x.User, user) && x.Package != null).AsQueryable();
        }

        public IQueryable<IAction> GetActions(IUser user)
        {
            var actions = GetUserPackages(user).Select(x => x.Package.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var userPackage = GetUserPackages(user).FirstOrDefault(x => Equals(x.Package.Action, action));
            return userPackage != null ? userPackage.Package : null;
        }
    }
}