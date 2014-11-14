using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestGroupPackageRepository : CannedRepository<IGroupPackage>, IGroupPackageRepository
    {
        public IQueryable<IGroupPackage> GetGroupPackages(IUser user)
        {
            return Entities.Where(x => x.Customer != null && (x.Customer.Users.Contains(user) && x.Package != null)).AsQueryable();
        }

        public IQueryable<IGroupPackage> GetGroupPackages(IUser user, IAction action)
        {
            return GetGroupPackages(user).Where(x => Equals(x.Package.Action, action));
        }

        public IPackage GetGroupPackage(IUser user, IAction action)
        {
            IEnumerable<IGroupPackage> groupPackages = null;
            if (user.HasMultipleRoles)
                groupPackages = GetGroupPackages(user, action).ToList();
            if (groupPackages == null) return null;

            var packages = groupPackages.Where(x => user.Groups.Contains(x.Group)).Select(x => x.Package).Distinct().ToList();

            return packages.Count() == 1 ? packages.First() : null;
        }

        public IQueryable<IAction> GetActions(IUser user)
        {
            var actions = GetGroupPackages(user).Select(x => x.Package.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var groupPackage = GetGroupPackages(user, action).FirstOrDefault(x => Equals(x.Group, user.DefaultGroup));
            return groupPackage != null ? groupPackage.Package : null;
        }
    }
}