using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestRolePackageRepository : CannedRepository<IRolePackage>, IRolePackageRepository
    {
        public IQueryable<IRolePackage> GetRolePackages(IUser user)
        {
            return Entities.Where(x => x.Customer.Users.Contains(user) && x.Package != null).AsQueryable();
        }

        public IQueryable<IRolePackage> GetRolePackages(IUser user, IAction action)
        {
            return GetRolePackages(user).Where(x => Equals(x.Package.Action, action));
        }

        public IPackage GetRolePackage(IUser user, IAction action)
        {
            IEnumerable<IRolePackage> packageRoles = null;
            if (user.HasMultipleRoles)
                packageRoles = GetRolePackages(user, action).ToList();
            if (packageRoles == null) return null;

            var packages = packageRoles.Where(x => user.Roles.Contains(x.Role)).Select(x => x.Package).Distinct().ToList();

            return packages.Count() == 1 ? packages.First() : null;
        }

        public IQueryable<IAction> GetActions(IUser user)
        {
            var actions = GetRolePackages(user).Select(x => x.Package.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var rolePackage = GetRolePackages(user, action).FirstOrDefault(x => Equals(x.Role, user.DefaultRole));
            return rolePackage != null ? rolePackage.Package : null;
        }
    }
}