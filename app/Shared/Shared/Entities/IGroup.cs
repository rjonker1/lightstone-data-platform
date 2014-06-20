using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IGroup : INamedEntity
    {
        IEnumerable<IGroupPermission> GroupPermissions { get; }
        IEnumerable<IAction> Actions { get; }
    }
}