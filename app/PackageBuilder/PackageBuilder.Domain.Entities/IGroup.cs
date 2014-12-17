using System.Collections.Generic;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IGroup : INamedEntity
    {
        IEnumerable<IGroupPermission> GroupPermissions { get; }
        IEnumerable<IAction> Actions { get; }
        void Add(IAction action);
    }
}