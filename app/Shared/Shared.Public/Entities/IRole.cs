using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IRole : INamedEntity
    {
        IEnumerable<IRolePermission> RolePermissions { get; }
        IEnumerable<IAction> Actions { get; }
    }
}