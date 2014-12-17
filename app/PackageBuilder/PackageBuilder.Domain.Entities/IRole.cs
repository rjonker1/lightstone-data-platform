using System.Collections.Generic;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IRole : INamedEntity
    {
        IEnumerable<IRolePermission> RolePermissions { get; }
        IEnumerable<IAction> Actions { get; }
        void Add(IAction action);
    }
}