using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IGroup : INamedEntity
    {
        IEnumerable<IGroupPermission> GroupPermissions { get; }
        IEnumerable<IAction> Actions { get; }
    }
}