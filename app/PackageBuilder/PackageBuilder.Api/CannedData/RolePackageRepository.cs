using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.CannedData
{
    public interface IRolePackageRepository : IRepository<IRolePackage>
    {
        IQueryable<IRolePackage> GetRolePackages(IUser user);
        IQueryable<IRolePackage> GetRolePackages(IUser user, IAction action);
        IPackage GetRolePackage(IUser user, IAction action);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }

    public class RolePackageRepository : Repository<IRolePackage>, IRolePackageRepository
    {
        public RolePackageRepository()
        {
            Add(
                new RolePackage()
                );
        }

        public IQueryable<IRolePackage> GetRolePackages(IUser user)
        {
            return Entities.Where(x => x.Customer.Users.Contains(user) && x.Package != null).AsQueryable();
        }

        public IQueryable<IRolePackage> GetRolePackages(IUser user, IAction action)
        {
            return GetRolePackages(user).Where(x => Equals(x.Action, action));
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
            var actions = GetRolePackages(user).Select(x => x.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var rolePackage = GetRolePackages(user, action).FirstOrDefault(x => Equals(x.Role, user.DefaultRole));
            return rolePackage != null ? rolePackage.Package : null;
        }
    }
}