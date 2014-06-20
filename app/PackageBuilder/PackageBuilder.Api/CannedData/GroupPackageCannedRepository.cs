using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface IGroupPackageRepository : IRepository<IGroupPackage>
    {
        IQueryable<IGroupPackage> GetGroupPackages(IUser user);
        IQueryable<IGroupPackage> GetGroupPackages(IUser user, IAction action);
        IPackage GetGroupPackage(IUser user, IAction action);
        IQueryable<IAction> GetActions(IUser user);
        IPackage GetPackage(IUser user, IAction action);
    }

    public class GroupPackageCannedRepository : CannedRepository<IGroupPackage>, IGroupPackageRepository
    {
        public GroupPackageCannedRepository()
        {
            Add(
                new GroupPackage()
                );
        }

        public IQueryable<IGroupPackage> GetGroupPackages(IUser user)
        {
            return Entities.Where(x => x.Customer != null && (x.Customer.Users.Contains(user) && x.Package != null)).AsQueryable();
        }

        public IQueryable<IGroupPackage> GetGroupPackages(IUser user, IAction action)
        {
            return GetGroupPackages(user).Where(x => Equals(x.Action, action));
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
            var actions = GetGroupPackages(user).Select(x => x.Action);
            return actions;
        }

        public IPackage GetPackage(IUser user, IAction action)
        {
            var groupPackage = GetGroupPackages(user, action).FirstOrDefault(x => Equals(x.Group, user.DefaultGroup));
            return groupPackage != null ? groupPackage.Package : null;
        }
    }
}