using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts
{
    public interface IPackageLookupRepository
    {
        IPackage Get(string username, string requestedAction);
        IEnumerable<IAction> GetActions(string username);
    }
}