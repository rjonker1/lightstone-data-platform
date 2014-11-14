using System.Collections.Generic;
using IPackage = PackageBuilder.Domain.Entities.Packages.WriteModels.IPackage;

namespace PackageBuilder.Domain.Entities
{
    public interface IPackageLookupRepository
    {
        IPackage Get(string username, string requestedAction);
        IEnumerable<IAction> GetActions(string username);
    }
}