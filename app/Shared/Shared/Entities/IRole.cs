using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IRole : INamedEntity
    {
        IEnumerable<IRolePermission> RolePermissions { get; }
        IEnumerable<IAction> Actions { get; }
        void Add(IAction action);
    }
}