using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IUser : IEntity, INamedEntity
    {
        ICustomer Customer { get; set; }
        IEnumerable<IUserGroup> UserGroups { get; }
        IEnumerable<IUserRole> UserRoles { get; }
        IEnumerable<IRole> Roles { get; }
        IEnumerable<IGroup> Groups { get; }
        bool HasGroups { get; }
        bool HasRoles { get; }
        bool HasSingleGroup { get; }
        bool HasSingleRole { get; }
        bool HasSingleGroupAndRole { get; }
        bool HasMultipleGroups { get; }
        bool HasMultipleRoles { get; }
        bool HasMultipleGroupsAndRoles { get; }
        IGroup DefaultGroup { get; }
        IRole DefaultRole { get; }
    }
}